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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void selectOrderBtn_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = ordersDataView.SelectedCells[0].RowIndex;
            int selectedColumnIndex = 0;

            object selectedCellValue = ordersDataView[selectedColumnIndex, selectedRowIndex].Value;

            OrderedItemsForm orderedItemsForm = new OrderedItemsForm(Convert.ToInt32(selectedCellValue));
            orderedItemsForm.ShowDialog();

        }

        private void populeOrdersView()
        {
            ordersDataView.DataSource = DbConnect.getOrderData(Login.getToken(), "http://127.0.0.1:8000/api/getallrendeles");
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            populeOrdersView();
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
