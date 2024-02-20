namespace Isabike
{
    partial class MainForm
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
            this.viewGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filterBtn = new System.Windows.Forms.Button();
            this.manufactererBox = new System.Windows.Forms.ComboBox();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.suly_textbox = new System.Windows.Forms.TextBox();
            this.termeknevTextbox = new System.Windows.Forms.TextBox();
            this.ReviewsBtn = new System.Windows.Forms.Button();
            this.SalesBtn = new System.Windows.Forms.Button();
            this.productBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewGrid
            // 
            this.viewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewGrid.Location = new System.Drawing.Point(13, 58);
            this.viewGrid.Name = "viewGrid";
            this.viewGrid.Size = new System.Drawing.Size(546, 380);
            this.viewGrid.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.filterBtn);
            this.panel1.Controls.Add(this.manufactererBox);
            this.panel1.Controls.Add(this.categoryBox);
            this.panel1.Controls.Add(this.suly_textbox);
            this.panel1.Controls.Add(this.termeknevTextbox);
            this.panel1.Location = new System.Drawing.Point(565, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 159);
            this.panel1.TabIndex = 4;
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(4, 126);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(97, 23);
            this.filterBtn.TabIndex = 8;
            this.filterBtn.Text = "Filter";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // manufactererBox
            // 
            this.manufactererBox.FormattingEnabled = true;
            this.manufactererBox.Items.AddRange(new object[] {
            "Gyarto1",
            "Gyarto2",
            "Gyarto3"});
            this.manufactererBox.Location = new System.Drawing.Point(3, 82);
            this.manufactererBox.Name = "manufactererBox";
            this.manufactererBox.Size = new System.Drawing.Size(121, 21);
            this.manufactererBox.TabIndex = 7;
            this.manufactererBox.Text = "Gyarto";
            // 
            // categoryBox
            // 
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Items.AddRange(new object[] {
            "Kategoria1",
            "Kategoria2",
            "Kategoria3"});
            this.categoryBox.Location = new System.Drawing.Point(3, 55);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(121, 21);
            this.categoryBox.TabIndex = 6;
            this.categoryBox.Text = "Kategoria";
            // 
            // suly_textbox
            // 
            this.suly_textbox.Location = new System.Drawing.Point(3, 29);
            this.suly_textbox.Name = "suly_textbox";
            this.suly_textbox.Size = new System.Drawing.Size(98, 20);
            this.suly_textbox.TabIndex = 1;
            this.suly_textbox.Text = "Suly";
            this.suly_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // termeknevTextbox
            // 
            this.termeknevTextbox.Location = new System.Drawing.Point(3, 3);
            this.termeknevTextbox.Name = "termeknevTextbox";
            this.termeknevTextbox.Size = new System.Drawing.Size(98, 20);
            this.termeknevTextbox.TabIndex = 0;
            this.termeknevTextbox.Text = "Termek neve";
            // 
            // ReviewsBtn
            // 
            this.ReviewsBtn.BackColor = System.Drawing.Color.Red;
            this.ReviewsBtn.Location = new System.Drawing.Point(565, 233);
            this.ReviewsBtn.Name = "ReviewsBtn";
            this.ReviewsBtn.Size = new System.Drawing.Size(96, 39);
            this.ReviewsBtn.TabIndex = 5;
            this.ReviewsBtn.Text = "Reviews";
            this.ReviewsBtn.UseVisualStyleBackColor = false;
            this.ReviewsBtn.Click += new System.EventHandler(this.ReviewsBtn_Click);
            // 
            // SalesBtn
            // 
            this.SalesBtn.BackColor = System.Drawing.Color.Red;
            this.SalesBtn.Location = new System.Drawing.Point(115, 13);
            this.SalesBtn.Name = "SalesBtn";
            this.SalesBtn.Size = new System.Drawing.Size(96, 39);
            this.SalesBtn.TabIndex = 6;
            this.SalesBtn.Text = "Sales";
            this.SalesBtn.UseVisualStyleBackColor = false;
            this.SalesBtn.Click += new System.EventHandler(this.SalesBtn_Click);
            // 
            // productBtn
            // 
            this.productBtn.BackColor = System.Drawing.Color.Lime;
            this.productBtn.Location = new System.Drawing.Point(13, 13);
            this.productBtn.Name = "productBtn";
            this.productBtn.Size = new System.Drawing.Size(96, 39);
            this.productBtn.TabIndex = 7;
            this.productBtn.Text = "Product Operations";
            this.productBtn.UseVisualStyleBackColor = false;
            this.productBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(569, 278);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 8;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.productBtn);
            this.Controls.Add(this.SalesBtn);
            this.Controls.Add(this.ReviewsBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.viewGrid);
            this.Name = "MainForm";
            this.Text = "Isabike";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView viewGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox suly_textbox;
        private System.Windows.Forms.TextBox termeknevTextbox;
        private System.Windows.Forms.ComboBox categoryBox;
        private System.Windows.Forms.ComboBox manufactererBox;
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.Button ReviewsBtn;
        private System.Windows.Forms.Button SalesBtn;
        private System.Windows.Forms.Button productBtn;
        private System.Windows.Forms.Button refreshBtn;
    }
}

