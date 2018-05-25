using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class empleados:hmiObject
    {

        public empleados()
        { 
        }

        public empleados(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public empleados(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int ID;
        public string NOMBRE = "";
        public string PUESTO = "";
        public DateTime FechaAlta = DateTime.Now.Date;

        public override string ToString()
        {
            return NOMBRE;
            
        }

        public static List<empleados> GetExistentes()
        {
            List<empleados> lista = new List<empleados>();

            String query = "SELECT * FROM empleados ORDER BY NOMBRE ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new empleados(dr));
            }
            return lista;

        }

    }
}
