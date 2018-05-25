using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//using libData;


namespace Form1
{
    public partial class FormProductoSpec : Form
    {
        public FormProductoSpec()
        {
            InitializeComponent();
        }

        public productos productoSeleccionadoi;
        private DataTable tablacodigos = new DataTable();
        bool nuevo2 = false;

        string rutaLogo = @"IMAGEN\No-image-found.jpg";
        string rutaImagen;
        FileStream fs;

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

        private void FormProductoSpec_Load(object sender, EventArgs e)
        {
            tablacodigos = prdoducto_codigos.tabla(CATALOGO.Text, productoSeleccionadoi.Id.ToString());
            string rutaDataSheet = @"DataSheet\" + productoSeleccionadoi.CATALOGO + ".pdf";

            if (File.Exists(rutaDataSheet))
            {
                buttonDataSheet.BackColor = System.Drawing.Color.GreenYellow;
                productoSeleccionadoi.ADJUNTOS = productoSeleccionadoi.CATALOGO;
                productoSeleccionadoi.Update("Id");
            }
            if(productoSeleccionadoi.DOCUMENTOS!="")
                button3.BackColor = System.Drawing.Color.GreenYellow;
            button2.Visible = false;
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (productoSeleccionadoi == null)
            {
                nuevo2 = true;
                productoSeleccionadoi = new productos();
            }
            productoSeleccionadoi.MostrarValores(this, false);
            DESCRIPCION.Text = productoSeleccionadoi.DESCRIPCION;
            double precio_oferta= productoSeleccionadoi.PrecioAlmacen;
            if (productoSeleccionadoi.STOCKMUERTO == 1)
            {
                ckmuerto.Checked = true;
                precio_oferta =Math.Round( precio_oferta * 0.5,2);
            }
            double porcentaje37= precio_oferta * 1.37;
            double porcentaje50 = precio_oferta * 1.5;
            PrecioAlmacen.Text = precio_oferta.ToString();
            textBox37.Text = porcentaje37.ToString();
            textBox50.Text = porcentaje50.ToString();
            labelActualizacion.Text = productoSeleccionadoi.FECHA_FACTURA.ToShortDateString();
            DateTime oldDate = productoSeleccionadoi.FECHA_FACTURA;
            DateTime newDate = DateTime.Now;
            // Difference in days, hours, and minutes.
            TimeSpan ts = newDate - oldDate;
            // Difference in days.
            int differenceInDays = ts.Days;
            //MessageBox.Show(newDate.Date.ToShortDateString()+"   "+oldDate.Date.ToShortDateString()+"   "+ differenceInDays.ToString());
            rutaImagen = @"IMAGEN\" + productoSeleccionadoi.CATALOGO + ".jpg";
            if (File.Exists(rutaImagen))
            {
                fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                Bitmap imagen = (Bitmap)System.Drawing.Image.FromStream(fs);
                double ladoMaximo = 450;              
                double factorReduccion;
                double factorAltoAncho=(double)imagen.Height/(double)imagen.Width;
                if (imagen.Width > ladoMaximo || imagen.Height > 450)
                {
                    if (factorAltoAncho >= 1)
                    {
                        factorReduccion = 450 / imagen.Height;
                    }
                    else
                    {
                    }
                }
                pictureBox1.Image = imagen;
                fs.Close();
            }
            else
            {
                fs = new FileStream(rutaLogo, FileMode.Open, FileAccess.Read);
                pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
            int diferencia = 0;
            /*if (DateTime.Now.Month < 4)
                diferencia = 90;
            else if (DateTime.Now.Month == 4)
                diferencia = 90;
            else if (DateTime.Now.Month == 5)
                diferencia = 90;
            else if (DateTime.Now.Month == 6)
                diferencia = 90;
            else if (DateTime.Now.Month ==7)
                diferencia = 120;
            else if (DateTime.Now.Month == 8)
                diferencia = 150;
            else if (DateTime.Now.Month > 8)
                diferencia = 180;*/
            diferencia = 180;
            if (differenceInDays > diferencia)
            {
                PrecioAlmacen.Visible = false;
                textBox37.Visible = false;
                textBox50.Visible = false;
            }
            if (productoSeleccionadoi.STOCKMUERTO == 1)
            {
                PrecioAlmacen.Visible = true;
                textBox37.Visible = true;
                textBox50.Visible = true;
            }
            DbObject db = new DbObject();
            string cambio = db.datoinfla();
           /* if (productoSeleccionadoi.STOCK == 0)
            {
                labelAdvertencia1.Visible = true;
                PrecioAlmacen.Visible = false;
                textBox37.Visible = false;
                textBox50.Visible = false;
            }*/
            /*if (cambio == "0")
            {
                labelAdvertencia1.Visible = true;
                labelAdvertencia1.Text = "Agrege el porcentaje de inflacion";
                PrecioAlmacen.Visible = false;
                textBox37.Visible = false;
                textBox50.Visible = false;
            }*/
            // MessageBox.Show(DateTime.Now.Month.ToString());
            //MessageBox.Show(productoSeleccionadoi.Id.ToString());
            ADJUNTOS.Text = productoSeleccionadoi.ADJUNTOS;
            var a1 = productoSeleccionadoi.ADJUNTOS;
            string[] adjuntos = a1.Split(',');
            for (int i = 0; i < adjuntos.Count(); i++)//mustra adjuntos
            {
                if (adjuntos[i] != "")
                {
                    //comboBox1.Items.Add(adjuntos[i]);
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDataSheet_Click(object sender, EventArgs e)
        {
            string rutaDataSheet = @"DataSheet\" + productoSeleccionadoi.CATALOGO + ".pdf";

            if (File.Exists(rutaDataSheet))
            {
                Process.Start(rutaDataSheet);
            }
            else
            {
                MessageBox.Show("Este producto no tiene Hoja de Datos adjunta");
            }
        }

      
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Gainsboro;
            //button2.Visible = true;
            DESCRIPCION.BackColor = Color.White;
                CATALOGO.ReadOnly = false;
                DESCRIPCION.ReadOnly = false;
                CODIGODEBARRAS.ReadOnly = false;
                MARCA.ReadOnly = false;
                COORDENADA.ReadOnly = false;
                UNIDAD.ReadOnly = false;
               // STOCK.ReadOnly = false;
                MINIMO.ReadOnly = false;
                MAXIMO.ReadOnly = false;
                buttonAdjuntarDataSheet.Visible = true;
                buttonAdjuntarImagen.Visible = true;
                buttonDataSheet.Visible = false;
                ButtonGuardarCambios.Visible = true;
                buttonEditar.Visible = false;
             //   PrecioAlmacen.ReadOnly = false;
               
                buttonAjustarStock.Visible = true;
                buttonEditPU.Visible = true;
            /*
           // pictureBox1.Image = Image.FromFile(rutaLogo);
            FormAltaProductos Alta = new FormAltaProductos();
            Alta.productoSeleccionado = pctoSeleccionado;
            fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
            Alta.pictureBox1.Image = System.Drawing.Image.FromStream(fs);
            fs.Close();
            Alta.ShowDialog();

            if (Alta.DialogResult == DialogResult.OK)
            {
                fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
            */
        }

        private void richTextBoxDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdjuntarImagen_Click(object sender, EventArgs e)
        {
            // pictureBox1.Image = Image.FromFile(rutaLogo);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            string ruta = "";
            string rutaimagen = @"IMAGEN\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ruta = ofd.FileName;

                //  MessageBox.Show(ruta);

                SimpleFileCopy.Copiar(productoSeleccionadoi.CATALOGO + ".jpg", ruta, rutaimagen);

                rutaImagen = rutaimagen + productoSeleccionadoi.CATALOGO + ".jpg";

                try
                {
                    fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                    pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                }
                catch
                {
                    MessageBox.Show("El archivo no se reemplazo con exito.");
                }
            }
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
                    SimpleFileCopy.Copiar(productoSeleccionadoi.CATALOGO + ".pdf", ruta, @"DataSheet\");
                    buttonAdjuntarDataSheet.BackColor = System.Drawing.Color.GreenYellow;
                    productoSeleccionadoi.ADJUNTOS = CATALOGO.Text;
                }
                catch
                {
                    MessageBox.Show("El archivo no se reemplazo con exito, verifique que sea un PDF antes de reemplazarlo");
                }
            }
        }

        private void ButtonGuardarCambios_Click(object sender, EventArgs e)
        {
            DESCRIPCION.Text = DESCRIPCION.Text.Replace("'", "`");//quita comila
            if (AccesoInternet() == false)//verifica si hay internet
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            PrecioAlmacen.Text=productoSeleccionadoi.PrecioAlmacen.ToString();
            if (!productoSeleccionadoi.AsignarValores(this))//carga valores
            {                
                labelError.Visible = true;
                return;
            }
            if (ckmuerto.Checked == true)
                productoSeleccionadoi.STOCKMUERTO = 1;
            else
                productoSeleccionadoi.STOCKMUERTO = 0;
            labelError.Visible = false;               
            productoSeleccionadoi.DESCRIPCION = DESCRIPCION.Text; 
            if (nuevo2)
            {
                //productoSeleccionadoi.Id = productoSeleccionadoi.NextID();
                //productoSeleccionadoi.Insert();
            }
            else
            {
                productoSeleccionadoi.Update("Id");
            }
            if (productoSeleccionadoi.Error != "")
            {
                MessageBox.Show(productoSeleccionadoi.Error);
                return;
            }
            foreach (DataRow f1 in tablacodigos.Rows)
            {
                if (f1.ItemArray[1] != DBNull.Value)
                {
                    if (f1.ItemArray[1].ToString() != "")
                    {
                        prdoducto_codigos pro = new prdoducto_codigos();
                        if (f1.ItemArray[0] == DBNull.Value)
                            pro.Id = pro.NextID();
                        else
                        {
                            if (f1.ItemArray[0].ToString() == "0")
                                pro.Id = pro.NextID();
                            else
                                pro.Id = Convert.ToInt32(f1.ItemArray[0]);
                        }
                        pro.CODIGO = f1.ItemArray[1].ToString();
                        pro.catalogo = productoSeleccionadoi.CATALOGO;
                        pro.idproducto = productoSeleccionadoi.Id;
                        if (f1.ItemArray[0] == DBNull.Value)
                            pro.Insert();
                        else
                        {
                            if (f1.ItemArray[0].ToString() == "0")
                                pro.Insert();
                            else
                                pro.Update("Id");
                        }
                    }
                }
            }
            CATALOGO.ReadOnly = true;
            DESCRIPCION.ReadOnly = true;
            CODIGODEBARRAS.ReadOnly = true;
            MARCA.ReadOnly = true;
            COORDENADA.ReadOnly = true;
            UNIDAD.ReadOnly = true;
            MINIMO.ReadOnly = true;
            MAXIMO.ReadOnly = true;
            buttonAdjuntarDataSheet.Visible = false;
            buttonAdjuntarImagen.Visible = false;
            buttonDataSheet.Visible = true;
            buttonEditar.Visible = true;
            ButtonGuardarCambios.Visible = false;
            this.Close();           
        }      

        private void CODIGODEBARRAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                buttonEditar.PerformClick();
                ButtonGuardarCambios.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                buttonCancelar.PerformClick();
            }
        }

