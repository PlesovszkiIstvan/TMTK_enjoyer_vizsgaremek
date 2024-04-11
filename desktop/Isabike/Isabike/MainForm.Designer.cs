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
            this.UserBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.viewGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewGrid
            // 
            this.viewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewGrid.Location = new System.Drawing.Point(17, 71);
            this.viewGrid.Margin = new System.Windows.Forms.Padding(4);
            this.viewGrid.Name = "viewGrid";
            this.viewGrid.RowHeadersWidth = 51;
            this.viewGrid.Size = new System.Drawing.Size(1549, 468);
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
            this.panel1.Location = new System.Drawing.Point(1575, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 196);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Gyártó:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kategória:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Súly:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Termék neve:";
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(12, 153);
            this.filterBtn.Margin = new System.Windows.Forms.Padding(4);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(129, 28);
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
            this.manufactererBox.Location = new System.Drawing.Point(132, 101);
            this.manufactererBox.Margin = new System.Windows.Forms.Padding(4);
            this.manufactererBox.Name = "manufactererBox";
            this.manufactererBox.Size = new System.Drawing.Size(160, 24);
            this.manufactererBox.TabIndex = 7;
            // 
            // categoryBox
            // 
            this.categoryBox.FormattingEnabled = true;
            this.categoryBox.Items.AddRange(new object[] {
            "Kategoria1",
            "Kategoria2",
            "Kategoria3"});
            this.categoryBox.Location = new System.Drawing.Point(132, 68);
            this.categoryBox.Margin = new System.Windows.Forms.Padding(4);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(160, 24);
            this.categoryBox.TabIndex = 6;
            // 
            // suly_textbox
            // 
            this.suly_textbox.Location = new System.Drawing.Point(132, 36);
            this.suly_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.suly_textbox.Name = "suly_textbox";
            this.suly_textbox.Size = new System.Drawing.Size(129, 22);
            this.suly_textbox.TabIndex = 1;
            this.suly_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // termeknevTextbox
            // 
            this.termeknevTextbox.Location = new System.Drawing.Point(132, 4);
            this.termeknevTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.termeknevTextbox.Name = "termeknevTextbox";
            this.termeknevTextbox.Size = new System.Drawing.Size(129, 22);
            this.termeknevTextbox.TabIndex = 0;
            // 
            // ReviewsBtn
            // 
            this.ReviewsBtn.BackColor = System.Drawing.Color.Red;
            this.ReviewsBtn.FlatAppearance.BorderSize = 0;
            this.ReviewsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReviewsBtn.Location = new System.Drawing.Point(153, 16);
            this.ReviewsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ReviewsBtn.Name = "ReviewsBtn";
            this.ReviewsBtn.Size = new System.Drawing.Size(128, 48);
            this.ReviewsBtn.TabIndex = 5;
            this.ReviewsBtn.Text = "Reviews";
            this.ReviewsBtn.UseVisualStyleBackColor = false;
            this.ReviewsBtn.Click += new System.EventHandler(this.ReviewsBtn_Click);
            // 
            // productBtn
            // 
            this.productBtn.BackColor = System.Drawing.Color.Lime;
            this.productBtn.Location = new System.Drawing.Point(17, 16);
            this.productBtn.Margin = new System.Windows.Forms.Padding(4);
            this.productBtn.Name = "productBtn";
            this.productBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.productBtn.Size = new System.Drawing.Size(128, 47);
            this.productBtn.TabIndex = 7;
            this.productBtn.Text = "Product Operations";
            this.productBtn.UseVisualStyleBackColor = false;
            this.productBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(1587, 292);
            this.refreshBtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(100, 28);
            this.refreshBtn.TabIndex = 8;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // UserBtn
            // 
            this.UserBtn.BackColor = System.Drawing.Color.Lime;
            this.UserBtn.Location = new System.Drawing.Point(289, 16);
            this.UserBtn.Margin = new System.Windows.Forms.Padding(4);
            this.UserBtn.Name = "UserBtn";
            this.UserBtn.Size = new System.Drawing.Size(128, 48);
            this.UserBtn.TabIndex = 10;
            this.UserBtn.Text = "User Operations";
            this.UserBtn.UseVisualStyleBackColor = false;
            this.UserBtn.Click += new System.EventHandler(this.UserBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1873, 554);
            this.Controls.Add(this.UserBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.productBtn);
            this.Controls.Add(this.ReviewsBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.viewGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button productBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UserBtn;
    }
}

