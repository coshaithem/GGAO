namespace GGAO.Reports
{
    partial class raportJournalier
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
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowReportBtn = new System.Windows.Forms.Button();
            this.PoleCombobox = new VMultiColumnComboBox.MultiColumComboBox();
            this.dateTimePickerLocal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rptViewer.LocalReport.ReportEmbeddedResource = "GGAO.Reports.RptConsumption.rdlc";
            this.rptViewer.Location = new System.Drawing.Point(0, 57);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(991, 453);
            this.rptViewer.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShowReportBtn);
            this.panel1.Controls.Add(this.PoleCombobox);
            this.panel1.Controls.Add(this.dateTimePickerLocal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 51);
            this.panel1.TabIndex = 24;
            // 
            // ShowReportBtn
            // 
            this.ShowReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowReportBtn.Location = new System.Drawing.Point(698, 8);
            this.ShowReportBtn.Name = "ShowReportBtn";
            this.ShowReportBtn.Size = new System.Drawing.Size(75, 31);
            this.ShowReportBtn.TabIndex = 27;
            this.ShowReportBtn.Text = "Afficher";
            this.ShowReportBtn.UseVisualStyleBackColor = true;
            this.ShowReportBtn.Click += new System.EventHandler(this.ShowReportBtn_Click);
            // 
            // PoleCombobox
            // 
            this.PoleCombobox.ColumnWidth = null;
            this.PoleCombobox.DataSource = null;
            this.PoleCombobox.DisplayColumnNo = 1;
            this.PoleCombobox.DropDownHeight = 200;
            this.PoleCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PoleCombobox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.PoleCombobox.Location = new System.Drawing.Point(489, 12);
            this.PoleCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PoleCombobox.Name = "PoleCombobox";
            this.PoleCombobox.SelectedItem = null;
            this.PoleCombobox.ShowHeader = true;
            this.PoleCombobox.Size = new System.Drawing.Size(175, 26);
            this.PoleCombobox.SourceDataHeader = null;
            this.PoleCombobox.SourceDataString = null;
            this.PoleCombobox.TabIndex = 26;
            this.PoleCombobox.ValueColumnNo = 0;
            // 
            // dateTimePickerLocal
            // 
            this.dateTimePickerLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerLocal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerLocal.Location = new System.Drawing.Point(238, 12);
            this.dateTimePickerLocal.MaxDate = new System.DateTime(2200, 2, 5, 0, 0, 0, 0);
            this.dateTimePickerLocal.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerLocal.Name = "dateTimePickerLocal";
            this.dateTimePickerLocal.Size = new System.Drawing.Size(175, 26);
            this.dateTimePickerLocal.TabIndex = 25;
            this.dateTimePickerLocal.Value = new System.DateTime(2021, 3, 13, 8, 56, 6, 275);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(446, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Pole";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(191, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date";
            // 
            // raportJournalier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 510);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rptViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "raportJournalier";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rapport Journalier";
            this.Load += new System.EventHandler(this.raportJournalier_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ShowReportBtn;
        private VMultiColumnComboBox.MultiColumComboBox PoleCombobox;
        private System.Windows.Forms.DateTimePicker dateTimePickerLocal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}