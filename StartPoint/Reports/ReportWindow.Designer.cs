namespace GGAO.Reports
{
    partial class ReportWindow
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
            this.myDateTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.poleTxt = new System.Windows.Forms.TextBox();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // myDateTxt
            // 
            this.myDateTxt.Location = new System.Drawing.Point(67, 4);
            this.myDateTxt.Name = "myDateTxt";
            this.myDateTxt.Size = new System.Drawing.Size(100, 20);
            this.myDateTxt.TabIndex = 1;
            this.myDateTxt.Text = "12/03/2021";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // poleTxt
            // 
            this.poleTxt.Location = new System.Drawing.Point(230, 4);
            this.poleTxt.Name = "poleTxt";
            this.poleTxt.Size = new System.Drawing.Size(100, 20);
            this.poleTxt.TabIndex = 4;
            this.poleTxt.Text = "1";
            this.poleTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.LocalReport.ReportEmbeddedResource = "GGAO.Reports.RptConsumption.rdlc";
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(800, 450);
            this.rptViewer.TabIndex = 5;
            // 
            // ReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptViewer);
            this.Controls.Add(this.poleTxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myDateTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReportWindow";
            this.Opacity = 0.99D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReportWindow";
            this.Load += new System.EventHandler(this.ReportWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox myDateTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox poleTxt;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
    }
}