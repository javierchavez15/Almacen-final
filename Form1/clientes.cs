using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class clientes:hmiObject
    {
        public clientes()
        { 
        }

        public clientes(int id)
        {
            this.LoadMembers("ID=" + id);
        }

        public clientes(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int ID;
        public string RAZON_SOCIAL = "";
        public string CALLEYNO = "";
        public string COLONIA = "";
        public string CIUDAD = "";
        public int CP = 0;
        public string RFC = "";
        public string TELEFONO = "";
        public string EMAIL = "";
        public string FAX = "";
        public int ID_CARTERA;
        public int CREDITO_DIAS;
        public int ID_VENDEDOR;
        public double PORCENTAJE = 0;
        public int IdCategoria = 0;
        public double credito = 0;
        public DateTime fecha = DateTime.Now.Date;
        public string noneda = "PESOS";
        public int estatus = 1;
        public double adeudo = 0;
        public int idmetodopago = 2;
        public string clave = "";

        /*
        private List<Contactos> listaDeContactos;

        public List<Contactos> ListaDeContactos
        {
            get
            {
                if (listaDeContactos == null)
                {
                    List<Contactos> lista = new List<Contactos>();

                    String query = "SELECT * FROM Contactos WHERE ID_CLIENTE=" + ID + " ORDER BY NOMBRE ASC";

                    String error = "";

                    DataTable dt = BaseDatosSQL.Tabla(query, ref error);

                    foreach (DataRow dr in dt.Rows)
                    {
                        lista.Add(new Contactos(dr));
                    }

                    listaDeContactos = lista;
                }
                return listaDeContactos;
            }
        }
        */

        public override string ToString()
        {
            return RAZON_SOCIAL;
            //  return RAZON_SOCIAL + " " + ID;
        }

        public static List<clientes> GetExistentes()
        {
            List<clientes> lista = new List<clientes>();

            String query = "SELECT * FROM clientes order by RAZON_SOCIAL";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new clientes(dr));
            }
            return lista;

        }

    }
}
