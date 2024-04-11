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

        private bool gridState = true;
        // false = termekek | true = velemenyek

        int[] ColumnIndex = [0,1];

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
            connectToDB(true);
            if (ReviewsBtn.BackColor.Equals(Color.Green))
            {
                ReviewsBtn.BackColor = Color.Red;
                gridState = false;
                connectToDB(gridState);
            }
            else
            {
                ReviewsBtn.BackColor = Color.Green;
                gridState = true;
                connectToDB(gridState);
            }

        }

        private void GetRESTData(string uri)
        {
            viewGrid.DataSource = DbConnect.getData(uri); 
        }

        DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
        {
            Name = "delete_column",
            Text = "Delete"
        };
        DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
        {
            Name = "update_column",
            Text = "Update"
        };

        private void refreshBtn_Click(object sender, EventArgs e)
        {

            if (ReviewsBtn.BackColor.Equals(Color.Green))
            {
                gridState = true;
            }
            else
            {
                gridState = false;
            }
            connectToDB(gridState);
            if (viewGrid.Columns["delete_column"] == null && viewGrid.Columns["update_column"] == null)
            {
                viewGrid.Columns.Insert(ColumnIndex[0], updateButtonColumn);
                viewGrid.Columns.Insert(ColumnIndex[1], deleteButtonColumn);
                
            }
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void connectToDB(bool isSales)
        {
            manufactererBox.DataSource = DbConnect.getData("http://127.0.0.1:8000/api/gyartok");
            manufactererBox.ValueMember = "gyarto_id";
            manufactererBox.DisplayMember = "gyarto_neve";
            categoryBox.DataSource = DbConnect.getData("http://127.0.0.1:8000/api/kategoria");
            categoryBox.ValueMember = "kategoria_id";
            categoryBox.DisplayMember = "kategoria_neve";

            if (viewGrid.Rows.Count > 0) {
                viewGrid.Rows.Clear();
                viewGrid.Columns.Clear();
            }
            if (!isSales) {
                //CreateConnection("192.168.1.103","3306","desktopUser","desktopadmin","isabike");
                GetRESTData("http://127.0.0.1:8000/api/termekek/100");
            }
            else
            {
                //CreateConnection("192.168.1.103","3306","desktopUser","desktopadmin","isabike");
                GetRESTData("http://127.0.0.1:8000/api/getvelemenyek");
            }

            
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            viewGrid.Rows.Clear();
            viewGrid.Columns.Clear();
            viewGrid.DataSource = DbConnect.getFilteredData("http://127.0.0.1:8000/api/termekek/100", termeknevTextbox.Text,Convert.ToDouble(suly_textbox.Text), manufactererBox.Text);
            if (viewGrid.Columns["delete_column"] == null && viewGrid.Columns["update_column"] == null)
            {
                viewGrid.Columns.Insert(ColumnIndex[0], updateButtonColumn);
                viewGrid.Columns.Insert(ColumnIndex[1], deleteButtonColumn);

            }
        }

        private void viewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewGrid.Columns["delete_column"].Index)
            {
                try
                {
                    var json = new
                    {
                        termek_id = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[2].Value)
                    };
                    
                    string jsonString = JsonConvert.SerializeObject(json);
                    MessageBox.Show(jsonString);
                    DbOperations dbOperations = new DbOperations();
                    dbOperations.deleteProduct(jsonString, "http://127.0.0.1:8000/api/deletetermek");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
                
            }
            if (e.ColumnIndex == viewGrid.Columns["update_column"].Index)
            {
                try
                {
                    var jsonString = new
                    {
                        token = Login.getToken(),
                        termek_id = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[2].Value),
                        termek_kateg = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[3].Value),
                        termek_nev = viewGrid.Rows[e.RowIndex].Cells[5].Value,
                        gyarto_id = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[6].Value),
                        raktarondb = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[10].Value),
                        tomeg_tulajdonsaga_id = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[11].Value),
                        tomeg_erteke = Convert.ToDouble(viewGrid.Rows[e.RowIndex].Cells[13].Value),
                        szine = viewGrid.Rows[e.RowIndex].Cells[14].Value,
                        leiras = viewGrid.Rows[e.RowIndex].Cells[15].Value,
                        egyseg_ar = Convert.ToInt32(viewGrid.Rows[e.RowIndex].Cells[16].Value),
                        elerheto = viewGrid.Rows[e.RowIndex].Cells[17].Value
                    };
                    string json = JsonConvert.SerializeObject(jsonString);
                    MessageBox.Show(jsonString.ToString());
                    DbOperations dbOperations = new DbOperations();
                    dbOperations.updateProduct(json, "http://127.0.0.1:8000/api/updatetermek");
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
    }
}
