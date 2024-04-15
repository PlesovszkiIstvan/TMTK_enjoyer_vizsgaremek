namespace Isabike
{
    partial class OrdersForm
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
            this.ordersDataView = new System.Windows.Forms.DataGridView();
            this.selectOrderBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersDataView
            // 
            this.ordersDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDataView.Location = new System.Drawing.Point(12, 12);
            this.ordersDataView.Name = "ordersDataView";
            this.ordersDataView.Size = new System.Drawing.Size(695, 342);
            this.ordersDataView.TabIndex = 0;
            // 
            // selectOrderBtn
            // 
            this.selectOrderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.selectOrderBtn.Location = new System.Drawing.Point(713, 12);
            this.selectOrderBtn.Name = "selectOrderBtn";
            this.selectOrderBtn.Size = new System.Drawing.Size(59, 63);
            this.selectOrderBtn.TabIndex = 1;
            this.selectOrderBtn.Text = "Select order";
            this.selectOrderBtn.UseVisualStyleBackColor = false;
            this.selectOrderBtn.Click += new System.EventHandler(this.selectOrderBtn_Click);
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.selectOrderBtn);
            this.Controls.Add(this.ordersDataView);
            this.Name = "OrdersForm";
            this.Text = "OrdersForm";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ordersDataView;
        private System.Windows.Forms.Button selectOrderBtn;
    }
}