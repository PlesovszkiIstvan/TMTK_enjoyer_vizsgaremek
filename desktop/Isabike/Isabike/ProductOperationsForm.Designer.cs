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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.closeBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.productManufactererBox = new System.Windows.Forms.ComboBox();
            this.productCategoryBox = new System.Windows.Forms.ComboBox();
            this.productWeightText = new System.Windows.Forms.TextBox();
            this.productNameText = new System.Windows.Forms.TextBox();
            this.productCountText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.productWeightclassBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.productColorText = new System.Windows.Forms.TextBox();
            this.productDescText = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.productPriceText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.productAvelableBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(573, 343);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(127, 58);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "Cancel";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(573, 246);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(127, 58);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // productManufactererBox
            // 
            this.productManufactererBox.FormattingEnabled = true;
            this.productManufactererBox.Location = new System.Drawing.Point(147, 92);
            this.productManufactererBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productManufactererBox.Name = "productManufactererBox";
            this.productManufactererBox.Size = new System.Drawing.Size(243, 24);
            this.productManufactererBox.TabIndex = 11;
            // 
            // productCategoryBox
            // 
            this.productCategoryBox.FormattingEnabled = true;
            this.productCategoryBox.Location = new System.Drawing.Point(147, 60);
            this.productCategoryBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productCategoryBox.Name = "productCategoryBox";
            this.productCategoryBox.Size = new System.Drawing.Size(243, 24);
            this.productCategoryBox.TabIndex = 10;
            // 
            // productWeightText
            // 
            this.productWeightText.Location = new System.Drawing.Point(147, 154);
            this.productWeightText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productWeightText.Name = "productWeightText";
            this.productWeightText.Size = new System.Drawing.Size(212, 22);
            this.productWeightText.TabIndex = 9;
            // 
            // productNameText
            // 
            this.productNameText.Location = new System.Drawing.Point(147, 31);
            this.productNameText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productNameText.Name = "productNameText";
            this.productNameText.Size = new System.Drawing.Size(212, 22);
            this.productNameText.TabIndex = 8;
            // 
            // productCountText
            // 
            this.productCountText.Location = new System.Drawing.Point(147, 124);
            this.productCountText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productCountText.Name = "productCountText";
            this.productCountText.Size = new System.Drawing.Size(212, 22);
            this.productCountText.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Termék neve";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Kategória";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Gyártó";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Raktáron db szám";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Súly";
            // 
            // productWeightclassBox
            // 
            this.productWeightclassBox.FormattingEnabled = true;
            this.productWeightclassBox.Location = new System.Drawing.Point(147, 185);
            this.productWeightclassBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productWeightclassBox.Name = "productWeightclassBox";
            this.productWeightclassBox.Size = new System.Drawing.Size(243, 24);
            this.productWeightclassBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Súly mértéke";
            // 
            // productColorText
            // 
            this.productColorText.Location = new System.Drawing.Point(147, 217);
            this.productColorText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productColorText.Name = "productColorText";
            this.productColorText.Size = new System.Drawing.Size(212, 22);
            this.productColorText.TabIndex = 20;
            // 
            // productDescText
            // 
            this.productDescText.Location = new System.Drawing.Point(476, 30);
            this.productDescText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.productDescText.Name = "productDescText";
            this.productDescText.Size = new System.Drawing.Size(316, 210);
            this.productDescText.TabIndex = 22;
            this.productDescText.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Szine";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Leírás";
            // 
            // productPriceText
            // 
            this.productPriceText.Location = new System.Drawing.Point(147, 246);
            this.productPriceText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.productPriceText.Name = "productPriceText";
            this.productPriceText.Size = new System.Drawing.Size(212, 22);
            this.productPriceText.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Egységár";
            // 
            // productAvelableBox
            // 
            this.productAvelableBox.AutoSize = true;
            this.productAvelableBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.productAvelableBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.productAvelableBox.Location = new System.Drawing.Point(19, 327);
            this.productAvelableBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.productAvelableBox.Name = "productAvelableBox";
            this.productAvelableBox.Size = new System.Drawing.Size(106, 29);
            this.productAvelableBox.TabIndex = 27;
            this.productAvelableBox.Text = "Elérhető";
            this.productAvelableBox.UseVisualStyleBackColor = true;
            // 
            // ProductOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 409);
            this.Controls.Add(this.productAvelableBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.productPriceText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productDescText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.productColorText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.productWeightclassBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productCountText);
            this.Controls.Add(this.productManufactererBox);
            this.Controls.Add(this.productCategoryBox);
            this.Controls.Add(this.productWeightText);
            this.Controls.Add(this.productNameText);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductOperationsForm";
            this.Text = "ProductOperationsForm";
            this.Load += new System.EventHandler(this.ProductOperationsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox productManufactererBox;
        private System.Windows.Forms.ComboBox productCategoryBox;
        private System.Windows.Forms.TextBox productWeightText;
        private System.Windows.Forms.TextBox productNameText;
        private System.Windows.Forms.TextBox productCountText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox productWeightclassBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox productColorText;
        private System.Windows.Forms.RichTextBox productDescText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox productPriceText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox productAvelableBox;
    }
}