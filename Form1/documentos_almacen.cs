using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Form1
{
    public class documentos_almacen : hmiObject
    {
        public int Id;
        public int idproducto = 0;
        public int identrada = 0;
        public string ruta = "";
        public string facturas = "";
        public string pedimento = "";
        public DateTime fecha = DateTime.Now.Date;
        public List<documentos_almacen> documentos = new List<documentos_almacen>();

        public documentos_almacen()
        { }

        public documentos_almacen(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public documentos_almacen(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public static DataTable documentosvacios()
        {
            String query = "SELECT * FROM documentos_almacen WHERE ID<0 limit 1";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
            return dt;
        }

        public static DataTable docementosproducto( int idprod)
        {
            String query = "SELECT identrada as OEN, fecha as FECHA, ruta as DOCUMENTO FROM documentos_almacen WHERE idproducto="+ idprod.ToString()+ " or identrada in (select ID_OENGRAL from oen_indiv where ID_PRODUCTO=" + idprod.ToString() + ") order by fecha desc";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
            return dt;
        }

        public static DataTable documentosfactiura(string factura1)
        {
            String query = "SELECT * FROM documentos_almacen WHERE facturas='"+factura1+"' order by fecha desc limit 10";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
            return dt;
        }

        public static DataTable documentospedimento(string pedimento1)
        {
            String query = "SELECT * FROM documentos_almacen WHERE pedimento='" + pedimento1 + "' order by fecha desc limit 10";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
            return dt;
        }
    }
}
