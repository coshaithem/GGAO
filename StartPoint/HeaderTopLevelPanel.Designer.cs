namespace StartPoint
{
    partial class HeaderTopLevelPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.header.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.header.Controls.Add(this.panel1);
            this.header.Controls.Add(this.label2);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(458, 29);
            this.header.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.UserName);
            this.panel1.Controls.Add(this.Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(355, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 29);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Application De Gestion";
            // 
            // Close
            // 
            this.Close.AutoSize = true;
            this.Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Close.Location = new System.Drawing.Point(72, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(31, 29);
            this.Close.TabIndex = 1;
            this.Close.Text = "X";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UserName.Location = new System.Drawing.Point(0, 0);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(0, 29);
            this.UserName.TabIndex = 0;
            this.UserName.Click += new System.EventHandler(this.About_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(49, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "?";
            // 
            // HeaderTopLevelPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.header);
            this.Name = "HeaderTopLevelPanel";
            this.Size = new System.Drawing.Size(458, 31);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label Close;
    }
}
