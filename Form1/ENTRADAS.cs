using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using libBarCode;
using MySql.Data.MySqlClient;

namespace Form1
{
    public partial class ENTRADAS : Form
    {
        public ENTRADAS()
        {
            InitializeComponent();
        }
        oen_gral OENGralSeleccionada;
        productos ProductoSeleccionado;
        proveedores ProveedorSeleccionado;
        DataTable PartidasOEN = oen_indiv.PartidasOEN().Clone();
        orep_gral OREPGralSeleccionada;
        int partidaId;
       
        private void ENTRADAS_Load(object sender, EventArgs e)
        {
            if (OENGralSeleccionada == null)
            {
                OENGRALnextId();
            }
            comboBoxProveedores.DataSource = proveedores.GetExisting();
            DataColumn workCol = PartidasOEN.Columns.Add("Catálogo", typeof(string));
            workCol.AllowDBNull = false;
            workCol.Unique = false;
            DataColumn Descripcion = PartidasOEN.Columns.Add("Descripción", typeof(string));
            Descripcion.AllowDBNull = false;
            Descripcion.Unique = false;
            PartidaNextId();
        }

        private void resetOEN()//reinicia forma
        {
            OENGRALnextId();
            PartidaNextId();
            txtFACTURAP.Text = "";
            dateTimePickerFacturaP.Value = DateTime.Now.Date;
            comboBoxProveedores.SelectedIndex = -1;
            textBoxProducto.Text = "";
            textBoxCantidad.Text = "1";
            PartidasOEN.Clear();
        }

        private void OENGRALnextId()//obtiene el siguiente id
        {
            OENGralSeleccionada = new oen_gral();
            OENGralSeleccionada.Id = OENGralSeleccionada.NextID();
            textBoxOENid.Text = OENGralSeleccionada.Id.ToString();
        }

        private void PartidaNextId()//obtiene el siguiente id
        {
            oen_indiv PartidaId = new oen_indiv();
            partidaId = PartidaId.NextID();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void VerDGV()        
        {
            dataGridView2.DataSource = PartidasOEN;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Width = 50;
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Width = 50;
            dataGridView2.Columns[5].Width = 90;
            dataGridView2.Columns[6].Width = 70;
            dataGridView2.Columns[6].ReadOnly = true;
            dataGridView2.Columns[7].Width = 70;
            dataGridView2.Columns[7].ReadOnly = true;
            dataGridView2.Columns[8].Width = 110;
            dataGridView2.Columns[9].Width = 110;
            dataGridView2.Columns[9].ReadOnly = true;
            dataGridView2.Columns[12].ReadOnly = true;
            dataGridView2.Columns[12].Width = 250;
            dataGridView2.Columns[12].DisplayIndex = 3;
            dataGridView2.Columns[13].ReadOnly = true;
            dataGridView2.Columns[13].Width = 500;
            dataGridView2.Columns[13].DisplayIndex = 4;
            dataGridView2.Columns[10].Width = 80;
            dataGridView2.Columns[10].DisplayIndex = 7;
            dataGridView2.Columns[11].Width = 80;
            dataGridView2.Columns[11].DisplayIndex = 8;
        }
        
        private void AgregarPartida(int idProducto,int qty)
        {         
            DataRow row = PartidasOEN.NewRow();
            row["ITEM"] = PartidasOEN.Rows.Count + 1;
            row["ID_PRODUCTO"] = idProducto;
            row["QTY"] = qty;
            row["COMPRA"] = 0;
            row["VENTA"] = 0;
            row["MONEDA"] = comboBoxMonedaCompra.Text;
            row["TC"] = Convert.ToDouble(textBoxTC.Text);
            row["FACTURA_PROVEEDOR"] = txtFACTURAP.Text;
            row["FECHA_FACTURAP"] = dateTimePickerFacturaP.Value;
            row["Catálogo"] = ProductoSeleccionado.CATALOGO;
            row["Descripción"] = ProductoSeleccionado.DESCRIPCION;
            PartidasOEN.Rows.Add(row);     
        }
        public double totales = 0;
        private void buttonIngresar_Click(object sender, EventArgs e)///////////////////boton ingresar
        {

            double tc = 0;
            #region validaciones
            try
            {
                tc = Convert.ToDouble(textBoxTC.Text);
            }
            catch
            {
                textBoxTC.Text = "0";
                MessageBox.Show("Escriba el Tipo de Cambio Actual");
            }

            if (tc < 16)
            {
                MessageBox.Show("Escriba el Tipo de Cambio Actual");
                return;
            }

            if (comboBoxMonedaCompra.Text == "")
            {
                MessageBox.Show("Seleccione la moneda correcta");
                return;
            }
            
            if (textBoxProducto.Text == "")
            {
                MessageBox.Show("Escriba un criterio de búsqueda");
                return;
            }
            #endregion validaciones
            int idP = 0;
            DataTable dt;
            try
            {
                dt = productos.ListaProductos(textBoxProducto.Text,"", false);//busca el producto
            }
            catch
            {
                dt = new DataTable();
            }            
            if (dt.Rows.Count ==1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    idP = Convert.ToInt32(dr["Id"]);//guarda el id del producto                    
                    ProductoSeleccionado = new productos(idP);//obtiene los datos del producto
                }
                
                AgregarPartida(idP, Convert.ToInt32(textBoxCantidad.Text));//agrega la partida
                VerDGV();//formato a datagrid
            }
            else
            {
                BuscarP();//BuscarP un producto parecido y lo agrega
            }
        }

