using Newtonsoft.Json.Linq;
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

        public void populateTomeg(string uri)
        {
            productWeightclassBox.DataSource = DbConnect.getData(uri);
            productWeightclassBox.ValueMember = "tomeg_tulajdonsaga_id";
            productWeightclassBox.DisplayMember = "mertek_egysege";
        }

        public void populateGyarto(string uri)
        {
            productManufactererBox.DataSource = DbConnect.getData(uri);
            productManufactererBox.ValueMember = "gyarto_id";
            productManufactererBox.DisplayMember = "gyarto_neve";
        }

        public void populateKategoria(string uri)
        {
            productCategoryBox.DataSource = DbConnect.getData(uri);
            productCategoryBox.ValueMember = "kategoria_id";
            productCategoryBox.DisplayMember = "kategoria_neve";
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
            try
            {
                var jsonString = new
                 {
                    token = Login.getToken(),
                    termek_kateg = Convert.ToInt32(productCategoryBox.SelectedValue),
                    termek_nev = productNameText.Text,
                    gyarto_id = Convert.ToInt32(productManufactererBox.SelectedValue),
                    raktarondb = Convert.ToInt32(productCountText.Text),
                    tomeg_tulajdonsaga_id = Convert.ToInt32(productWeightclassBox.SelectedValue),
                    tomeg_erteke = Convert.ToDouble(productWeightText.Text),
                    szine = productColorText.Text,
                    leiras = productDescText.Text,
                    egyseg_ar = Convert.ToInt32(productPriceText.Text),
                    elerheto = productAvelableBox.Checked
                  };
                  string json = JsonConvert.SerializeObject(jsonString);
                  DbOperations.addProduct(json, "http://127.0.0.1:8000/api/addtermek");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                throw;
            }
        }

        private void ProductOperationsForm_Load(object sender, EventArgs e)
        {
            populateGyarto("http://127.0.0.1:8000/api/gyartok");
            populateKategoria("http://127.0.0.1:8000/api/kategoriak");
            populateTomeg("http://127.0.0.1:8000/api/tomegtulajdonsagok");
        }

    }
}
