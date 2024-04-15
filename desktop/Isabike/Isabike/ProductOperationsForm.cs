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
        int ProductId;

        bool isUpdate = false;

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

        public ProductOperationsForm(int termekId, string termekNev,
                                 int raktarondb, double tomegErteke,
                                 string szine, string leiras, int egysegAr)
        {
            InitializeComponent();
            productNameText.Text = termekNev;
            productCountText.Text = raktarondb.ToString();
            productWeightText.Text = tomegErteke.ToString();
            productColorText.Text = szine;
            productDescText.Text = leiras;
            productPriceText.Text = egysegAr.ToString();
            ProductId = termekId;
            isUpdate = true;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
                if (!isUpdate) {
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
                            egyseg_ar = Convert.ToInt32(productPriceText.Text)
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
                else
                {
                    try
                    {
                        var jsonString = new
                        {
                            token = Login.getToken(),
                            termek_id = ProductId,
                            termek_kateg = Convert.ToInt32(productCategoryBox.SelectedValue),
                            termek_nev = productNameText.Text,
                            gyarto_id = Convert.ToInt32(productManufactererBox.SelectedValue),
                            raktarondb = Convert.ToInt32(productCountText.Text),
                            tomeg_tulajdonsaga_id = Convert.ToInt32(productWeightclassBox.SelectedValue),
                            tomeg_erteke = Convert.ToDouble(productWeightText.Text),
                            szine = productColorText.Text,
                            leiras = productDescText.Text,
                            egyseg_ar = Convert.ToInt32(productPriceText.Text)
                        };
                        string json = JsonConvert.SerializeObject(jsonString);
                        DbOperations db = new DbOperations();
                        db.updateProduct(json, "http://127.0.0.1:8000/api/updatetermek");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                        throw;
                    }
                
                }
                
            
        }

        private void ProductOperationsForm_Load(object sender, EventArgs e)
        {
            populateGyarto("http://127.0.0.1:8000/api/gyartok");
            populateKategoria("http://127.0.0.1:8000/api/kategoriak");
            populateTomeg("http://127.0.0.1:8000/api/tomegtulajdonsagok");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.MaximizeBox = false;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void productCountText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void productPriceText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void productWeightText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }


}
