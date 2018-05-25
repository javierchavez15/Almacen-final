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
    public partial class FormSALIDAS : Form
    {
        public FormSALIDAS()
        {
            InitializeComponent();
        }
        private int idosa = 0;
        public osa_gral OSAGralSeleccionada;
        productos ProductoSeleccionado2;
        clientes ClienteSeleccionado;
        usuario EmpleadoSeleccionado;
        polizasdb polizaseleccionada;
        DataTable PartidasOSA = osa_indiv.PartidasOSA().Clone();
        proyectos proyectoSeleccionado;
        public double sumatoria = 0;
        int partidaId;
        DataBase bdMysql;
        public int idproyectos = 0;

        public void estatus(int ok)
        {
            idosa = ok;
        }

        private void FormSALIDAS_Load(object sender, EventArgs e)
        {
            idproyectos = 0;
            if (OSAGralSeleccionada == null)
            {
                OENGRALnextId();
            }
            //comboBoxClientes.DataSource = clientes.GetExistentes();
            comboVendedor.DataSource = usuario.GetExistentes();
            comboBoxClientes.SelectedIndex = -1;
            comboVendedor.SelectedIndex = -1;
            EmpleadoSeleccionado = (usuario)comboVendedor.SelectedItem;
            DataColumn workCol = PartidasOSA.Columns.Add("Catálogo", typeof(string));
            workCol.AllowDBNull = false;
            workCol.Unique = false;
            DataColumn Descripcion = PartidasOSA.Columns.Add("Descripción", typeof(string));
            Descripcion.AllowDBNull = false;
            Descripcion.Unique = false;
            PartidaNextId();
            if(idosa > 0)
            {
                polizaseleccionada = new polizasdb(OSAGralSeleccionada.idpoliza);
                ClienteSeleccionado = new clientes(OSAGralSeleccionada.ID_CLIENTE);
                comboBoxClientes.Text = ClienteSeleccionado.RAZON_SOCIAL;
                proyectoSeleccionado = new proyectos(OSAGralSeleccionada.PROYECTO_ID);
                comboBoxProyecto.Text = proyectoSeleccionado.NOMBRE;
                textBoxOENid.Text = OSAGralSeleccionada.Id.ToString();
                FACTURA.Text = OSAGralSeleccionada.FACTURA;
                REMISION.Text = OSAGralSeleccionada.REMISION;
                textBoxTipoCambio.Text = OSAGralSeleccionada.TC.ToString();
                COTIZACION.Text = OSAGralSeleccionada.COTIZACION.ToString();
                buttonCancelar.Visible = false;
                buttonIngresarHoja.Visible = false;
                buttonIngresar.Visible = false;
                buttonNewProject.Visible = false;
                label2.Visible = false;
                textBoxCantidad.Visible = false;
                label1.Visible = false;
                textBoxProducto.Visible = false;
                button1.Visible = true;
            }
        }
        
        private void resetOSA()//reset
        {
            OENGRALnextId();
            PartidaNextId();
            FACTURA.Text = "";            
            comboBoxClientes.SelectedIndex = -1;
            comboVendedor.SelectedIndex = -1;
            //REMISION.Text = "";
            COTIZACION.Text = "";
            textBoxProducto.Text = "";
            textBoxCantidad.Text = "1";
            PartidasOSA.Clear();
            OSAGralSeleccionada = null;
            ProductoSeleccionado2 = null;
            ClienteSeleccionado = null;
            EmpleadoSeleccionado = null;
        }

        private void OENGRALnextId()//siguiente id
        {
            if (idosa == 0)
            {
                OSAGralSeleccionada = new osa_gral();
                OSAGralSeleccionada.Id = OSAGralSeleccionada.NextID();
                textBoxOENid.Text = OSAGralSeleccionada.Id.ToString();
            }
        }

        private void PartidaNextId()//siguiente id
        {
            osa_indiv PartidaId = new osa_indiv();
            partidaId = PartidaId.NextID();
        }

        private void VerDGV()
        {
            dataGridView2.DataSource = PartidasOSA;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Width = 50;
            dataGridView2.Columns[2].HeaderText = "ITEM";
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Width = 50;
            dataGridView2.Columns[4].HeaderText = "CANT.";
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[8].ReadOnly = true;
            dataGridView2.Columns[8].Width = 300;
            dataGridView2.Columns[8].DisplayIndex = 3;
            dataGridView2.Columns[8].HeaderText = "CATALOGO";
            dataGridView2.Columns[9].ReadOnly = true;
            dataGridView2.Columns[9].Width = 600;
            dataGridView2.Columns[9].DisplayIndex = 4;
            dataGridView2.Columns[9].HeaderText = "DESCRIPCION";
            dataGridView2.Columns["VENTA"].Visible = false;
        }

        private void AgregarPartida(int qty)
        {
            DataRow row = PartidasOSA.NewRow();
            row["ITEM2"] = PartidasOSA.Rows.Count + 1;
            row["ID_PRODUCTO2"] = ProductoSeleccionado2.Id;
            row["QTY2"] = qty;
            row["VENTA"] = 0;
            row["Catálogo"] = ProductoSeleccionado2.CATALOGO;
            row["Descripción"] = ProductoSeleccionado2.DESCRIPCION;
           // row["Tipo_Cambio"]=    
            PartidasOSA.Rows.Add(row);
        }     

        private void BuscarP()
        {
            FormBuscarProducto FBP = new FormBuscarProducto();
            FBP.textBoxCatalogo.Text = textBoxProducto.Text;
            FBP.VisualizarDGV1();
            FBP.ShowDialog();
            if (FBP.DialogResult == DialogResult.OK)
            {
                ProductoSeleccionado2 = FBP.ProductoSelecto;
                if(ProductoSeleccionado2==null)
                {
                    MessageBox.Show("Elige un producto dando click");
                    return;
                }
                if (ProductoSeleccionado2.PrecioAlmacen > 0)
                {
                    AgregarPartida(Convert.ToInt32(textBoxCantidad.Text));
                    VerDGV();
                }
                else
                {
                    MessageBox.Show("Favor de asignar precio al " + ProductoSeleccionado2.CATALOGO + " antes de Registrar su salida");
                    AbrirFormProducto(ProductoSeleccionado2);
                }
            }
        }

        private void AbrirFormProducto(productos productoSeleccionado)
        {            

            FormProductoSpec fps = new FormProductoSpec();
            fps.productoSeleccionadoi = productoSeleccionado;
            fps.ShowDialog();
            if (fps.DialogResult == DialogResult.OK)
            {
                AgregarPartida(Convert.ToInt32(textBoxCantidad.Text));
                VerDGV();
                //  textBoxCatalogo.Text = "";
               // textBoxCatalogo.Focus();
                //   dataGridView1.DataSource = null;
                //   VisualizarDGV();
            }
        }

        private void comboBoxProveedores_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (OSAGralSeleccionada == null)
            {
                OENGRALnextId();
            }
            if (comboBoxClientes.SelectedIndex != -1)
            {
                ClienteSeleccionado = (clientes)comboBoxClientes.SelectedItem;
                if (ClienteSeleccionado != null)
                {
                    OSAGralSeleccionada.ID_CLIENTE = ClienteSeleccionado.ID;
                    if(checkBoxPorProyecto.Checked==false)
                    {
                        List<usuario>  listavendedor=usuario.delcliente(ClienteSeleccionado.ID_VENDEDOR);
                        if(listavendedor.Count>0)
                            comboVendedor.Text = listavendedor[0].Nombre;
                    }
                }
            }           
        }

        private void buttonIngresar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBoxTipoCambio.Text) > 10 && Convert.ToDouble(textBoxTipoCambio.Text) < 30)
                { }
                else
                { MessageBox.Show("Agrege un TC valido"); return; }
            }
            catch
            { MessageBox.Show("Agrege un TC valido"); return; }
            if (textBoxProducto.Text == "")            
            {
                MessageBox.Show("Escriba un criterio de búsqueda");
                return;
            }
            int idP = 0;
            DataTable dt;
            try
            {
                dt = productos.ListaProductos(textBoxProducto.Text, "",false);
            }
            catch
            {
                dt = new DataTable();
            }
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    idP = Convert.ToInt32(dr["Id"]);//guarda el id del producto
                    ProductoSeleccionado2 = new productos(idP);//trae el producto
                }
                if (ProductoSeleccionado2.PrecioAlmacen > 0)
                {
                    AgregarPartida(Convert.ToInt32(textBoxCantidad.Text));//agrga el producto
                    VerDGV();//da formato
                }
                else
                {
                    MessageBox.Show("Favor de asignar precio al " + ProductoSeleccionado2.CATALOGO + " antes de Registrar su salida");
                    AbrirFormProducto(ProductoSeleccionado2);//guarda el precio
                }
            }
            else
            {
                BuscarP();//busca un producto y lo agrega
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void buttonIngresarHoja_Click_1(object sender, EventArgs e)
        {
            #region validaciones
            if (FACTURA.Text!="")
            {
                try
                {
                    Convert.ToInt32(FACTURA.Text);
                }
                catch
                {
                    MessageBox.Show("Solo numeros en la factura");
                    return;
                }
            }
            if (checkBoxPorProyecto.Checked == true)
            {
                if(proyectoSeleccionado==null)
                {
                    MessageBox.Show("Falta elegir el proyecto");
                    return;
                }
            }
            else
            {
                if(FACTURA.Text=="" && txtpo.Text=="" && COTIZACION.Text=="" && REMISION.Text == "")
                {
                    MessageBox.Show("Es necesario capturar un comprobante de salida");
                    return;
                }
            }
            if(FACTURA.Text!="" && txtpo.Text=="")
            {
                MessageBox.Show("Falta capturar la PO de la factura");
                return;
            }
            if (comboBoxClientes.SelectedIndex == -1 || comboVendedor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione Cliente y Vendedor");
                return;
            }
            #endregion validaciones
            List<productos> listaproductos = new List<productos>();
            List<inventariocostos> listainventarios = new List<inventariocostos>();
            OSAGralSeleccionada.PARTIDAS2.Clear();
            if (AccesoInternet())
            {
                DataTable sal;
                sumatoria = 0;
                if (dataGridView2.RowCount > 0)
                {
                    for (int jj = 0; jj < dataGridView2.RowCount - 1; jj++)
                    {
                        string a = dataGridView2.Rows[jj].Cells[8].Value.ToString();
                        sal = productos.sumas(dataGridView2.Rows[jj].Cells[8].Value.ToString());
                        string w = dataGridView2.Rows[jj].Cells[4].Value.ToString();
                        sumatoria += Convert.ToDouble(sal.Rows[0][0]) * Convert.ToInt32(dataGridView2.Rows[jj].Cells[4].Value);
                    }
                }
                try
                {
                    /*
                    OSA_GRAL OrdenSalida = new OSA_GRAL();
                    OrdenSalida.Id = OrdenSalida.NextID();
                    OrdenSalida.ID_CLIENTE = ClienteSeleccionado.ID;
                    OrdenSalida.ID_VENDEDOR = EmpleadoSeleccionado.ID;
                    OrdenSalida.FACTURA = FACTURA.Text;
                    OrdenSalida.CODIGODEBARRAS = OrdenSalida.Id.ToString();
                    OrdenSalida.FECHA = DateTime.Now.Date;
                */
                    #region datos de salida general
                    if (checkBoxPorProyecto.Checked == true)
                    {
                        OSAGralSeleccionada.PROYECTO_ID = proyectoSeleccionado.ID;
                    }
                    OSAGralSeleccionada.ID_CLIENTE = ClienteSeleccionado.ID;
                    OSAGralSeleccionada.ID_VENDEDOR = EmpleadoSeleccionado.ID;
                    OSAGralSeleccionada.FACTURA = FACTURA.Text;
                    OSAGralSeleccionada.TC = Convert.ToDouble(textBoxTipoCambio.Text);
                    OSAGralSeleccionada.CODIGODEBARRAS = OSAGralSeleccionada.Id.ToString();
                    OSAGralSeleccionada.FECHA = DateTime.Now.Date;
                    OSAGralSeleccionada.REMISION = REMISION.Text;
                    OSAGralSeleccionada.COTIZACION = COTIZACION.Text;
                    #endregion salida
                    if (PartidasOSA.Rows.Count > 0)
                    {
                        int item = 1;
                        #region validacion de productos
                        foreach (DataRow dr in PartidasOSA.Rows)
                        {
                            int idproducto = Convert.ToInt32(dr["ID_PRODUCTO2"]);
                            productos stock = new productos(idproducto);
                            if (stock.PrecioAlmacen == 0)
                            {
                                MessageBox.Show("El producto " + idproducto + " " + stock.DESCRIPCION + " No tiene PRECIO ACTUAL, favor de ingresarlo");
                                return;
                            }
                            osa_indiv PartidaIndividual = new osa_indiv();
                            PartidaIndividual.Id = partidaId;
                            PartidaIndividual.ID_OSAGRAL = OSAGralSeleccionada.Id;
                            PartidaIndividual.ITEM2 = item;
                            PartidaIndividual.ID_PRODUCTO2 = idproducto;
                            PartidaIndividual.QTY2 = Convert.ToInt32(dr["QTY2"]);
                            PartidaIndividual.VENTA = Convert.ToInt32(dr["VENTA"]);
                            if (stock.PrecioAlmacen > 0)
                            {
                                PartidaIndividual.precioAlmacen = stock.PrecioAlmacen;
                                PartidaIndividual.totalItem = stock.PrecioAlmacen * PartidaIndividual.QTY2;
                            }
                            stock.STOCK -= PartidaIndividual.QTY2;
                            if (stock.STOCK < 0)
                            {
                                MessageBox.Show("No hay suficientes " + dr["Catálogo"].ToString() + " en Stock");
                                return;
                            }
                        }
                        #endregion validacion
                        foreach (DataRow dr in PartidasOSA.Rows)
                        {
                            int idproducto = Convert.ToInt32(dr["ID_PRODUCTO2"]);
                            productos stock = new productos(idproducto);
                            /* if (stock.PrecioAlmacen == 0)
                             {
                                 MessageBox.Show("El producto " + idproducto + " " + stock.DESCRIPCION + " No tiene PRECIO ACTUAL, favor de ingresarlo");
                                 return;
                             }*/
                            #region guardar individual
                            osa_indiv PartidaIndividual = new osa_indiv();
                            PartidaIndividual.Id = partidaId;
                            PartidaIndividual.ID_OSAGRAL = OSAGralSeleccionada.Id;
                            PartidaIndividual.ITEM2 = item;
                            PartidaIndividual.ID_PRODUCTO2 = idproducto;
                            PartidaIndividual.QTY2 = Convert.ToInt32(dr["QTY2"]);
                            PartidaIndividual.VENTA = Convert.ToInt32(dr["VENTA"]);
                            if (stock.PrecioAlmacen > 0)
                            {
                                PartidaIndividual.precioAlmacen = stock.PrecioAlmacen;
                                PartidaIndividual.totalItem = stock.PrecioAlmacen * PartidaIndividual.QTY2;
                            }
                            #endregion individual
                            stock.STOCK -= PartidaIndividual.QTY2;//resta al stock
                                                                  /*if (stock.STOCK < 0)
                                                                  {
                                                                      MessageBox.Show("No hay suficientes " + dr["Catálogo"].ToString() + " en Stock");
                                                                      return;
                                                                  }*/
                            listaproductos.Add(stock);
                            //stock.Update("Id");//actualiza datos del producto
                            MessageBox.Show(stock.CATALOGO + " nuevo stock " + stock.STOCK);
                            #region LOOP SALIDAS INVETNARIOCOSTOS
                            inventariocostos invCost = new inventariocostos(PartidaIndividual.ID_PRODUCTO2, "Salida");
                            if (invCost.Id > 0)
                            {
                                if (PartidaIndividual.QTY2 <= invCost.cantidad_actual)//si la cantidad de salida es menor o igual a la cantidad de inventario costos
                                {
                                    invCost.cantidad_actual -= PartidaIndividual.QTY2;//le resta la cantidad de salida a la de inventario costos
                                    listainventarios.Add(invCost);
                                    //invCost.Update("Id");//actualiza
                                }
                                else//si la cantidad de salida es mayor
                                {
                                    int Qty = PartidaIndividual.QTY2;
                                    Qty -= invCost.cantidad_actual;//a la cantidad de salida le resta la de inventarios
                                    invCost.cantidad_actual = 0;
                                    listainventarios.Add(invCost);
                                    //invCost.Update("Id");//actaliza
                                    while (Qty > 0)
                                    {
                                        inventariocostos invCost2 = new inventariocostos(PartidaIndividual.ID_PRODUCTO2, "Salida2");
                                        if (invCost2.Id > 0)
                                        {
                                            if (Qty <= invCost2.cantidad_actual)//si la cantidad de salida es menor o igual a la cantidad de inventario costos
                                            {
                                                invCost2.cantidad_actual -= Qty;//le resta la cantidad de salida a la de inventario costos
                                                listainventarios.Add(invCost2);
                                                //invCost2.Update("Id");
                                                Qty = 0;
                                            }
                                            else// si la cantidad de salida es mayor
                                            {
                                                Qty -= invCost2.cantidad_actual;
                                                invCost2.cantidad_actual = 0;
                                                listainventarios.Add(invCost2);
                                                //invCost2.Update("Id");
                                            }
                                        }
                                        else
                                        {
                                            // MessageBox.Show("No hay entradas registradas para esta salida");
                                            Qty = 0;
                                        }
                                    }
                                }
                            }
                            /* else
                             {
                                 // MessageBox.Show("Este producto no tiene Facturas de compra, Favor de ingresarlas antes de Sacar el Producto");
                             }*/
                            #endregion LOOP SALIDAS INVETNARIOCOSTOS
                            OSAGralSeleccionada.PARTIDAS2.Add(PartidaIndividual);//agrga la individual
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
                        DialogResult result = MessageBox.Show("DESEA GENERAR LA SALIDA CON LOS DATOS CAPTURADOS?", "REVISAR PDF ANTES DE GUARDAR", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                        else if (result == DialogResult.Yes)
                        {
                            OSAGralSeleccionada.InsertarHoja();
                            string titulo = "OSA:"+textBoxOENid.Text+ "\n\n";
                            foreach (productos prod in listaproductos)
                            {
                                titulo+= prod.CATALOGO+"="+prod.DESCRIPCION+ ".\n\n";
                                prod.Update("Id");
                            }
                            foreach (inventariocostos inve in listainventarios)
                            {
                                inve.Update("Id");
                            }
                            if (!(Directory.Exists(Application.StartupPath + @"/OSA_RESPALDO/")))
                            {
                                Directory.CreateDirectory(Application.StartupPath + @"/OSA_RESPALDO/");
                            }
                            string ruta = Application.StartupPath + @"/OSA_RESPALDO/OSA_" + textBoxOENid.Text + ".pdf";
                            CreatePDF(ruta);
                            polizasdb crearpoliza = new polizasdb();
                            crearpoliza.Insertarpoliza(this,titulo);//////////////////////////////////////poliza

                            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                            
                             sb.Server = "secure199.inmotionhosting.com";
                             sb.UserID = "abdsto5_felipe";
                             sb.Password = "1945Inadescobi";
                             sb.Database = "abdsto5_cotizaciones";
                          

                            //PRUEBAS EN LOCALHOST
                            /*
                            sb.Server = "localhost";
                            sb.UserID = "felipe";
                            sb.Password = "1945Inadescobi";
                            sb.Database = "ejemplo";
                            */
                            bdMysql = new DataBase();
                            bdMysql.DataBaseProvider = TypeOfDataBase.MySqlServer;
                            bdMysql.ConnectionString = sb.ToString();
                            //   bdMysql.ConnectionString = "Server = localhost; Database = descobi; Uid = felipe; Pwd = 1945Inadescobi";
                            bdMysql.CreateConnection();
                            DbObject.DefaultDataBaseObject = bdMysql;

                            resetOSA();//reset
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay partidas para guardar");
                    }
                }
                catch
                {
                    MessageBox.Show("Ingrese los datos correctos");
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
                    using (Document pdfDoc = new Document(PageSize.LETTER, 22f, 10f, 180f, 40f))
                    {
                        try
                        {
                            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                            ITextEvents ITE = new ITextEvents();
                            ITE.NombreDoc = "ORDEN DE SALIDA OSA";
                            ITE.NoDoc = OSAGralSeleccionada.Id.ToString();
                            ITE.CodigoDoc = OSAGralSeleccionada.CODIGODEBARRAS;
                            ITE.FechaDoc = OSAGralSeleccionada.FECHA;
                            ITE.NoFactura = OSAGralSeleccionada.FACTURA;
                            ITE.NoRemision = OSAGralSeleccionada.REMISION;
                            ITE.NoCotizacion = OSAGralSeleccionada.COTIZACION.ToString();
                            ITE.NombreCte = ClienteSeleccionado.RAZON_SOCIAL;
                            ITE.NombreVendedor = EmpleadoSeleccionado.Nombre;
                            ITE.NombreContacto = CONTACTO.Text;
                            ITE.total = sumatoria.ToString("#,##0.00");
                            if (proyectoSeleccionado != null)
                            {
                                ITE.NombreProyecto = proyectoSeleccionado.NOMBRE;
                            }
                            pdfWriter.PageEvent = ITE;
                            pdfDoc.Open();
                            #region tablas
                            PdfPTable NombreColumnas2 = new PdfPTable(4);
                            NombreColumnas2.TotalWidth = pdfDoc.PageSize.Width - 90f;
                            NombreColumnas2.LockedWidth = true;
                            NombreColumnas2.WidthPercentage = 70;
                            float[] widths2 = new float[] { 1f, 4f, 8f, 1f };
                            NombreColumnas2.SetWidths(widths2);
                            #region foreach
                            foreach (osa_indiv partida in OSAGralSeleccionada.PARTIDAS2)
                            {
                                productos pctos = new productos(partida.ID_PRODUCTO2);
                                PdfPCell item = new PdfPCell(new Phrase(partida.ITEM2.ToString(), ITextEvents.arial2));
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
                                PdfPCell Cantidad = new PdfPCell(new Phrase(partida.QTY2.ToString(), ITextEvents.arial2));
                                Cantidad.HorizontalAlignment = 1;
                                Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                                //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                                NombreColumnas2.AddCell(Cantidad);
                            }
                            #endregion
                            PdfPCell espacio1 = new PdfPCell();
                            espacio1.FixedHeight = 8F;
                            espacio1.Colspan = 6;
                            espacio1.Border = 0;
                            NombreColumnas2.AddCell(espacio1);
                            /*PdfPCell espacio2 = new PdfPCell(new Phrase("Total USD: "+sumatoria.ToString("#,##0.00"), ITextEvents.arial2));
                            espacio2.FixedHeight = 8F;
                            espacio2.Colspan = 6;
                            espacio2.Border = 0;
                            NombreColumnas2.AddCell(espacio2);*/
                            NombreColumnas2.DefaultCell.PaddingBottom = 60;
                            NombreColumnas2.DefaultCell.PaddingTop = 60;
                            pdfDoc.Add(NombreColumnas2);
                            #endregion tablas   
                            pdfDoc.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Cierre el pdf");
                        }
                        finally
                        { }
                    }
                }
            }
            catch { MessageBox.Show("Cierre el pdf"); }
        }

        private void EMPLEADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboVendedor.SelectedIndex != -1)
            {
                EmpleadoSeleccionado = (usuario)comboVendedor.SelectedItem;
                if (EmpleadoSeleccionado != null)
                {
                    OSAGralSeleccionada.ID_VENDEDOR = EmpleadoSeleccionado.ID;
                }
            }
        }

        private void textBoxProducto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(Convert.ToDouble(textBoxTipoCambio.Text)>10 && Convert.ToDouble(textBoxTipoCambio.Text) <30)
                {                }
                else
                { MessageBox.Show("Agrege un TC valido");return; }
            }
            catch
            { MessageBox.Show("Agrege un TC valido"); return; }
            if (e.KeyCode == Keys.Enter)
            {
                DataRow dr = ReconocerCodigo.codigoReconocido(textBoxProducto.Text);
                if (dr != null)
                {
                    //   MessageBox.Show("no Es nulo");
                    int idPto = Convert.ToInt32(dr["Id"]);
                    int unidad = 0;
                    try
                    {
                        unidad = Convert.ToInt32(dr["UNIDAD"]);
                    }
                    catch
                    {
                        unidad = 1;
                    }                    
                    ProductoSeleccionado2 = new productos(idPto);
                    AgregarPartida(unidad);
                    VerDGV();

                    textBoxProducto.Text = "";
                }
                else
                {
                    buttonIngresar.PerformClick();
                }               
            }
        }

        private void textBoxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonIngresar.PerformClick();
            }
        }

        private void herramientasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buttonAltaEditar_Click(object sender, EventArgs e)
        {
            FormAltaCliente fac = new FormAltaCliente();
            fac.ShowDialog();
            if (fac.DialogResult == DialogResult.OK)
            {
                comboBoxClientes.DataSource = clientes.GetExistentes();
                
            }
        }

        private void checkBoxPorProyecto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPorProyecto.Checked== true)
            {
                comboBoxProyecto.Enabled = true;
                //buttonNewProject.Enabled = true;               
                List<proyectos> lista2 = proyectos.GetExistentes();
                comboBoxProyecto.DataSource = lista2;
                comboBox1.Items.Clear();
                foreach (proyectos c in lista2)
                {
                    comboBox1.Items.Add(c.ID);
                }
                comboBox1.SelectedIndex = -1;
                comboBoxProyecto.SelectedIndex = -1;
                comboBoxClientes.Enabled = false;
                comboVendedor.Enabled = false;
                CONTACTO.Enabled = false;
                FACTURA.Enabled = false;
                REMISION.Enabled = false;
                txtpo.Enabled = false;
                COTIZACION.Enabled = false;
                comboBox1.Enabled = true;
            }
            else
            {
                comboBoxProyecto.Enabled = false;
                comboBoxProyecto.SelectedIndex = -1;
                buttonNewProject.Enabled = false;
                textBoxProyectoId.Text = "";
                proyectoSeleccionado = null;
                comboBoxClientes.Enabled = true;
                comboVendedor.Enabled = true;
                CONTACTO.Enabled = true;
                FACTURA.Enabled = true;
                REMISION.Enabled = true;
                txtpo.Enabled = true;
                COTIZACION.Enabled = true;
                comboBox1.Enabled = false;
            }
        }

        int i = 0;
        private void comboBoxProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBoxProyecto.SelectedIndex != -1 && i>0)
            {
                proyectoSeleccionado = (proyectos)comboBoxProyecto.SelectedItem;
                textBoxProyectoId.Text = proyectoSeleccionado.ID.ToString();
                clientes c = new clientes(proyectoSeleccionado.ID_CLIENTE);
                comboBoxClientes.SelectedIndex = comboBoxClientes.FindStringExact(c.RAZON_SOCIAL);
                comboVendedor.SelectedIndex = comboVendedor.FindStringExact(proyectoSeleccionado.GERENTE);
                idproyectos = proyectoSeleccionado.ID;
                comboBoxClientes.Text = c.RAZON_SOCIAL;
                comboBox1.Text = proyectoSeleccionado.ID.ToString();
            }
            ++i;
        }

        private void buttonNewProject_Click(object sender, EventArgs e)
        {
            FormAltaProyecto a = new FormAltaProyecto();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK && a.proyectoSelected != null)
            {                
                comboBoxProyecto.DataSource = proyectos.GetExistentes();
                comboBoxProyecto.SelectedIndex = comboBoxProyecto.FindStringExact(a.proyectoSelected.NOMBRE);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelProyecto_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{Convert.ToDouble(textBoxTipoCambio.Text);}
            catch { MessageBox.Show("Falta tipo de cambio correcto");return; }
            OSAGralSeleccionada.ID_CLIENTE = ClienteSeleccionado.ID;
            if (checkBoxPorProyecto.Checked == true)
                OSAGralSeleccionada.PROYECTO_ID = proyectoSeleccionado.ID;
            else
                OSAGralSeleccionada.PROYECTO_ID = 0;
            OSAGralSeleccionada.FACTURA = FACTURA.Text;
            OSAGralSeleccionada.REMISION = REMISION.Text;
            OSAGralSeleccionada.COTIZACION = COTIZACION.Text;
            OSAGralSeleccionada.TC = Convert.ToDouble(textBoxTipoCambio.Text);
            OSAGralSeleccionada.Update("Id");

            if(FACTURA.Text!="")
                polizaseleccionada.factura = FACTURA.Text;
            if(REMISION.Text!="")
                polizaseleccionada.remision= REMISION.Text;
            if(txtpo.Text!="")
                polizaseleccionada.pocliente = txtpo.Text;
            polizaseleccionada.tipocambio= Convert.ToDouble(textBoxTipoCambio.Text);
            polizaseleccionada.idcliente = ClienteSeleccionado.ID;
            polizaseleccionada.subdestino = ClienteSeleccionado.RAZON_SOCIAL;
            if (checkBoxPorProyecto.Checked == true)
            { polizaseleccionada.destino = "PREFACTURA PROYECTOS";
                polizaseleccionada.idproyecto = proyectoSeleccionado.ID;
            }
            else
            { polizaseleccionada.destino = "PREFACTURA PRODUCTOS"; polizaseleccionada.idproyecto = 0; }
            if (comboVendedor.Text == "Felipe Ortiz" || comboVendedor.Text == "Oficina" || comboVendedor.Text == "Antonio Viera") 
                polizaseleccionada.idnegocio = 1;
            else if (comboVendedor.Text == "Jesus ortiz")
                polizaseleccionada.idnegocio = 19;
            else if (comboVendedor.Text == "Samuel" || comboVendedor.Text == "Taller")
                polizaseleccionada.idnegocio = 18;
            else if(comboVendedor.Text != "")
                polizaseleccionada.idnegocio = 3;
            polizaseleccionada.Update("folio");
            this.Close();
        }

        //int u = 1;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 )
            {
                try
                {
                    Convert.ToInt32(comboBox1.Text);
                    proyectoSeleccionado = new proyectos(Convert.ToInt32(comboBox1.Text));
                    textBoxProyectoId.Text = proyectoSeleccionado.ID.ToString();
                    clientes c = new clientes(proyectoSeleccionado.ID_CLIENTE);
                    comboBoxClientes.SelectedIndex = comboBoxClientes.FindStringExact(c.RAZON_SOCIAL);
                    comboVendedor.SelectedIndex = comboVendedor.FindStringExact(proyectoSeleccionado.GERENTE);
                    idproyectos = proyectoSeleccionado.ID;
                    comboBoxClientes.Text = c.RAZON_SOCIAL;
                    comboBoxProyecto.Text = proyectoSeleccionado.NOMBRE+" "+ proyectoSeleccionado.ID.ToString();
                }
                catch { }
            }
           // ++u;
        }

        private void buttonArmadoPartes_Click(object sender, EventArgs e)
        {
            FormBotoneria ArmadoPartes = new FormBotoneria();
            ArmadoPartes.ShowDialog();
        }
    }
}
