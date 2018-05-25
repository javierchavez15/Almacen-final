using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Form1
{
    public class prdoducto_codigos : hmiObject
    {
        public prdoducto_codigos()
        {
        }

        public prdoducto_codigos(int id)
        {
            this.LoadMembers("Id=" + id);
        }

        public prdoducto_codigos(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public int Id=0;
        public string CODIGO = "";
        public int idproducto = 0;
        public string catalogo = "";

        public override string ToString()
        {
            return CODIGO.ToString();

        }

        public static DataTable tabla(string cat, string ids)
        {
            String query = "SELECT Id, CODIGO FROM prdoducto_codigos where catalogo='"+cat+"' or idproducto="+ids;
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            return dt;
        }

        public static DataTable vacia()
        {
            String query = "SELECT Id, CODIGO FROM prdoducto_codigos where catalogo='prdoducto_codigos'";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);

            return dt;
        }

        public static List<empleados> GetExistentes()
        {
            List<empleados> lista = new List<empleados>();
            String query = "SELECT * FROM prdoducto_codigos ORDER BY codigo ASC";
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new empleados(dr));
            }
            return lista;
        }
    }
}
