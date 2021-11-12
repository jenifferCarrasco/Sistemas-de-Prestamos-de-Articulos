using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Articulos_Prestados
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Devolucion frm = new Devolucion();
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Articulos frm1 = new Articulos();
            frm1.Show();
        }

        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Usuario frm1 = new Usuario();
            frm1.Show();
        }

        private void toolStripTextBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Prestacion frm2 = new Prestacion();
            frm2.Show();
        }

        private void Menu_Load_1(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void hideSubMenu()
        {
            /*if (panelSubmenuConsultas.Visible == true)
            {
                panelSubmenuConsultas.Visible = false;

            }*/

           
        }
        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        //hideSubMenu();
        private void button6_Click(object sender, EventArgs e)
        {
            showMenu(panel5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFormHijo(new Articulos());
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFormHijo(new Usuario());
            /*this.Hide();
            Usuario frm = new Usuario();
            frm.Show();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFormHijo(new Prestacion());
            /*this.Hide();
            Prestacion frm = new Prestacion();
            frm.Show();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {

            openFormHijo(new Devolucion());
            /*this.Hide();
            Devolucion frm = new Devolucion();
            frm.Show();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private Form activeForm = null;
        private void openFormHijo(Form formhijo)
        {
            if (activeForm != null)
                activeForm.Close();


            activeForm = formhijo;
            formhijo.TopLevel = false;
            formhijo.FormBorderStyle = FormBorderStyle.None;
            formhijo.Dock = DockStyle.Fill;
            contenedor.Controls.Add(formhijo);
            contenedor.Tag = formhijo;
            formhijo.BringToFront();
            formhijo.Show();



        }

        private void formhijo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
