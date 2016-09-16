using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Departamental_non_conformance_metrics
{
    [Serializable]
    public class Goal
    {
        public string department;
        public int goal;

        public Goal(string _department, int _goal)
        {
            this.department = _department;
            this.goal = _goal;
        }

        public Goal()
        {
            department = "";
            goal = 0;
        }
    }
}