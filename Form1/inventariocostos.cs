using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class inventariocostos:hmiObject
    {
        public inventariocostos()
        {
        }

        public inventariocostos(int id)
        {
            this.LoadMembers("ID=" + id);
        }

        public inventariocostos(int idProducto, String Salida)
        {
            String query = "SELECT * FROM inventariocostos " +
           "WHERE id_producto =" + idProducto +
           " AND cantidad_actual > 0 " +
           "ORDER BY fechaFactura ASC limit 1";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            if (dt.Rows.Count > 0)
            {
                this.LoadDataRow(dt.Rows[0]);
            }
            
        }


        public inventariocostos(int idProducto, bool Devolucion)
        {
            String query = "SELECT * FROM inventariocostos " +
           "WHERE id_producto =" + idProducto +
           " AND cantidad_actual < cantidad_oen " +
           "ORDER BY fechaFactura DESC limit 1";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            if (dt.Rows.Count > 0)
            {
                this.LoadDataRow(dt.Rows[0]);
            }

        }

        public inventariocostos(DataRow dr)
        {
            this.LoadDataRow(dr);
        }


        public int Id;
        public int id_oen_indiv = 0;
        public int id_producto = 0;
        public int cantidad_oen = 0;
        public int cantidad_actual = 0;
        public double tipoCambio = 0;
        public string Moneda = "";
        public double costoU = 0;
        public string facturaProveedor = "";
        public DateTime fechaFactura = DateTime.Now.Date;
        public double totalItemPMX = 0;
        public double totalItem = 0;


        public void salidaInventario(int idProducto, DateTime fechaSalida)
        {

        }

        public void devolverSalida()
        { 
        }

        public static DataTable listacostos(int idprod)
        {
            String query;
            query = "SELECT 'Entrada' as ORIGEN, inv.fechaFactura as FECHA, inv.costoU AS PRECIO, inv.moneda AS MONEDA, inv.tipoCambio AS T_C, '' AS URL_1, '' AS URL_2, '' AS URL_3, '' AS COTIZACION, inv.facturaProveedor as FACTURA, pv.NOMBRE AS PROVEEDOR, '' AS CONTACTO, 'Almacen' as MODIFICO FROM inventariocostos as inv LEFT JOIN oen_indiv o ON ( inv.Id = o.Id ) LEFT JOIN oen_gral g ON ( o.ID_OENGRAL = g.Id ) LEFT JOIN proveedores pv ON ( g.ID_PROVEEDOR = pv.ID ) WHERE inv.id_producto =" + idprod.ToString();
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);
            return dt;
        }
    }
}
