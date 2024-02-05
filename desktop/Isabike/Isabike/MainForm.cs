﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            //CreateConnection("192.168.1.103","3306","desktopUser","desktopadmin","isabike");
            GetRESTData("http://192.168.1.103:8000/api/termekek");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ProductOperationsForm productOperationsForm = new ProductOperationsForm();
            productOperationsForm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void GetRESTData(string uri)
        {
            
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (s.Length > 0))
                {
                    
                    var arr = JsonConvert.DeserializeObject<JArray>(s);
                    dataGridView1.DataSource = arr;
                }
                else
                {
                    MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            



            //Source: https://www.codeproject.com/Tips/712109/How-to-Get-REST-Data-and-Display-it-in-a-DataGridV
        }

        private void CreateConnection(string ip,string port,string uid,string pwd,string database)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;


            myConnectionString = 
                "server=" + ip +
                ";port=" + port +
                ";uid=" + uid + 
                ";pwd=" + pwd +
                ";database=" + database;

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MessageBox.Show("Sikeres csatlakozás!");
                MySQL_ToDatagridview(myConnectionString);


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MySQL_ToDatagridview(string con)
        {
            MySqlConnection mysqlCon = new

            MySqlConnection(con);
            mysqlCon.Open();

            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "CALL get_termekek_procedure();";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;


            dataGridView1.DataSource = bSource;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            GetRESTData("http://192.168.1.103:8000/api/termekek");
        }
    }
}
