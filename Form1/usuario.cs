using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Form1
{
    public class usuario : hmiObject
    {
        public usuario()
        {
        }

        public usuario(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public usuario(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        #region variables globales
        public int ID;
        public string NombreUsuario = "";
        public string Clave = "";
        public int idEmpleado = 0;
        public int NivelSeguridad = 0;
        public int idCartera = 0;
        public string Nombre = "";
        public int IdPerfil = 0;
        public string email = "";
        public string mensajeEmail = "";
        public string paswordEmail = "";
        public static usuario UsuarioActual;
        public static usuario CotizadorActual;
        public static usuario VendedorActual;
        #endregion variables globales

        public override string ToString()
        {
            return Nombre;
        }

        public static List<usuario> GetExistentes()
        {
            List<usuario> lista = new List<usuario>();

            String query = "SELECT * from usuario where proyecto=1 ORDER BY NOMBREUSUARIO ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new usuario(dr));
            }
            return lista;
        }
        public static List<usuario> delcliente(int id1)
        {
            List<usuario> lista = new List<usuario>();

            String query = "SELECT * from usuario where ID="+id1.ToString()+" ORDER BY NOMBREUSUARIO ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new usuario(dr));
            }
            return lista;
        }
    }
}
