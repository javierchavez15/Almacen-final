using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;

namespace Form1
{
    public class statusorep:hmiObject
    {

        public statusorep()
        { }

        public statusorep(int id)
        {
            this.LoadMembers("Id=" + id);

        }

        public statusorep(DataRow dr)        
        {
            this.LoadDataRow(dr);
        }

        public int Id;
        public string Nombre = "";

        public override string ToString()
        {
            return Nombre;
        }

        public static List<statusorep> GetExistentes()
        {
            List<statusorep> lista = new List<statusorep>();

            String query = "SELECT * FROM statusorep ORDER BY Nombre ASC";


            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); 

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new statusorep(dr));
            }
            return lista;

        }
    }
}
