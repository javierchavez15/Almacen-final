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

namespace Form1
{
    public partial class FormOREP : Form
    {
        public FormOREP()
        {
            InitializeComponent();
        }

        DataTable TablaListaReposicion = orep_gral.tablaProductos().Copy();
        DataTable TablaOREP = orep_gral.tablaProductos().Clone();
        orep_gral OREPGralSeleccionada;

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

        private void FormOREP_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            OREPGralSeleccionada = new orep_gral();
            textBoxIdOREP.Text = OREPGralSeleccionada.NextID().ToString();            

            vistaDGV1();
            vistaDGV2();

            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
            dataGridView2.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView2_CellDoubleClick);
        }

        private void vistaDGV1()
        {
            dataGridView1.DataSource = TablaListaReposicion;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[7].Width = 60;
            dataGridView1.Columns[8].Visible = false;

        }

        private void vistaDGV2()
        {
            dataGridView2.DataSource = TablaOREP;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[3].Width = 50;
            dataGridView2.Columns[4].Width = 50;
            dataGridView2.Columns[5].Width = 70;
            dataGridView2.Columns[6].Width = 50;
            dataGridView2.Columns[7].Width = 60;
            dataGridView2.Columns[8].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;

            TablaOREP.ImportRow(TablaListaReposicion.Rows[e.RowIndex]);

            DataRow dr;
            dr = TablaListaReposicion.Rows[e.RowIndex];
            TablaListaReposicion.Rows.Remove(dr);

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView2.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;

            TablaListaReposicion.ImportRow(TablaOREP.Rows[e.RowIndex]);

            DataRow dr;
            dr = TablaOREP.Rows[e.RowIndex];
            TablaOREP.Rows.Remove(dr);       

        }

        private void button1Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void buttonIzquierdaTodos_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataRow dr in TablaOREP.Rows)
            {
                TablaListaReposicion.ImportRow(TablaOREP.Rows[i]);
                i++;
            }

            TablaOREP.Clear();
        }

        private void buttonDerechaTodos_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataRow dr in TablaListaReposicion.Rows)
            {
                TablaOREP.ImportRow(TablaListaReposicion.Rows[i]);  
                i++;
            }

            TablaListaReposicion.Clear();
        }

        private void buttonDerecha1_Click(object sender, EventArgs e)
        {

        }

        private void buttonImprimirOREP_Click(object sender, EventArgs e)
        {
            OREPGralSeleccionada.OREP_Individual.Clear();
            List<productos> listaproductos = new List<productos>();
            List<orep_indiv> listareponer = new List<orep_indiv>();
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (TablaOREP.Rows.Count > 0)
            {
                OREPGralSeleccionada.Id = OREPGralSeleccionada.NextID();
                OREPGralSeleccionada.CodigoBarras = OREPGralSeleccionada.Id.ToString();
                OREPGralSeleccionada.Fecha = DateTime.Today.Date;
                OREPGralSeleccionada.StetusOREP = 1;
                int i = 1;
                string ruta = "";
                foreach (DataRow dr in TablaOREP.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"]);
                    int reponer = Convert.ToInt32(dr["REPONER"]);

                    productos Pcto = new productos(id);
                    Pcto.ORDENADO += reponer;
                    //Pcto.Update("Id");
                    listaproductos.Add(Pcto);
                    orep_indiv OI = new orep_indiv();
                    OI.Id = OI.NextID();
                    OI.ID_OREP_GRAL = OREPGralSeleccionada.Id;
                    OI.ITEM_OREP = i;
                    OI.ID_PRODUCTO = Pcto.Id;
                    //MessageBox.Show(OI.ID_PRODUCTO.ToString());
                    OI.CANTIDAD_OREP = reponer;
                    OREPGralSeleccionada.OREP_Individual.Add(OI);
                    listareponer.Add(OI);
                    //OI.Insert();
                    i++;
                }
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = "pdf";
                save.Filter = "PDF files|*.pdf";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    ruta = save.FileName;

                    CreatePDF(ruta);
                    System.Diagnostics.Process.Start(ruta);
                }
                DialogResult result = MessageBox.Show("DESEA GENERAR LA REPOSICION CON LOS DATOS CAPTURADOS?", "REVISAR PDF ANTES DE GUARDAR", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    OREPGralSeleccionada.Insert();
                    foreach (productos prod in listaproductos)
                    {
                        prod.Update("Id");
                    }
                    foreach (orep_indiv ord in listareponer)
                    {
                        ord.Insert();
                    }
                    if (!(Directory.Exists(Application.StartupPath + @"/OREP_RESPALDO/")))
                    {
                        Directory.CreateDirectory(Application.StartupPath + @"/OREP_RESPALDO/");
                    }
                    ruta = Application.StartupPath + @"/OREP_RESPALDO/OREP_" + textBoxIdOREP.Text + ".pdf";
                    CreatePDF(ruta);
                    TablaOREP.Clear();
                    textBoxIdOREP.Text = OREPGralSeleccionada.NextID().ToString();
                    MessageBox.Show("Orden Generada");
                }
            }
            else
            {
                MessageBox.Show("No hay partidas para imprimir");
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
                            ITextOREP ITE = new ITextOREP();
                            ITE.NombreDoc = "ORDEN DE REPOSICION OREP";
                            ITE.NoDoc = OREPGralSeleccionada.Id.ToString();
                            ITE.CodigoDoc = OREPGralSeleccionada.CodigoBarras;
                            ITE.FechaDoc = OREPGralSeleccionada.Fecha;


                            pdfWriter.PageEvent = ITE;


                            //open the stream 
                            pdfDoc.Open();


                            #region tablas

                            //     Conv conv = new Conv();

                            PdfPTable NombreColumnas2 = new PdfPTable(4);
                            NombreColumnas2.TotalWidth = pdfDoc.PageSize.Width - 90f;
                            NombreColumnas2.LockedWidth = true;
                            NombreColumnas2.WidthPercentage = 70;
                            float[] widths2 = new float[] { 1f, 4f, 8f, 1f };
                            NombreColumnas2.SetWidths(widths2);

                            #region foreach
                            int ITEM = 1;
                            foreach (orep_indiv partida in OREPGralSeleccionada.OREP_Individual)
                            {
                                productos pctos = new productos(partida.ID_PRODUCTO);

                                PdfPCell item = new PdfPCell(new Phrase(ITEM.ToString(), ITextEvents.arial2));
                                item.HorizontalAlignment = 1;
                                item.VerticalAlignment = Element.ALIGN_MIDDLE;
                                //  item.BackgroundColor = BaseColor.LIGHT_GRAY;
                                NombreColumnas2.AddCell(item);
                                ITEM++;

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

                                PdfPCell Cantidad = new PdfPCell(new Phrase(partida.CANTIDAD_OREP.ToString(), ITextEvents.arial2));
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
            catch { MessageBox.Show("Cierre el pdf"); }
        }

        private void buttonImprimirLista_Click(object sender, EventArgs e)
        {

        }
    }
}
