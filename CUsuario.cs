using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulos_Prestados
{
    class CUsuario
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public string User { get; set; }
        public int Pin { get; set; }

        public string Rol { get; set; }
        public string Estatus { get; set; }

        public CUsuario() { }


        public CUsuario(int Codigo, String ANombre, string User, int APin, string Rol, String AEstatus)
        {
            
            this.Codigo = Codigo;
            this.Nombre = ANombre;
            this.User = User;
            this.Pin = APin;
            this.Rol = Rol;
            this.Estatus = AEstatus;
        }
        public static int Agregar(CUsuario usu)
        {

            int retorno = 0;

            using (SqlConnection con = new SqlConnection(@"Data Source = (localdb)\DESKTOP-Q68DLRE;Initial Catalog=Prestamos; Integrated Security = True"))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand(String.Format("Insert into Usuarios(Id_User, Name_User, UserU, Pin_User, Rol_User, Estatus)values('{0}','{1}','{2}','{3}','{4}','{5}')", usu.Codigo, usu.Nombre, usu.User, usu.Pin, usu.Rol,  usu.Estatus), con);

                retorno = cmd.ExecuteNonQuery();

            }


            return retorno;
        }

    }
}
