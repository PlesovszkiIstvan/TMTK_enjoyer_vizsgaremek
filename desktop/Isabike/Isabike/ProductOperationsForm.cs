﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    public partial class ProductOperationsForm : Form
    {



        public void populateGyarto(string uri)
        {
            productManufactererBox.DataSource = DbConnect.getData(uri);
            productManufactererBox.ValueMember = "gyarto_id";
            productManufactererBox.DisplayMember = "gyarto_neve";
        }

        public void pupulateKategoria(string uri)
        {
            productCategoryBox.DataSource = DbConnect.getData(uri);
            productCategoryBox.ValueMember = "gyarto_id";
            productCategoryBox.DisplayMember = "gyarto_neve";
        }
        public ProductOperationsForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            
        }

        static async Task PostData(string apiUrl, string jsonData)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Create the content to be sent
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Make the POST request and get the response
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("sikeres feltöltés!", "Sikeres feltöltés");
                    }
                    else
                    {
                        MessageBox.Show(response.StatusCode.ToString() + " | " + response.ReasonPhrase, "Hiba!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Hiba!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProductOperationsForm_Load(object sender, EventArgs e)
        {
            populateGyarto("http://172.16.16.157:8000/api/gyartok");
        }
    }
}
