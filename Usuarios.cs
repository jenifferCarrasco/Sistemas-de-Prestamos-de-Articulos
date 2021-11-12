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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True");

       

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
      

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Usuarios", con);
            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cmd;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

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
        private void limpiar()
        {
            codigo.Clear();
            Nomb.Clear();
            user.Clear();
            Pin.Clear();
            rol.Clear();
            Estatus.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            CUsuario usus = new CUsuario();

            usus.Codigo = (int)Convert.ToInt64(codigo.Text);
            usus.Nombre = Nomb.Text;
            usus.User = user.Text;
            usus.Pin = int.Parse(Pin.Text);
            usus.Rol = rol.Text;
            usus.Estatus = Estatus.Text;

            int resultado = CUsuario.Agregar(usus);

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

        private void Nomb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
