using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Articulos_Prestados
{
    public partial class Articulos : Form
    {
        public Articulos()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Articulos_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Articulos", con);
            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cmd;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Articulos", con);
            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cmd;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu form = new Menu();
            form.Show();
        }

        private void limpiar() {

            cod.Clear();
            Descr.Clear();
            
            Esta.Clear();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CArticulos art = new CArticulos();

            art.Codigo = int.Parse(cod.Text);
            art.Descripcion = Descr.Text;
           
            art.Estatus = Esta.Text;

            int resultado = CArticulos.Agregar(art);

            if (resultado > 0)
            {

                MessageBox.Show("Registro Correcto!");
                limpiar();

            }
            else {

                MessageBox.Show("Registro Incorrecto!");
            }

            SqlCommand cmd = new SqlCommand("select * from Articulos", con);
            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cmd;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query = "update Articulos set Descripcion = @descripcion, Estatus = @estatus where Id_Articulos = @Id_Articulos";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("descripcion", Descr.Text);
         
            cmd.Parameters.AddWithValue("@estatus", Esta.Text);
            cmd.Parameters.AddWithValue("Id_Articulos", cod.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Actualizado");

            SqlCommand cm = new SqlCommand("select * from Articulos", con);
            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cm;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;


        }
        //Prueba de GitHub
    }
}
