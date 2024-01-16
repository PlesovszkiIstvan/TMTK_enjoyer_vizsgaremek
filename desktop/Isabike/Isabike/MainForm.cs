using System;
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
            GetRESTData("http://localhost:8000/termekek");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
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
    }
}
