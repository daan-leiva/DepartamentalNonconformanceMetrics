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

namespace Departamental_non_conformance_metrics
{
    public partial class PrintWCMonthlyDPPMForm : Form
    {
        // connection variables
        private readonly static string uni_DSN = "uniPointDB";
        private readonly static string username = "jbread";
        private readonly static string password = "Cloudy2Day";
        string uni_connectionString = "DSN=" + uni_DSN + ";UID=" + username + ";PWD=" + password;
        // global variables
        List<string> departments;
        DateTime date;
        List<string> WCs;

        public PrintWCMonthlyDPPMForm(List<string> departments, DateTime date)
        {
            InitializeComponent();

            // deep copy all values
            this.departments = departments.ToList<string>();
            this.date = date;
        }

        private void PrintWCMonthlyDPPMForm_Load(object sender, EventArgs e)
        {
            using (OdbcConnection conn = new OdbcConnection(uni_connectionString))
            {
                // connect and query monthly values
                string getWCSubQuery = "SELECT jb.Work_Center " +
                                            "FROM Production.dbo.Work_Center AS jb " +
                                            "WHERE jb.Department IN ('" + string.Join("','", departments) + "')";

                OdbcCommand com = new OdbcCommand(getWCSubQuery, conn);
                OdbcDataReader dbReader = com.ExecuteReader();
            }
        }
    }
}
