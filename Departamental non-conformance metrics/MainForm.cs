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
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Collections.Specialized;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Collections.Specialized;

namespace Departamental_non_conformance_metrics
{
    public partial class MainForm : Form
    {
        private readonly static string jb_DSN = "jobboss32";
        private readonly static string uni_DSN = "uniPointDB";
        private readonly static string username = "jbread";
        private readonly static string password = "Cloudy2Day";
        private static string jb_connectionString;
        private static string uni_connectionString;
        private static List<DataRow> vals_escaped = new List<DataRow>();
        private static List<DataRow> vals_caught = new List<DataRow>();
        private static List<ProcessInfo> process_owners_dictionary = new List<ProcessInfo>();
        private static int marginShift = 5;
        private static int numOfMonths;
        public enum Status { FoundAtSubsequentOp, FoundAtQuality, FoundAtCustomer, FoundByYou, CausedAtPreviousOp };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // setting up connection variables
            jb_connectionString = "DSN=" + jb_DSN + ";UID=" + username + ";PWD=" + password;
            uni_connectionString = "DSN=" + uni_DSN + ";UID=" + username + ";PWD=" + password;

            // setting up department list box
            using (OdbcConnection conn = new OdbcConnection(jb_connectionString))
            {
                conn.Open();
                string query = "SELECT Department\n" +
                                "FROM Production.dbo.Work_Center\n" +
                                "GROUP BY Department;";
                OdbcCommand command = new OdbcCommand(query, conn);

                OdbcDataReader dbReader = command.ExecuteReader();

                while (dbReader.Read())
                    if (!dbReader.IsDBNull(0))
                        departmentListBox.Items.Add(dbReader.GetString(0));
            }

            // setting up work center list box
            using (OdbcConnection conn = new OdbcConnection(jb_connectionString))
            {
                conn.Open();
                string query = "SELECT DISTINCT Work_Center, Department\n" +
                                "FROM Production.dbo.Work_Center\n" +
                                "WHERE Department IS NOT NULL\n" +
                                "ORDER BY Department;";

                OdbcCommand command = new OdbcCommand(query, conn);

                OdbcDataReader dbReader = command.ExecuteReader();

                while (dbReader.Read())
                    if (!dbReader.IsDBNull(0))
                        workCenterListBox.Items.Add(dbReader.GetString(0));
            }


            this.departmentListBox.SelectedIndexChanged += this.updateDepartmentInfo;

            // setting up start date time picker
            startDateTimePicker.Value = DateTime.Now.AddMonths(-12);
            startDateTimePicker.CloseUp += this.departmentListBox_SelectedIndexChanged;

            // setting up end date time picker
            endDateTimePicker.Value = DateTime.Now;
            endDateTimePicker.CloseUp += this.departmentListBox_SelectedIndexChanged;

            // setting up charts
            //adding a title
            ncCountChart.Titles.Add("Monthly NC Count");
            monthlyDPPM_Chart.Titles.Add("Monthly DPPM");
            wc_chart.Titles.Add("WCs Rejected Qty");
            // interval of axis
            ncCountChart.ChartAreas[0].AxisX.Interval = 1;
            monthlyDPPM_Chart.ChartAreas[0].AxisX.Interval = 1;
            wc_chart.ChartAreas[0].AxisX.Interval = 1;

