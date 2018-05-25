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

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;




namespace Form1
{
    public partial class FormENTRADAS : Form
    {
        public FormENTRADAS()
        {
            InitializeComponent();
        }
        clientes ClienteSeleccionado;
        usuario EmpleadoSeleccionado;
        oen_gral OENGralSeleccionada;
        productos ProductoSeleccionado;
        proveedores ProveedorSeleccionado;
        DataTable PartidasOEN = oen_indiv.PartidasOEN().Clone();
        orep_gral OREPGralSeleccionada;
        int partidaId;
        proyectos proyectoSeleccionado;
        DataTable tabladocumentos;
       // DataTable documentosadjuntos = documentos_almacen.documentosvacios();
        DataTable docfactura;
        DataTable docpedimento;


        private void Download(string filePath, string fileName)
        {
            string ftpServerIP;
            string ftpUserID;
            string ftpPassword;
            ftpServerIP = "ftp.abdstock.com";
            ftpUserID = "abdsto5";
            ftpPassword = "1945*abdstock";
            FtpWebRequest reqFTP;
            try
            {
                //filePath = <<La direcci�n / path completa donde el archivo sera creado.>>, 
                //fileName = <<Nombre del archivo a ser creado(Necesario el nombre del archovo en el FTP server).>>
                FileStream outputStream;
                try
                {
                    outputStream = new FileStream(filePath + fileName, FileMode.Create);
                }
                catch
                { return; }

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/documentos/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                //MessageBox.Show("Archivo: n" + fileName + "Bajado con �xito!...", "Atenci�n!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void FormENTRADAS_Load(object sender, EventArgs e)
        {
            //FolderBrowserDialog fldDlg = new FolderBrowserDialog();
            //Name = "C:\\Descoa\\596-Dry Ice Container.pdf"
           // Download("C:\\Descoa\\", "596-Dry Ice Container.pdf");

            // SubirArchivoAFTP("ftp://ftp.abdstock.com", "abdsto5", "1945*abdstock", @"C:\Archivo.txt", "/respaldos", "respaldos.txt");
            // UploadFTP(@"C:\Archivo.txt", "ftp://ftp.abdstock.com/respaldos", "abdsto5", "1945Inadescobi");
            item = 1;
            tabladocumentos = documentos_almacen.documentosvacios();
            docfactura = tabladocumentos;
            docpedimento = tabladocumentos;
            if (OENGralSeleccionada == null)
            {
                OENGRALnextId();
            }
            comboVendedor.DataSource = usuario.GetExistentes();
            comboBoxClientes.SelectedIndex = -1;
            comboVendedor.SelectedIndex = -1;
            comboBoxProveedores.DataSource = proveedores.GetExisting();
            DataColumn workCol = PartidasOEN.Columns.Add("Catálogo", typeof(string));
            workCol.AllowDBNull = false;
            workCol.Unique = false;
            DataColumn Descripcion = PartidasOEN.Columns.Add("Descripción", typeof(string));
            Descripcion.AllowDBNull = false;
            Descripcion.Unique = false;
            PartidaNextId();
            ClienteSeleccionado = null;
            EmpleadoSeleccionado = null;
            OREPGralSeleccionada = null;
        }

        private bool SubirArchivoAFTP(string server, string user, string pass, string origen, string rutadestino, string nombredestino)
        {
            try
            {
                string rutaser= "ftp://ftp.abdstock.com/documentos/"+ nombredestino;
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(rutaser);
                //FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(server + rutadestino + "/" + nombredestino);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(user, pass);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;
                FileStream stream = File.OpenRead(origen);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Flush();
                reqStream.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*public void UploadFTP(string FilePath, string RemotePath, string Login, string Password)
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                string url = "ftp://ftp.abdstock.com/respaldos/Archivo.txt"; //Path.Combine(RemotePath, Path.GetFileName(FilePath));

                // Creo el objeto ftp
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(url);

                // Fijo las credenciales, usuario y contraseña
                ftp.Credentials = new NetworkCredential(Login, Password);

                // Le digo que no mantenga la conexión activa al terminar.
                ftp.KeepAlive = false;

                // Indicamos que la operación es subir un archivo...
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                // … en modo binario … (podria ser como ASCII)
                ftp.UseBinary = true;

                // Indicamos la longitud total de lo que vamos a enviar.
                ftp.ContentLength = fs.Length;

                // Desactivo cualquier posible proxy http.
                // Ojo pues de saltar este paso podría usar 
                // un proxy configurado en iexplorer
                ftp.Proxy = null;

                // Pongo el stream al inicio
                fs.Position = 0;

                // Configuro el buffer a 2 KBytes
                int buffLength = 2048;
                byte[] buff = new byte[buffLength];

                int contentLen;

                // obtener el stream del socket sobre el que se va a escribir.
                using (Stream strm = ftp.GetRequestStream())
                {
                    // Leer del buffer 2kb cada vez
                    contentLen = fs.Read(buff, 0, buffLength);

                    // mientras haya datos en el buffer ….
                    while (contentLen != 0)
                    {
                        // escribir en el stream de conexión
                        //el contenido del stream del fichero
                        strm.Write(buff, 0, contentLen);
                        contentLen = fs.Read(buff, 0, buffLength);
                    }
                }
            }
        }*/

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
            dataGridView2.Columns[6].ReadOnly = false;
            dataGridView2.Columns[7].Width = 70;
            dataGridView2.Columns[7].ReadOnly = false;
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
            dataGridView2.Columns["COMPRA"].Visible = false;
            dataGridView2.Columns["VENTA"].Visible = false;
        }

        private void AgregarPartida(int idProducto, int qty)
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
                dt = productos.ListaProductos(textBoxProducto.Text, "",false);//busca el producto
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
                        catch (Exception)
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
            { MessageBox.Show("Cierre el pdf"); }
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

        private void ingresarOREPToolStripMenuItem_Click(object sender, EventArgs e)
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
                OREPGralSeleccionada = forepG.OREPseleccionada;

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
            double tc = 0;
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

        private void textBoxProducto_TextChanged(object sender, EventArgs e)
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

        private void label8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sat.gob.mx/informacion_fiscal/tablas_indicadores/Paginas/tipo_cambio.aspx/");
        }

