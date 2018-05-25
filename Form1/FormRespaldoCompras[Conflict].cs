using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using libData;
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
            dataGridView1.DataSource = productosPU();
        }

        private void buttonBuscarRespaldos_Click(object sender, EventArgs e)
        {
           
        }

        private void respaldosDeCOMPRASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // respaldoCompras();
        }

        private void respaldoCompras()
        {
            DataTable dtCompras;
            DataTable dtProductosStock = queryStock();
            int idproducto = 0;
            int idInvetarioCostos = 1;

            foreach (DataRow dr in dtProductosStock.Rows)
            {
                idproducto = Convert.ToInt32(dr["Id"]);
                PRODUCTOS p = new PRODUCTOS(idproducto);
                //     if (p.stock_respaldado == 0)
                //     {
                dtCompras = queryCompras(p.CATALOGO);
                if (dtCompras.Rows.Count > 0)
                {
                    int i = 0;
                    int stock = p.STOCK;
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
                            ic.Moneda = cpr.oneda;
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
                    PRODUCTOS producto = new PRODUCTOS(idproducto);

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
              actualizarRespaldos();
        }


        private DataTable queryProductosStock()
        {
            String query = "SELECT * FROM PRODUCTOS WHERE STOCK > 0 AND CATALOGO <> '' ";
            DataTable dtProductoStock = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductoStock;
        }

        private DataTable productosPU()
        {
            String query = "SELECT * FROM PRODUCTOS WHERE PrecioAlmacen > 0 ";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable productosSinPU()
        {
            String query = "SELECT * FROM PRODUCTOS WHERE STOCK >0 AND ( PrecioAlmacen is null OR PrecioAlmacen = 0) ";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable queryRespaldoProductos(int idProducto)
        {
            String query = "SELECT * FROM INVENTARIOCOSTOS " +
           "WHERE id_producto =" + idProducto +
           " AND cantidad_actual > 0 " +
           "ORDER BY fechaFactura DESC";

            DataTable dt = DbObject.DefaultDataBaseObject.GetTable(query);
            return dt;
        }

        private DataTable queryProductos()
        {
            
            String query = "SELECT * FROM PRODUCTOS WHERE stock_respaldado > 0";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable queryStock()
        {
            String query = "SELECT * FROM PRODUCTOS WHERE STOCK>0 and stock_respaldado is null";
            DataTable dtProductosPU = DbObject.DefaultDataBaseObject.GetTable(query);
            return dtProductosPU;
        }

        private DataTable queryCompras(string catalogo)
        {
          //  String query = "SELECT TOP 1 * FROM COMPRAS WHERE CATALOGO LIKE '%" + catalogo + "%' ORDER BY fecha DESC, ID DESC";

           String query = "SELECT * FROM COMPRAS WHERE CATALOGO LIKE '%"+catalogo+"%'  ORDER BY fecha DESC";
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
                    PRODUCTOS producto = new PRODUCTOS(iDprodcuto);
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

        private void recuperarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime value = new DateTime(2015, 12, 31);
            DataTable dtProductoSinPU = productosSinPU();
            foreach (DataRow dr in dtProductoSinPU.Rows)
            {
                int idProducto=Convert.ToInt32(dr["Id"]);
                PRODUCTOS p=new PRODUCTOS(idProducto);
                COMPRAS cpr = new COMPRAS(p.CATALOGO, true);
                if (cpr.Id > 0)
                {

                    if (cpr.fecha > value)
                    {

                        if (cpr.oneda == "PMX"||cpr.oneda=="PESOS")
                        {
                            p.PrecioAlmacen = cpr.costoUnitario / cpr.tipoCambio;
                            
                        }
                        if (cpr.oneda == "USD"||cpr.oneda=="DOLARES")
                        {
                            p.PrecioAlmacen = cpr.costoUnitario;
                        }

                        p.MONEDA = "USD";
                        p.Update("Id");

                        cotizacionProveedor qp = new cotizacionProveedor();
                        qp.Id = qp.NextID();
                        qp.numeroCotizacion = "FOLIO COMPRA " + cpr.folio.ToString();
                        qp.fecha = cpr.fecha;
                        qp.precioUnitario = cpr.costoUnitario;
                        qp.tipoMoneda = cpr.oneda;
                        qp.tipoCambio = cpr.tipoCambio;
                        qp.idProducto = p.Id;
                        qp.Insert();

                    }
                }
            }

            MessageBox.Show("Listo");
        }

    }
}
