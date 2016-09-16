using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Departamental_non_conformance_metrics
{
    public class DataRow
    {
        public int NC_Count { get; set; }
        public double Rejected_Qty { get; set; }
        public int Actual_Qty { get; set; }
        public double DPPM { get; set; }
        public List<int> monthly_Ran_Qty = new List<int>();
        public List<int> monthly_NC_Count = new List<int>();
        public List<double> monthly_Rejected_Qty = new List<double>();
        public List<double> WCs_Scrap_Qty = new List<double>();
        public List<int> WCs_Total_Qty = new List<int>();

        public DataRow(int nc_count, double scrap_Qty, int actual_Qty)
        {
            this.NC_Count = nc_count;
            this.Rejected_Qty = scrap_Qty;
            this.Actual_Qty = actual_Qty;
            this.DPPM = actual_Qty == 0 ? 0 : Math.Round(scrap_Qty / ((double)actual_Qty) * 1000000, 0);
        }   

        public List<double> getDPPM_monthly()
        {
            List<double> DPPMs = new List<double>();

            if (monthly_Ran_Qty.Count != monthly_Rejected_Qty.Count)
                MessageBox.Show("Internal count error. Contact IT");
            for (int i = 0; i < monthly_Rejected_Qty.Count; i++)
                if (monthly_Ran_Qty[i] == 0)
                    DPPMs.Add(0);
                else
                    DPPMs.Add(Math.Round(monthly_Rejected_Qty[i] / ((double)monthly_Ran_Qty[i]) * 1000000, 0));

            return DPPMs;
        }

        public List<double> getDPPM_WCs()
        {
            List<double> DPPMs = new List<double>();

            for (int i = 0; i < WCs_Total_Qty.Count; i++)
                if (WCs_Total_Qty[i] == 0)
                    DPPMs.Add(0);
                else
                    DPPMs.Add(Math.Round(WCs_Scrap_Qty[i] / ((double)WCs_Total_Qty[i]) * 1000000, 0));

            return DPPMs;
        }
    }
}