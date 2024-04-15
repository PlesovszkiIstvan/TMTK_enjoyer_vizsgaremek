namespace Isabike
{
    partial class OrderedItemsForm
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
            this.itemViewGrid = new System.Windows.Forms.DataGridView();
            this.deliveredBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.itemViewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // itemViewGrid
            // 
            this.itemViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemViewGrid.Location = new System.Drawing.Point(12, 12);
            this.itemViewGrid.Name = "itemViewGrid";
            this.itemViewGrid.Size = new System.Drawing.Size(677, 337);
            this.itemViewGrid.TabIndex = 0;
            // 
            // deliveredBtn
            // 
            this.deliveredBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.deliveredBtn.Location = new System.Drawing.Point(695, 12);
            this.deliveredBtn.Name = "deliveredBtn";
            this.deliveredBtn.Size = new System.Drawing.Size(70, 66);
            this.deliveredBtn.TabIndex = 1;
            this.deliveredBtn.Text = "Delivered";
            this.deliveredBtn.UseVisualStyleBackColor = false;
            this.deliveredBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderedItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.deliveredBtn);
            this.Controls.Add(this.itemViewGrid);
            this.Name = "OrderedItemsForm";
            this.Text = "OrderedItemsForm";
            this.Load += new System.EventHandler(this.OrderedItemsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemViewGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView itemViewGrid;
        private System.Windows.Forms.Button deliveredBtn;
    }
}