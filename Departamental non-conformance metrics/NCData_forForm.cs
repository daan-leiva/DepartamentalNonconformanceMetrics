using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamental_non_conformance_metrics
{
    class NCData_forForm
    {
        public string NCNumber { get; set; }
        public string NCDate { get; set; }
        public string NCWC { get; set; }
        public string PartNumber { get; set; }
        public string NCType { get; set; }
        public string JobNumber { get; set; }
        public double RejectedQuantity { get; set; }

        public NCData_forForm(string NC, string ncDate, string wc, string part, string type, string job, double rejectedCount)
        {
            this.NCNumber = NC;
            this.NCDate = ncDate;
            this.NCWC = wc;
            this.PartNumber = part;
            this.NCType = type;
            this.JobNumber = job;
            this.RejectedQuantity = rejectedCount;
        }
    }
}