        private void FormProductoSpec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ajustarEntradasYsalidas(int ajuste)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            int stockActual=productoSeleccionadoi.STOCK;           
            if(stockActual != ajuste)
            {
                if (stockActual > ajuste)
                {
                    int diferencia = stockActual - ajuste;
                    osa_gral og = new osa_gral();
                    osa_indiv oi = new osa_indiv();
                    og.Id = og.NextID();
                    og.ID_CLIENTE = 0;
                    og.FECHA = DateTime.Now.Date;
                    oi.Id = oi.NextID();
                    oi.ID_OSAGRAL = og.Id;
                    oi.ID_PRODUCTO2 = productoSeleccionadoi.Id;
                    oi.QTY2 = diferencia;
                    oi.precioAlmacen = productoSeleccionadoi.PrecioAlmacen;
                    oi.totalItem = oi.precioAlmacen * oi.QTY2;
                    #region LOOP SALIDAS INVETNARIOCOSTOS
                    inventariocostos invCost = new inventariocostos(oi.ID_PRODUCTO2, "Salida");
                    if (invCost.Id > 0)
                    {
                        if (oi.QTY2 <= invCost.cantidad_actual)
                        {
                            invCost.cantidad_actual -= oi.QTY2;
                            invCost.Update("Id");
                        }
                        else
                        {
                            int Qty = oi.QTY2;
                            Qty -= invCost.cantidad_actual;
                            invCost.cantidad_actual = 0;
                            invCost.Update("Id");
                            while (Qty > 0)
                            {
                                inventariocostos invCost2 = new inventariocostos(oi.ID_PRODUCTO2, "Salida2");
                                if (invCost2.Id > 0)
                                {
                                    if (Qty <= invCost2.cantidad_actual)
                                    {
                                        invCost2.cantidad_actual -= Qty;
                                        invCost2.Update("Id");
                                        Qty = 0;
                                    }
                                    else
                                    {
                                        Qty -= invCost2.cantidad_actual;
                                        invCost2.cantidad_actual = 0;
                                        invCost2.Update("Id");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No hay entradas registradas para esta salida");
                                    Qty = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Este producto no tiene Facturas de compra, Favor de ingresarlas antes de Sacar el Producto");
                    }
                    #endregion LOOP SALIDAS INVETNARIOCOSTOS      
                    generalok:
                    og.Id = og.NextID();
                    og.Insert();
                    if (og.Error != "")
                        goto generalok;
                    individualok:
                    oi.Id = oi.NextID();
                    oi.ID_OSAGRAL = og.Id;
                    oi.Insert();
                    if (oi.Error != "")
                        goto individualok;
                }
                else                
                {
                    int diferencia = ajuste - stockActual;

                    oen_gral og = new oen_gral();
                    oen_indiv oi = new oen_indiv();
                    og.Id = og.NextID();
                    og.ID_PROVEEDOR = 0;
                    og.FECHA = DateTime.Now;
                    oi.Id = oi.NextID();
                    oi.ID_OENGRAL = og.Id;
                    oi.ID_PRODUCTO = productoSeleccionadoi.Id;
                    oi.QTY = diferencia;

                    generalok:
                    og.Id = og.NextID();
                    og.Insert();
                    if (og.Error != "")
                        goto generalok;
                    individualok:
                    oi.Id = oi.NextID();
                    oi.ID_OENGRAL = og.Id;
                    oi.Insert();
                    if (oi.Error != "")
                        goto individualok;
                }
            }
        }

        private void buttonAjustarStock_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            FormAjustarStock ajustes = new FormAjustarStock();
            ajustes.ProductoEscogido = productoSeleccionadoi;
            ajustes.ShowDialog();

            if (ajustes.DialogResult == DialogResult.OK)
            {
                if (ajustes.textBoxAjuste.Text == "" || ajustes.textBoxConteoFisico.Text == "")
                {
                    MessageBox.Show("Escriba un numero de Inventario y el conteo realizado");                    
                }
                else
                {                       
                    int conteoFisico=Convert.ToInt32(ajustes.textBoxConteoFisico.Text);

                    if (conteoFisico < productoSeleccionadoi.STOCK)
                    {

                        productoSeleccionadoi.AJUSTE = Convert.ToInt32(ajustes.textBoxAjuste.Text);
                        productoSeleccionadoi.FECHA_AJUSTE = ajustes.dateTimePicker1.Value;

                        ajustarEntradasYsalidas(conteoFisico);

                        productoSeleccionadoi.STOCK = conteoFisico;
                        productoSeleccionadoi.Update("Id");
                        AJUSTE.Text = productoSeleccionadoi.AJUSTE.ToString();
                        FECHA_AJUSTE.Text = productoSeleccionadoi.FECHA_AJUSTE.ToShortDateString();
                        STOCK.Text = productoSeleccionadoi.STOCK.ToString();
                    }
                    else if (conteoFisico >= productoSeleccionadoi.STOCK)//javier, agrege metodo para permitid crear inventario con las mismas cantidades
                    {

                        productoSeleccionadoi.AJUSTE = Convert.ToInt32(ajustes.textBoxAjuste.Text);
                        productoSeleccionadoi.FECHA_AJUSTE = ajustes.dateTimePicker1.Value;

                        ajustarEntradasYsalidas(conteoFisico);

                        productoSeleccionadoi.STOCK = conteoFisico;
                        productoSeleccionadoi.Update("Id");
                        AJUSTE.Text = productoSeleccionadoi.AJUSTE.ToString();
                        FECHA_AJUSTE.Text = productoSeleccionadoi.FECHA_AJUSTE.ToShortDateString();
                        STOCK.Text = productoSeleccionadoi.STOCK.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Para ingresar productos al Stock Genere Ordenes de Entrada");
                    }
                }


            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            FormEditPU editpu = new FormEditPU();
            editpu.cotizacionElegida = new cotizacionproveedor();
            editpu.cotizacionElegida.Id = editpu.cotizacionElegida.NextID();
            editpu.productoElegido = productoSeleccionadoi;
            editpu.ShowDialog();

            if (editpu.DialogResult == DialogResult.OK)
            {
                if (editpu.textBoxNuevoPrecio.Text != "")
                {
                    PrecioAlmacen.Text = editpu.textBoxNuevoPrecio.Text;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FormCostos fr_costos = new FormCostos(productoSeleccionadoi.Id, CATALOGO.Text, PrecioAlmacen.Text);
            fr_costos.ShowDialog();
        }

        private void buttonAgregarPartida_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* string targetPath = Application.StartupPath + "\\DOCUMENTOS\\";
            string fileName = comboBox1.SelectedItem.ToString();
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (System.IO.File.Exists(destFile))
                System.Diagnostics.Process.Start(destFile);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CATALOGO.Text == "")
            {
                MessageBox.Show("ESCRIBA EL CATALOGO DEL PRODUCTO");
                CATALOGO.BackColor = Color.Yellow;
                return;
            }
            item = 1;
            fileName = "";
            string filtro = "All  Files |*.*";
            ADJUNTOS.Text = guardar("Documentos", filtro);
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
                    targetPath = Application.StartupPath + "\\" + tipo + "\\";//ruta donde se guardaran
                    if (!(Directory.Exists(targetPath)))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                    nombre = CATALOGO.Text + "-" + item.ToString() + Path.GetExtension(file);
                    destFile = System.IO.Path.Combine(targetPath, nombre);
                    System.IO.File.Copy(sourcePath, destFile, true);//copia
                    item++;
                    fileName += nombre + ",";
                    /*if (nuevo == false)
                        poliza.adjunto2 += fileName;*/
                }
                button2.BackColor = System.Drawing.Color.GreenYellow;
            }
            return fileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDocumentos frmdocumento = new FormDocumentos();
            frmdocumento.catalogo = CATALOGO.Text;
            frmdocumento.idproducto = productoSeleccionadoi.Id;
            this.Hide();
            frmdocumento.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            codigos abrir = new codigos();
            /*try
            {
                Convert.ToInt32(CODIGODEBARRAS.Text);
                abrir.codigo = Convert.ToInt32(CODIGODEBARRAS.Text);
            }
            catch { }*/
            abrir.catalogo = CATALOGO.Text;
            abrir.tablacodigos = tablacodigos;
            if (CATALOGO.Text != "")
            {
                this.Hide();
                abrir.ShowDialog();
                if (abrir.DialogResult == DialogResult.OK)
                    tablacodigos = abrir.tablacodigos;
                else if (abrir.DialogResult == DialogResult.Cancel)
                    tablacodigos = prdoducto_codigos.tabla(CATALOGO.Text, productoSeleccionadoi.Id.ToString());
                this.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conteo con = new conteo();
            con.ShowDialog();
            if (con.DialogResult == DialogResult.OK)
            {
                productoSeleccionadoi.FECHA_AJUSTE = DateTime.Now;
                productoSeleccionadoi.AJUSTE = Convert.ToInt32(con.txtnumero.Text);
                productoSeleccionadoi.Update("Id");
                FECHA_AJUSTE.Text = productoSeleccionadoi.FECHA_AJUSTE.ToShortDateString();
                AJUSTE.Text = productoSeleccionadoi.AJUSTE.ToString();
            }
        }
    }
}
