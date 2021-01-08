namespace StartPoint
{
    partial class f_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private HeaderTopLevelPanel htlp = null ;

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
            this.htlp = new StartPoint.HeaderTopLevelPanel();
            this.headerTopLevelPanel1 = new StartPoint.HeaderTopLevelPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // htlp
            // 
            this.htlp.Dock = System.Windows.Forms.DockStyle.Top;
            this.htlp.Location = new System.Drawing.Point(0, 0);
            this.htlp.Name = "htlp";
            this.htlp.Size = new System.Drawing.Size(458, 31);
            this.htlp.TabIndex = 0;
            // 
            // headerTopLevelPanel1
            // 
            this.headerTopLevelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerTopLevelPanel1.Location = new System.Drawing.Point(0, 0);
            this.headerTopLevelPanel1.Name = "headerTopLevelPanel1";
            this.headerTopLevelPanel1.Size = new System.Drawing.Size(729, 31);
            this.headerTopLevelPanel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(97, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(410, 33);
            this.textBox1.TabIndex = 2;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToOrderColumns = true;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Location = new System.Drawing.Point(2, 81);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.Size = new System.Drawing.Size(727, 397);
            this.advancedDataGridView1.TabIndex = 3;
            this.advancedDataGridView1.TimeFilter = false;
            // 
            // f_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(729, 490);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.headerTopLevelPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_Main";
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HeaderTopLevelPanel headerTopLevelPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
    }
}