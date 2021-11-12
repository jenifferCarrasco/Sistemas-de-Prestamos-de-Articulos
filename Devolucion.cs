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
    public partial class Devolucion : Form
    {
        public Devolucion()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Devolucion_Load(object sender, EventArgs e)
        {
            //int a = 0;
            
            
                SqlCommand cmd = new SqlCommand("SELECT c.Id_Consulta, c.Id_Articulos, a.Descripcion, a.Estatus, c.Id_User as Id_Usuario, u.Name_User as Nombre_Usuario, c.Date_start as Fecha_Inicial, c.Date_end as Fecha_Fin  FROM Consulta c INNER JOIN Articulos a ON c.Id_Articulos = a.Id_Articulos INNER JOIN Usuarios u ON c.Id_User = u.Id_User", con);

                SqlDataAdapter adt = new SqlDataAdapter();
                adt.SelectCommand = cmd;
                DataTable tabla = new DataTable();
                adt.Fill(tabla);
                dataGridView1.DataSource = tabla;
          
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            /*SqlDataAdapter OSK = new SqlDataAdapter("SELECT * FROM Articulos where Estatus = 'No Disponible'",con);
            DataTable dataSet = new DataTable();
            OSK.Fill(dataSet);
            if (dataSet.TableName.Contains("Estatus"))
            {
                SqlCommand j = new SqlCommand("Update Articulos set Estatus = 'No Disponible' where Estatus ='Disponible' ");
                MessageBox.Show("Actualizado Exitosamente!");

            }
            else
            {
                MessageBox.Show("No actualizado");
            }*/
            con.Open();
            string cod = buscar.Text;
            string cadena = "delete from Consulta where Id_Articulos =" + cod;
            SqlCommand comando = new SqlCommand(cadena, con);
            int cant;
            cant = comando.ExecuteNonQuery();
            con.Close();
            int a = 0;
            MessageBox.Show("La Devolucion se realizo Exitosamente");
            if (Convert.ToInt32(buscar.Text) != a)
            {
                SqlCommand cmd = new SqlCommand("Update Articulos set Estatus = 'Disponible' WHERE Estatus = 'No disponible' and Id_Articulos = '" + Convert.ToInt32( cod )+ "' ", con); //and c.Id_Consulta = '" + cod +"' "
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                // DataTable d = new DataTable();
                DataSet c = new DataSet();
                
                da.Fill(c);
                
                

            }
            SqlCommand cd = new SqlCommand("SELECT c.Id_Consulta, c.Id_Articulos, a.Descripcion, a.Estatus, c.Id_User as Id_Usuario, u.Name_User as Nombre_Usuario, c.Date_start as Fecha_Inicial, c.Date_end as Fecha_Fin  FROM Consulta c INNER JOIN Articulos a ON c.Id_Articulos = a.Id_Articulos INNER JOIN Usuarios u ON c.Id_User = u.Id_User", con);

            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cd;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT c.Id_Consulta, c.Id_Articulos, a.Descripcion, a.Estatus, c.Id_User as Id_Usuario, u.Name_User as Nombre_Usuario, c.Date_start as Fecha_Inicial, c.Date_end as Fecha_Fin  FROM Consulta c INNER JOIN Articulos a ON c.Id_Articulos = a.Id_Articulos INNER JOIN Usuarios u ON c.Id_User = u.Id_User", con);

            SqlDataAdapter adt = new SqlDataAdapter();
            adt.SelectCommand = cmd;
            DataTable tabla = new DataTable();
            adt.Fill(tabla);
            dataGridView1.DataSource = tabla;

           
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu frm = new Menu();
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            con.Open();
            string cod = buscar.Text;
            string cadena = "select * from Consulta where Id_Articulos=" + cod;
            SqlCommand comando = new SqlCommand(cadena, con);
            SqlDataReader registro = comando.ExecuteReader();
            registro.Close();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = comando;
            DataTable tabl = new DataTable();
            ad.Fill(tabl);
            dataGridView1.DataSource = tabl;

            /*if (registro.Read())
            {
                //label4.Text = registro["descripcion"].ToString();
                //label5.Text = registro["precio"].ToString();
                
                button2.Enabled = true;
            }
            else
                MessageBox.Show("No existe un artículo con el código ingresado");*/
            con.Close();
        }

        private void buscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
