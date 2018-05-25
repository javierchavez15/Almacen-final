using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using libData;
using MySql.Data.MySqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace Form1
{
    public partial class FormOEN_INDIVIDUAL : Form
    {
        public FormOEN_INDIVIDUAL()
        {
            InitializeComponent();
        }

        public oen_gral oenSeleccionada;
        public string nombreProvedor;
      //  DataTable PartidasOEN = OEN_INDIV.TablaOEN_INDIV().Clone();

        private void FormOEN_INDIVIDUAL_Load(object sender, EventArgs e)
        {
            if (oenSeleccionada == null)
            {
                oenSeleccionada = new oen_gral();
            }

            textBoxFecha.Text = oenSeleccionada.FECHA.ToString("dd/MMMM/yyyy");
            textBoxOREP.Text = oenSeleccionada.ID_OREP.ToString();
            textBoxOEN.Text = oenSeleccionada.Id.ToString();
            textBoxProveedor.Text = nombreProvedor;
            

            VerDGV(oenSeleccionada.Id);
        }

        private void VerDGV(int oenG)
        {
            dataGridView1.DataSource = oen_indiv.TablaOEN_INDIV(oenG);
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 500;       
            dataGridView1.Columns[3].Width = 65;
            dataGridView1.Columns[4].Width = 55;
            dataGridView1.Columns[5].Width = 55;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 65;
            dataGridView1.Columns[8].Width = 65;

        }

        private void button1Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int w = 0;
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (w == 0)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
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
                if (!(Directory.Exists(Application.StartupPath + @"/OEN_RESPALDO/")))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"/OEN_RESPALDO/");
                }
                ruta = Application.StartupPath + @"/OEN_RESPALDO/OEN_" + textBoxOEN.Text + ".pdf";
                CreatePDF(ruta);
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
                            ITE.NoDoc = oenSeleccionada.Id.ToString();
                            ITE.CodigoDoc = oenSeleccionada.CODIGODEBARRAS;
                            ITE.FechaDoc = oenSeleccionada.FECHA;
                            ITE.NombreProveedor = textBoxProveedor.Text;
                            //ITE.total = 50;
                            pdfWriter.PageEvent = ITE;
                            pdfDoc.Open();
                            #region tablas
                            PdfPTable NombreColumnas2 = new PdfPTable(5);
                            NombreColumnas2.TotalWidth = pdfDoc.PageSize.Width - 90f;
                            NombreColumnas2.LockedWidth = true;
                            NombreColumnas2.WidthPercentage = 70;
                            float[] widths2 = new float[] { 1f, 4f, 8f, 1f, 2 };
                            NombreColumnas2.SetWidths(widths2);
                            #region foreach
                            double totales = 0;
                            foreach (DataGridViewRow partida in dataGridView1.Rows)
                            {
                                // productos pctos = new productos(partida.ID_PRODUCTO);
                                if (partida.Cells["ITEM"].Value != null)
                                {
                                    PdfPCell item = new PdfPCell(new Phrase(partida.Cells["ITEM"].Value.ToString(), ITextEvents.arial2));
                                    item.HorizontalAlignment = 1;
                                    item.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    NombreColumnas2.AddCell(item);

                                    PdfPCell Catalogo;
                                    Catalogo = new PdfPCell(new Phrase(partida.Cells["CATALOGO"].Value.ToString(), ITextEvents.arial2));
                                    Catalogo.FixedHeight = 22f;
                                    Catalogo.HorizontalAlignment = 0;
                                    Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    NombreColumnas2.AddCell(Catalogo);

                                    PdfPCell Descrip = new PdfPCell(new Phrase(partida.Cells["DESCRIPCION"].Value.ToString(), ITextEvents.arial2));
                                    Descrip.HorizontalAlignment = 0;
                                    Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    NombreColumnas2.AddCell(Descrip);

                                    PdfPCell Cantidad = new PdfPCell(new Phrase(partida.Cells["CANTIDAD"].Value.ToString(), ITextEvents.arial2));
                                    Cantidad.HorizontalAlignment = 1;
                                    Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    NombreColumnas2.AddCell(Cantidad);

                                    PdfPCell Factura = new PdfPCell(new Phrase(partida.Cells["FACTURA_PROVEEDOR"].Value.ToString(), ITextEvents.arial2));
                                    Factura.HorizontalAlignment = 1;
                                    Factura.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    NombreColumnas2.AddCell(Factura);
                                    double valor = 0;
                                    if (partida.Cells["MONEDA"].Value.ToString() == "PMX")
                                        valor = Convert.ToDouble(partida.Cells["PU"].Value) / Convert.ToDouble(partida.Cells["TC"].Value);
                                    else
                                        valor = Convert.ToDouble(partida.Cells["PU"].Value);
                                    valor = valor * Convert.ToInt32(partida.Cells["CANTIDAD"].Value);
                                    totales += valor;
                                }
                            }
                            ITE.total = totales;
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
            catch { MessageBox.Show("Cierre el pdf");}
        }
    }
}
