using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
   public class osa_gral : hmiObject
   {
       public osa_gral()
       {
       }

       public osa_gral(int id)
       {
           this.LoadMembers("Id=" + id);
       }

       public osa_gral(DataRow dr)
       {
           this.LoadDataRow(dr);
       }

       public int Id;
       public string CODIGODEBARRAS = "";   
       public DateTime FECHA = DateTime.Now.Date;
       public int ID_CLIENTE = 0;
       public int ID_CONTACTO = 0;
       public int ID_VENDEDOR = 0;
       public string FACTURA = "";
       public double TC = 0;
       public string REMISION = "";
       public string COTIZACION = "";
       public int PROYECTO_ID = 0;
       public int idpoliza = 0;

       public List<osa_indiv> PARTIDAS2=new List<osa_indiv>();

        public void InsertarHoja()
       {
           foreach (osa_indiv oeni in PARTIDAS2)
           {
               oeni.Insert();
           }
           this.Insert();
       }

       public static DataTable osaXproyecto(int idProyecto)
       {
            string query = "SELECT OSA.Id, " +
                  "OSA.FECHA, " +
                  "C.RAZON_SOCIAL, " +
                  "OSA.FACTURA, " +
                  "OSA.REMISION, " +
                  "OSA.PROYECTO_ID, " +
                  "OSA.COTIZACION " +
                  "FROM osa_gral OSA, clientes C " +
                  "WHERE OSA.ID_CLIENTE=C.ID " +
                  "AND OSA.PROYECTO_ID LIKE '%" + idProyecto +"%'"+
                  " ORDER BY OSA.Id  DESC";
          

           DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

           return dt;
       }

       public static DataTable ListaOSA(int osa)
       {
           String query="";

           if (osa == 0)
           {
               query = "SELECT OSA.Id, "+
                   "OSA.FECHA, "+
                   "C.RAZON_SOCIAL, "+
                 //  "T.NOMBRE AS CONTACTO, "+
                   "E.NOMBRE AS VENDEDOR, "+
                   "OSA.FACTURA, "+
                   "OSA.REMISION, "+
                   "OSA.PROYECTO_ID, " +
                   "OSA.COTIZACION "+
                   "FROM osa_gral OSA, clientes C, empleados E "+
                   "WHERE OSA.ID_CLIENTE=C.ID "+
                   "AND OSA.ID_VENDEDOR=E.ID "+
               //    "AND OSA.ID_CONTACTO=T.ID "+
                   "ORDER BY OSA.Id  DESC";
           
           }
           else
           {

               query = "SELECT OSA.Id, " +
                  "OSA.FECHA, " +
                  "C.RAZON_SOCIAL, " +
                //  "CTO.NOMBRE AS CONTACTO, " +
                  "E.NOMBRE AS VENDEDOR, " +
                  "OSA.FACTURA, " +
                  "OSA.REMISION, " +
                  "OSA.PROYECTO_ID, " +
                  "OSA.COTIZACION " +
                  "FROM osa_gral OSA, clientes C, empleados E "+ // contactos CTO " +
                  "WHERE OSA.ID_CLIENTE=C.ID " +
                  "AND OSA.ID_VENDEDOR=E.ID " +
                 // "AND OSA.ID_CONTACTO=CTO.ID " +
                  "AND OSA.Id LIKE '%" + osa+"%'"+
                  " ORDER BY OSA.Id  DESC";
           }

           DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

           return dt;
       }


   }

}

