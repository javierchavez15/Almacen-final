using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class contactos:hmiObject
    {
        public contactos()
        { 
        }

        public contactos(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public contactos(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int ID;
        public int ID_CLIENTE = 0;
        public string NOMBRE = "";
        public string PUESTO = "";
        public string Extension = "";
        public string RADIO = "";
        public string CELULAR = "";
        public string EMAIL = "";
        public int STATUS;
        public DateTime FECHAALTA = DateTime.Now;
        public DateTime FECHABAJA;
        public DateTime CUMPLEANIOS;


        public override string ToString()
        {
            return NOMBRE;
        }

        public static List<contactos> GetExistentes()
        {
            List<contactos> lista = new List<contactos>();

            String query = "SELECT * FROM contactos ORDER BY NOMBRE ASC";           

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new contactos(dr));
            }
            return lista;

        }
    }
}