        private void aLTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltaProveedores Proveedor = new FormAltaProveedores();
            Proveedor.cmbListaProveedores.Visible = false;
            Proveedor.label16.Visible = false;
            Proveedor.btnEliminar.Visible = false;
            Proveedor.btnGuardar.Visible = false;
            Proveedor.ShowDialog();
        }

        private void eDITARMODIFICARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltaProveedores Proveedor2 = new FormAltaProveedores();
            Proveedor2.cmbListaProveedores.DataSource = proveedores.GetExisting();
            Proveedor2.cmbListaProveedores.SelectedIndex = -1;
            Proveedor2.Reset();
            Proveedor2.btnAlta.Visible = false;
            Proveedor2.Show();
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonIngresarHoja_Click(object sender, EventArgs e)
        {
            if(txtFACTURAP.Text=="")
            {
                MessageBox.Show("Se necesita capturar la factura");
                return;
            }
            string docume = "1";
            if (tabladocumentos.Rows.Count == 0 && docfactura.Rows.Count==0 && docpedimento.Rows.Count==0)
            {
                docume = "";
                MessageBox.Show("Se necesita adjuntar documentos");
                return;
            }
            //documentosadjuntos = documentos_almacen.documentosvacios();
            List<productos> listaproductos = new List<productos>();

            List<documentos_almacen> listadocumentos = new List<documentos_almacen>();
            if (ProveedorSeleccionado == null)
                return;
            if (AccesoInternet())
            {
                OENGralSeleccionada.PARTIDAS.Clear();
                OENGralSeleccionada.ItemsInventario.Clear();
                OENGralSeleccionada.ID_PROVEEDOR = ProveedorSeleccionado.ID;
                OENGralSeleccionada.CODIGODEBARRAS = OENGralSeleccionada.Id.ToString();
                OENGralSeleccionada.FECHA = DateTime.Now.Date;
                if (proyectoSeleccionado != null)
                    OENGralSeleccionada.ID_CLIENTE = proyectoSeleccionado.ID_CLIENTE;
                OENGralSeleccionada.PROYECTO_ID = Convert.ToInt32(textBoxProyectoId.Text);
                if(OREPGralSeleccionada!=null)
                OENGralSeleccionada.ID_OREP = OREPGralSeleccionada.Id;
                if (ClienteSeleccionado != null)
                    OENGralSeleccionada.ID_CLIENTE = ClienteSeleccionado.ID;
                if (EmpleadoSeleccionado != null)
                    OENGralSeleccionada.ID_VENDEDOR = EmpleadoSeleccionado.ID;
                if (PartidasOEN.Rows.Count > 0)
                {
                    int item = 1;
                    totales = 0;
                    double tjavier = 0;
                    foreach (DataRow dr in PartidasOEN.Rows)
                    {
                        if(dr[6].ToString()=="USD"|| dr[6].ToString() == "PMX")
                        { }
                        else
                        {
                            MessageBox.Show("Escriba la moneda correcta en todas las partidas");
                            return;
                        }
                        try
                        {
                            if (Convert.ToDouble(dr[7]) < 10 || Convert.ToDouble(dr[7]) > 40)
                            {
                                MessageBox.Show("Escriba TC correcto en todas las partidas");
                                return;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Escriba TC correcto en todas las partidas");
                            return;
                        }
                        #region datos individuales
                        oen_indiv PartidaIndividual = new oen_indiv();
                        PartidaIndividual.Id = partidaId;
                        PartidaIndividual.ID_OENGRAL = OENGralSeleccionada.Id;
                        PartidaIndividual.ITEM = item;
                        PartidaIndividual.ID_PRODUCTO = Convert.ToInt32(dr["ID_PRODUCTO"]);

                        /*foreach (DataRow fila in tabladocumentos.Rows)
                        {
                            documentos_almacen documento = new documentos_almacen();
                            documento.idproducto =PartidaIndividual.ID_PRODUCTO;
                            documento.ruta = fila["ruta"].ToString();
                            documento.facturas = txtFACTURAP.Text;
                            documento.pedimento = txtpedimento.Text;
                            listadocumentos.Add(documento);
                        }*/
                        try
                        {
                            PartidaIndividual.QTY = Convert.ToInt32(dr["QTY"]);
                            PartidaIndividual.COMPRA = Convert.ToInt32(dr["COMPRA"]);
                            PartidaIndividual.VENTA = Convert.ToInt32(dr["VENTA"]);
                            PartidaIndividual.PU = Convert.ToDouble(dr["PU"]);
                            if (ckimportacion.Checked == true)
                                PartidaIndividual.PU =Math.Round( PartidaIndividual.PU * 1.08,2);
                            if (dr["MONEDA"].ToString() == "USD" || dr["MONEDA"].ToString() == "usd")
                            {
                                tjavier = Convert.ToDouble(dr["PU"]) * Convert.ToDouble(dr["QTY"]);
                                if (ckimportacion.Checked == true)
                                    tjavier = Math.Round(Convert.ToDouble(dr["PU"])*1.08,2) * Convert.ToDouble(dr["QTY"]);
                            }
                            else
                            {
                                tjavier = (Convert.ToDouble(dr["PU"]) / Convert.ToDouble(dr["TC"])) * Convert.ToDouble(dr["QTY"]);
                                if (ckimportacion.Checked == true)
                                    tjavier = (Math.Round(Convert.ToDouble(dr["PU"])*1.08,2) / Convert.ToDouble(dr["TC"])) * Convert.ToDouble(dr["QTY"]);
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
                            if(pu > stock.PrecioAlmacen*2 || pu <stock.PrecioAlmacen / 2)
                            {
                                MessageBox.Show("Favor de revisar el precio del producto " + stock.CATALOGO + " y la moneda de la Entrada");
                            }
                            if (docume != "")
                                stock.DOCUMENTOS = docume;
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
                        foreach (productos prod in listaproductos)
                        {
                            prod.Update("Id");
                        }
                        if (!(Directory.Exists(Application.StartupPath + @"/OEN_RESPALDO/")))
                        {
                            Directory.CreateDirectory(Application.StartupPath + @"/OEN_RESPALDO/");
                        }
                        string ruta = Application.StartupPath + @"/OEN_RESPALDO/OEN_" + textBoxOENid.Text + ".pdf";
                       /* foreach (documentos_almacen doc  in listadocumentos)
                        {
                            doc.Id = doc.NextID();
                            doc.fecha = DateTime.Now.Date;
                            doc.identrada = Convert.ToInt32(textBoxOENid.Text);
                            doc.facturas = txtFACTURAP.Text;
                            doc.pedimento = txtpedimento.Text;
                            doc.Insert();

                        }
                        foreach (DataRow fila in tabladocumentos.Rows)
                        {
                            string rutaa = fila["ruta"].ToString();
                        }
                        */
                        foreach (DataRow fila in tabladocumentos.Rows)
                        {
                            documentos_almacen documento = new documentos_almacen();
                            documento.Id = documento.NextID();
                            documento.idproducto = 0;
                            documento.fecha = DateTime.Now.Date;
                            documento.identrada = Convert.ToInt32(textBoxOENid.Text);
                            documento.ruta = fila["ruta"].ToString();
                            documento.facturas = txtFACTURAP.Text;
                            documento.pedimento = txtpedimento.Text;
                            documento.Insert();
                            string rutaorigen = @"C:\Descoa\documentos\" + fila["ruta"].ToString();
                            SubirArchivoAFTP("ftp://ftp.abdstock.com", "abdsto5", "1945*abdstock", rutaorigen, "/documentos", fila["ruta"].ToString());
                            //listadocumentos.Add(documento);
                        }
                        foreach (DataRow fila in docpedimento.Rows)
                        {
                            documentos_almacen documento = new documentos_almacen();
                            documento.Id = Convert.ToInt32(fila["ID"].ToString());
                            documento.idproducto = 0;
                            documento.fecha = DateTime.Now.Date;
                            documento.identrada = Convert.ToInt32(textBoxOENid.Text);
                            documento.ruta = fila["ruta"].ToString();
                            documento.facturas = txtFACTURAP.Text;
                            documento.pedimento = txtpedimento.Text;
                            documento.Update("Id");
                        }
                        foreach (DataRow fila in docfactura.Rows)
                        {
                            documentos_almacen documento = new documentos_almacen();
                            documento.Id = Convert.ToInt32(fila["ID"].ToString());
                            documento.idproducto = 0;
                            documento.fecha = DateTime.Now.Date;
                            documento.identrada = Convert.ToInt32(textBoxOENid.Text);
                            documento.ruta = fila["ruta"].ToString();
                            documento.facturas = txtFACTURAP.Text;
                            documento.pedimento = txtpedimento.Text;
                            documento.Update("Id");
                        }
                        button1.BackColor = System.Drawing.Color.Gainsboro;
                        comboBox1.Items.Clear();
                        tabladocumentos = documentos_almacen.documentosvacios();
                        CreatePDF(ruta);
                        resetOEN();
                        comboBoxClientes.Enabled = false;
                        comboVendedor.Enabled = false;
                        comboBoxProyecto.Enabled = false;
                        buttonNewProject.Enabled = false;
                        ClienteSeleccionado=null;
                        EmpleadoSeleccionado=null;
                        OREPGralSeleccionada = null;
                        comboBoxClientes.SelectedIndex = -1;
                        comboVendedor.SelectedIndex = -1;
                        comboVendedor.SelectedIndex = -1;
                        checkBoxPorProyecto.Checked = false;
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

        private void buttonIngresar_Click_1(object sender, EventArgs e)
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
                dt = productos.ListaProductos(textBoxProducto.Text, "",false);//busca el producto
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

        private void checkBoxPorProyecto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPorProyecto.Checked == true)
            {
                comboBoxProyecto.Enabled = true;
                buttonNewProject.Enabled = true;
                comboBoxProyecto.DataSource = proyectos.GetExistentes();
                comboBoxProyecto.SelectedIndex = -1;
                ///comboBoxClientes.Enabled = true;
                //comboVendedor.Enabled = true;
                textBoxProyectoId.Text = "0";
                //comboBoxClientes.DataSource = clientes.GetExistentes();
                comboBoxClientes.SelectedIndex = -1;
            }
            else
            {
                comboBoxProyecto.Enabled = false;
                comboBoxProyecto.SelectedIndex = -1;
                buttonNewProject.Enabled = false;
                textBoxProyectoId.Text = "";
                proyectoSeleccionado = null;
                comboBoxClientes.Enabled = false;
                comboVendedor.Enabled = false;
                comboBoxClientes.Text = "";
                comboVendedor.Text = "";
                textBoxProyectoId.Text = "0";
            }
        }

        int i = 0;
        private void comboBoxProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProyecto.SelectedIndex != -1 && i > 0)
            {
                proyectoSeleccionado = (proyectos)comboBoxProyecto.SelectedItem;
                textBoxProyectoId.Text = proyectoSeleccionado.ID.ToString();
                clientes c = new clientes(proyectoSeleccionado.ID_CLIENTE);
                comboBoxClientes.SelectedIndex = comboBoxClientes.FindStringExact(c.RAZON_SOCIAL);
                comboVendedor.SelectedIndex = comboVendedor.FindStringExact(proyectoSeleccionado.GERENTE);
            }
            ++i;
        }

        private void buttonNewProject_Click(object sender, EventArgs e)
        {
            FormAltaProyecto a = new FormAltaProyecto();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK && a.proyectoSelected!=null)
            {
                comboBoxProyecto.DataSource = proyectos.GetExistentes();
                comboBoxProyecto.SelectedIndex = comboBoxProyecto.FindStringExact(a.proyectoSelected.NOMBRE);
            }
        }

        private void comboVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboVendedor.SelectedIndex != -1)
            {
                EmpleadoSeleccionado = (usuario)comboVendedor.SelectedItem;
                if (EmpleadoSeleccionado != null)
                {
                    OENGralSeleccionada.ID_VENDEDOR = EmpleadoSeleccionado.ID;
                }
            }
        }

        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OENGralSeleccionada == null)
            {
                OENGRALnextId();
            }
            if (comboBoxClientes.SelectedIndex != -1)
            {
                ClienteSeleccionado = (clientes)comboBoxClientes.SelectedItem;
                if (ClienteSeleccionado != null)
                {
                    OENGralSeleccionada.ID_CLIENTE = ClienteSeleccionado.ID;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fileName = "";
            string filtro = "All  Files |*.*";
            guardar("Documentos", filtro);
        }

        public string fileName = "";
        private int item = 0;

        private string guardar(string tipo, string filtro)//guardar adjunto
        {
            string nombre = "";
            string sourcePath = "";
            string targetPath = "";
            string destFile = "";
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.FileName = "Elegir  " + tipo;
            abrir.Filter = filtro;
            abrir.FilterIndex = 1;
            abrir.Multiselect = true;
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in abrir.FileNames)
                {
                    sourcePath = file;
                    //string rutaorigen = @"C:\Descoa\" + fila["ruta"].ToString();
                    targetPath = @"C:\Descoa\documentos\";//ruta donde se guardaran
                    if (!(Directory.Exists(@"c:\Descoa\")))
                    {
                        Directory.CreateDirectory(@"c:\Descoa\");
                    }
                    if (!(Directory.Exists(targetPath)))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                    nombre = textBoxOENid.Text + "-" + item.ToString() + Path.GetExtension(file);
                    destFile = System.IO.Path.Combine(targetPath, nombre);
                    System.IO.File.Delete(destFile);
                    System.IO.File.Copy(sourcePath, destFile, true);//copia
                    item++;
                    comboBox1.Items.Add(nombre);
                    DataRow row = tabladocumentos.NewRow();
                    row["ID"] = 0;
                    row["idproducto"] = 0;
                    row["identrada"] = Convert.ToUInt32(textBoxOENid.Text);
                    row["ruta"] = nombre;
                    row["facturas"] = nombre;
                    row["pedimento"] = nombre;
                    tabladocumentos.Rows.Add(row);
                    fileName += nombre + ",";
                    /*if (nuevo == false)
                        poliza.adjunto2 += fileName;*/
                }
                button1.BackColor = System.Drawing.Color.GreenYellow;
            }
            return fileName;
        }
        /*
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed!");
        }

*/
        static void descargarFic(string ficFTP, string user, string pass, string dirLocal)
        {
            FtpWebRequest dirFtp = ((FtpWebRequest)FtpWebRequest.Create(ficFTP));

            // Los datos del usuario (credenciales)
            NetworkCredential cr = new NetworkCredential(user, pass);
            dirFtp.Credentials = cr;

            // El comando a ejecutar usando la enumeración de WebRequestMethods.Ftp
            dirFtp.Method = WebRequestMethods.Ftp.DownloadFile;

            // Obtener el resultado del comando
            StreamReader reader =
                new StreamReader(dirFtp.GetResponse().GetResponseStream());

            // Leer el stream
            string res = reader.ReadToEnd();

            // Mostrarlo.
            //Console.WriteLine(res);

            // Guardarlo localmente con la extensión .txt
            string ficLocal = Path.Combine(dirLocal, Path.GetFileName(ficFTP));
            StreamWriter sw = new StreamWriter(ficLocal, false, Encoding.UTF8);
            sw.Write(res);
            sw.Close();

            // Cerrar el stream abierto.
            reader.Close();
        }

        static void listarFTP(string dir, string user, string pass)
        {
            FtpWebRequest dirFtp = ((FtpWebRequest)FtpWebRequest.Create(dir));

            // Los datos del usuario (credenciales)
            NetworkCredential cr = new NetworkCredential(user, pass);
            dirFtp.Credentials = cr;

            // El comando a ejecutar
            dirFtp.Method = "LIST";

            // También usando la enumeración de WebRequestMethods.Ftp
            dirFtp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            // Obtener el resultado del comando
            StreamReader reader =
                new StreamReader(dirFtp.GetResponse().GetResponseStream());

            // Leer el stream
            string res = reader.ReadToEnd();

            // Mostrarlo.
            Console.WriteLine(res);

            // Cerrar el stream abierto.
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //descargarFic("ftp://ftp.abdstock.com/respaldos/596-Dry Ice Container.pdf", "abdsto5", "1945*abdstock", @"c:\Descoa");

            if (comboBox1.Text != "")
            {
                DataRow filaeliminar = null;
                if (tabladocumentos.Rows.Count > 0)
                {
                    filaeliminar = null;
                    foreach (DataRow fila in tabladocumentos.Rows)
                    {
                        if (fila.ItemArray[3].ToString() == comboBox1.Text)
                            filaeliminar = fila;
                    }
                    if (filaeliminar != null)
                        tabladocumentos.Rows.Remove(filaeliminar);
                }
                if (docfactura.Rows.Count > 0)
                {
                    filaeliminar = null;
                    foreach (DataRow fila in docfactura.Rows)
                    {
                        if (fila.ItemArray[3].ToString() == comboBox1.Text)
                            filaeliminar = fila;
                    }
                    if (filaeliminar != null)
                        docfactura.Rows.Remove(filaeliminar);
                }

                if (docpedimento.Rows.Count > 0)
                {
                    filaeliminar = null;
                    foreach (DataRow fila in docpedimento.Rows)
                    {
                        if (fila.ItemArray[3].ToString() == comboBox1.Text)
                            filaeliminar = fila;
                    }
                    if (filaeliminar != null)
                        docpedimento.Rows.Remove(filaeliminar);
                }
                comboBox1.Items.Remove(comboBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string targetPath = Application.StartupPath + "\\DOCUMENTOS\\";
            string targetPath = @"c:\Descoa\documentos";
            if (!(Directory.Exists(@"c:\Descoa\")))
            {
                Directory.CreateDirectory(@"c:\Descoa\");
            }
            if (!(Directory.Exists(targetPath)))
            {
                Directory.CreateDirectory(targetPath);
            }
            string fileName = comboBox1.SelectedItem.ToString();
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (System.IO.File.Exists(destFile))
                System.Diagnostics.Process.Start(destFile);
        }

        private void txtFACTURAP_Leave(object sender, EventArgs e)
        {
            if (txtFACTURAP.Text != "")
            {
                string targetPath = @"c:\Descoa\documentos";
                if (!(Directory.Exists(@"c:\Descoa\")))
                {
                    Directory.CreateDirectory(@"c:\Descoa\");
                }
                if (!(Directory.Exists(targetPath)))
                {
                    Directory.CreateDirectory(targetPath);
                }
                docfactura = documentos_almacen.documentosfactiura(txtFACTURAP.Text);
                foreach (DataRow fila in docfactura.Rows)
                {
                    comboBox1.Items.Add(fila.ItemArray[3].ToString());
                    Download("C:\\Descoa\\documentos\\", fila.ItemArray[3].ToString());
                    button1.BackColor = System.Drawing.Color.GreenYellow;
                }
            }
        }

        private void txtpedimento_Leave(object sender, EventArgs e)
        {
            if (txtpedimento.Text != "")
            {
                string targetPath = @"c:\Descoa\documentos";
                if (!(Directory.Exists(@"c:\Descoa\")))
                {
                    Directory.CreateDirectory(@"c:\Descoa\");
                }
                if (!(Directory.Exists(targetPath)))
                {
                    Directory.CreateDirectory(targetPath);
                }
                docpedimento = documentos_almacen.documentospedimento(txtpedimento.Text);
                foreach (DataRow fila in docpedimento.Rows)
                {
                    comboBox1.Items.Add(fila.ItemArray[3].ToString());
                    Download("C:\\Descoa\\documentos\\", fila.ItemArray[3].ToString());
                    button1.BackColor = System.Drawing.Color.GreenYellow;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAltaProductos AP = new FormAltaProductos();
            this.Hide();
            AP.ShowDialog();
            this.Show();
        }

        private void buttonArmadoPartes_Click(object sender, EventArgs e)
        {
            FormBotoneria ArmadoPartes = new FormBotoneria();
            ArmadoPartes.ShowDialog();
        }
    }
}
