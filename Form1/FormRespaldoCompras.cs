using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using libData;
using System.Management;

namespace Form1
{
    public partial class FormRespaldoCompras : Form
    {
        public FormRespaldoCompras()
        {
            InitializeComponent();
        }



        private void FormRespaldoCompras_Load(object sender, EventArgs e)
        {
          //  dataGridView1.DataSource = queryStock();
        }

        private void buttonBuscarRespaldos_Click(object sender, EventArgs e)
        {
           
        }

        private void respaldosDeCOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            DataTable dtCompras;
            DataTable dtProductosStock = queryStock();
            int idproducto = 0;
            int idInvetarioCostos=1;

            foreach (DataRow dr in dtProductosStock.Rows)
            {
                idproducto = Convert.ToInt32(dr["Id"]);
                PRODUCTOS p = new PRODUCTOS(idproducto);
           //     if (p.stock_respaldado == 0)
           //     {
                    dtCompras = queryCompras(p.CATALOGO);
                    if (dtCompras.Rows.Count > 0)
                    {
                        int i=0;
                        int stock=p.STOCK;
                        foreach (DataRow c in dtCompras.Rows)
                        {                            

                            if (i < p.STOCK)
                            {
                                InventarioCostos ic = new InventarioCostos();

                                int idCompra = Convert.ToInt32(dr["Id"]);
                                COMPRAS cpr = new COMPRAS(idCompra);

                                ic.Id = idInvetarioCostos;
                                idInvetarioCostos++;

                                ic.id_producto = p.Id;
                                ic.cantidad_oen = cpr.cantidad;

                                ic.tipoCambio = cpr.tipoCambio;
                                ic.Moneda = cpr.moneda;
                                ic.costoU = cpr.costoUnitario;
                                ic.facturaProveedor = "Folio Adminpaq " + cpr.folio.ToString();
                                ic.fechaFactura = cpr.fecha;
                                ic.totalItemPMX = cpr.totalMX;
                                ic.totalItem = cpr.totalItem;

                                if (cpr.cantidad < stock)
                                {
                                    i += cpr.cantidad;
                                    stock -= i;
                                    ic.cantidad_actual = cpr.cantidad;

                                }

                                if (cpr.cantidad >= stock)
                                {
                                    ic.cantidad_actual = cpr.cantidad - stock;
                                    i += stock;
                                    stock = 0;
                                    
                                }

                                ic.Insert();
                            }

                        }


                        if (i > 0)
                        {
                            p.stock_respaldado = i;
                            p.Update("Id");
                        }
                    }                    
              //  }

            }


            MessageBox.Show("yA ESTA");
            */
        }

        private void respaldarStock()
        {
            DataTable dtProductoStock = queryProductosStock();

        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dtProductoStock = queryProductosStock();
            labelListaProductos.Text += dtProductoStock.Rows.Count.ToString();

            DataTable dtProductosPU = productosPU();
            labelProductPU.Text += dtProductosPU.Rows.Count.ToString();

            DataTable consulta = queryProductos();

            if (consulta.Rows.Count > 0)
            {
                int[] Respaldados = new int[2000];
                int[] AlgunRespaldo = new int[2000];
                int[] SobreRespaldado = new int[2000];
                int i = 0;
                foreach (DataRow dr in consulta.Rows)
                {
                    int idproducto = Convert.ToInt32(dr["Id"]);
                    productos producto = new productos(idproducto);

                    if (producto.stock_respaldado == producto.STOCK)
                    {
                        Respaldados[i] = 1;
                    }

                    if (producto.stock_respaldado < producto.STOCK)
                    {
                        AlgunRespaldo[i] = 1;
                    }

                    if (producto.stock_respaldado > producto.STOCK)
                    {
                        SobreRespaldado[i] = 1;
                    }

                    i++;
                }



                labelProductRespaldados.Text += Respaldados.Sum().ToString() + ", Con algun Respaldo: " + AlgunRespaldo.Sum().ToString() + ", Sobre respaldados:" + SobreRespaldado.Sum().ToString();

                dataGridView1.DataSource = queryProductos();

            }



        }