        private void BuscarP()
        {
            FormBuscarProducto FBP = new FormBuscarProducto();
            FBP.textBoxCatalogo.Text = textBoxProducto.Text;//envia el producto
            FBP.VisualizarDGV1();//realiza la busqueda
            FBP.ShowDialog();

            if (FBP.DialogResult == DialogResult.OK)
            {
                ProductoSeleccionado = FBP.ProductoSelecto;//regresa el producto
                if (ProductoSeleccionado != null)
                {
                    try
                    {
                        Convert.ToInt32(textBoxCantidad.Text);
                        AgregarPartida(ProductoSeleccionado.Id, Convert.ToInt32(textBoxCantidad.Text));//agrega el producto
                        VerDGV();//formato
                    }
                    catch { MessageBox.Show("Escriba solo numero en la cantidad"); }
                }
                else
                {
                    MessageBox.Show("Eliga un producto dando click");
                }
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
          
        }

        public bool AccesoInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.descoa.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void buttonIngresarHoja_Click(object sender, EventArgs e)
        {
            List<productos> listaproductos = new List<productos>();
            if (ProveedorSeleccionado == null)
                return;
            if (AccesoInternet())
            {
                OENGralSeleccionada.PARTIDAS.Clear();
                OENGralSeleccionada.ItemsInventario.Clear();
                OENGralSeleccionada.ID_PROVEEDOR = ProveedorSeleccionado.ID;
                OENGralSeleccionada.CODIGODEBARRAS = OENGralSeleccionada.Id.ToString();
                OENGralSeleccionada.FECHA = DateTime.Now.Date;
                if (PartidasOEN.Rows.Count > 0)
                {
                    int item = 1;
                    totales = 0;
                    double tjavier = 0;
                    foreach (DataRow dr in PartidasOEN.Rows)
                    {
                        #region datos individuales
                        oen_indiv PartidaIndividual = new oen_indiv();
                        PartidaIndividual.Id = partidaId;
                        PartidaIndividual.ID_OENGRAL = OENGralSeleccionada.Id;
                        PartidaIndividual.ITEM = item;
                        PartidaIndividual.ID_PRODUCTO = Convert.ToInt32(dr["ID_PRODUCTO"]);
                        try
                        {
                            PartidaIndividual.QTY = Convert.ToInt32(dr["QTY"]);
                            PartidaIndividual.COMPRA = Convert.ToInt32(dr["COMPRA"]);
                            PartidaIndividual.VENTA = Convert.ToInt32(dr["VENTA"]);
                            PartidaIndividual.PU = Convert.ToDouble(dr["PU"]);
                            if (dr["MONEDA"].ToString() == "USD" || dr["MONEDA"].ToString() == "usd")
                            {
                                tjavier = Convert.ToDouble(dr["PU"])* Convert.ToDouble(dr["QTY"]);
                            }
                            else
                            {
                                tjavier = (Convert.ToDouble(dr["PU"]) / Convert.ToDouble(dr["TC"]))*Convert.ToDouble(dr["QTY"]);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Escriba costo unitario de todas las partidas");
                            return;
                        }
                        totales += tjavier;
                        PartidaIndividual.TC = Convert.ToDouble(dr["TC"]);
                        PartidaIndividual.MONEDA = dr["MONEDA"].ToString();
                        PartidaIndividual.FACTURA_PROVEEDOR = dr["FACTURA_PROVEEDOR"].ToString();
                        PartidaIndividual.FECHA_FACTURAP = Convert.ToDateTime(dr["FECHA_FACTURAP"]);
                        string moneda = PartidaIndividual.MONEDA;
                        double pu = PartidaIndividual.PU;
                        double tc = PartidaIndividual.TC;
                        int qty = PartidaIndividual.QTY;
                        #endregion datos
                        productos stock = new productos(PartidaIndividual.ID_PRODUCTO);
                        if (stock.PrecioAlmacen > 0)
                        {
                            int nuevaCantidad = qty + stock.STOCK;
                            if (moneda == "PMX")//convierte a dolar
                            {
                                pu = pu / tc;
                            }
                            //if (stock.PrecioAlmacen < pu)
                            //{
                            stock.PrecioAlmacen = pu;//guarda el precio
                              /*                       //}
                            if (stock.PrecioAlmacen != pu)
                            {

                                double sumaStock = stock.STOCK * stock.PrecioAlmacen;
                                double sumaIngresos = pu * qty;
                                double sumaTotal = sumaStock + sumaIngresos;
                                double nuevoCosto = sumaTotal / nuevaCantidad;

                                stock.PrecioAlmacen = nuevoCosto;
                            }*/
                        }
                        else
                        {
                            if (moneda == "PMX")
                            {
                                pu /= tc;
                            }
                            stock.PrecioAlmacen = pu;
                            stock.MONEDA = "USD";
                        }
                        stock.STOCK += PartidaIndividual.QTY;//suma al stock
                        if (PartidaIndividual.QTY <= stock.ORDENADO)//le resta las entradas a las cantidades ordenadas
                        {
                            stock.ORDENADO -= PartidaIndividual.QTY;
                        }
                        else if (stock.ORDENADO > 0)//pone en cero lo ordenado
                        {
                            stock.ORDENADO = 0;
                        }
                        stock.FECHA_FACTURA = PartidaIndividual.FECHA_FACTURAP;
                        listaproductos.Add(stock);
                        //stock.Update("Id");//actualiza los datos del producto    ///////
                        #region guarda datos de inventario costos
                        inventariocostos invCost = new inventariocostos();// LLENADO DE InventarioCostos
                        invCost.Id = PartidaIndividual.Id;
                        invCost.id_producto = PartidaIndividual.ID_PRODUCTO;
                        invCost.cantidad_actual = PartidaIndividual.QTY;
                        invCost.cantidad_oen = PartidaIndividual.QTY;
                        invCost.costoU = PartidaIndividual.PU;
                        invCost.Moneda = PartidaIndividual.MONEDA;
                        invCost.tipoCambio = PartidaIndividual.TC;
                        invCost.facturaProveedor = PartidaIndividual.FACTURA_PROVEEDOR;
                        invCost.fechaFactura = PartidaIndividual.FECHA_FACTURAP;
                        invCost.totalItem = PartidaIndividual.PU * PartidaIndividual.QTY;
                        if (PartidaIndividual.MONEDA == "USD")//convierte a pesos
                        {
                            invCost.totalItemPMX = invCost.totalItem * invCost.tipoCambio;
                        }
                        else
                        {
                            invCost.totalItemPMX = invCost.totalItem;
                        }
                        #endregion guarda
                        OENGralSeleccionada.PARTIDAS.Add(PartidaIndividual);
                        OENGralSeleccionada.ItemsInventario.Add(invCost);
                        partidaId++;
                        item++;
                    }
                    SaveFileDialog save = new SaveFileDialog();
                    save.DefaultExt = "pdf";
                    save.Filter = "PDF files|*.pdf";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        string ruta = save.FileName;
                        CreatePDF(ruta);
                        System.Diagnostics.Process.Start(ruta);
                    }
                    DialogResult result = MessageBox.Show("DESEA GENERAR LA ENTRADA CON LOS DATOS CAPTURADOS?", "REVISAR PDF ANTES DE GUARDAR", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        OENGralSeleccionada.InsertarHoja();
                        foreach(productos prod in listaproductos)
                        {
                            prod.Update("Id");
                        }
                        if (!(Directory.Exists(Application.StartupPath + @"/OEN_RESPALDO/")))
                        {
                            Directory.CreateDirectory(Application.StartupPath + @"/OEN_RESPALDO/");
                        }
                        string ruta = Application.StartupPath + @"/OEN_RESPALDO/OEN_" + textBoxOENid.Text + ".pdf"; 
                        CreatePDF(ruta);
                        resetOEN();
                    }
                }
                else
                {
                    MessageBox.Show("No hay partidas para guardar");
                }
            }
            else
            {
                MessageBox.Show("NO HAY INTERNET INTENTELO EN UN MOMENTO");//10000
            }            
        }

        private void CreatePDF(string ruta)
        {
            try
            {
                using (FileStream msReport = new FileStream(ruta, FileMode.Create))
                {
                    //step 1
                    using (Document pdfDoc = new Document(PageSize.LETTER, 22f, 10f, 180f, 40f))
                    {
                        try
                        {
                            // step 2
                            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                            ITextOEN ITE = new ITextOEN();
                            ITE.NombreDoc = "ORDEN DE ENTRADA OEN";
                            ITE.NoDoc = OENGralSeleccionada.Id.ToString();
                            ITE.CodigoDoc = OENGralSeleccionada.CODIGODEBARRAS;
                            ITE.FechaDoc = OENGralSeleccionada.FECHA;
                            ITE.NombreProveedor = ProveedorSeleccionado.NOMBRE;
                            ITE.total = totales;
                            pdfWriter.PageEvent = ITE;
                            //open the stream 
                            pdfDoc.Open();
                            #region tablas
                            //     Conv conv = new Conv();
                            PdfPTable NombreColumnas2 = new PdfPTable(5);
                            NombreColumnas2.TotalWidth = pdfDoc.PageSize.Width - 90f;
                            NombreColumnas2.LockedWidth = true;
                            NombreColumnas2.WidthPercentage = 70;
                            float[] widths2 = new float[] { 1f, 4f, 8f, 1f, 2 };
                            NombreColumnas2.SetWidths(widths2);

                            #region foreach
                            foreach (oen_indiv partida in OENGralSeleccionada.PARTIDAS)
                            {

                                productos pctos = new productos(partida.ID_PRODUCTO);


                                PdfPCell item = new PdfPCell(new Phrase(partida.ITEM.ToString(), ITextEvents.arial2));
                                item.HorizontalAlignment = 1;
                                item.VerticalAlignment = Element.ALIGN_MIDDLE;
                                //  item.BackgroundColor = BaseColor.LIGHT_GRAY;
                                NombreColumnas2.AddCell(item);

                                PdfPCell Catalogo;

                                Catalogo = new PdfPCell(new Phrase(pctos.CATALOGO, ITextEvents.arial2));
                                //  PdfPCell Catalogo = new PdfPCell(new Phrase(partida.ALIAS, ITextEvents.arial2));
                                Catalogo.FixedHeight = 22f;
                                Catalogo.HorizontalAlignment = 0;
                                Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
                                //  Catalogo.BackgroundColor = BaseColor.LIGHT_GRAY;
                                NombreColumnas2.AddCell(Catalogo);

                                PdfPCell Descrip = new PdfPCell(new Phrase(pctos.DESCRIPCION, ITextEvents.arial2));
                                Descrip.HorizontalAlignment = 0;
                                Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
                                //  Descrip.BackgroundColor = BaseColor.LIGHT_GRAY;
                                NombreColumnas2.AddCell(Descrip);

                                PdfPCell Cantidad = new PdfPCell(new Phrase(partida.QTY.ToString(), ITextEvents.arial2));
                                Cantidad.HorizontalAlignment = 1;
                                Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                                //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                                NombreColumnas2.AddCell(Cantidad);

                                PdfPCell Factura = new PdfPCell(new Phrase(partida.FACTURA_PROVEEDOR, ITextEvents.arial2));
                                Factura.HorizontalAlignment = 1;
                                Factura.VerticalAlignment = Element.ALIGN_MIDDLE;
                                //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                                NombreColumnas2.AddCell(Factura);

                            }
                            #endregion

                            PdfPCell espacio1 = new PdfPCell();
                            espacio1.FixedHeight = 8F;
                            espacio1.Colspan = 6;
                            espacio1.Border = 0;
                            NombreColumnas2.AddCell(espacio1);
                            NombreColumnas2.DefaultCell.PaddingBottom = 60;
                            NombreColumnas2.DefaultCell.PaddingTop = 60;
                            pdfDoc.Add(NombreColumnas2);
                            #endregion tablas
                            pdfDoc.Close();
                        }
                        catch (Exception )
                        {
                            MessageBox.Show("Cierre el pdf");
                        }
                        finally
                        {
                        }
                    }
                }
            }
            catch
            { MessageBox.Show("Cierre el pdf");}
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void comboBoxProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProveedorSeleccionado = (proveedores)comboBoxProveedores.SelectedItem;
            if (ProveedorSeleccionado != null)
            {
                OENGralSeleccionada.ID_PROVEEDOR = ProveedorSeleccionado.ID;//guarda el id del proveedor
            }
        }

        private void NuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOREP_GENERAL forepG = new FormOREP_GENERAL();
            forepG.buttonCopiar.Visible = true;
            forepG.ShowDialog();

            if (forepG.DialogResult == DialogResult.OK)
            {
                if (forepG.OREPseleccionada == null)
                {
                    MessageBox.Show("Usted no selecciono ninguna OREP, para seleccinar haga un clic sobre la OREP requerida");
                    return;
                }               
           

                DataTable dt = orep_indiv.PartidasOREP(forepG.OREPseleccionada.Id);//trae la lista de productos a reponer
                foreach (DataRow dr in dt.Rows)//agrege los productos
                {
                    int orepIndivID = Convert.ToInt32(dr["ID"]);
                    orep_indiv OrepIndiv = new orep_indiv(orepIndivID);
                    ProductoSeleccionado = new productos(OrepIndiv.ID_PRODUCTO);//obtiene el producto
                    AgregarPartida(OrepIndiv.ID_PRODUCTO, OrepIndiv.CANTIDAD_OREP);//agrega la partida
                    forepG.buttonCopiar.Visible = false;
                    VerDGV();//formato
                }
            }
        }

