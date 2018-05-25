using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using libData;

namespace Form1
{
    public class PRODUCTOS : hmiObject
    {
         public PRODUCTOS()
        { 
        }

         public PRODUCTOS(int id)
        {
            this.LoadMembers("ID=" + id);
        }

         public PRODUCTOS(string catalogo)
         {
           //  this.LoadMembers("CATALOGO=" + catalogo+ "OR CODIGODEBARRAS ="+ Convert.ToInt32(catalogo));
             this.LoadMembers("CATALOGO=" + catalogo);
         }

         public PRODUCTOS(DataRow dr)
         {
             this.LoadDataRow(dr);
         }

        /*
        public PRODUCTOS(int id)
        {
            string error="";
            string query="select "+
                            "L.ID,"+
                            "L.CATALOGO,"+
                            "L.DESCRIPCION,"+
                            "L.CATEGORIA,"+  
                            "L.IDMODULO,"+
                            "L.PRECIOLISTA,"+
                            "L.MONEDA,"+
                            "L.MARCA,"+
                            "F.factor "+
                            " from ListaPrecios L, Factores F "+
                            " where L.ID="+id+
                            " AND L.IDMODULO = F.ID";
            
            DataTable dt = BaseDatosSQL.Tabla(query, ref error);
            if (dt.Rows.Count > 0)
            {
                Leer(dt.Rows[0]);
            }
        }
        */

        public int Id;       
        public string CATALOGO = "";
        public string DESCRIPCION = "";
        public string CATEGORIA = "";
        public int IDMODULO = 0;
        public double PRECIOLISTA = 0;
        public string MONEDA = "";
        public string MARCA = "";
        public int UNIDAD = 1;
        public string CODIGODEBARRAS = "";
        public int ORDENADO = 0;
        public int STOCK = 0;
        public int MINIMO = 0;
        public int MAXIMO = 0;
        
        public string COORDENADA = "";

        public static DataTable listaExistencias(string marca)
        {
            String query = "";

            if (marca == "TODAS")
            {
                query = "SELECT ID,CATALOGO,DESCRIPCION,MARCA,STOCK,COORDENADA FROM PRODUCTOS WHERE STOCK > 0 ORDER BY MARCA,CATALOGO ASC";
            }
            else if(marca!="")          
            {
                query = "SELECT ID,CATALOGO,DESCRIPCION,MARCA,STOCK,COORDENADA FROM PRODUCTOS WHERE STOCK > 0 AND MARCA LIKE '%" + marca + "%' ORDER BY CATALOGO ASC";
            }

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public static DataTable ListaProductos(string referencia, string marca)
        {

            if (referencia == "") return null;

            string[] lista = referencia.Split(' ');

            string subquery = "";
            int i = 0;
            foreach (string palabra in lista)
            {

                if (i == 0)
                {
                    subquery = palabra;
                }
                else
                {
                    subquery += "%' AND PD.DESCRIPCION LIKE '%" + palabra;
                }
                i++;
            }            
            

           
            String query = "";
            String query1 = "SELECT * FROM PRODUCTOS " +
                           "WHERE ((CATALOGO LIKE '%" + referencia + "%' )" +
                           "OR (DESCRIPCION LIKE '%" + subquery + "%'))";
                        //   "OR (CODIGODEBARRAS LIKE '%" + referencia + "%'))";
            String query2 = " AND MARCA LIKE '%" + marca + "%' ";
         // String query4 = " AND CODIGODEBARRAS LIKE '%" + codigo + "%' ";
            String query3 = " ORDER BY STOCK DESC, CATALOGO ASC";


            if (marca == "")
            {
                query = query1 + query3;
            }
            else
            {
                query = query1 + query2 + query3;
            }


            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);
          
            return dt;
 
        }
               
        public override string ToString()
        {
            return CATALOGO;            
        }

        public static List<PRODUCTOS> GetExistentes()
        {
            List<PRODUCTOS> lista = new List<PRODUCTOS>();

            String query = "SELECT * FROM PRODUCTOS ORDER BY CATALOGO ASC";

            String error = "";

            DataTable dt = BaseDatosSQL.Tabla(query, ref error);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new PRODUCTOS(dr));
            }
            return lista;

        }


    }
}
