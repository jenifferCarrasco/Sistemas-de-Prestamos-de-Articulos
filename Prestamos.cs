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
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True");
        private int attempt;

        public void login(string usuario, string contraseña)
        {

            try
            {
                //int count = 0;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select UserU, Rol_User FROM Usuarios where UserU= @usuario AND Pin_User = @pas", con);
                cmd.Parameters.AddWithValue("usuario", usuario);

                cmd.Parameters.AddWithValue("pas", contraseña);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        this.Hide();
                        Menu form = new Menu();
                        form.Show();

                    }
                    else if (dt.Rows[0][1].ToString() == "Cliente")
                    {
                        MessageBox.Show("El usuario que haz ingresado no es Administrador");

                    }


                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrecto");
                    attempt = attempt + 1;
                    disable();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void disable()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login(this.textBox2.Text, this.textBox1.Text);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();
            
            /*string LastChar = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            textBox1.Text = LastChar;

            string LasChar = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
            textBox2.Text = LasChar;*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prestamos_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
