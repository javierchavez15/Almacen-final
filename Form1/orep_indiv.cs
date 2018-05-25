using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;

namespace Form1
{
    public class orep_indiv:hmiObject
    {
        public orep_indiv()
        { }

        public orep_indiv(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public orep_indiv(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int Id;
        public int ID_OREP_GRAL = 0;
        public int ITEM_OREP = 0;
        public int ID_PRODUCTO = 0;
        public int CANTIDAD_OREP = 0;

        public static DataTable PartidasOREP(int idOrepGral)
        {
            String query = "SELECT " +
                "ORI.ID, " +
                "ORI.ITEM_OREP AS ITEM, " +
                "P.CATALOGO, " +
                "P.DESCRIPCION, " +
                "ORI.CANTIDAD_OREP AS CANTIDAD " +
                "FROM orep_indiv ORI, productos P " +
                "WHERE ORI.ID_PRODUCTO = P.ID " +
                "AND ORI.ID_OREP_GRAL =" + idOrepGral +
                " ORDER BY ORI.ID DESC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            return dt;
        }
    }
}
