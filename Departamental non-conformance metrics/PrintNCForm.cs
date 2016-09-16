using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Drawing.Printing;

namespace Departamental_non_conformance_metrics
{
    public partial class PrintNCForm : Form
    {
        List<NCData_forForm> ncData = new List<NCData_forForm>();
        string uniConnection;
        PrintDocument printDocument1 = new PrintDocument();
        List<string> departments;
        int leftAdjustment = 20;

        public PrintNCForm(string uniConn, List<string> _departments)
        {
            this.departments = _departments.ToList();
            this.uniConnection = uniConn;
            InitializeComponent();
        }

        private void PrintNCForm_Load(object sender, EventArgs e)
        {
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // Fill Table
            FillNCSummaryTable();
        }

        private void FillNCSummaryTable()
        {
            ncData = new List<NCData_forForm>();
            using (OdbcConnection conn = new OdbcConnection(uniConnection))
            {
                conn.Open();

                string getWCSubQuery = "SELECT jb.Work_Center\n" +
                                        "FROM Production.dbo.Work_Center AS jb\n" +
                                        "WHERE jb.Department IN ('" + string.Join("','", departments) + "')\n";

                string query = "SELECT NCR, NCR_Date, Origin_ref, Material, NC_type, Job, Qty_rejected\n" +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE NCR_Date > '" + DateTime.Now.AddMonths(-1).ToShortDateString() + "' AND (Origin_ref IN\n\t(" + getWCSubQuery + ")\n OR Origin_ref IN ('" + string.Join("','", departments) + "')" + ")\n" +
                                "ORDER BY Qty_rejected DESC, Work_Center ASC, Material ASC;";

                OdbcCommand command = new OdbcCommand(query, conn);
                OdbcDataReader odbcReader = null; ;
                try
                {
                    odbcReader = command.ExecuteReader();
                }
                catch (System.InvalidOperationException ec)
                {
                    MessageBox.Show(ec.Message);
                    conn.Close();
                }
                int index = 0;
                // add columns
                try
                {
                    while (odbcReader.Read())
                    {
                        ncData.Add(new NCData_forForm(
                            odbcReader.IsDBNull(0) ? "" : odbcReader.GetString(0),
                            odbcReader.IsDBNull(1) ? DateTime.MinValue.ToShortDateString() : odbcReader.GetDateTime(1).ToShortDateString(),
                            odbcReader.IsDBNull(2) ? "" : odbcReader.GetString(2),
                            odbcReader.IsDBNull(3) ? "" : odbcReader.GetString(3),
                            odbcReader.IsDBNull(4) ? "" : odbcReader.GetString(4),
                            odbcReader.IsDBNull(5) ? "" : odbcReader.GetString(5),
                            odbcReader.IsDBNull(6) ? -999 : odbcReader.GetDouble(6)
                            ));
                    }
                }
                catch (System.InvalidCastException ec)
                {
                    MessageBox.Show("Problem with: " + odbcReader.GetString(0) + "\nAt index: " + index + "\nCorrect type: " + odbcReader.GetFieldType(index - 1) + "\n" + ec.Message);
                }

                // set data source
                ncSummaryDataGridview.DataSource = ncData;

                // set column names
                ncSummaryDataGridview.Columns[0].HeaderText = "NC";
                ncSummaryDataGridview.Columns[1].HeaderText = "NC Date";
                ncSummaryDataGridview.Columns[2].HeaderText = "Origin";
                ncSummaryDataGridview.Columns[3].HeaderText = "Part Number";
                ncSummaryDataGridview.Columns[4].HeaderText = "NC Type";
                ncSummaryDataGridview.Columns[5].HeaderText = "Job";
                ncSummaryDataGridview.Columns[6].HeaderText = "Rejected Quantity";

                // set max width for description
                ncSummaryDataGridview.Columns[4].Width = 100;
            }
        }

        void printButton_Click_1(object sender, EventArgs e)
        {
            // set up correct settings
            printButton.Visible = false;
            this.Location = new Point(0, 0);
            this.Size = new Size(875, 1040);
            // CaptureScreen();

            //Open the print dialog
            
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "NC Summary";
                printDocument1.Print();
            }
            /*
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
            */
            //printDocument1.Print();
            printButton.Visible = true;
        }

        PrintProperties pProps = new PrintProperties();
        public StringFormat strFormat;
        public bool bFirstPage;
        public bool bNewPage;

        private void printDocument1_BeginPrint(object sender,
    System.Drawing.Printing.PrintEventArgs e)
        {
            pProps.gridToPrint = ncSummaryDataGridview;

            strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Near;
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Trimming = StringTrimming.EllipsisCharacter;
            bFirstPage = true;
            bNewPage = true;

            try
            {
                pProps.arrColumnLefts.Clear();
                pProps.arrColumnWidths.Clear();
                pProps.iCellHeight = 0;
                pProps.iCount = 0;

                // Calculating Total Widths
                pProps.iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in pProps.gridToPrint.Columns)
                {
                    pProps.iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender,
    System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left - leftAdjustment;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in ncSummaryDataGridview.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)pProps.iTotalWidth * (double)pProps.iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)pProps.iTotalWidth))));

                        pProps.iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        pProps.arrColumnLefts.Add(iLeftMargin);
                        pProps.arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (pProps.iRow <= ncSummaryDataGridview.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = ncSummaryDataGridview.Rows[pProps.iRow];
                    //Set the cell height
                    pProps.iCellHeight = GridRow.Height +5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + pProps.iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("NC Summary: " + string.Join(", ", departments),
                                new Font(ncSummaryDataGridview.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left - leftAdjustment,
                                e.MarginBounds.Top - e.Graphics.MeasureString("NC Summary: " + string.Join(", ", departments),
                                new Font(ncSummaryDataGridview.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.AddMonths(-1).ToLongDateString() + " " + " - " + DateTime.Now.ToLongDateString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(ncSummaryDataGridview.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(ncSummaryDataGridview.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("NC Summary: " + string.Join(", ", departments),
                                new Font(new Font(ncSummaryDataGridview.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in ncSummaryDataGridview.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)pProps.arrColumnLefts[iCount], iTopMargin,
                                    (int)pProps.arrColumnWidths[iCount], pProps.iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)pProps.arrColumnLefts[iCount], iTopMargin,
                                    (int)pProps.arrColumnWidths[iCount], pProps.iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)pProps.arrColumnLefts[iCount], iTopMargin,
                                    (int)pProps.arrColumnWidths[iCount], pProps.iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += pProps.iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)pProps.arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)pProps.arrColumnWidths[iCount], (float)pProps.iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)pProps.arrColumnLefts[iCount], iTopMargin,
                                (int)pProps.arrColumnWidths[iCount], pProps.iCellHeight));
                            iCount++;
                        }
                    }
                    pProps.iRow++;
                    iTopMargin += pProps.iCellHeight;
                }
                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }
    }
}