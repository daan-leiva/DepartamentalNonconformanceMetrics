using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Departamental_non_conformance_metrics
{
    public partial class NCData : Form
    {
        List<NCDataRow> ncData = new List<NCDataRow>();
        string department;
        DateTime startDate;
        MainForm.Status status;
        string uniPointConnectionString;

        public NCData(string department, DateTime startDate, MainForm.Status status, string uniPointConnectionString)
        {
            InitializeComponent();

            // set variables
            this.department = department;
            this.startDate = startDate;
            this.status = status;
            this.uniPointConnectionString = uniPointConnectionString;
        }

        private void NCData_Load(object sender, EventArgs e)
        {
            // set control
            departmentLabel.Text = department;
            switch (status)
            {
                case MainForm.Status.CausedAtPreviousOp:
                    statusLabel.Text = "Caused at Previous Op";
                    break;
                case MainForm.Status.FoundAtCustomer:
                    statusLabel.Text = "Found at Customer";
                    break;
                case MainForm.Status.FoundAtQuality:
                    statusLabel.Text = "Found at Quality";
                    break;
                case MainForm.Status.FoundAtSubsequentOp:
                    statusLabel.Text = "Found at Subsequent Op";
                    break;
                case MainForm.Status.FoundByYou:
                    statusLabel.Text = "Found/Caused by You";
                    break;
            }
            dateLabel.Text = string.Format("{0:MMM yy}'", startDate);

            // subscribe checkbox change to updatechart
            this.showSubsequentCheckBox.CheckedChanged += this.UpdateDataChart;

            UpdateDataChart(new object(), new EventArgs());
        }

        private void UpdateDataChart(object sender, EventArgs e)
        {
            ncData.Clear();
            ncDataGridView.DataSource = null;

            using (OdbcConnection conn = new OdbcConnection(uniPointConnectionString))
            {
                conn.Open();

                string finalNCQuery = string.Empty;

                // query to get Work center's under department
                string getWCSubQuery = "SELECT jb.Work_Center " +
                                        "FROM Production.dbo.Work_Center AS jb " +
                                        "WHERE jb.Department = '" + department + "'";
                // select statment
                finalNCQuery += "SELECT NCR, NCR_Date, Status, Material, Description, NC_type, Job, Qty_rejected\n" +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n";


                int numOfMonths = ((DateTime.Now.Year - startDate.Year) * 12) + DateTime.Now.Month - startDate.Month - 1; // do not include current month

                DateTime lowerBoundary;
                DateTime upperBoundary;

                if (showSubsequentCheckBox.Checked)
                {
                    lowerBoundary = DateTime.Now.AddMonths(-numOfMonths - 1).AddDays(-DateTime.Now.Day + 1);
                    upperBoundary = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
                }
                else
                {
                    lowerBoundary = DateTime.Now.AddMonths(-numOfMonths - 1).AddDays(-DateTime.Now.Day + 1);
                    upperBoundary = lowerBoundary.AddDays(DateTime.DaysInMonth(lowerBoundary.Year, lowerBoundary.Month) - 1);
                }

                switch (status)
                {
                    case MainForm.Status.CausedAtPreviousOp:
                        //
                        finalNCQuery += "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + lowerBoundary.ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + upperBoundary.ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center IN (" + getWCSubQuery + ") OR uni.Department = '" + department + "') " + // origination filters
                            "AND (uni.Origin_ref <> '" + department + "' AND uni.Origin_ref NOT IN (" + getWCSubQuery + "))"; // investigation filters
                        break;
                    case MainForm.Status.FoundAtCustomer:
                        //
                        finalNCQuery += "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + lowerBoundary.ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + upperBoundary.ToShortDateString() + " 11:59:59 PM" + "'  AND uni.NC_Type = 'Customer' " + // origination filters
                            "AND (uni.Origin_ref = '" + department + "' OR uni.Origin_ref IN (" + getWCSubQuery + "))"; // investigation filters
                        break;
                    case MainForm.Status.FoundAtQuality:
                        //
                        finalNCQuery += "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + lowerBoundary.ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + upperBoundary.ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center = '16-QUALITY') " + // origination filters
                            "AND (uni.Origin_ref = '" + department + "' OR uni.Origin_ref IN (" + getWCSubQuery + "))"; // investigation filters
                        break;
                    case MainForm.Status.FoundAtSubsequentOp:
                        //
                        finalNCQuery += "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + lowerBoundary.ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + upperBoundary.ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center NOT IN (" + getWCSubQuery + ") AND uni.Work_Center <> '16-QUALITY' AND uni.Department <> '" + department + "') " + // origination filters
                                    "AND (uni.Origin_ref = '" + department + "' OR uni.Origin_ref IN (" + getWCSubQuery + "))"; // investigation filters
                        break;
                    case MainForm.Status.FoundByYou:
                        //
                        finalNCQuery += "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + lowerBoundary.ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + upperBoundary.ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center IN (" + getWCSubQuery + ") OR uni.Department = '" + department + "') " + // origination filters
                            "AND (uni.Origin_ref = '" + department + "' OR uni.Origin_ref IN (" + getWCSubQuery + "))"; // investigation filters
                        break;
                }

                OdbcCommand command = new OdbcCommand(finalNCQuery, conn);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    ncData.Add(
                        new NCDataRow(
                            reader.IsDBNull(0) ? " " : reader.GetString(0),
                            reader.IsDBNull(1) ? DateTime.MinValue : reader.GetDateTime(1),
                            reader.IsDBNull(2) ? " " : reader.GetString(2),
                            reader.IsDBNull(3) ? " " : reader.GetString(3),
                            reader.IsDBNull(4) ? " " : reader.GetString(4),
                            reader.IsDBNull(5) ? " " : reader.GetString(5),
                            reader.IsDBNull(6) ? " " : reader.GetString(6),
                            reader.IsDBNull(7) ? 0 : (reader.GetFieldType(7).Equals(typeof(Double)) ? reader.GetDouble(7) : reader.GetInt32(7))
                            )
                            );

                // sort data
                ncData.OrderBy(p => p.NCNumber);

                // set controls
                ncDataGridView.DataSource = ncData;
                ncCountLabel.Text = ncData.Count.ToString();
                rejectedCountLabel.Text = ncData.Sum(p => p.RejectedQuantity).ToString();

                // set column names
                ncDataGridView.Columns[0].HeaderText = "NC";
                ncDataGridView.Columns[1].HeaderText = "NC Date";
                ncDataGridView.Columns[2].HeaderText = "NC Status";
                ncDataGridView.Columns[3].HeaderText = "Part Number";
                ncDataGridView.Columns[4].HeaderText = "NC Description";
                ncDataGridView.Columns[5].HeaderText = "NC Type";
                ncDataGridView.Columns[6].HeaderText = "Job";
                ncDataGridView.Columns[7].HeaderText = "Rejected Quantity";
            }
        }
    }
}
