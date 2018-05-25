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
//using libData;

namespace Form1
{
    public partial class FormOSA_INDIVIDUAL : Form
    {
        public FormOSA_INDIVIDUAL()
        {
            InitializeComponent();
        }

       public osa_gral osaSeleccionada;       
       public string nombreCliente;
       public string nombreVendedor;
        public List<clientes> lista;
        public string tc = "";
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

        private void FormOSA_INDIVIDUAL_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (osaSeleccionada == null)
            {
                osaSeleccionada = new osa_gral();
            }
            osaSeleccionada.MostrarValores(this, false);
            textBoxCliente.Text = nombreCliente;
            textBoxVendedor.Text = nombreVendedor;

            VerDGV(osaSeleccionada.Id);

            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            if (dataGridView1.RowCount > 0)
            {
                double sumatoria = 0;
                DataTable sal;
                sumatoria = 0;
                for (int jj = 0; jj < dataGridView1.RowCount - 1; jj++)
                {
                    string a = dataGridView1.Rows[jj].Cells[1].Value.ToString();
                    sal = productos.sumas(dataGridView1.Rows[jj].Cells[1].Value.ToString());
                    string w = dataGridView1.Rows[jj].Cells[3].Value.ToString();
                    try
                    {
                        Convert.ToDouble(sal.Rows[0][0]);
                        sumatoria += Convert.ToDouble(sal.Rows[0][0]) * Convert.ToInt32(dataGridView1.Rows[jj].Cells[3].Value);
                    }
                    catch { }
                }
                txttotal.Text= sumatoria.ToString("#,##0.00");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;

            int item = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
            string catalogo = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();

            osa_indiv i=new osa_indiv(item,osaSeleccionada.Id);
            productos p = new productos(i.ID_PRODUCTO2);
            inventariocostos invCost = new inventariocostos(i.ID_PRODUCTO2, true);
            
            FormDevolucion d = new FormDevolucion();
            d.labelProducto.Text = "OSA no. " + osaSeleccionada.Id + ",  ITEM: " + item + ",  CATALOGO: " + catalogo;
            d.textBoxExistencia.Text = i.QTY2.ToString();
            d.existencia = i.QTY2;
            d.stock = p.STOCK;
            d.ShowDialog();

            if (d.DialogResult == DialogResult.OK)
            {
                if(d.existencia < i.QTY2)
                {
                    #region WHILE DEVOLVER A iNVENTARIOCOSTOS
                    if (invCost.Id > 0)
                    {
                        int diferenciaOen = invCost.cantidad_oen - invCost.cantidad_actual;
                        int restaOsa = i.QTY2 - d.existencia;

                        if (restaOsa <= diferenciaOen)
                        {
                            invCost.cantidad_actual += restaOsa;
                            invCost.Update("Id");
                        }
                        else
                        {
                            int qty = restaOsa;

                            invCost.cantidad_actual += diferenciaOen;
                            invCost.Update("Id");
                            qty -= diferenciaOen;                            

                            while (qty > 0)
                            {
                                inventariocostos invCost2 = new inventariocostos(i.ID_PRODUCTO2, true);
                                if (invCost2.Id > 0)
                                {
                                    int restaOen = invCost2.cantidad_oen - invCost2.cantidad_actual;
                                    if (qty <= restaOen)
                                    {
                                        invCost2.cantidad_actual += qty;
                                        invCost2.Update("Id");
                                        qty = 0;
                                    }
                                    else
                                    {
                                        invCost2.cantidad_actual += restaOen;
                                        invCost2.Update("Id");
                                        qty -= restaOen;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No hay ordenes de entrada para este producto");
                                    qty = 0;
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay ordenes de entrada para estos productos");
                    }

                    #endregion WHILE DEVOLVER A INVENTARIOcOSTOS

                    i.QTY2 = d.existencia;
                    p.STOCK = d.stock;
                    i.Update("Id");
                    p.Update("Id");

                    MessageBox.Show("Devolucion aplicada");
                    VerDGV(osaSeleccionada.Id);
                    foreach(DataGridViewRow fila in dataGridView1.Rows)
                    {
                        string cantidad = fila.Cells[2].ToString();
                        string cat= fila.Cells[1].ToString();
                    }
                }
            }
            if (osaSeleccionada.idpoliza > 0)
            {
                double tot = 0;
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells[3].Value != null)
                    {
                        string cantidad = fila.Cells[3].Value.ToString();
                        catalogo = fila.Cells[1].Value.ToString();
                        item = Convert.ToInt32(dataGridView1.Rows[fila.Index].Cells[0].Value);
                        i = new osa_indiv(item, osaSeleccionada.Id);
                        p = new productos(i.ID_PRODUCTO2);
                        tot += Convert.ToInt32(cantidad) * p.PrecioAlmacen;
                    }
                }
                polizasdb pol = new polizasdb(osaSeleccionada.idpoliza);                
                pol.subtotal = tot;
                pol.egreso = tot;
                pol.Update("folio");
            }
        }

        private void VerDGV(int oenG)
        {
            dataGridView1.DataSource = osa_indiv.TablaOSA_INDIV(oenG);
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 550;
            dataGridView1.Columns["VENTA"].Visible = false;
        }


       // int w = 0;
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("De un CLic sobre la partida que desea devolver");

            /*
            if (w == 0)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                buttonEditar.BackColor = Color.Yellow;
                buttonEditar.Text = "Actualizar";

                w++;
            }
            else
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                buttonEditar.BackColor = Color.LightGray;
                buttonEditar.Text = "Editar";

                w = 0;
            }
            */
        }


        private void button1Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "pdf";
            save.Filter = "PDF files|*.pdf";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string ruta = save.FileName;
                CreatePDF(ruta);
                System.Diagnostics.Process.Start(ruta);
                if (!(Directory.Exists(Application.StartupPath + @"/OSA_RESPALDO/")))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"/OSA_RESPALDO/");
                }
                ruta = Application.StartupPath + @"/OSA_RESPALDO/OSA_" + Id.Text + ".pdf";
                CreatePDF(ruta);
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
                            ITE.NoDoc = osaSeleccionada.Id.ToString();
                            ITE.CodigoDoc = osaSeleccionada.CODIGODEBARRAS;
                            ITE.FechaDoc = osaSeleccionada.FECHA;
                            ITE.NoFactura = osaSeleccionada.FACTURA;
                            ITE.NoRemision = osaSeleccionada.REMISION;
                            ITE.NoCotizacion = osaSeleccionada.COTIZACION.ToString();
                            ITE.NombreCte = textBoxCliente.Text;
                            ITE.NombreVendedor = textBoxVendedor.Text;
                            ITE.NombreContacto = "";
                            ITE.total = txttotal.Text;
                            if (osaSeleccionada.PROYECTO_ID != 0)
                            {
                                proyectos pry = new proyectos(osaSeleccionada.PROYECTO_ID);
                                ITE.NombreProyecto = pry.NOMBRE;
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
                            foreach (DataGridViewRow partida in dataGridView1.Rows)
                            {
                                //productos pctos = new productos(partida.ID_PRODUCTO2);
                                if (partida.Cells["ITEM"].Value != null)
                                {
                                    PdfPCell item = new PdfPCell(new Phrase(partida.Cells["ITEM"].Value.ToString(), ITextEvents.arial2));
                                    item.HorizontalAlignment = 1;
                                    item.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //  item.BackgroundColor = BaseColor.LIGHT_GRAY;
                                    NombreColumnas2.AddCell(item);

                                    PdfPCell Catalogo;
                                    Catalogo = new PdfPCell(new Phrase(partida.Cells["CATALOGO"].Value.ToString(), ITextEvents.arial2));
                                    //  PdfPCell Catalogo = new PdfPCell(new Phrase(partida.ALIAS, ITextEvents.arial2));
                                    Catalogo.FixedHeight = 22f;
                                    Catalogo.HorizontalAlignment = 0;
                                    Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //  Catalogo.BackgroundColor = BaseColor.LIGHT_GRAY;
                                    NombreColumnas2.AddCell(Catalogo);

                                    PdfPCell Descrip = new PdfPCell(new Phrase(partida.Cells["DESCRIPCION"].Value.ToString(), ITextEvents.arial2));
                                    Descrip.HorizontalAlignment = 0;
                                    Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //  Descrip.BackgroundColor = BaseColor.LIGHT_GRAY;
                                    NombreColumnas2.AddCell(Descrip);

                                    PdfPCell Cantidad = new PdfPCell(new Phrase(partida.Cells["CANTIDAD"].Value.ToString(), ITextEvents.arial2));
                                    Cantidad.HorizontalAlignment = 1;
                                    Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                                    NombreColumnas2.AddCell(Cantidad);
                                }
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
                        catch (Exception )
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormSALIDAS SACAS = new FormSALIDAS();
            SACAS.comboBoxClientes.DataSource = lista;
            SACAS.textBoxTipoCambio.Text = tc;
            SACAS.OSAGralSeleccionada =new  osa_gral(Convert.ToInt32(Id.Text));
            SACAS.estatus(Convert.ToInt32(Id.Text));
            this.Hide();
            SACAS.ShowDialog();
            this.Show();
            if (SACAS.DialogResult == DialogResult.OK)
                this.Close();
        }
    }
}
