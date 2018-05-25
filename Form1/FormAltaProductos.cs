using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Form1
{
    public partial class FormAltaProductos : Form
    {
        public FormAltaProductos()
        {
            InitializeComponent();
        }

        public productos productoSeleccionado;
        public factores ModuloSeleccionado;
        DataTable tabladocumentos = documentos_almacen.documentosvacios();
        bool nuevo = false;
        private DataTable tablacodigos = new DataTable();
        string rutaLogo = @"IMAGEN\No-image-found.jpg";
        FileStream fs;

        private void frmEditarProductos_Load(object sender, EventArgs e)
        {
            tablacodigos = prdoducto_codigos.vacia();
            item = 1;
            tabladocumentos = documentos_almacen.documentosvacios();
            if (productoSeleccionado == null)
            {
                nuevo = true;
                productoSeleccionado = new productos();
            }
            productoSeleccionado.MostrarValores(this, false);
            PRECIOLISTA.Text = "";
            Modulo.DataSource = factores.GetExistentes();
            Modulo.SelectedIndex = -1;
            ADJUNTOS.Text = "";
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            /*if (tabladocumentos.Rows.Count==0)
            {
                MessageBox.Show("Se necesita adjuntar documentos");
                return;
            }*/
            if(CATALOGO.Text=="")
            {
                MessageBox.Show("Se necesita agregar el catalogo");
                return;
            }
            if(DESCRIPCION.Text=="")
            {
                MessageBox.Show("Se necesita agregar la descripcion");
                return;
            }
            if (MARCA.Text == "")
            {
                MessageBox.Show("Se necesita agregar la marca");
                return;
            }
            if (UNIDAD.Text == "")
            {
                MessageBox.Show("Se necesita agregar la unidad");
                return;
            }
            if (PRECIOLISTA.Text == "")
            {
                MessageBox.Show("Se necesita agregar el precio");
                return;
            }
            if(DOCUMENTOS.Text=="")
            {
                MessageBox.Show("Se necesita agregar Hoja de datos");
                return;
            }
            //ADJUNTOS.Text
            DESCRIPCION.Text = DESCRIPCION.Text.Replace("'", "`");//quita comila
            if (AccesoInternet() == false)//verifica si hay internet
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            labelError.Visible = false;
            if (!productoSeleccionado.AsignarValores(this))//carga valores
            {
                labelError.Visible = true;
                return;
            }
            if (MONEDA.Text == "USD" || MONEDA.Text == "MXP")
            { 
              /*
                if (ModuloSeleccionado == null)
                {
                 //   MessageBox.Show("Seleccione un modulo");
                 //   return;
                }
                else
                {
                */
                    productoSeleccionado.DESCRIPCION = DESCRIPCION.Text;
                //    productoSeleccionado.IDMODULO = ModuloSeleccionado.ID;
                    productoSeleccionado.MONEDA = MONEDA.Text;
                if (tabladocumentos.Rows.Count > 0)
                    DOCUMENTOS.Text = "1";
                    if (nuevo)
                    {
                        productoSeleccionado.Id = productoSeleccionado.NextID();//asigna id
                        productoSeleccionado.Insert();
                    }
                    else
                    {
                        //productoSeleccionado.Update("Id");
                    }
                    if (productoSeleccionado.Error != "")
                    {
                        MessageBox.Show(productoSeleccionado.Error);
                        return;
                    }
                    foreach(DataRow f1 in tablacodigos.Rows)
                {
                    if (f1.ItemArray[1] != DBNull.Value)
                    {
                        if (f1.ItemArray[1].ToString() != "")
                        {
                            prdoducto_codigos pro = new prdoducto_codigos();
                            pro.Id = pro.NextID();
                            pro.CODIGO = f1.ItemArray[1].ToString();
                            pro.catalogo = productoSeleccionado.CATALOGO;
                            pro.idproducto = productoSeleccionado.Id;
                            pro.Insert();
                        }
                    }
                }
                    foreach(DataRow fila in tabladocumentos.Rows)
                {
                    DOCUMENTOS.Text = "1";
                    documentos_almacen documento = new documentos_almacen();
                    documento.Id = documento.NextID();
                    documento.idproducto = productoSeleccionado.Id;
                    documento.identrada = 0;
                    documento.ruta = fila.ItemArray[3].ToString();
                    documento.fecha = DateTime.Now.Date;
                    documento.facturas = "";
                    documento.pedimento = "";
                    documento.Insert();
                    string rutaorigen = @"C:\Descoa\documentos\" + fila["ruta"].ToString();
                    SubirArchivoAFTP("ftp://ftp.abdstock.com", "abdsto5", "1945*abdstock", rutaorigen, "/documentos", fila["ruta"].ToString());
                }

                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("ALTA EXITOSA");
                ADJUNTOS.Text = "";
                button1.BackColor = System.Drawing.Color.Gainsboro;
                //  }
            }
            else
            {
                MessageBox.Show("Seleccione una moneda");
                return;
            }
        }

        private bool SubirArchivoAFTP(string server, string user, string pass, string origen, string rutadestino, string nombredestino)
        {
            try
            {
                string rutaser = "ftp://ftp.abdstock.com/documentos/" + nombredestino;
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

        private void buttonAdjuntarImagen_Click(object sender, EventArgs e)
        {
            CATALOGO.BackColor = Color.White;
            if (CATALOGO.Text == "")
            {
                MessageBox.Show("ESCRIBA EL CATALOGO DEL PRODUCTO");
                CATALOGO.BackColor = Color.Yellow;
                return;
            }
           // pictureBox1.Image = Image.FromFile(rutaLogo);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            string ruta="";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
              //  MessageBox.Show(ruta);
                productoSeleccionado.CATALOGO = CATALOGO.Text;
                SimpleFileCopy.Copiar(productoSeleccionado.CATALOGO + ".jpg", ruta, @"IMAGEN\");
                string rutaImagen = @"IMAGEN\" + productoSeleccionado.CATALOGO + ".jpg";
                try
                {
                    fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                }
                catch
                {
                    fs = new FileStream(rutaLogo, FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                }
            }       
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdjuntarDataSheet_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF files (*.pdf, *.PDF) | *.pdf; *.PDF";
            string ruta = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;
                //  MessageBox.Show(ruta);
                try
                {
                    SimpleFileCopy.Copiar(CATALOGO.Text + ".pdf", ruta, @"DataSheet\");
                    DOCUMENTOS.Text = CATALOGO.Text + ".pdf";
                    buttonAdjuntarDataSheet.BackColor = System.Drawing.Color.GreenYellow;
                }
                catch
                {
                    MessageBox.Show("El archivo no se reemplazo con exito, verifique que sea un PDF antes de reemplazarlo");
                }              
            }
        }

        private void Modulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModuloSeleccionado = (factores)Modulo.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CATALOGO.Text == "")
            {
                MessageBox.Show("ESCRIBA EL CATALOGO DEL PRODUCTO");
                CATALOGO.BackColor = Color.Yellow;
                return;
            }
            fileName = "";
            string filtro = "All  Files |*.*";
            ADJUNTOS.Text=guardar("Documentos", filtro);
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
                    targetPath = @"C:\Descoa\documentos\";//ruta donde se guardaran
                    if (!(Directory.Exists(@"c:\Descoa\")))
                    {
                        Directory.CreateDirectory(@"c:\Descoa\");
                    }
                    if (!(Directory.Exists(targetPath)))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                    nombre = CATALOGO.Text + "-" + item.ToString() + Path.GetExtension(file);
                    destFile = System.IO.Path.Combine(targetPath, nombre);
                    System.IO.File.Delete(destFile);
                    System.IO.File.Copy(sourcePath, destFile, true);//copia
                    item++;
                    comboBox1.Items.Add(nombre);
                    DataRow row = tabladocumentos.NewRow();
                    row["ID"] = 0;
                    row["idproducto"] = 0;
                    row["identrada"] = 0;
                    row["ruta"] = nombre;
                    row["facturas"] = "";
                    row["pedimento"] = "";
                    tabladocumentos.Rows.Add(row);
                    fileName += nombre + ",";
                    /*if (nuevo == false)
                        poliza.adjunto2 += fileName;*/
                }
                button1.BackColor = System.Drawing.Color.GreenYellow;
            }
            return fileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                DataRow filaeliminar = null;
                foreach (DataRow fila in tabladocumentos.Rows)
                {
                    if (fila.ItemArray[3].ToString() == comboBox1.Text)
                        filaeliminar = fila;
                }
                tabladocumentos.Rows.Remove(filaeliminar);
                comboBox1.Items.Remove(comboBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            string fileName = comboBox1.SelectedItem.ToString();
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (System.IO.File.Exists(destFile))
                System.Diagnostics.Process.Start(destFile);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            codigos abrir = new codigos();
           /* try
            {
                Convert.ToInt32(CODIGODEBARRAS.Text);
                abrir.codigo = Convert.ToInt32(CODIGODEBARRAS.Text);
            }
            catch { }*/
            abrir.catalogo = CATALOGO.Text;
            abrir.tablacodigos= tablacodigos;
           // if (CATALOGO.Text != "")
           // {
                this.Hide();
                abrir.ShowDialog();
                if (abrir.DialogResult == DialogResult.OK)
                    tablacodigos = abrir.tablacodigos;
                else if(abrir.DialogResult==DialogResult.Cancel)
                    tablacodigos = prdoducto_codigos.vacia();
                this.Show();
           // }
        }
    }
}
