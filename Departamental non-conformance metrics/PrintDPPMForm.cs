using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Odbc;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Departamental_non_conformance_metrics
{
    public partial class PrintDPPMForm : Form
    {
        int quantityRan;
        List<string> departments;
        DateTime date;
        Dictionary<string, double> foundAtSubsequentData;
        Dictionary<string, double> foundAtQualityData;
        Dictionary<string, double> foundAtCustData;
        Dictionary<string, double> foundByYouData;
        PrintDocument printDocument1 = new PrintDocument();
        double totalDPPMValue;
        string ownerText;
        string owner2Text;
        string leadText;

        string uniConnection;

        public PrintDPPMForm(List<string> departments, DateTime date, Dictionary<string, double> foundAtSubsequentData, Dictionary<string, double> foundAtQualityData, Dictionary<string, double> foundAtCustData, Dictionary<string, double> foundByYouData, Chart workCenterChart, Chart DPPMChart, int quantityRan, string uniConnection, double totalDPPM, string _ownerText, string _owner2Text, string _leadText)
        {
            this.quantityRan = quantityRan;
            this.departments = departments.ToList();
            this.date = date;
            this.foundAtSubsequentData = foundAtSubsequentData.ToDictionary(x => x.Key, v => v.Value);
            this.foundAtQualityData = foundAtQualityData.ToDictionary(k => k.Key, v => v.Value);
            this.foundAtCustData = foundAtCustData.ToDictionary(k => k.Key, v => v.Value);
            this.foundByYouData = foundByYouData.ToDictionary(k => k.Key, v => v.Value);
            this.uniConnection = uniConnection;
            this.totalDPPMValue = totalDPPM;
            this.ownerText = _ownerText;
            this.owner2Text = _owner2Text;
            this.leadText = _leadText;

            InitializeComponent();

            // print components
            printButton.Click += new EventHandler(printButton_Click);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            this.Controls.Add(printButton);

            // copy charts
            CopyChart(DPPMChart, this.dppmChart);
            CopyChart(workCenterChart, this.wcChart);
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            // set date label
            dateLabel.Text = "From: " + date.ToString("MMM", CultureInfo.InvariantCulture) + " " + date.ToString("yy") + "'";

            // fill charts
            FillDPPMSummaryTable();

            // departments
            departmentsLabel.Text = "";
            for (int i = 0; i < departments.Count; i++)
                if (i != departments.Count - 1)
                    departmentsLabel.Text += departments[i] + ", ";
                else
                    departmentsLabel.Text += departments[i];

            // sety up totallable
            totalDPPMLabel.Text = totalDPPMValue.ToString();

            // set up goal if only one department
            int goal = -1000;
            if (departments != null && departments.Count == 1)
            {
                List<Goal> goals = Deserialize();
                if (goals == null || goals.Count < 1)
                {
                    MessageBox.Show("There was a problem loading a binary file. Contact IT support");
                }
                else // if you have goals data
                {
                    foreach (string department in departments)
                        goal = goals.Find(g => g.department.Contains(department.ToLower().Replace(" ", ""))).goal;
                    goalDppmLabel.Text = goal.ToString();
                }
            }
            else
            {
                goalDppmLabel.Text = "0";
            }
            // set up labels
            //ownerLabel.Text = ownerText;
            //owner2Label.Text = owner2Text;
            //leadLabel.Text = leadText;
        }

        private void CopyChart(Chart copyFrom, Chart copyTo)
        {
            System.IO.MemoryStream myStream = new System.IO.MemoryStream();
            copyFrom.Serializer.Save(myStream);
            copyTo.Serializer.Load(myStream);

            copyTo.Size = new Size(808, 304);
        }

        private void FillDPPMSummaryTable()
        {
            //add columns
            dppmSummaryDataGridview.Columns.Add("Quantity Ran", "Quantity Ran");
            dppmSummaryDataGridview.Columns.Add("Quantity Rejected", "Quantity Rejected");
            dppmSummaryDataGridview.Columns.Add("DPPM", "DPPM");

            // add rows
            dppmSummaryDataGridview.Rows.Add("Found at Customer");
            dppmSummaryDataGridview.Rows[0].HeaderCell.Value = "Found at Customer";
            dppmSummaryDataGridview.Rows.Add("Found at Quality");
            dppmSummaryDataGridview.Rows[1].HeaderCell.Value = "Found at Quality";
            dppmSummaryDataGridview.Rows.Add("Found at Subsequenty Operation");
            dppmSummaryDataGridview.Rows[2].HeaderCell.Value = "Found at Subsequent Operation";
            dppmSummaryDataGridview.Rows.Add("Found by Department(s)");
            dppmSummaryDataGridview.Rows[3].HeaderCell.Value = "Found by Department(s)";

            // insert data
            for (int i = 0; i < dppmSummaryDataGridview.Rows.Count; i++)
                dppmSummaryDataGridview.Rows[i].Cells[0].Value = quantityRan;
            dppmSummaryDataGridview.Rows[0].Cells[1].Value = foundAtCustData["RejectedQty"];
            dppmSummaryDataGridview.Rows[0].Cells[2].Value = foundAtCustData["DPPM"];
            dppmSummaryDataGridview.Rows[1].Cells[1].Value = foundAtQualityData["RejectedQty"];
            dppmSummaryDataGridview.Rows[1].Cells[2].Value = foundAtQualityData["DPPM"];
            dppmSummaryDataGridview.Rows[2].Cells[1].Value = foundAtSubsequentData["RejectedQty"];
            dppmSummaryDataGridview.Rows[2].Cells[2].Value = foundAtSubsequentData["DPPM"];
            dppmSummaryDataGridview.Rows[3].Cells[1].Value = foundByYouData["RejectedQty"];
            dppmSummaryDataGridview.Rows[3].Cells[2].Value = foundByYouData["DPPM"];


            // adapt width of total textboxes according

            totalDPPMLabel.Location = new Point(dppmSummaryDataGridview.GetCellDisplayRectangle(2, 3, false).Left + dppmSummaryDataGridview.Location.X - 1, totalDPPMLabel.Location.Y);
            totalDPPMLabel.Width = dppmSummaryDataGridview.Columns[2].Width + 2;

            dppmTitleLabel.Location = new Point(dppmSummaryDataGridview.GetCellDisplayRectangle(0, 3, false).Left + dppmSummaryDataGridview.Location.X - 1, dppmTitleLabel.Location.Y);
            dppmTitleLabel.Width = dppmSummaryDataGridview.Columns[0].Width + dppmSummaryDataGridview.Columns[1].Width + 2;

            goalDppmLabel.Location = new Point(totalDPPMLabel.Location.X, goalDppmLabel.Location.Y);
            goalDppmLabel.Width = totalDPPMLabel.Width;

            goalDPPMTitleLabel.Location = new Point(dppmTitleLabel.Location.X, goalDPPMTitleLabel.Location.Y);
            goalDPPMTitleLabel.Width = dppmTitleLabel.Width;
        }

        void printButton_Click(object sender, EventArgs e)
        {
            // set up correct settings
            printButton.Visible = false;
            this.Location = new Point(0, 0);
            this.Size = new Size(875,1040);
            CaptureScreen();

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "NC Summary";
                printDocument1.Print();
            }

            /*PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
            */
            //printDocument1.Print();
            printButton.Visible = true;
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            memoryImage.SetResolution(100.0f, 90.0f);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X + 18, this.Location.Y +30 , 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public static List<Goal> Deserialize()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    var goals = (List<Goal>)bin.Deserialize(stream);
                    return goals;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem with binary issue\nContact IT support");
                return null;
            }
        }
    }
}