        private void actualizarRespaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  actualizarRespaldos();
        }


        private DataTable queryProductosStock()
        {
            String query = "SELECT * FROM productos WHERE STOCK > 0 AND CATALOGO <> '' ";
            DataTable dtProductoStock = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductoStock;
        }

        private DataTable productosPU()
        {
            String query = "SELECT CATALOGO, STOCK, PrecioAlmacen  FROM productos WHERE PrecioAlmacen > 0 ";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable productosSinPU()
        {
            String query = "SELECT * FROM productos WHERE (PrecioAlmacen = 0 or PrecioAlmacen is null) and STOCK > 0 AND CATALOGO <> ''";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable reporteABC()
        {
            String query = "SELECT p.CATALOGO, p.STOCK, p.PrecioAlmacen, "+
                "SUM(oi.QTY2) as cantidad, " +                
                "FROM productos p, osa_gral og, osa_indiv oi  WHERE (PrecioAlmacen = 0 or PrecioAlmacen is null) and STOCK > 0 AND CATALOGO <> '' and ";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable reporteSalidas()
        {
            String query = "SELECT p.CATALOGO, oi.QTY2, og.FECHA FROM productos p, osa_gral og, osa_indiv oi WHERE oi.QTY2 > 0 AND oi.ID_PRODUCTO2 = p.Id  AND oi.ID_OSAGRAL = og.Id ORDER BY p.CATALOGO ASC";

            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable queryRespaldoProductos(int idProducto)
        {
            String query = "SELECT * FROM inventariocostos " +
           "WHERE id_producto =" + idProducto +
           " AND cantidad_actual > 0 " +
           "ORDER BY fechaFactura DESC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
            return dt;
        }

        private DataTable queryProductos()
        {
            
            String query = "SELECT * FROM productos WHERE stock_respaldado > 0";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable queryStock()
        {
            String query = "SELECT * FROM productos WHERE STOCK>0 and stock_respaldado is null";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable queryCompras(string catalogo)
        {
            String query = "SELECT * FROM compras WHERE CATALOGO LIKE '%"+catalogo+"%'  ORDER BY fecha DESC";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private void buttonProductosR_Click(object sender, EventArgs e)
        {
            
        }

        private void actualizarRespaldos()
        {
            #region ACTUALIZAR RESPALDOS

            DataTable dtProductoStock = queryProductosStock();
            labelListaProductos.Text += dtProductoStock.Rows.Count.ToString();

            DataTable dtProductosPU = productosPU();
            labelProductPU.Text += dtProductosPU.Rows.Count.ToString();

            int[] Respaldados = new int[2000];
            int[] AlgunRespaldo = new int[2000];
            int i2 = 0;

            foreach (DataRow dr in dtProductoStock.Rows)
            {
                int iDprodcuto = Convert.ToInt32(dr["Id"]);

                DataTable dtRespaldo1 = queryRespaldoProductos(iDprodcuto);

                if (dtRespaldo1.Rows.Count > 0)
                {
                    productos producto = new productos(iDprodcuto);
                    int[] cantActual = new int[100];
                    int i = 0;
                    foreach (DataRow dr2 in dtRespaldo1.Rows)
                    {
                        cantActual[i] = Convert.ToInt32(dr2["cantidad_actual"]);
                        i++;
                    }

                    producto.stock_respaldado = cantActual.Sum();
                    producto.Update("Id");

                    if (producto.STOCK == cantActual.Sum())
                    {
                        Respaldados[i2] = 1;
                    }
                    if (producto.STOCK > cantActual.Sum())
                    {
                        AlgunRespaldo[i2] = 1;
                    }

                }

                i2++;

            }

            labelProductRespaldados.Text += Respaldados.Sum().ToString() + " Con algun Respaldo: " + AlgunRespaldo.Sum().ToString();

            dataGridView1.DataSource = queryProductos();

            #endregion ACTUALIZAR RESPALDOS
        }

        private void borrarOrdenadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            
            String query = "DELET FROM PRODUCTOS WHERE STOCK =0 OR STOCK IS NULL";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            MessageBox.Show("Registros encontrados:" + dtProductosPU.Rows.Count);
           
          

            if (dtProductosPU.Rows.Count > 0)
            {
                foreach (DataRow dr in dtProductosPU.Rows)
                {
                    int producto = Convert.ToInt32(dr["Id"]);
                    PRODUCTOS p1 = new PRODUCTOS(producto);
                    p1.MINIMO = 0;
                    p1.MAXIMO = 0;
                    p1.Update("Id");

                }
            }
           
            */
        }

        private void consulta1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String query = "SELECT * FROM productos WHERE PrecioAlmacen > 0 and stock >0 ";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);

            double inventarioTotal = 0;
            double[] preciosU = new double[100000];
           
            int i2 = 0;

            foreach (DataRow dr in dtProductosPU.Rows)
            {
                int idproducto = Convert.ToInt32(dr["Id"]);
                productos productos = new productos(idproducto);

                preciosU[i2] = productos.PrecioAlmacen * productos.STOCK;
                

                i2++;

            }

            inventarioTotal = preciosU.Sum();

            labelProductRespaldados.Text = "Valor de Inventario = " + inventarioTotal.ToString();
        }

        private void productosSinPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productosSinPU();
        }

        private void reporteABCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = reporteSalidas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productosConPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productosPU();//productos con pu>0
        }

       
        

    }
}