        private void textBoxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            double tc=0;
            try
            {
                tc = Convert.ToDouble(textBoxTC.Text);
            }
            catch
            {
                textBoxTC.Text = "0";
                MessageBox.Show("Escriba el Tipo de Cambio Actual");
                return;
            }

            if (tc < 15)
            {
                MessageBox.Show("Escriba el Tipo de Cambio Actual");
                return;
            }
            else if (tc > 30)
            {
                MessageBox.Show("Escriba el Tipo de Cambio Actual");
                return;
            }

            if (comboBoxMonedaCompra.Text == "")
            {
                MessageBox.Show("Seleccione la moneda correcta");
                return;
            }
            if (e.KeyValue == 13)//si presiona enter agrega el producto
            {                
                DataRow dr = ReconocerCodigo.codigoReconocido(textBoxProducto.Text);
                if (dr != null)
                {
                    int idPto=Convert.ToInt32(dr["Id"]);
                    int unidad = 0;
                    try
                    {
                        unidad = Convert.ToInt32(dr["UNIDAD"]);
                    }
                    catch
                    {
                        unidad = 1;
                    }
                    ProductoSeleccionado = new productos(idPto);
                    AgregarPartida(idPto, unidad);
                    VerDGV();
                    textBoxProducto.Text = "";
                }
                else
                {
                    BuscarP();
                }
            }
        }

        private void textBoxProducto_Enter(object sender, EventArgs e)
        {
            
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double tc = 0;
            try
            {
                tc = Convert.ToDouble(textBoxTC.Text);
            }
            catch
            {
                MessageBox.Show("Escriba solo numeros");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {         

            System.Diagnostics.Process.Start("http://www.sat.gob.mx/informacion_fiscal/tablas_indicadores/Paginas/tipo_cambio.aspx/");

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)//registra nuevo proveedor
        {
            FormAltaProveedores Proveedor = new FormAltaProveedores();
            Proveedor.cmbListaProveedores.Visible = false;
            Proveedor.label16.Visible = false;
            Proveedor.btnEliminar.Visible = false;
            Proveedor.btnGuardar.Visible = false;
            Proveedor.ShowDialog();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)//edita un proveedor
        {
            FormAltaProveedores Proveedor2 = new FormAltaProveedores();
            Proveedor2.cmbListaProveedores.DataSource = proveedores.GetExisting();
            Proveedor2.cmbListaProveedores.SelectedIndex = -1;
            Proveedor2.Reset();
            Proveedor2.btnAlta.Visible = false;
            Proveedor2.Show();
        }
    }
}
