using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Articulos_Prestados
{
    class CArticulos
    { 
        public int Codigo { get; set; }
        public String Descripcion { get; set; }

      
        public String Estatus { get; set; }

        public CArticulos() { }

        public CArticulos(int Codigo, String ADescripcion, String AEstatus) {

            this.Codigo = Codigo;
            this.Descripcion = ADescripcion;
           
            this.Estatus = AEstatus;
        }

        public static int Agregar(CArticulos arti) {

            int retorno = 0;

            using (SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True")) {

                con.Open();
                SqlCommand cmd = new SqlCommand(String.Format("Insert into Articulos(Id_Articulos, Descripcion, Estatus)values('{0}','{1}','{2}')",arti.Codigo, arti.Descripcion, arti.Estatus), con);

                retorno = cmd.ExecuteNonQuery();

            }
           
            
            return retorno;
        }

      





    }
}
