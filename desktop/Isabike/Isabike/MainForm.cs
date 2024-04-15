using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Isabike
{
    public partial class MainForm : Form
    {

        private bool gridState = false;
        // false = termekek | true = velemenyek

        int[] ColumnIndex = { 0, 1 };

        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            connectToDB(gridState);
            if (viewGrid.Columns["delete_column"] == null && viewGrid.Columns["update_column"] == null)
            {
                viewGrid.Columns.Insert(ColumnIndex[0], updateButtonColumn);
                viewGrid.Columns.Insert(ColumnIndex[1], deleteButtonColumn);

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ProductOperationsForm productOperationsForm = new ProductOperationsForm();
            productOperationsForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DbConnect.logOut(Login.getToken(), "http://127.0.0.1:8000/api/logout");
            Environment.Exit(0);
        }

        private void ReviewsBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No");

        }

        private void GetRESTData(string uri)
        {
            viewGrid.DataSource = DbConnect.getData(uri); 
        }

        DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
        {
            Name = "delete_column",
            Text = "Delete",
            HeaderText = "Delete"
        };

        DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
        {
            Name = "update_column",
            Text = "Update",
            HeaderText = "Update"
        };

        private void refreshBtn_Click(object sender, EventArgs e)
        {

            viewGridRefresh();
            if (viewGrid.Columns["delete_column"] == null && viewGrid.Columns["update_column"] == null)
            {
                viewGrid.Columns.Insert(ColumnIndex[0], updateButtonColumn);
                viewGrid.Columns.Insert(ColumnIndex[1], deleteButtonColumn);

            }

        }

        private void connectToDB(bool isSales)
        {

            if (viewGrid.Rows.Count > 0) {
                viewGrid.Rows.Clear();
                viewGrid.Columns.Clear();
            }
            GetRESTData("http://127.0.0.1:8000/api/termekek/100");      
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            viewGrid.Rows.Clear();
            viewGrid.Columns.Clear();
            viewGrid.DataSource = DbConnect.getFilteredData("http://127.0.0.1:8000/api/termekek/100", termeknevTextbox.Text);
            if (viewGrid.Columns["delete_column"] == null && viewGrid.Columns["update_column"] == null)
            {
                     viewGrid.Columns.Insert(ColumnIndex[0], updateButtonColumn);
                     viewGrid.Columns.Insert(ColumnIndex[1], deleteButtonColumn);

            }
            
        }

        private void viewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                try
                {
                    var json = new
                    {
                        termek_id = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[2].Value)
                    };
                    
                    string jsonString = JsonConvert.SerializeObject(json);
                    DbOperations dbOperations = new DbOperations();
                    dbOperations.deleteProduct(jsonString, "http://127.0.0.1:8000/api/deletetermek");
                    viewGridRefresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
                
            }
            if (e.ColumnIndex == 0)
            {
                try
                {

                    int termekId = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[2].Value);
                    int termekKateg = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[3].Value);
                    string termekNev = viewGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    int gyartoId = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[6].Value);
                    int raktarondb = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[10].Value);
                    int tomegTulajdonsagaId = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[11].Value);
                    double tomegErteke = Convert.ToDouble(viewGrid.Rows[e.RowIndex].Cells[13].Value);
                    string szine = viewGrid.Rows[e.RowIndex].Cells[14].Value.ToString();
                    string leiras = viewGrid.Rows[e.RowIndex].Cells[15].Value.ToString();
                    int egysegAr = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[16].Value);

                    ProductOperationsForm form = new ProductOperationsForm(
                        termekId, termekNev, raktarondb,
                        tomegErteke, szine, leiras, egysegAr);
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }

            }
        }

        private void UserBtn_Click(object sender, EventArgs e)
        {
            UserForm frm = new UserForm();
            frm.ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MaximizeBox = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Width = 602;
            this.Height = 651;
        }

        private void viewGridRefresh()
        {
            connectToDB(gridState);
            if (viewGrid.Columns["delete_column"] == null && viewGrid.Columns["update_column"] == null)
            {
                viewGrid.Columns.Insert(ColumnIndex[0], updateButtonColumn);
                viewGrid.Columns.Insert(ColumnIndex[1], deleteButtonColumn);
            }
            
        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.ShowDialog();
        }
    }
}
