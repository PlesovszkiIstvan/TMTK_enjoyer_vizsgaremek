using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    public partial class OrderedItemsForm : Form
    {
        int orderId;

        public OrderedItemsForm(int id)
        {
            InitializeComponent();
            this.orderId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int selectedRowIndex = itemViewGrid.SelectedCells[0].RowIndex;
            int selectedColumnIndex = 0;

            object selectedCellValue = itemViewGrid[selectedColumnIndex, selectedRowIndex].Value;

            DbOperations db = new DbOperations();
            db.updateOrder("http://127.0.0.1:8000/api/updaterendelttermek/"+Convert.ToInt32(selectedCellValue));
            reloadData();
        }

        private void OrderedItemsForm_Load(object sender, EventArgs e)
        {
            itemViewGrid.DataSource = DbConnect.getOrderData("http://127.0.0.1:8000/api/getonerendelestermekek/"+orderId);
        }

        private void reloadData()
        {
            itemViewGrid.Rows.Clear();
            itemViewGrid.Columns.Clear();
            itemViewGrid.DataSource = DbConnect.getOrderData("http://127.0.0.1:8000/api/getonerendelestermekek/" + orderId);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MaximizeBox = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = 800;
            this.Height = 400;
        }
    }
}
