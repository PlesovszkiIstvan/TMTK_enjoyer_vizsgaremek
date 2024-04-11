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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filterBtn = new System.Windows.Forms.Button();
            this.manufactererBox = new System.Windows.Forms.ComboBox();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.suly_textbox = new System.Windows.Forms.TextBox();
            this.termeknevTextbox = new System.Windows.Forms.TextBox();
            this.ReviewsBtn = new System.Windows.Forms.Button();
            this.productBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.SalesBtn = new System.Windows.Forms.Button();
            this.UserBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewGrid
            // 
            this.viewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewGrid.Location = new System.Drawing.Point(13, 58);
            this.viewGrid.Name = "viewGrid";
            this.viewGrid.Size = new System.Drawing.Size(1162, 380);
            this.viewGrid.TabIndex = 3;
            this.viewGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewGrid_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filterBtn);
            this.panel1.Controls.Add(this.manufactererBox);
            this.panel1.Controls.Add(this.categoryBox);
            this.panel1.Controls.Add(this.suly_textbox);
            this.panel1.Controls.Add(this.termeknevTextbox);
            this.panel1.Location = new System.Drawing.Point(1181, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 159);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Gyártó:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kategória:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Súly:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Termék neve:";
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(9, 124);
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
            this.manufactererBox.Location = new System.Drawing.Point(99, 82);
            this.manufactererBox.Name = "manufactererBox";
            this.manufactererBox.Size = new System.Drawing.Size(121, 21);
            this.manufactererBox.TabIndex = 7;
            // 
            // categoryBox
            // 
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Items.AddRange(new object[] {
            "Kategoria1",
            "Kategoria2",
            "Kategoria3"});
            this.categoryBox.Location = new System.Drawing.Point(99, 55);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(121, 21);
            this.categoryBox.TabIndex = 6;
            // 
            // suly_textbox
            // 
            this.suly_textbox.Location = new System.Drawing.Point(99, 29);
            this.suly_textbox.Name = "suly_textbox";
            this.suly_textbox.Size = new System.Drawing.Size(98, 20);
            this.suly_textbox.TabIndex = 1;
            this.suly_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // termeknevTextbox
            // 
            this.termeknevTextbox.Location = new System.Drawing.Point(99, 3);
            this.termeknevTextbox.Name = "termeknevTextbox";
            this.termeknevTextbox.Size = new System.Drawing.Size(98, 20);
            this.termeknevTextbox.TabIndex = 0;
            // 
            // ReviewsBtn
            // 
            this.ReviewsBtn.BackColor = System.Drawing.Color.Red;
            this.ReviewsBtn.FlatAppearance.BorderSize = 0;
            this.ReviewsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReviewsBtn.Location = new System.Drawing.Point(217, 12);
            this.ReviewsBtn.Name = "ReviewsBtn";
            this.ReviewsBtn.Size = new System.Drawing.Size(96, 39);
            this.ReviewsBtn.TabIndex = 5;
            this.ReviewsBtn.Text = "Reviews";
            this.ReviewsBtn.UseVisualStyleBackColor = false;
            this.ReviewsBtn.Click += new System.EventHandler(this.ReviewsBtn_Click);
            // 
            // productBtn
            // 
            this.productBtn.BackColor = System.Drawing.Color.Lime;
            this.productBtn.Location = new System.Drawing.Point(13, 13);
            this.productBtn.Name = "productBtn";
            this.productBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.productBtn.Size = new System.Drawing.Size(96, 38);
            this.productBtn.TabIndex = 7;
            this.productBtn.Text = "Product Operations";
            this.productBtn.UseVisualStyleBackColor = false;
            this.productBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(1190, 237);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 8;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // SalesBtn
            // 
            this.SalesBtn.BackColor = System.Drawing.Color.Red;
            this.SalesBtn.Cursor = System.Windows.Forms.Cursors.No;
            this.SalesBtn.Enabled = false;
            this.SalesBtn.Location = new System.Drawing.Point(115, 13);
            this.SalesBtn.Name = "SalesBtn";
            this.SalesBtn.Size = new System.Drawing.Size(96, 39);
            this.SalesBtn.TabIndex = 6;
            this.SalesBtn.Text = "Sales";
            this.SalesBtn.UseVisualStyleBackColor = false;
            this.SalesBtn.Click += new System.EventHandler(this.SalesBtn_Click);
            // 
            // UserBtn
            // 
            this.UserBtn.BackColor = System.Drawing.Color.Lime;
            this.UserBtn.Location = new System.Drawing.Point(319, 13);
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Size = new System.Drawing.Size(96, 39);
            this.UserBtn.TabIndex = 10;
            this.UserBtn.Text = "User Operations";
            this.UserBtn.UseVisualStyleBackColor = false;
            this.UserBtn.Click += new System.EventHandler(this.UserBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 450);
            this.Controls.Add(this.UserBtn);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UserBtn;
    }
}

