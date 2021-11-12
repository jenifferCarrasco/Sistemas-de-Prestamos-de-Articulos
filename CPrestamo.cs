using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulos_Prestados
{
    class CPrestamo
    {
        public int ID_Consulta { get; set; }
        public int ID_Articulos { get; set; }
        public int ID_Usuarios { get; set; }

        public DateTime Date_start { get; set; }

        public DateTime Date_end { get; set; }

        public CPrestamo() { }
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True");


        public CPrestamo(int IConsulta, int IArticulos, int IUsuarios, DateTime Dfecha1, DateTime Dfecha2)
        {
            this.ID_Consulta = IConsulta;
            this.ID_Articulos = IArticulos;
            this.ID_Usuarios = IUsuarios;
            this.Date_start = Dfecha1;
            this.Date_start = Dfecha2;
        }

        public static int Agregar(CPrestamo pres)
        {

            int retorno = 0;

            using (SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True"))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(String.Format("Insert into Consulta(Id_Consulta,Id_Articulos,Id_User,Date_start, Date_end)values('{0}','{1}', '{2}','{3}', '{4}')",pres.ID_Consulta, pres.ID_Articulos, pres.ID_Usuarios, pres.Date_start.ToString("yyyy-MM-dd"), pres.Date_end.ToString("yyyy-MM-dd")), con);

                retorno = cmd.ExecuteNonQuery();

            }


            return retorno;
        }
        public static DataTable ObtCant()
        {
            //int ret = 0;
            using (SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True"))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(String.Format("select Cantidad, Estatus from Articlos", con));

                SqlDataAdapter adt = new SqlDataAdapter();
                adt.SelectCommand = cmd;
                //adt.Fill(dl);
                DataTable ta = new DataTable();
                adt.Fill(ta);
                return ta;

                
                
               // ret = cmd.ExecuteNonQuery();

                //if (Ca)

            }
            //return ret;
        }

        private void Disminuir ()
        {
            DataTable ta = ObtCant();
            int rest = 20;
            foreach(DataRow r in ta.Rows)
            {
                rest = rest - Convert.ToInt32(r["Cantidad"].ToString());
                if (rest <= 0)
                {
                     
                    SqlCommand cmd = new SqlCommand("Update Estatus, Name_User from Usu", con);
                }
            }
        }
    }
}
