using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using libData;
using MySql.Data.MySqlClient;

namespace Form1
{
    public class productos : hmiObject
    {
         public productos()
        { 
        }

         public productos(int id)
        {
            this.LoadMembers("Id=" + id);
        }

         public productos(string catalogo)
         {
           //  this.LoadMembers("CATALOGO=" + catalogo+ "OR CODIGODEBARRAS ="+ Convert.ToInt32(catalogo));
             this.LoadMembers("CATALOGO=" + catalogo);
         }

         public productos(DataRow dr)
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
        public int AJUSTE = 0;
        public DateTime FECHA_AJUSTE;
        public DateTime FECHA_FACTURA;
        public double PrecioAlmacen = 0;
        public int stock_respaldado = 0; 
        public string ADJUNTOS = "";
        public string DOCUMENTOS = "";
        public int STOCKMUERTO = 0;
        public string COORDENADA = "";

        public static DataTable Entradas(int idproducto)
        {
            String query = "SELECT " +
            "G.FECHA, I.QTY, G.ID, P.NOMBRE " +
            "FROM oen_indiv I, oen_gral G, proveedores P "+
            "WHERE I.ID_PRODUCTO = " + idproducto + " AND I.ID_OENGRAL=G.ID AND G.ID_PROVEEDOR=P.ID ORDER BY G.FECHA ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public static DataTable sumas(string catalogos)
        {
            String query = "select precioAlmacen from productos where CATALOGO='"+ catalogos+"' limit 1";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public static DataTable Salidas(int idproducto)
        {
            String query = "SELECT " +
            "G.FECHA, I.QTY2, G.ID, C.RAZON_SOCIAL " +
            "FROM osa_indiv I, osa_gral G, clientes C " +
            "WHERE I.ID_PRODUCTO2 = " + idproducto + " AND I.ID_OSAGRAL=G.ID AND G.ID_CLIENTE=C.ID ORDER BY G.FECHA ASC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public static DataTable listaExistencias(string marca)
        {
            String query = "";

            if (marca == "TODAS")
            {
                query = "SELECT ID,CATALOGO,DESCRIPCION,MARCA,STOCK,COORDENADA FROM productos WHERE STOCK > 0 ORDER BY MARCA,CATALOGO ASC";
            }
            else if(marca!="")          
            {
                query = "SELECT ID,CATALOGO,DESCRIPCION,MARCA,STOCK,COORDENADA FROM productos WHERE STOCK > 0 AND MARCA LIKE '%" + marca + "%' ORDER BY CATALOGO ASC";
            }

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public static DataTable ListaProductos(string referencia, string marca, bool muerto)
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
                    subquery += "%' and DESCRIPCION like '%" + palabra;
                }
                i++;
            }            
            

           
            String query = "";
            String query1 = "select * from productos " +
                           "where ((CATALOGO LIKE '%" + referencia + "%' )" +
                           "OR (DESCRIPCION LIKE '%" + subquery + "%'))";
                        //   "OR (CODIGODEBARRAS LIKE '%" + referencia + "%'))";
            String query2 = " AND MARCA LIKE '%" + marca + "%' ";
         // String query4 = " AND CODIGODEBARRAS LIKE '%" + codigo + "%' ";
            String query3 = " ORDER BY STOCK DESC, CATALOGO ASC";

            if (muerto == true)
                query1 = query1 + " and STOCKMUERTO=1 ";
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

        public static DataTable ListaProductos()
        {

            string subquery = "SELECT pro.CATALOGO, "+
                "ROUND( pro.precioAlmacen, 2 ) AS PRECIO, "+
                "IF( pro.STOCK < SUM( ent.QTY ) , pro.STOCK, SUM( ent.QTY ) ) AS CANTIDAD, "+
                "ROUND((pro.precioAlmacen * (IF(pro.STOCK < SUM(ent.QTY), pro.STOCK, SUM(ent.QTY)))) , 2) AS TOTAL, pro.ID " +
"FROM productos AS pro "+
"LEFT JOIN oen_indiv AS ent ON pro.Id = ent.ID_PRODUCTO "+
"WHERE pro.STOCK > 0 "+
"AND pro.precioAlmacen > 0 "+
"AND ent.QTY > 0 " +
"AND ent.FACTURA_PROVEEDOR <> 'AJUSTE STOCK' " +
"AND ent.FACTURA_PROVEEDOR <> 'AJUSTE INVENTARIO' " + 
"AND ent.FACTURA_PROVEEDOR <> '0' " +
"AND ent.FACTURA_PROVEEDOR <> 'AJUSTE' " +
"AND ent.FACTURA_PROVEEDOR <> 'AJUSTE INVENTARIO 2' " +
"AND ent.FACTURA_PROVEEDOR <> 'AJUSTE STOCK ' " +
"AND ent.FACTURA_PROVEEDOR <> 'CAMBIO DE CONTACTOR' " +
"AND ent.FACTURA_PROVEEDOR <> 'CORRECCION STOCK' " +
"AND ent.FACTURA_PROVEEDOR <> 'AJUSTE DE STOCK' " +
"AND ent.FACTURA_PROVEEDOR <> 'AJUSTE DE STOCK ' " +
"and ent.FACTURA_PROVEEDOR <> '' " +
"GROUP BY ent.ID_PRODUCTO";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(subquery); //BaseDatosSQL.Tabla(query, ref error);

            return dt;

        }
        public static DataTable ListaProductos(string id1)
        {
            string subquery = "SELECT FACTURA_PROVEEDOR FROM oen_indiv WHERE FACTURA_PROVEEDOR<>'' and ID_PRODUCTO="+id1;

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(subquery); //BaseDatosSQL.Tabla(query, ref error);

            return dt;
        }

        public override string ToString()
        {
            return CATALOGO;            
        }

        public static List<productos> GetExistentes()
        {
            List<productos> lista = new List<productos>();

            String query = "SELECT * FROM PRODUCTOS ORDER BY CATALOGO ASC";

            String error = "";

            DataTable dt = BaseDatosSQL.Tabla(query, ref error);

            foreach (DataRow dr in dt.Rows)
            {
                lista.Add(new productos(dr));
            }
            return lista;

        }

        public static List<string> listamarcas()
        {
            List<string> lista = new List<string>();
            String query = "";
            query = "SELECT MARCA FROM productos group by MARCA ORDER BY MARCA ASC";
            DataBase bas = new DataBase();
            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query); //BaseDatosSQL.Tabla(query, ref error);

            foreach (DataRow dr in dt.Rows)
            { 
                lista.Add(dr["MARCA"].ToString());
            }
            return lista;
        }
    }
}
