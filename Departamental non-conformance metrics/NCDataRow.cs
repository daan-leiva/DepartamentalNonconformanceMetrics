using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamental_non_conformance_metrics
{
    class NCDataRow
    {
        public string NCNumber { get; set; }
        public DateTime NCDate {get; set;}
        public string NCStatus {get; set;}
        public string PartNumber { get; set; }
        public string Description {get; set;}
        public string NCType {get; set;}
        public string JobNumber { get; set; }
        public double RejectedQuantity { get; set; }

        public NCDataRow(string NC, DateTime ncDate, string status, string part, string description, string type, string job, double rejectedCount)
        {
            this.NCNumber = NC;
            this.NCDate = ncDate;
            this.NCStatus = status;
            this.PartNumber = part;
            this.Description = description;
            this.NCType = type;
            this.JobNumber = job;
            this.RejectedQuantity = rejectedCount;
        }
    }
}