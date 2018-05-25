using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;

namespace Form1
{
    public class oen_indiv : hmiObject
    {

        public oen_indiv()
        {
        }

        public oen_indiv(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public oen_indiv(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int Id;
        public int ID_OENGRAL;
        public int ITEM = 0;
        public int ID_PRODUCTO = 0;
        public int QTY = 1;
        public double PU = 0;
        public string MONEDA = "";
        public double TC = 0;
        public string FACTURA_PROVEEDOR = "";
        public DateTime FECHA_FACTURAP = DateTime.Now.Date;
        public int COMPRA = 0;
        public int VENTA = 0;

        public static DataTable PartidasOEN()
        {            
            String query = "SELECT * FROM oen_indiv";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            return dt;
        }

        public static DataTable TablaOEN_INDIV(int oenGral)
        {
            string query = "SELECT OI.ITEM, "+
                "P.CATALOGO, "+
                "P.DESCRIPCION, "+
                "OI.QTY AS CANTIDAD, OI.COMPRA, OI.VENTA, OI.PU, OI.MONEDA, OI.TC, OI.FACTURA_PROVEEDOR " +
                "FROM oen_indiv as OI, "+
                "productos as P "+
                "WHERE OI.ID_OENGRAL=" + oenGral+ 
                " AND OI.ID_PRODUCTO=P.Id "+
                " ORDER BY OI.ITEM ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            return dt;
        }

    }
}

