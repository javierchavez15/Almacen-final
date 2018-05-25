using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class factores : hmiObject
    {
        public factores()
        {
        }

        public factores(int id)
        {
            this.LoadMembers("ID=" + id);
        }

        public factores(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int ID = 0;
        public string Modulo = "";
        public double Factor = 0;
        public DateTime Actualizacion = DateTime.Now;

        public override string ToString()
        {
            return Modulo;
        }
        
        public static List<factores> GetExistentes()
        {
            List<factores> lista = new List<factores>();

            String query = "SELECT * FROM factores ORDER BY Modulo ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new factores(dr));
            }
            return lista;

        }



    }
}
