using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;

namespace Form1
{
    public class orep_gral:hmiObject
    {

        public orep_gral()
        { }

        public orep_gral(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public orep_gral(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int Id;
        public DateTime Fecha = DateTime.Today.Date;
        public string CodigoBarras = "";
        public int StetusOREP = 0;
        public List<orep_indiv> OREP_Individual=new List<orep_indiv>();

        public static DataTable tablaProductos()
        {
            String query = "SELECT ID, " +
                "CATALOGO, " +
                "DESCRIPCION, " +
                "UNIDAD, " +
                "STOCK," +
                "ORDENADO," +
                "MINIMO," +
                "MAXIMO, " +
                "MAXIMO-MINIMO AS DIF_MAXMIN, " +
                "MAXIMO - (ABS(ORDENADO)+STOCK) AS REPONER " +
                "FROM productos " +
                "WHERE STOCK <= MINIMO AND MAXIMO - (ABS(ORDENADO)+STOCK) > 0 AND MINIMO > 0";          

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);        

            return dt;
        }

        public static DataTable ListaOREP(int idOREP,int status)
        {
            
            String query;

            if (status == 0 && idOREP == 0)
            {
                query="select og.id, og.FECHA, og.codigobarras as BarCode, so.nombre as STATUS from statusorep so, orep_gral og where og.stetusorep= so.id order by og.id desc";
             
            }
            else if (status > 0 && idOREP > 0) 
            {
                query = "select og.id, og.FECHA, og.codigobarras as BarCode, so.nombre as STATUS from statusorep so, orep_gral og where og.stetusorep= so.id AND OG.ID=" + idOREP + " AND OG.stetusOREP=" +status+" order by og.id desc";
              //  query = "SELECT * FROM OREP_GRAL WHERE ID=" + idOREP + " AND StatusOREP=" + status + " ORDER BY ID DESC";
            }
            else if (status > 0)
            {
                query = "select og.id, og.FECHA, og.codigobarras as BarCode, so.nombre as STATUS from statusorep so, orep_gral og where og.stetusorep= so.id AND OG.stetusOREP=" + status + " order by og.id desc";
                
              //  query = "SELECT * FROM OREP_GRAL WHERE StatusOREP=" + status + " ORDER BY ID DESC";
            }
            else
            {
                query = "select og.id, og.FECHA, og.codigobarras as BarCode, so.nombre as STATUS from statusorep so, orep_gral og where og.stetusorep= so.id AND OG.ID=" + idOREP + " order by og.id desc";
               
              //  query = "SELECT * FROM OREP_GRAL WHERE ID=" + idOREP + "  ORDER BY ID DESC";
            }
                       

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;

        }

        public static DataTable tablaOREPS(int statusOREP, int idOREP, string Codigo)
        {

            String query = "SELECT * FROM orep_gral " +
                          "WHERE (StatusOREP =" + statusOREP + ") OR (CodigoBarras = '" + Codigo + "') OR (Id =" + idOREP + ")  ORDER BY Id ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;

        }
    }
}
