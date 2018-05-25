using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Form1
{
    public class inout:BaseDatosSQL
    {
        public inout()
        {
 
        }

        public inout(DataRow dr)
        {
            Leer(dr);
        }

        public int ID;
        public int ENTRADA = 0;
        public int SALIDA=0;
        public DateTime FECHA = DateTime.Now.Date;
        public int ID_PRODUCTO = 0;

        public int Existencias(int idProducto)
        {
            String error = "";
            String query = "SELECT * FROM inout " +
                          "WHERE ID_PRODUCTO=" + idProducto + " ORDER BY CATALOGO ASC";

            DataTable dt = BaseDatosSQL.Tabla(query, ref error);
            int stock = 0;

            if (dt.Rows.Count > 0)
            {
                int[] entradA = new int[10000];
                int[]  salidA = new int[10000];
                int i=0;
                foreach (DataRow dr in dt.Rows)
                {
                    entradA[i] = Convert.ToInt32(dr["ENTRADA"]);
                    salidA[i] = Convert.ToInt32(dr["SALIDA"]);
                    i++;
                }

                stock = entradA.Sum() - salidA.Sum();
            }
            
            return stock;
 
        }

    }
}
