using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private string token {get;set;}

        private bool gridState = false;
        // false = termekek | true = velemenyek

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

        }


        private void button1_Click(object sender, EventArgs e)
        {
            ProductOperationsForm productOperationsForm = new ProductOperationsForm();
            productOperationsForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DbConnect.logOut(Login.getToken(), "http://172.16.16.157:8000/api/logout");
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
        }

        private void SalesBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void connectToDB(bool isSales)
        {
            manufactererBox.DataSource = DbConnect.getData("http://172.16.16.157:8000/api/gyartok");
            manufactererBox.ValueMember = "gyarto_id";
            manufactererBox.DisplayMember = "gyarto_neve";
            categoryBox.DataSource = DbConnect.getData("http://172.16.16.157:8000/api/kategoria");
            categoryBox.ValueMember = "kategoria_id";
            categoryBox.DisplayMember = "kategoria_neve";

            if (viewGrid.Rows.Count > 0) {
                viewGrid.Rows.Clear();
                viewGrid.Columns.Clear();
            }
            if (!isSales) {
                //CreateConnection("192.168.1.103","3306","desktopUser","desktopadmin","isabike");
                GetRESTData("http://172.16.16.157:8000/api/termekek/100");
            }
            else
            {
                //CreateConnection("192.168.1.103","3306","desktopUser","desktopadmin","isabike");
                GetRESTData("http://172.16.16.157:8000/api/getvelemenyek");
            }

            
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            viewGrid.Rows.Clear();
            viewGrid.Columns.Clear();
            viewGrid.DataSource = DbConnect.getFilteredData("http://172.16.16.157:8000/api/termekek/100", termeknevTextbox.Text,Convert.ToDouble(suly_textbox.Text),categoryBox.Text, manufactererBox.Text);
        }
    }
}
