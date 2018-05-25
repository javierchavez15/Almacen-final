using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;

namespace Form1
{
    public class ReconocerCodigo:hmiObject
    {
        public static DataRow codigoReconocido(string codigo)
        {
                       
            string query = "SELECT * FROM productos WHERE CODIGODEBARRAS='" + codigo + "' or Id in (select idproducto from prdoducto_codigos where codigo='" + codigo + "')";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);


            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0];
            }

            return null;

        }
    }
}
