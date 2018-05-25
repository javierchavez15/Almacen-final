using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class cotizacionproveedor:hmiObject
    {
        public cotizacionproveedor()
        { 
        }

        
         public cotizacionproveedor(int id)
        {
            this.LoadMembers("Id=" + id);
        }

         public cotizacionproveedor(string catalogo)
         {           
             this.LoadMembers("CATALOGO=" + catalogo);
         }

         public cotizacionproveedor(DataRow dr)
         {
             this.LoadDataRow(dr);
         }

         public int Id;
         public string numeroCotizacion = "";
         public DateTime fecha = DateTime.Now.Date;
         public double precioUnitario = 0;
         public string tipoMoneda = "";
         public double tipoCambio = 0;
         public int idProducto = 0;
        public string tipo = "Ajuste";
        public string edito = "Almacen";

        public static DataTable listacostos(int idprod)
        {
            String query;
            query = "SELECT cot.tipo as ORIGEN, cot.fecha AS FECHA, cot.precioUnitario AS PRECIO, cot.tipoMoneda AS MONEDA, cot.tipoCambio AS T_C, cot.url1 AS URL_1, cot.url2 AS URL_2, cot.url3 AS URL_3, cot.numeroCotizacion AS COTIZACION, '' as FACTURA, cot.proveedor AS PROVEEDOR, cot.contacto AS CONTACTO, cot.edito as MODIFICO FROM cotizacionproveedor as cot WHERE cot.idProducto=" + idprod.ToString();
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);
            return dt;
        }
    }
}
