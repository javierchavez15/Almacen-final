using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;

namespace Form1
{
   public class oen_gral : hmiObject
   {
       public oen_gral()
       {
       }

       public oen_gral(int id)
       {
           this.LoadMembers("Id=" + id);
       }

       public oen_gral(DataRow dr)
       {
           this.LoadDataRow(dr);
       }

       public int Id;
       public string CODIGODEBARRAS = "";
       public DateTime FECHA = DateTime.Now.Date;
       public int ID_PROVEEDOR = 0;
       public int ID_OREP = 0;
       public List<oen_indiv> PARTIDAS=new List<oen_indiv>();
       public List<inventariocostos> ItemsInventario = new List<inventariocostos>();
        public int PROYECTO_ID=0;
        public int ID_VENDEDOR=0;
        public int ID_CLIENTE=0;

        public static DataTable ListaOEN(int oen)
       {
           String query;

           if (oen == 0)
           {
               query = "SELECT OEN.ID AS OEN, OEN.CODIGODEBARRAS, OEN.FECHA, P.NOMBRE AS PROVEEDOR, OEN.ID_OREP AS OREP FROM oen_gral OEN, proveedores P WHERE OEN.ID_PROVEEDOR= P.ID ORDER BY OEN.ID DESC";
           }
           else
           {
               query = "SELECT OEN.ID AS OEN, OEN.CODIGODEBARRAS, OEN.FECHA, P.NOMBRE AS PROVEEDOR, OEN.ID_OREP AS OREP FROM oen_gral OEN, proveedores P WHERE OEN.ID_PROVEEDOR= P.ID AND OEN.ID LIKE '%" + oen + "%' ORDER BY OEN.ID DESC";
              
           }

           DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

           return dt;
       }

      
       public void InsertarHoja()
       {
           foreach (oen_indiv oeni in PARTIDAS)
           {
               oeni.Insert();
           }

           foreach (inventariocostos invCost in ItemsInventario)
           {
               invCost.Insert();
           }

           this.Insert();
       }

   }

}

