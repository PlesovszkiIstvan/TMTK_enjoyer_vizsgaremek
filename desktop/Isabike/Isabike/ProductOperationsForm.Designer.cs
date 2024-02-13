namespace Isabike
{
    partial class ProductOperationsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductOperationsForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addToolstripBtn = new System.Windows.Forms.ToolStripButton();
            this.modifyToolstripBtn = new System.Windows.Forms.ToolStripButton();
            this.deactivateToolstripBtn = new System.Windows.Forms.ToolStripButton();
            this.closeBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.productManufactererBox = new System.Windows.Forms.ComboBox();
            this.productCategoryBox = new System.Windows.Forms.ComboBox();
            this.productWeightText = new System.Windows.Forms.TextBox();
            this.productNameText = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolstripBtn,
            this.modifyToolstripBtn,
            this.deactivateToolstripBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(338, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addToolstripBtn
            // 
            this.addToolstripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addToolstripBtn.Image = ((System.Drawing.Image)(resources.GetObject("addToolstripBtn.Image")));
            this.addToolstripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addToolstripBtn.Name = "addToolstripBtn";
            this.addToolstripBtn.Size = new System.Drawing.Size(23, 22);
            this.addToolstripBtn.Text = "Add";
            // 
            // modifyToolstripBtn
            // 
            this.modifyToolstripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.modifyToolstripBtn.Image = ((System.Drawing.Image)(resources.GetObject("modifyToolstripBtn.Image")));
            this.modifyToolstripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modifyToolstripBtn.Name = "modifyToolstripBtn";
            this.modifyToolstripBtn.Size = new System.Drawing.Size(23, 22);
            this.modifyToolstripBtn.Text = "Modify Product";
            // 
            // deactivateToolstripBtn
            // 
            this.deactivateToolstripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deactivateToolstripBtn.Image = ((System.Drawing.Image)(resources.GetObject("deactivateToolstripBtn.Image")));
            this.deactivateToolstripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deactivateToolstripBtn.Name = "deactivateToolstripBtn";
            this.deactivateToolstripBtn.Size = new System.Drawing.Size(23, 22);
            this.deactivateToolstripBtn.Text = "Delete Product";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(12, 429);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(95, 47);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Cancel";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(231, 429);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(95, 47);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // productManufactererBox
            // 
            this.productManufactererBox.FormattingEnabled = true;
            this.productManufactererBox.Location = new System.Drawing.Point(12, 153);
            this.productManufactererBox.Name = "productManufactererBox";
            this.productManufactererBox.Size = new System.Drawing.Size(183, 21);
            this.productManufactererBox.TabIndex = 11;
            this.productManufactererBox.Text = "Gyarto1";
            // 
            // productCategoryBox
            // 
            this.productCategoryBox.FormattingEnabled = true;
            this.productCategoryBox.Items.AddRange(new object[] {
            "Kategoria1",
            "Kategoria2",
            "Kategoria3"});
            this.productCategoryBox.Location = new System.Drawing.Point(12, 114);
            this.productCategoryBox.Name = "productCategoryBox";
            this.productCategoryBox.Size = new System.Drawing.Size(183, 21);
            this.productCategoryBox.TabIndex = 10;
            this.productCategoryBox.Text = "Kategoria1";
            // 
            // productWeightText
            // 
            this.productWeightText.Location = new System.Drawing.Point(12, 78);
            this.productWeightText.Name = "productWeightText";
            this.productWeightText.Size = new System.Drawing.Size(160, 20);
            this.productWeightText.TabIndex = 9;
            this.productWeightText.Text = "Suly";
            // 
            // productNameText
            // 
            this.productNameText.Location = new System.Drawing.Point(12, 40);
            this.productNameText.Name = "productNameText";
            this.productNameText.Size = new System.Drawing.Size(160, 20);
            this.productNameText.TabIndex = 8;
            this.productNameText.Text = "Termek neve";
            // 
            // ProductOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 488);
            this.Controls.Add(this.productManufactererBox);
            this.Controls.Add(this.productCategoryBox);
            this.Controls.Add(this.productWeightText);
            this.Controls.Add(this.productNameText);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProductOperationsForm";
            this.Text = "ProductOperationsForm";
            this.Load += new System.EventHandler(this.ProductOperationsForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addToolstripBtn;
        private System.Windows.Forms.ToolStripButton modifyToolstripBtn;
        private System.Windows.Forms.ToolStripButton deactivateToolstripBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox productManufactererBox;
        private System.Windows.Forms.ComboBox productCategoryBox;
        private System.Windows.Forms.TextBox productWeightText;
        private System.Windows.Forms.TextBox productNameText;
    }
}