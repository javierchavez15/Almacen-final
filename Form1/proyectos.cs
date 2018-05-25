using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;


namespace Form1
{
    public class proyectos : hmiObject
    {
          public proyectos()
          {
          }

          public proyectos(int id)
          {
             this.LoadMembers("ID=" + id);
          }

         public proyectos(DataRow dr)
         {
             this.LoadDataRow(dr);
         }

        public int ID;
        public string NOMBRE="";
        public int ID_CLIENTE = 0;
        public string GERENTE="";
        public DateTime FECHA=DateTime.Now.Date;
        public int STATUS=0;
        public int idvendedor = 0;
        public DateTime fechainicio = DateTime.Now.Date;
        public DateTime fechafinal = DateTime.Now.Date;
        public double anticipo = 0;


        public DataTable proyectos2(int id, string descripcion, int status)
        {
            string query;

            if (id > 0)
            {
                query = "SELECT " +
                "FROM proyectos" +
                "WHERE ID = " + id + " AND STATUS= "+ status +" ORDER BY ID ASC";
            }
            else if (descripcion != "")
            {
                query = "SELECT * FROM proyectos" +
                        "WHERE NOMBRE LIKE '%" + descripcion + "%' AND STATUS= " + status + " ORDER BY ID ASC";
            }
            else
            {
                query = "SELECT * FROM proyectos WHERE STATUS= " + status + " ORDER BY ID ASC";
            }

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public static DataTable osaProyecto(int idProyecto)
        {
            string query = "SELECT I.ID_OSAGRAL AS OSA, I.ITEM2 AS ITEM, P.CATALOGO, P.DESCRIPCION, I.QTY2 AS CANT, OG.FECHA, ROUND((P.precioAlmacen * I.QTY2),2)  AS PRECIO " +
                           "FROM productos P, osa_indiv I, osa_gral OG " +
                           "WHERE OG.PROYECTO_ID= " + idProyecto +
                           " AND I.ID_OSAGRAL = OG.ID " +
                           "AND I.ID_PRODUCTO2=P.ID "+
                           "ORDER BY I.ID_OSAGRAL ASC";


            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public override string ToString()
        {
            return NOMBRE+" "+ ID;
        }

        public static List<proyectos> GetExistentes()
        {
            List<proyectos> lista = new List<proyectos>();

            String query = "SELECT * FROM proyectos where STATUS=0 ORDER BY ID ASC";           

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new proyectos(dr));
            }
            return lista;
        }


    }
}
