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
    public partial class Prestacion : Form
    {
        public Prestacion()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True");

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu form = new Menu();
            form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Prestacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'prestamosDataSet.Articulos' Puede moverla o quitarla según sea necesario.
            this.articulosTableAdapter.Fill(this.prestamosDataSet.Articulos);
            
            //articulo
            con.Open();
            SqlCommand vb = new SqlCommand("select Id_Articulos, Descripcion from Articulos", con);
            //SqlDataReader dl = vb.ExecuteReader();
            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = vb;
            //adt.Fill(dl);
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            
            comboBox2.DataSource = tabla;
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "Id_Articulos";
            con.Close();

            //usuario
            con.Open();
            SqlCommand cmd = new SqlCommand("select Id_User, Name_User from Usuarios", con);
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;

            DataTable tabl = new DataTable();
            ad.Fill(tabl);
            comboBox3.DataSource = tabl;
            comboBox3.DisplayMember = "Name_User";
            comboBox3.ValueMember = "Id_User";
            con.Close();

            SqlCommand c = new SqlCommand("SELECT c.Id_Consulta, c.Id_Articulos, a.Descripcion, c.Id_User as Id_Usuario, u.Name_User as Nombre_Usuario, c.Date_start as Fecha_Inicial, c.Date_end as Fecha_Fin  FROM Consulta c INNER JOIN Articulos a ON c.Id_Articulos = a.Id_Articulos INNER JOIN Usuarios u ON c.Id_User = u.Id_User", con);

            SqlDataAdapter a = new SqlDataAdapter();
            a.SelectCommand = c;
            DataTable tab = new DataTable();
            a.Fill(tab);
            dataGridView1.DataSource = tab;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CPrestamo pre = new CPrestamo();
           
            
            
                pre.ID_Consulta = Convert.ToInt32(ID.Text);
                pre.ID_Articulos = Convert.ToInt32(comboBox2.SelectedValue);
                pre.ID_Usuarios = Convert.ToInt32(comboBox3.SelectedValue);
                pre.Date_start = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                pre.Date_end = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd"));

            int a = 0;

            if (Convert.ToInt32(ID.Text) != a)
            {
                SqlCommand cmd = new SqlCommand("Select * From Consulta where Id_Articulos = '"+Convert.ToInt32(comboBox2.SelectedValue)+"'",con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                // DataTable d = new DataTable();
                DataSet c = new DataSet();
                da.Fill(c);
                
                int i = c.Tables[0].Rows.Count;
                if (i >0)
                {
                    MessageBox.Show("Este Articulo" + comboBox2.Text + " Ya Esta Prestado");
                    c.Clear();
                }
                else
                {
                    int resultado = CPrestamo.Agregar(pre);

                    if (resultado > 0)
                    {

                        MessageBox.Show("Registro Correcto!");
                        limpiar();

                    }
                    else
                    {
                        MessageBox.Show("Registro Incorrecto!");
                    }
                }

            }
            if (Convert.ToInt32(ID.Text) != a)
            {
                SqlCommand cmd = new SqlCommand("Update Articulos set Estatus = 'No disponible' where Estatus = 'Disponible' and Id_Articulos = '" + Convert.ToInt32(comboBox2.SelectedValue) + "'", con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                // DataTable d = new DataTable();
                DataSet c = new DataSet();
                da.Fill(c);

                /*int i = c.Tables[0].Rows.Count;
                if (i > 0)
                {
                    MessageBox.Show("Este Articulo" + comboBox2.Text + " Ya Esta Prestado");
                    c.Clear();
                }
                else
                {
                    int resultado = CPrestamo.Agregar(pre);

                    if (resultado > 0)
                    {

                        MessageBox.Show("Registro Correcto!");
                        limpiar();

                    }
                    else
                    {
                        MessageBox.Show("Registro Incorrecto!");
                    }
                }*/

            }

            SqlCommand co = new SqlCommand("SELECT c.Id_Consulta, c.Id_Articulos, a.Descripcion, c.Id_User as Id_Usuario, u.Name_User as Nombre_Usuario, c.Date_start as Fecha_Inicial, c.Date_end as Fecha_Fin  FROM Consulta c INNER JOIN Articulos a ON c.Id_Articulos = a.Id_Articulos INNER JOIN Usuarios u ON c.Id_User = u.Id_User", con);

            SqlDataAdapter b = new SqlDataAdapter();
            b.SelectCommand = co;
            DataTable tab = new DataTable();
            b.Fill(tab);
            dataGridView1.DataSource = tab;



            /* int resultado = CPrestamo.Agregar(pre);

                 if (resultado > 0)
                 {

                     MessageBox.Show("Registro Correcto!");
                     limpiar();

                 }
                 else
                 {
                     MessageBox.Show("Registro Incorrecto!");
                 }*/










        }

        private void limpiar()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT c.Id_Consulta, c.Id_Articulos, a.Descripcion, c.Id_User as Id_Usuario, u.Name_User as Nombre_Usuario, c.Date_start as Fecha_Inicial, c.Date_end as Fecha_Fin  FROM Consulta c INNER JOIN Articulos a ON c.Id_Articulos = a.Id_Articulos INNER JOIN Usuarios u ON c.Id_User = u.Id_User", con);
           
            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cmd;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;

           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        

      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
