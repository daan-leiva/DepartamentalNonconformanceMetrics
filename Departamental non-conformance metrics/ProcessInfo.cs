using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamental_non_conformance_metrics
{
    class ProcessInfo
    {
        public readonly string process;
        public readonly string owner;
        public readonly string owner2;
        public readonly string lead;
        public readonly string notes;

        public ProcessInfo(string process, string owner, string owner2, string lead, string notes)
        {
            this.process = process;
            this.owner = owner;
            this.owner2 = owner2;
            this.lead = lead;
            this.notes = notes;
        }
    }
}