            // manually generate dictionary of process owners
            // ideally this should be moved to a DB or be automatically loaded from sharePoint
            process_owners_dictionary.Add(new ProcessInfo("APQP", "Nick", "Tim", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Balancing", "Ved", "Andre", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Calibration", "Lili", "Jason", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("CMM/Automation", "Nick", "Tim", "John O.", ""));
            process_owners_dictionary.Add(new ProcessInfo("CMSP", "Nick", "Jason", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Customer MRB", "Amanda", "Andrea", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Deburr", "Javier", "Lucas", "Claudiu", "Includes glass bead, polish, superfnish, tapping, etc."));
            process_owners_dictionary.Add(new ProcessInfo("EDM", "Billy", "Ved", "Tom E.", ""));
            process_owners_dictionary.Add(new ProcessInfo("Gear", "Ved", "Andre", "Tom E.", ""));
            process_owners_dictionary.Add(new ProcessInfo("Grind", "Jorge", "Billy", "Mark", ""));
            process_owners_dictionary.Add(new ProcessInfo("Gundrill", "Billy", "Ytzayam", "Randy", ""));
            process_owners_dictionary.Add(new ProcessInfo("Heat Treat & Hot Straightening", "Ved", "Andre", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Honda", "Nick", "Kaitlyn", "", "Brittany to backup Kaitlyn"));
            process_owners_dictionary.Add(new ProcessInfo("Hone", "Nick", "Trevor", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Large Lathe", "Billy", "Jorge", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Large Screw Cell", "Javier", "Ytzayam", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Manual Inspection", "Lili", "Tim", "Albert", ""));
            process_owners_dictionary.Add(new ProcessInfo("Marking", "Nick", "Kaitlyn", "Shawn", ""));
            process_owners_dictionary.Add(new ProcessInfo("Mill", "Trevor", "Jason", "Daniel", ""));
            process_owners_dictionary.Add(new ProcessInfo("Mill Turn", "Trevor", "Javier", "Dusty", ""));
            process_owners_dictionary.Add(new ProcessInfo("MPI", "Jorge", "Tim", "John Q.", ""));
            process_owners_dictionary.Add(new ProcessInfo("MSA", "Lili", "Jason", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("PDM", "Billy", "Trevor", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Plating", "Andrea", "Tim", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Receiving Inspection", "Andrea", "Kaitlyn", "Tony", ""));
            process_owners_dictionary.Add(new ProcessInfo("Rework", "Jorge", "Scott", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Rolls-Royce", "Alison", "Andre", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Shot Peen", "Lili", "Ved", "Delia", ""));
            process_owners_dictionary.Add(new ProcessInfo("Small Lathe", "Javier", "Jason", "Tu", ""));
            process_owners_dictionary.Add(new ProcessInfo("Special Processes", "Lili", "Jorge", "", ""));
            process_owners_dictionary.Add(new ProcessInfo("Special Tooling", "Ved", "Ytzayam", "Mark H.", ""));
            process_owners_dictionary.Add(new ProcessInfo("Thread Grind", "Ved", "Javier", "Tom E.", ""));
        }

        private void Fill_DPPMGraph()
        {
            // get months
            List<string> monthsS = new List<string>();
            int monthCount = vals_escaped[0].monthly_NC_Count.Count;
            for (int i = 0; i < monthCount; i++)
                monthsS.Add(endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("MMM", CultureInfo.InvariantCulture) + " " + endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("yy") + "'");

            //
            // Scaped your op
            //
            monthlyDPPM_Chart.Series.Clear();

            Series barSeries;

            //
            // Contained at your op
            //
            //Create the series using just the y data
            barSeries = new Series("Found by Department(s)");
            barSeries.Color = Color.FromArgb(0, 102, 204);
            //barSeries.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_caught[0].getDPPM_monthly());
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            monthlyDPPM_Chart.Series.Add(barSeries);

            //Create the series using just the y data
            barSeries = new Series("Found at Subsequent Op");
            barSeries.Color = Color.FromArgb(0, 153, 51);
            //barSeries.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_escaped[0].getDPPM_monthly());
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            monthlyDPPM_Chart.Series.Add(barSeries);

            //Create the series using just the y data
            barSeries = new Series("Found at Quality");
            barSeries.Color = Color.FromArgb(255, 251, 0);
            //barSeries.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_escaped[1].getDPPM_monthly());
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            monthlyDPPM_Chart.Series.Add(barSeries);

            //Create the series using just the y data
            barSeries = new Series("Found at Customer");
            barSeries.Color = Color.FromArgb(255, 40, 17);
            //barSeries.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_escaped[2].getDPPM_monthly());
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            monthlyDPPM_Chart.Series.Add(barSeries);

            // naming axis
            monthlyDPPM_Chart.ChartAreas[0].AxisX.Title = "Date";
            monthlyDPPM_Chart.ChartAreas[0].AxisY.Title = "DPPM";

            monthlyDPPM_Chart.ChartAreas[0].RecalculateAxesScale();

            string startDate = endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString();
            string endDate = endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString();
            monthlyDPPM_Chart.Titles[0].Text = "Monthly DPPM (" + startDate + " - " + endDate + ")";
        }

        private void Fill_MainChart()
        {
            CausedByYouDataGridview.Rows.Clear();
            CausedByYouDataGridview.Columns.Clear();

            // Adding Months
            for (int i = 0; i < vals_escaped[0].monthly_Ran_Qty.Count; i++)
            {
                CausedByYouDataGridview.Columns.Add(endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("MMM", CultureInfo.InvariantCulture) + " " + endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("yy") + "'",
                                                endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("MMM", CultureInfo.InvariantCulture) + " " + endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("yy") + "'");
            }

            // add totals column
            CausedByYouDataGridview.Columns.Add("Total", "Total");

            List<double> dppmValues;

            int numOfRows = 13;
            for (int i = 0; i < numOfRows; i++)
                CausedByYouDataGridview.Rows.Add();

            // add rows of data for scaped
            for (int i = 0; i < vals_escaped.Count; i++)
            {
                dppmValues = vals_escaped[i].getDPPM_monthly();
                for (int j = 0; j < vals_escaped[0].monthly_NC_Count.Count; j++)
                {
                    if (i == 0)
                        CausedByYouDataGridview.Rows[0].Cells[j].Value = vals_escaped[0].monthly_Ran_Qty[j];
                    CausedByYouDataGridview.Rows[i * (3) + 1].Cells[j].Value = vals_escaped[i].monthly_NC_Count[j];
                    CausedByYouDataGridview.Rows[i * (3) + 2].Cells[j].Value = vals_escaped[i].monthly_Rejected_Qty[j];
                    CausedByYouDataGridview.Rows[i * (3) + 3].Cells[j].Value = dppmValues[j];


                }
                if (i == 0)
                    CausedByYouDataGridview.Rows[0].HeaderCell.Value = "Quantity Ran";
                CausedByYouDataGridview.Rows[i * (3) + 1].HeaderCell.Value = "NC Count";
                CausedByYouDataGridview.Rows[i * (3) + 2].HeaderCell.Value = "Rejected Qty";
                CausedByYouDataGridview.Rows[i * (3) + 3].HeaderCell.Value = "DPPM";
            }

            // add rows of data for caught
            int rowOffset = 3;
            for (int i = 0; i < 1; i++)
            {
                dppmValues = vals_caught[i].getDPPM_monthly();
                for (int j = 0; j < vals_caught[0].monthly_NC_Count.Count; j++)
                {
                    CausedByYouDataGridview.Rows[(i + rowOffset) * (2 + 1) + 1].Cells[j].Value = vals_caught[i].monthly_NC_Count[j];
                    CausedByYouDataGridview.Rows[(i + rowOffset) * (2 + 1) + 2].Cells[j].Value = vals_caught[i].monthly_Rejected_Qty[j];
                    CausedByYouDataGridview.Rows[(i + rowOffset) * (2 + 1) + 3].Cells[j].Value = dppmValues[j];


                    CausedByYouDataGridview.Rows[(i + rowOffset) * (2 + 1) + 1].HeaderCell.Value = "NC Count";
                    CausedByYouDataGridview.Rows[(i + rowOffset) * (2 + 1) + 2].HeaderCell.Value = "Rejected Qty";
                    CausedByYouDataGridview.Rows[(i + rowOffset) * (2 + 1) + 3].HeaderCell.Value = "DPPM";
                }
            }

            // calculate categorical totals
            int rowSum = 0;
            for (int j = 0; j < CausedByYouDataGridview.Rows.Count; j++)
            {
                rowSum = 0;
                for (int i = 0; i < CausedByYouDataGridview.Columns.Count - 1; i++)
                    if (CausedByYouDataGridview.Rows[j].HeaderCell.Value.Equals("NC Count") || CausedByYouDataGridview.Rows[j].HeaderCell.Value.Equals("Rejected Qty"))
                        rowSum += int.Parse(CausedByYouDataGridview.Rows[j].Cells[i].Value.ToString());
                CausedByYouDataGridview.Rows[j].Cells[CausedByYouDataGridview.Columns.Count - 1].Value = rowSum.ToString();
            }


            // department totals
            double totalPartsRan = 0;
            for (int j = 0; j < CausedByYouDataGridview.Columns.Count - 1; j++)
                totalPartsRan += double.Parse(CausedByYouDataGridview.Rows[0].Cells[j].Value.ToString());

            CausedByYouDataGridview.Rows[0].Cells[CausedByYouDataGridview.Columns.Count - 1].Value = totalPartsRan.ToString();

            // categorical dppm
            for (int i = 1; i <= 4; i++)
                CausedByYouDataGridview.Rows[i * 3].Cells[CausedByYouDataGridview.Columns.Count - 1].Value = (Math.Round(double.Parse(CausedByYouDataGridview.Rows[i * 3 - 1].Cells[CausedByYouDataGridview.Columns.Count - 1].Value.ToString()) / double.Parse(CausedByYouDataGridview.Rows[0].Cells[CausedByYouDataGridview.Columns.Count - 1].Value.ToString()) * 1000000, 0)).ToString();

            // total dppm
            double totalPartsScrapped = 0;
            for (int i = 0; i < CausedByYouDataGridview.Rows.Count; i++)
                if (CausedByYouDataGridview.Rows[i].HeaderCell.Value.ToString().Equals("Rejected Qty"))
                    for (int j = 0; j < CausedByYouDataGridview.Columns.Count - 1; j++)
                        totalPartsScrapped += double.Parse(CausedByYouDataGridview.Rows[i].Cells[j].Value.ToString());

            totalDPPM.Text = (Math.Round(totalPartsScrapped / totalPartsRan * 1000000, 0)).ToString();

            // make qty row different color
            CausedByYouDataGridview.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(170, 170, 170);
            CausedByYouDataGridview.Rows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(170, 170, 170);


            // disable sorting
            for (int i = 0; i < CausedByYouDataGridview.Columns.Count; i++)
                CausedByYouDataGridview.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void Fill_SubOpChart()
        {
            previousOpDatagridview.Rows.Clear();
            previousOpDatagridview.Columns.Clear();

            // Adding Months
            for (int i = 0; i < vals_caught[0].monthly_Ran_Qty.Count; i++)
            {
                previousOpDatagridview.Columns.Add(endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("MMM", CultureInfo.InvariantCulture) + " " + endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("yy") + "'",
                                                endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("MMM", CultureInfo.InvariantCulture) + " " + endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("yy") + "'");
            }

            // add totals column
            previousOpDatagridview.Columns.Add("Total", "Total");

            int numOfRows = 2;
            for (int i = 0; i < numOfRows; i++)
                previousOpDatagridview.Rows.Add();

            // add rows of data for scaped
            for (int j = 0; j < vals_caught[1].monthly_NC_Count.Count; j++)
            {
                previousOpDatagridview.Rows[0].Cells[j].Value = vals_caught[1].monthly_NC_Count[j];
                previousOpDatagridview.Rows[1].Cells[j].Value = vals_caught[1].monthly_Rejected_Qty[j];
            }

            previousOpDatagridview.Rows[0].HeaderCell.Value = "NC Count";
            previousOpDatagridview.Rows[1].HeaderCell.Value = "Rejected Qty";


            // calculate categorical totals
            int rowSum = 0;
            for (int j = 0; j < previousOpDatagridview.Rows.Count; j++)
            {
                rowSum = 0;
                for (int i = 0; i < previousOpDatagridview.Columns.Count - 1; i++)
                    if (previousOpDatagridview.Rows[j].HeaderCell.Value.Equals("NC Count") || previousOpDatagridview.Rows[j].HeaderCell.Value.Equals("Rejected Qty"))
                        rowSum += int.Parse(previousOpDatagridview.Rows[j].Cells[i].Value.ToString());
                previousOpDatagridview.Rows[j].Cells[previousOpDatagridview.Columns.Count - 1].Value = rowSum.ToString();
            }

            // disable sorting
            for (int i = 0; i < previousOpDatagridview.Columns.Count; i++)
                previousOpDatagridview.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void Fill_CountGraph()
        {
            ncCountChart.Series.Clear();

            List<string> monthsS = new List<string>();
            int monthCount = vals_escaped[0].monthly_NC_Count.Count;
            for (int i = 0; i < monthCount; i++)
                monthsS.Add(endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("MMM", CultureInfo.InvariantCulture) + " " + endDateTimePicker.Value.AddMonths(-vals_escaped[0].getDPPM_monthly().Count + i).ToString("yy") + "'");

            Series barSeries;

            //Create the series using just the y data
            barSeries = new Series("Cause by Previous Op");
            barSeries.Color = Color.FromArgb(211, 211, 211);
            //barSeries2.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_caught[1].monthly_NC_Count);
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            ncCountChart.Series.Add(barSeries);

            //Create the series using just the y data
            barSeries = new Series("Found by Department(s)");
            barSeries.Color = Color.FromArgb(0, 102, 204);
            //barSeries2.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_caught[0].monthly_NC_Count);
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            ncCountChart.Series.Add(barSeries);

            //Create the series using just the y data
            barSeries = new Series("Found at Subsequent Op");
            barSeries.Color = Color.FromArgb(0, 153, 51);
            //barSeries2.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_escaped[0].monthly_NC_Count);
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            ncCountChart.Series.Add(barSeries);


            //Create the series using just the y data
            barSeries = new Series("Found at Quality");
            barSeries.Color = Color.FromArgb(255, 251, 0);
            //barSeries2.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_escaped[1].monthly_NC_Count);
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            ncCountChart.Series.Add(barSeries);

            //Create the series using just the y data
            barSeries = new Series("Found at Customer");
            barSeries.Color = Color.FromArgb(255, 40, 17);
            //barSeries2.Points.DataBindY(yData);
            barSeries.Points.DataBindXY(monthsS, vals_escaped[2].monthly_NC_Count);
            //Set the chart type, column; vertical bars
            barSeries.ChartType = SeriesChartType.StackedColumn;
            //Add the series to the chart
            ncCountChart.Series.Add(barSeries);

            // naming axis
            ncCountChart.ChartAreas[0].AxisX.Title = "Date";
            ncCountChart.ChartAreas[0].AxisY.Title = "NC Count";

            ncCountChart.ChartAreas[0].RecalculateAxesScale();
        }

        private void Fill_WCGraph()
        {
            using (OdbcConnection conn = new OdbcConnection(uni_connectionString))
            {
                conn.Open();

                // query to get Work center's under department
                List<string> departments = new List<string>();

                foreach (var item in departmentListBox.SelectedItems)
                    departments.Add(item.ToString());

                List<string> WCs = new List<string>();

                foreach (var wc in workCenterListBox.SelectedItems)
                    WCs.Add(wc.ToString());

                // add department name itself
                foreach (var item in departmentListBox.SelectedItems)
                    WCs.Add(item.ToString());

                string workcenters_departments_list = "'";
                workcenters_departments_list += string.Join("','", WCs);
                workcenters_departments_list += "'";

                string selectQuery = string.Empty;

                //
                // MAKES THE WCs SELECT STATEMETNS

                for (int i = 0; i < WCs.Count; i++)
                {
                    selectQuery += "SUM(CASE WHEN(uni.Origin_ref = '" + WCs[i] + "' AND ((uni.Work_Center IS NULL OR uni.Work_Center NOT IN (" + workcenters_departments_list + ")) AND uni.Department <> '" + departmentListBox.SelectedItem.ToString() + "')) THEN uni.Qty_rejected ELSE 0 END)";
                    if (i != WCs.Count - 1)
                        selectQuery += ",\n";
                    else
                        selectQuery += "\n";
                }

                //
                // FOUND AT SUBSEQUENT OPERATION
                //
                string query = "SELECT " + selectQuery +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE uni.Disposition <> 'No Defect' AND uni.NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND uni.Work_Center <> '16-QUALITY'";

                OdbcCommand com = new OdbcCommand(query, conn);
                OdbcDataReader dbReader = com.ExecuteReader();

                dbReader.Read();

                for (int i = 0; i < WCs.Count; i++)
                {
                    vals_escaped[0].WCs_Scrap_Qty.Add(dbReader.IsDBNull(i) ? 0 : dbReader.GetDouble(i));
                }

                //exhaust reader
                dbReader.Read();

                //
                // Found at quality
                //
                query = "SELECT " + selectQuery +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE uni.Disposition <> 'No Defect' AND uni.NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center = '16-QUALITY') ";

                com = new OdbcCommand(query, conn);
                dbReader = com.ExecuteReader();

                dbReader.Read();

                for (int i = 0; i < WCs.Count; i++)
                {
                    vals_escaped[1].WCs_Scrap_Qty.Add(dbReader.IsDBNull(i) ? 0 : dbReader.GetDouble(i));
                }

                //
                // Found at customer
                //
                query = "SELECT " + selectQuery +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE uni.Disposition <> 'No Defect' AND uni.NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'Customer' ";

                com = new OdbcCommand(query, conn);
                dbReader = com.ExecuteReader();

                dbReader.Read();

                for (int i = 0; i < WCs.Count; i++)
                {
                    vals_escaped[2].WCs_Scrap_Qty.Add(dbReader.IsDBNull(i) ? 0 : dbReader.GetDouble(i));
                }

                //=================================================================

                //clear select query
                selectQuery = string.Empty;

                for (int i = 0; i < WCs.Count; i++)
                {
                    selectQuery += "SUM(CASE WHEN(uni.Origin_ref = '" + WCs[i] + "' AND (uni.Work_Center IN (" + workcenters_departments_list + ") OR uni.Department = '" + departmentListBox.SelectedItem.ToString() + "')) THEN uni.Qty_rejected ELSE 0 END)";
                    if (i != WCs.Count - 1)
                        selectQuery += ",\n";
                    else
                        selectQuery += "\n";
                }

                //
                // Found by you
                //
                query = "SELECT " + selectQuery +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE uni.Disposition <> 'No Defect' AND uni.NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process'"; // origination filters

                com = new OdbcCommand(query, conn);
                dbReader = com.ExecuteReader();

                dbReader.Read();

                for (int i = 0; i < WCs.Count; i++)
                {
                    vals_caught[0].WCs_Scrap_Qty.Add(dbReader.IsDBNull(i) ? 0 : dbReader.GetDouble(i));
                }

                //clear select query
                selectQuery = string.Empty;

                for (int i = 0; i < WCs.Count; i++)
                {
                    if (i < WCs.Count - 1)
                        selectQuery += "SUM(CASE WHEN(uni.Work_Center = '" + WCs[i] + "' AND ((uni.Origin_ref IS NULL OR uni.Origin_ref NOT IN (" + workcenters_departments_list + ")) AND uni.Origin_ref <> '" + departmentListBox.SelectedItem.ToString() + "')) THEN uni.Qty_rejected ELSE 0 END)";
                    else
                        selectQuery += "SUM(CASE WHEN(uni.Department = '" + WCs[i] + "' AND ((uni.Origin_ref IS NULL OR uni.Origin_ref NOT IN (" + workcenters_departments_list + ")) AND uni.Origin_ref <> '" + departmentListBox.SelectedItem.ToString() + "')) THEN uni.Qty_rejected ELSE 0 END)";
                    if (i != WCs.Count - 1)
                        selectQuery += ",\n";
                    else
                        selectQuery += "\n";
                }

                //
                // Caused by previous operation
                //
                query = "SELECT " + selectQuery +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE uni.Disposition <> 'No Defect' AND uni.NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process'"; // origination filters

                com = new OdbcCommand(query, conn);
                dbReader = com.ExecuteReader();

                dbReader.Read();

                for (int i = 0; i < WCs.Count; i++)
                {
                    vals_caught[1].WCs_Scrap_Qty.Add(dbReader.IsDBNull(i) ? 0 : dbReader.GetDouble(i));
                }

                //===========================PLOTTING=======================================

                //
                // Create plots
                //

                wc_chart.Series.Clear();

                Series barSeries;

                //Create the series using just the y data
                barSeries = new Series("Found by Department(s)");
                barSeries.Color = Color.FromArgb(0, 102, 204);
                //barSeries2.Points.DataBindY(yData);
                barSeries.Points.DataBindXY(WCs, vals_caught[0].WCs_Scrap_Qty);
                //Set the chart type, column; vertical bars
                barSeries.ChartType = SeriesChartType.StackedColumn;
                //Add the series to the chart
                wc_chart.Series.Add(barSeries);

                //Create the series using just the y data
                barSeries = new Series("Found at Subsequent Op");
                barSeries.Color = Color.FromArgb(0, 153, 51);
                //barSeries2.Points.DataBindY(yData);
                barSeries.Points.DataBindXY(WCs, vals_escaped[0].WCs_Scrap_Qty);
                //Set the chart type, column; vertical bars
                barSeries.ChartType = SeriesChartType.StackedColumn;
                //Add the series to the chart
                wc_chart.Series.Add(barSeries);

                //Create the series using just the y data
                barSeries = new Series("Found at Quality");
                barSeries.Color = Color.FromArgb(255, 251, 0);
                //barSeries2.Points.DataBindY(yData);
                barSeries.Points.DataBindXY(WCs, vals_escaped[1].WCs_Scrap_Qty);
                //Set the chart type, column; vertical bars
                barSeries.ChartType = SeriesChartType.StackedColumn;
                //Add the series to the chart
                wc_chart.Series.Add(barSeries);

                //Create the series using just the y data
                barSeries = new Series("Found at Customer");
                barSeries.Color = Color.FromArgb(255, 40, 17);
                //barSeries2.Points.DataBindY(yData);
                barSeries.Points.DataBindXY(WCs, vals_escaped[2].WCs_Scrap_Qty);
                //Set the chart type, column; vertical bars
                barSeries.ChartType = SeriesChartType.StackedColumn;
                //Add the series to the chart
                wc_chart.Series.Add(barSeries);

                // naming axis
                wc_chart.ChartAreas[0].AxisX.Title = "Work Centers";
                wc_chart.ChartAreas[0].AxisY.Title = "Rejected Qty";

                string startDate = endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString();
                string endDate = endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString();
                wc_chart.Titles[0].Text = "WCs Rejected Qty (" + startDate + " - " + endDate + ")";

                wc_chart.ChartAreas[0].RecalculateAxesScale();

            }
        }

        //
        // 
        //
        private void departmentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmentListBox.Enabled = false;
            workCenterListBox.Enabled = false;
            workCenterListBox.SelectedIndexChanged -= this.workCenterListBox_SelectedIndexChanged; // disable event so no double dipping occurs

            vals_escaped.Clear();
            vals_caught.Clear();

            if (departmentListBox.SelectedItem == null)
            {
                CausedByYouDataGridview.DataSource = null;
                CausedByYouDataGridview.Rows.Clear();
                previousOpDatagridview.DataSource = null;
                previousOpDatagridview.Rows.Clear();
                totalDPPM.Text = "";
                ownerLabel.Text = "";
                leadLabel.Text = "";
                wc_chart.Series.Clear();
                ncCountChart.Series.Clear();
                monthlyDPPM_Chart.Series.Clear();
                departmentListBox.Enabled = true;
                workCenterListBox.Enabled = true;
                return;
            }

            List<string> departments = new List<string>();

            foreach (var item in departmentListBox.SelectedItems)
                departments.Add(item.ToString());

            using (OdbcConnection conn = new OdbcConnection(uni_connectionString))
            {
                conn.Open();

                // query to get Work center's under department
                string getWorkCentersQuery = "SELECT jb.Work_Center " +
                                        "FROM Production.dbo.Work_Center AS jb " +
                                        "WHERE jb.Department IN ('" + string.Join("','", departments) + "')";

                // update Work_Center List
                OdbcCommand command = new OdbcCommand(getWorkCentersQuery, conn);
                OdbcDataReader reader = command.ExecuteReader();


                string workCentersList = string.Empty;
                while (reader.Read())
                    if (!reader.IsDBNull(0))
                    {
                        int index = workCenterListBox.FindString(reader.GetString(0));
                        workCenterListBox.SelectedIndices.Add(index);
                        workCentersList += "'" + reader.GetString(0) + "',";
                    }

                // remove last comma
                if (workCentersList.Length > 0)
                    workCentersList = workCentersList.Substring(0, workCentersList.Length - 1);

                // nc select statement 
                string ncselectStatement = "COUNT(uni.NCR),\n" +
                                    "SUM(uni.Qty_rejected)";
                numOfMonths = ((endDateTimePicker.Value.Year - startDateTimePicker.Value.Year) * 12) + endDateTimePicker.Value.Month - startDateTimePicker.Value.Month; // do not include current month
                if (numOfMonths > 0)
                    ncselectStatement += ",\n";
                else
                    ncselectStatement += "\n";
                DateTime monthlyDate;
                DateTime highDateLimit;
                for (int i = -2; i < numOfMonths - 2; i++)
                {
                    monthlyDate = endDateTimePicker.Value.AddMonths(i - numOfMonths + 2).AddDays(-endDateTimePicker.Value.Day + 1);
                    highDateLimit = monthlyDate.AddDays(DateTime.DaysInMonth(monthlyDate.Year, monthlyDate.Month) - 1);
                    ncselectStatement += "SUM(CASE WHEN(uni.NCR_Date >= '" + monthlyDate.ToShortDateString() + " 12:00:00 AM" + "' AND uni.NCR_Date <= '" + highDateLimit.ToShortDateString() + " 11:59:59 PM" + "') THEN 1 ELSE 0 END),\n";
                    ncselectStatement += "SUM(CASE WHEN(uni.NCR_Date >= '" + monthlyDate.ToShortDateString() + " 12:00:00 AM" + "' AND uni.NCR_Date <= '" + monthlyDate.AddDays(DateTime.DaysInMonth(monthlyDate.Year, monthlyDate.Month) - 1).ToShortDateString() + " 11:59:59 PM" + "') THEN uni.Qty_rejected ELSE 0 END)";
                    if (i != numOfMonths - 3)
                        ncselectStatement += ",\n";
                }

                // job select statement
                string jobselectStatement = "SUM(CASE WHEN (jboss.Actual_Start >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND jboss.Actual_Start <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "') THEN jboss.Act_Run_Qty ELSE 0 END)";
                if (numOfMonths > 0)
                    jobselectStatement += ",\n";
                else
                    jobselectStatement += "\n";
                for (int i = -2; i < numOfMonths - 2; i++)
                {
                    monthlyDate = endDateTimePicker.Value.AddMonths(i - numOfMonths + 2).AddDays(-endDateTimePicker.Value.Day + 1);
                    highDateLimit = monthlyDate.AddDays(DateTime.DaysInMonth(monthlyDate.Year, monthlyDate.Month) - 1);
                    jobselectStatement += "SUM(CASE WHEN(jboss.Actual_Start >= '" + monthlyDate.ToShortDateString() + " 12:00:00 AM" + "' AND jboss.Actual_Start <= '" + highDateLimit.ToShortDateString() + " 11:59:59 PM" + "') THEN jboss.Act_Run_Qty ELSE 0 END)";
                    if (i != numOfMonths - 3)
                        jobselectStatement += ",\n";
                }

                //
                // actual count of parts ran
                //
                string query = "SELECT " + jobselectStatement + "\n" +
                        "FROM PRODUCTION.dbo.Job_Operation AS jboss\n" +
                        "WHERE jboss.Work_Center IN\n" + // origination filters
                            "(SELECT jb.Work_Center\n" +
                            "FROM Production.dbo.Work_Center AS jb\n" +
                            "WHERE jb.Department IN ('" + string.Join("','", departments) + "'))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                int actualCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                int[] monthly_actualCount = new int[numOfMonths];
                for (int i = 1; i < numOfMonths + 1; i++)
                    monthly_actualCount[i - 1] = reader.IsDBNull(i) ? 0 : reader.GetInt32(i);

                // Found at subsequent operation
                query = "SELECT " + ncselectStatement + "\n" +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND ((uni.Work_Center IS NULL OR uni.Work_Center NOT IN (" + workCentersList + ")) AND uni.Work_Center <> '16-QUALITY' AND (uni.Department IS NULL OR uni.Department NOT IN ('" + string.Join("','", departments) + "'))) " + // origination filters
                                    "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                int ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                double rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_escaped.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_escaped[0].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_escaped[0].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_escaped[0].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                // found at quality
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center = '16-QUALITY') " + // origination filters
                            "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_escaped.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_escaped[1].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_escaped[1].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_escaped[1].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                // found at customer
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "'  AND uni.NC_Type = 'Customer' " + // origination filters
                            "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_escaped.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_escaped[2].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_escaped[2].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_escaped[2].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                // ===========================================================================

                //non-conformace cause by you
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center IN (" + workCentersList + ") OR uni.Department IN ('" + string.Join("','", departments) + "')) " + // origination filters
                            "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_caught.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_caught[0].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_caught[0].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_caught[0].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                //non conformance cause by previous opearation
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center IN (" + workCentersList + ") OR uni.Department IN ('" + string.Join("','", departments) + "')) " + // origination filters
                            "AND ((uni.Origin_ref IS NULL OR uni.Origin_ref NOT IN ('" + string.Join("','", departments) + "')) AND (uni.Origin_ref IS NULL OR uni.Origin_ref NOT IN (" + workCentersList + ")))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_caught.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_caught[1].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_caught[1].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_caught[1].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                //
                // TRIPLE GRAPHS
                //
                Fill_DPPMGraph();
                Fill_CountGraph();
                Fill_WCGraph();

                Fill_MainChart();
                Fill_SubOpChart();

                workCenterListBox.SelectedIndexChanged += this.workCenterListBox_SelectedIndexChanged;
                departmentListBox.Enabled = true;
                workCenterListBox.Enabled = true;
            }
        }

        private void updateDepartmentInfo(object sender, EventArgs e)
        {
            if (departmentListBox.SelectedItems.Count != 1 || !process_owners_dictionary.Exists(p => p.process.Equals(departmentListBox.SelectedItem.ToString())))
            {
                ownerLabel.Text = "N/A";
                owner2Label.Text = "N/A";
                leadLabel.Text = "N/A";
                return;
            }


            ProcessInfo infoToPrint;
            infoToPrint = process_owners_dictionary.Find(p => p.process.Equals(departmentListBox.SelectedItem.ToString()));

            ownerLabel.Text = infoToPrint.owner;
            owner2Label.Text = infoToPrint.owner2;
            leadLabel.Text = infoToPrint.lead;

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            /*//Open the print dialog
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Test Page Print";
                printDocument1.DefaultPageSettings.Landscape = true;
                printDocument1.Print();
            }*/

            //Open the print preview dialog
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            printDocument1.DefaultPageSettings.Landscape = true;
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
        }

        PrintProperties[] pProps = new PrintProperties[] { new PrintProperties(), new PrintProperties()/*, new PrintProperties(), new PrintProperties(), new PrintProperties() */};
        public StringFormat strFormat;
        public bool bFirstPage;
        public bool bNewPage;

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            pProps[0].gridToPrint = CausedByYouDataGridview;
            pProps[1].gridToPrint = previousOpDatagridview;

            strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Near;
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Trimming = StringTrimming.EllipsisCharacter;
            bFirstPage = true;
            bNewPage = true;

            for (int i = 0; i < pProps.Length; i++)
            {
                try
                {
                    pProps[i].arrColumnLefts.Clear();
                    pProps[i].arrColumnWidths.Clear();
                    pProps[i].iCellHeight = 0;
                    pProps[i].iCount = 0;

                    // Calculating Total Widths
                    pProps[i].iTotalWidth = pProps[i].gridToPrint.RowHeadersWidth;
                    foreach (DataGridViewColumn dgvGridCol in pProps[i].gridToPrint.Columns)
                    {
                        pProps[i].iTotalWidth += dgvGridCol.Width;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                for (int i = 0; i < pProps.Length; i++)
                {

                    iTopMargin = printGrid(sender, e, iLeftMargin, iTopMargin, bMorePagesToPrint, iTmpWidth, i, pProps[i].gridToPrint) + 10;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }

        }

        private int printGrid(object sender, System.Drawing.Printing.PrintPageEventArgs e, int iLeftMargin, int iTopMargin, bool bMorePagesToPrint, int iTmpWidth, int index, DataGridView gridToPrint)
        {
            bool needColHeader = true;
            //For the first page to print set the cell width and header height
            if (bFirstPage)
            {
                // take care of the row headers first
                if (index == 0 || index == 2)
                {
                    iTmpWidth = (int)(Math.Floor((double)((double)95 /
                            (double)pProps[index].iTotalWidth * (double)pProps[index].iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)pProps[index].iTotalWidth))));
                }
                else
                {
                    iTmpWidth = (int)(Math.Floor((double)((double)gridToPrint.RowHeadersWidth /
                        (double)pProps[index].iTotalWidth * (double)pProps[index].iTotalWidth *
                        ((double)e.MarginBounds.Width / (double)pProps[index].iTotalWidth))));
                }

                pProps[index].iHeaderHeight = (int)(e.Graphics.MeasureString(gridToPrint.Columns[0].HeaderText,
                    gridToPrint.Columns[0].InheritedStyle.Font, iTmpWidth).Height) + 11;

                // Save width and height of headers
                pProps[index].arrColumnLefts.Add(iLeftMargin);
                pProps[index].arrColumnWidths.Add(iTmpWidth);
                iLeftMargin += iTmpWidth;

                foreach (DataGridViewColumn GridCol in gridToPrint.Columns)
                {
                    iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                        (double)pProps[index].iTotalWidth * (double)pProps[index].iTotalWidth *
                        ((double)e.MarginBounds.Width / (double)pProps[index].iTotalWidth))));

                    pProps[index].iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                        GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                    // Save width and height of headers
                    pProps[index].arrColumnLefts.Add(iLeftMargin);
                    pProps[index].arrColumnWidths.Add(iTmpWidth);
                    iLeftMargin += iTmpWidth;
                }
            }
            pProps[index].iRow = 0;
            //Loop till all the grid rows not get printed
            while (pProps[index].iRow <= gridToPrint.Rows.Count - 1)
            {
                DataGridViewRow GridRow = gridToPrint.Rows[pProps[index].iRow];
                //Set the cell height
                pProps[index].iCellHeight = GridRow.Height + 5;
                int iCount = 0;
                //Check whether the current page settings allows more rows to print
                if (iTopMargin + pProps[index].iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
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
                        e.Graphics.DrawString("DPPM Summary: " + departmentListBox.SelectedItem.ToString(),
                            new Font(gridToPrint.Font, FontStyle.Bold),
                            Brushes.Black, e.MarginBounds.Left,
                            e.MarginBounds.Top - e.Graphics.MeasureString("DPPM Summary: " + departmentListBox.SelectedItem.ToString(),
                            new Font(gridToPrint.Font, FontStyle.Bold),
                            e.MarginBounds.Width).Height - 13);

                        String strDate = endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + " - " + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM";
                        //Draw Date
                        e.Graphics.DrawString(strDate,
                            new Font(gridToPrint.Font, FontStyle.Bold), Brushes.Black,
                            e.MarginBounds.Left +
                            (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                            new Font(gridToPrint.Font, FontStyle.Bold),
                            e.MarginBounds.Width).Width),
                            e.MarginBounds.Top - e.Graphics.MeasureString("DPPM Summary: " + departmentListBox.SelectedItem.ToString(),
                            new Font(new Font(gridToPrint.Font, FontStyle.Bold),
                            FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                        //Draw Columns                 
                        iTopMargin = e.MarginBounds.Top;
                    }
                    if (needColHeader || bNewPage)
                    {
                        // do empty block first
                        e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)pProps[index].arrColumnLefts[iCount], iTopMargin,
                                (int)pProps[index].arrColumnWidths[iCount], pProps[index].iHeaderHeight));

                        e.Graphics.DrawRectangle(Pens.Black,
                            new Rectangle((int)pProps[index].arrColumnLefts[iCount], iTopMargin,
                            (int)pProps[index].arrColumnWidths[iCount], pProps[index].iHeaderHeight));
                        iCount++;

                        // take care of other column headers
                        foreach (DataGridViewColumn GridCol in gridToPrint.Columns)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)pProps[index].arrColumnLefts[iCount], iTopMargin,
                                (int)pProps[index].arrColumnWidths[iCount], pProps[index].iHeaderHeight));

                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)pProps[index].arrColumnLefts[iCount], iTopMargin,
                                (int)pProps[index].arrColumnWidths[iCount], pProps[index].iHeaderHeight));

                            e.Graphics.DrawString(GridCol.HeaderText,
                                GridCol.InheritedStyle.Font,
                                new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                new RectangleF((int)pProps[index].arrColumnLefts[iCount] + marginShift, iTopMargin,
                                (int)pProps[index].arrColumnWidths[iCount], pProps[index].iHeaderHeight), strFormat);
                            iCount++;
                        }
                        bNewPage = false;
                        iTopMargin += pProps[index].iHeaderHeight;
                        needColHeader = false;
                    }
                    //}
                    iCount = 0;
                    // do row headers first
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                new Rectangle((int)pProps[index].arrColumnLefts[iCount], iTopMargin,
                                (int)pProps[index].arrColumnWidths[iCount], pProps[index].iCellHeight));
                    e.Graphics.DrawString(GridRow.HeaderCell.Value.ToString(),
                                GridRow.HeaderCell.InheritedStyle.Font,
                                new SolidBrush(GridRow.HeaderCell.InheritedStyle.ForeColor),
                                new RectangleF((int)pProps[index].arrColumnLefts[iCount] + marginShift,
                                (float)iTopMargin,
                                (int)pProps[index].arrColumnWidths[iCount], (float)pProps[index].iCellHeight),
                                strFormat);
                    e.Graphics.DrawRectangle(Pens.Black,
                            new Rectangle((int)pProps[index].arrColumnLefts[iCount], iTopMargin,
                            (int)pProps[index].arrColumnWidths[iCount], pProps[index].iCellHeight));
                    iCount++;
                    //Draw Columns Contents                
                    foreach (DataGridViewCell Cel in GridRow.Cells)
                    {
                        if (Cel.Value != null)
                        {
                            e.Graphics.DrawString(Cel.Value.ToString(),
                                Cel.InheritedStyle.Font,
                                new SolidBrush(Cel.InheritedStyle.ForeColor),
                                new RectangleF((int)pProps[index].arrColumnLefts[iCount] + marginShift,
                                (float)iTopMargin,
                                (int)pProps[index].arrColumnWidths[iCount] - 5, (float)pProps[index].iCellHeight),
                                strFormat);
                        }
                        //Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black,
                            new Rectangle((int)pProps[index].arrColumnLefts[iCount], iTopMargin,
                            (int)pProps[index].arrColumnWidths[iCount], pProps[index].iCellHeight));
                        iCount++;
                    }
                }
                pProps[index].iRow++;
                iTopMargin += pProps[index].iCellHeight;
            }
            //If more lines exist, print another page.
            if (bMorePagesToPrint)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

            return iTopMargin;

        }

        private void DPPMDataGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (departmentListBox.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select a single department for NC data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (CausedByYouDataGridview.SelectedCells[0].RowIndex == 0)
            {
                MessageBox.Show("Select a cell with a category type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Form ncdata = new NCData(departmentListBox.SelectedItem.ToString(), startDateTimePicker.Value.AddMonths(CausedByYouDataGridview.SelectedCells[0].ColumnIndex), (Status)((CausedByYouDataGridview.SelectedCells[0].RowIndex - 1) / 3), uni_connectionString);
            ncdata.ShowDialog();
        }

        private void previousOpDatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (departmentListBox.SelectedItems.Count != 1)
            {
                MessageBox.Show("Please select a single department for NC data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Form ncdata = new NCData(departmentListBox.SelectedItem.ToString(), startDateTimePicker.Value.AddMonths(previousOpDatagridview.SelectedCells[0].ColumnIndex), Status.CausedAtPreviousOp, uni_connectionString);
            ncdata.ShowDialog();
        }

        private void printFormButton_Click(object sender, EventArgs e)
        {
            // check that something is selecetd
            if (departmentListBox.SelectedItems.Count == 0)
                return;

            //
            // create dictionaries to submit
            //
            // departments lists
            List<string> departments = new List<string>();
            for (int i = 0; i < departmentListBox.SelectedItems.Count; i++)
                departments.Add(departmentListBox.SelectedItems[i].ToString());
            // found at subsequent data (DPPM and rejected qty)
            int DataColCount = CausedByYouDataGridview.Columns.Count;
            int FoundAtSubsequent_RejectedRow = 2;
            int FoundAtSubsequent_DPPMRow = 3;
            int FoundAtQuality_RejectedRow = 5;
            int FoundAtQuality_DPPMRow = 6;
            int FoundAtCustomer_RejectedRow = 8;
            int FoundAtCustomer_DPPMRow = 9;
            int FoundByYou_RejectedRow = 11;
            int FoundByYou_DPPMRow = 12;

            // create dictionaries
            Dictionary<string, double> foundAtSubsequentData = new Dictionary<string, double>();
            Dictionary<string, double> foundAtQualityData = new Dictionary<string, double>();
            Dictionary<string, double> foundAtCustData = new Dictionary<string, double>();
            Dictionary<string, double> foundByYouData = new Dictionary<string, double>();

            // insert data
            foundAtSubsequentData.Add("RejectedQty", double.Parse(CausedByYouDataGridview.Rows[FoundAtSubsequent_RejectedRow].Cells[DataColCount - 1].Value.ToString()));
            foundAtSubsequentData.Add("DPPM", double.Parse(CausedByYouDataGridview.Rows[FoundAtSubsequent_DPPMRow].Cells[DataColCount - 1].Value.ToString()));
            foundAtQualityData.Add("RejectedQty", double.Parse(CausedByYouDataGridview.Rows[FoundAtQuality_RejectedRow].Cells[DataColCount - 1].Value.ToString()));
            foundAtQualityData.Add("DPPM", double.Parse(CausedByYouDataGridview.Rows[FoundAtQuality_DPPMRow].Cells[DataColCount - 1].Value.ToString()));
            foundAtCustData.Add("RejectedQty", double.Parse(CausedByYouDataGridview.Rows[FoundAtCustomer_RejectedRow].Cells[DataColCount - 1].Value.ToString()));
            foundAtCustData.Add("DPPM", double.Parse(CausedByYouDataGridview.Rows[FoundAtCustomer_DPPMRow].Cells[DataColCount - 1].Value.ToString()));
            foundByYouData.Add("RejectedQty", double.Parse(CausedByYouDataGridview.Rows[FoundByYou_RejectedRow].Cells[DataColCount - 1].Value.ToString()));
            foundByYouData.Add("DPPM", double.Parse(CausedByYouDataGridview.Rows[FoundByYou_DPPMRow].Cells[DataColCount - 1].Value.ToString()));

            Form DPPMPrintForm = new PrintDPPMForm(departments, startDateTimePicker.Value, foundAtSubsequentData, foundAtQualityData, foundAtCustData, foundByYouData, this.wc_chart, this.monthlyDPPM_Chart, int.Parse(CausedByYouDataGridview.Rows[0].Cells[DataColCount - 1].Value.ToString()), uni_connectionString, double.Parse(totalDPPM.Text), ownerLabel.Text, owner2Label.Text, leadLabel.Text);
            DPPMPrintForm.ShowDialog();
        }

        private void setGoalsButton_Click(object sender, EventArgs e)
        {
            // first get their password
            bool passwordCorrect = PasswordPrompt.ShowDialog("Please enter password", "Password");

            if (passwordCorrect)
            {
                Form SetGoalsForm = new Goals();
                SetGoalsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Password does not match records");
            }
        }

        private void printNCFormButton_Click(object sender, EventArgs e)
        {
            // check that something is selected
            if (departmentListBox.SelectedItems.Count == 0)
                return;

            List<string> departments = new List<string>();

            foreach (var selected_department in departmentListBox.SelectedItems)
                departments.Add(selected_department.ToString());

            Form NCPrintForm = new PrintNCForm(uni_connectionString, departments);
            NCPrintForm.ShowDialog();
        }

        private void workCenterListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            departmentListBox.Enabled = false;
            workCenterListBox.Enabled = false;
            departmentListBox.SelectedIndexChanged -= this.departmentListBox_SelectedIndexChanged;

            vals_escaped.Clear();
            vals_caught.Clear();

            if (workCenterListBox.SelectedItem == null)
            {
                CausedByYouDataGridview.DataSource = null;
                CausedByYouDataGridview.Rows.Clear();
                previousOpDatagridview.DataSource = null;
                previousOpDatagridview.Rows.Clear();
                totalDPPM.Text = "";
                ownerLabel.Text = "";
                leadLabel.Text = "";
                wc_chart.Series.Clear();
                ncCountChart.Series.Clear();
                monthlyDPPM_Chart.Series.Clear();
                departmentListBox.Enabled = true;
                workCenterListBox.Enabled = true;
                return;
            }

            List<string> departments = new List<string>();

            foreach (var item in departmentListBox.SelectedItems)
                departments.Add(item.ToString());

            using (OdbcConnection conn = new OdbcConnection(uni_connectionString))
            {
                conn.Open();

                string workCentersList = string.Empty;

                foreach (var wc in workCenterListBox.SelectedItems)
                    workCentersList += "'" + wc.ToString() + "',";
                // remove last comma
                if (workCentersList.Length > 0)
                    workCentersList = workCentersList.Substring(0, workCentersList.Length - 1);

                // select departments
                string departmentquery = "SELECT DISTINCT Department\n" +
                                "FROM Production.dbo.Work_Center\n" +
                                "WHERE Work_Center IN (" + workCentersList + ");";
                OdbcCommand command = new OdbcCommand(departmentquery, conn);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    if (!reader.IsDBNull(0))
                    {
                        int index = departmentListBox.FindString(reader.GetString(0));
                        departmentListBox.SelectedIndices.Add(index);
                    }



                // nc select statement 
                string ncselectStatement = "COUNT(uni.NCR),\n" +
                                    "SUM(uni.Qty_rejected)";
                numOfMonths = ((endDateTimePicker.Value.Year - startDateTimePicker.Value.Year) * 12) + endDateTimePicker.Value.Month - startDateTimePicker.Value.Month; // do not include current month
                if (numOfMonths > 0)
                    ncselectStatement += ",\n";
                else
                    ncselectStatement += "\n";
                DateTime monthlyDate;
                DateTime highDateLimit;
                for (int i = -2; i < numOfMonths - 2; i++)
                {
                    monthlyDate = endDateTimePicker.Value.AddMonths(i - numOfMonths + 2).AddDays(-endDateTimePicker.Value.Day + 1);
                    highDateLimit = monthlyDate.AddDays(DateTime.DaysInMonth(monthlyDate.Year, monthlyDate.Month) - 1);
                    ncselectStatement += "SUM(CASE WHEN(uni.NCR_Date >= '" + monthlyDate.ToShortDateString() + " 12:00:00 AM" + "' AND uni.NCR_Date <= '" + highDateLimit.ToShortDateString() + " 11:59:59 PM" + "') THEN 1 ELSE 0 END),\n";
                    ncselectStatement += "SUM(CASE WHEN(uni.NCR_Date >= '" + monthlyDate.ToShortDateString() + " 12:00:00 AM" + "' AND uni.NCR_Date <= '" + monthlyDate.AddDays(DateTime.DaysInMonth(monthlyDate.Year, monthlyDate.Month) - 1).ToShortDateString() + " 11:59:59 PM" + "') THEN uni.Qty_rejected ELSE 0 END)";
                    if (i != numOfMonths - 3)
                        ncselectStatement += ",\n";
                }

                // job select statement
                string jobselectStatement = "SUM(CASE WHEN (jboss.Actual_Start >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND jboss.Actual_Start <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "') THEN jboss.Act_Run_Qty ELSE 0 END)";
                if (numOfMonths > 0)
                    jobselectStatement += ",\n";
                else
                    jobselectStatement += "\n";
                for (int i = -2; i < numOfMonths - 2; i++)
                {
                    monthlyDate = endDateTimePicker.Value.AddMonths(i - numOfMonths + 2).AddDays(-endDateTimePicker.Value.Day + 1);
                    highDateLimit = monthlyDate.AddDays(DateTime.DaysInMonth(monthlyDate.Year, monthlyDate.Month) - 1);
                    jobselectStatement += "SUM(CASE WHEN(jboss.Actual_Start >= '" + monthlyDate.ToShortDateString() + " 12:00:00 AM" + "' AND jboss.Actual_Start <= '" + highDateLimit.ToShortDateString() + " 11:59:59 PM" + "') THEN jboss.Act_Run_Qty ELSE 0 END)";
                    if (i != numOfMonths - 3)
                        jobselectStatement += ",\n";
                }

                //
                // actual count of parts ran
                //
                string query = "SELECT " + jobselectStatement + "\n" +
                        "FROM PRODUCTION.dbo.Job_Operation AS jboss\n" +
                        "WHERE jboss.Work_Center IN\n" + // origination filters
                            "(SELECT jb.Work_Center\n" +
                            "FROM Production.dbo.Work_Center AS jb\n" +
                            "WHERE jb.Department IN ('" + string.Join("','", departments) + "'))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                int actualCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                int[] monthly_actualCount = new int[numOfMonths];
                for (int i = 1; i < numOfMonths + 1; i++)
                    monthly_actualCount[i - 1] = reader.IsDBNull(i) ? 0 : reader.GetInt32(i);

                // Found at subsequent operation
                query = "SELECT " + ncselectStatement + "\n" +
                                "FROM uniPoint_Live.dbo.PT_NC AS uni\n" +
                                "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND ((uni.Work_Center IS NULL OR uni.Work_Center NOT IN (" + workCentersList + ")) AND uni.Work_Center <> '16-QUALITY' AND (uni.Department IS NULL OR uni.Department NOT IN ('" + string.Join("','", departments) + "'))) " + // origination filters
                                    "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                int ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                double rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_escaped.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_escaped[0].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_escaped[0].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_escaped[0].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                // found at quality
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center = '16-QUALITY') " + // origination filters
                            "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_escaped.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_escaped[1].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_escaped[1].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_escaped[1].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                // found at customer
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "'  AND uni.NC_Type = 'Customer' " + // origination filters
                            "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_escaped.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_escaped[2].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_escaped[2].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_escaped[2].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                // ===========================================================================

                //non-conformace cause by you
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center IN (" + workCentersList + ") OR uni.Department IN ('" + string.Join("','", departments) + "')) " + // origination filters
                            "AND (uni.Origin_ref IN ('" + string.Join("','", departments) + "') OR uni.Origin_ref IN (" + workCentersList + "))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_caught.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_caught[0].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_caught[0].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_caught[0].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                //non conformance cause by previous opearation
                query = "SELECT " + ncselectStatement + "\n" +
                        "FROM uniPoint_Live.dbo.PT_NC AS uni " +
                        "WHERE uni.Disposition <> 'No Defect' AND NCR_Date >= '" + endDateTimePicker.Value.AddMonths(-numOfMonths).AddDays(-endDateTimePicker.Value.Day + 1).ToShortDateString() + " 12:00:00 AM" + "' AND NCR_Date <= '" + endDateTimePicker.Value.AddDays(-endDateTimePicker.Value.Day).ToShortDateString() + " 11:59:59 PM" + "' AND uni.NC_Type = 'In Process' AND (uni.Work_Center IN (" + workCentersList + ") OR uni.Department IN ('" + string.Join("','", departments) + "')) " + // origination filters
                            "AND ((uni.Origin_ref IS NULL OR uni.Origin_ref NOT IN ('" + string.Join("','", departments) + "')) AND (uni.Origin_ref IS NULL OR uni.Origin_ref NOT IN (" + workCentersList + ")))"; // investigation filters
                command = new OdbcCommand(query, conn);
                reader = command.ExecuteReader();

                reader.Read();

                ncCount = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                rejectCount = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                vals_caught.Add(new DataRow(ncCount, rejectCount, actualCount));
                for (int i = 1; i < numOfMonths + 1; i++)
                {
                    vals_caught[1].monthly_NC_Count.Add(reader.IsDBNull(i * 2) ? 0 : reader.GetInt32(i * 2));
                    vals_caught[1].monthly_Rejected_Qty.Add(reader.IsDBNull(i * 2 + 1) ? 0 : reader.GetDouble(i * 2 + 1));
                    vals_caught[1].monthly_Ran_Qty.Add(monthly_actualCount[i - 1]);
                }

                reader.Read(); // exhaust reader

                //
                // TRIPLE GRAPHS
                //
                Fill_DPPMGraph();
                Fill_CountGraph();
                Fill_WCGraph();

                Fill_MainChart();
                Fill_SubOpChart();

                departmentListBox.SelectedIndexChanged += this.departmentListBox_SelectedIndexChanged;
                departmentListBox.Enabled = true;
                workCenterListBox.Enabled = true;
            }
        }
    }
}
