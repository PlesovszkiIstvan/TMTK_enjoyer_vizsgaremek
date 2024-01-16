using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    internal class Class1
    {
        public Class1() {}

        public void fillTable(DataGridView view) {
            for (int i = 1; i < 6; i++)
            {
                view.Columns.Add(i+". Oszlop", i + ". Oszlop");
                view.Rows.Add();
            }
            
        }
    }
}
