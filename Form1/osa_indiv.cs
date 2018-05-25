using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class osa_indiv : hmiObject
    {

        public osa_indiv()
        {
        }

        public osa_indiv(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public osa_indiv(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public osa_indiv(int item, int osa)
        {
            this.LoadMembers("ID_OSAGRAL = " + osa + " AND ITEM2 = " + item);
        }

        public int Id;
        public int ID_OSAGRAL;
        public int ITEM2 = 0;
        public int ID_PRODUCTO2 = 0;
        public int QTY2 = 1;
        public int VENTA = 0;
        public double precioAlmacen = 0;
        public double totalItem = 0;
             

        public static DataTable PartidasOSA()
        {            
            String query = "SELECT * FROM osa_indiv";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            return dt;
        }

        public static DataTable TablaOSA_INDIV(int osa)
        {//, OI.VENTA
            String query = "SELECT OI.ITEM2 AS ITEM, P.CATALOGO, P.DESCRIPCION, OI.QTY2 AS CANTIDAD, OI.VENTA FROM osa_indiv OI, productos P WHERE P.ID= OI.ID_PRODUCTO2 AND ID_OSAGRAL=" + osa+" ORDER BY OI.ID DESC";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            return dt;
        }

    }
}

