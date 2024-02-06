using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isabike
{
    public partial class ProductOperationsForm : Form
    {
        public ProductOperationsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:8000/termekek";
            string jsonData = "{ " +
                " \"termek_kateg\":" + "\"" + categoryBox.SelectedText + "\"," +
                " \"termek_nev\":" + "\"" + productName.Text + "\"," +
                " \"gyarto_id\":" + "\"" + manufactererBox.SelectedText + "\"," +
                "\"raktarondb\": \"4\"," +
                "\"tomeg_tulajdonsaga_id\": \"1\"," +
                "\"tomeg_erteke\":" + "\"" + suly_textbox.Text + "\"," +
                "\"szine\": \"pink\"," +
                "\"leiras\": \"Added via desktop\"," +
                "\"egyseg_ar\": \"420\"," +
                "\"elerheto\": \"true\"," +
                "}";

            PostData(url, jsonData).Wait(5);
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
    }
}
