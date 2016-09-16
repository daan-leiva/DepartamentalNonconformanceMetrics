using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Departamental_non_conformance_metrics
{
    public class PrintProperties
    {
        
        public List<int> arrColumnLefts = new List<int>();
        public List<int> arrColumnWidths = new List<int>();
        public int iCellHeight;
        public int iCount;
        public int iTotalWidth;
        public int iHeaderHeight;
        public int iRow = 0;
        public DataGridView gridToPrint;
    }
}
