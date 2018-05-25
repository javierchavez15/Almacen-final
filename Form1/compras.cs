using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class compras:hmiObject
    {
        public compras()
        {
        }

        public compras(int id)
        {
            this.LoadMembers("Id=" + id);
        }

         public compras(string catalogo)
         {           
             this.LoadMembers("CATALOGO=" + catalogo);
         }

         public compras(DataRow dr)
         {
             this.LoadDataRow(dr);
         }

         public compras(int idProducto, String Salida)
         {
            String query = "SELECT TOP 1 * FROM INVENTARIOCOSTOS " +
           "WHERE id_producto =" + idProducto +
           " AND cantidad_actual > 0 " +
           "ORDER BY fechaFactura ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            if (dt.Rows.Count > 0)
            {
                this.LoadDataRow(dt.Rows[0]);
            }
            
         }


         public compras(string catalogo, bool Devolucion)
         {
             String query = "SELECT TOP 1 * FROM COMPRAS WHERE CATALOGO LIKE '%" + catalogo + "%' ORDER BY fecha DESC, ID DESC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            if (dt.Rows.Count > 0)
            {
                this.LoadDataRow(dt.Rows[0]);
            }

         }


         public int Id;
         public DateTime fecha = DateTime.Now.Date;
         public int folio = 0;
         public string nombreProveedor = "";
         public string oneda = "";
         public double tipoCambio = 0;
         public string catalogo = "";
         public string descripcion = "";
         public int cantidad = 0;
         public double costoUnitario = 0;
         public double totalItem = 0;
         public double totalMX = 0;
         public double pumx = 0;
         public int anio = 0;
         public int mes = 0;
         public int idProveedor = 0;



    }
}
