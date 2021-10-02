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
            this.idLists = new System.Windows.Forms.Label();
            this.AddNewItemBtn = new System.Windows.Forms.Button();
            this.ListOfItem = new System.Windows.Forms.Label();
            this.SourceComboBox = new VMultiColumnComboBox.MultiColumComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.rptViewer.LocalReport.ReportEmbeddedResource = "GGAO.Reports.RptJournalier.rdlc";
            this.rptViewer.Location = new System.Drawing.Point(0, 40);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(1119, 370);
            this.rptViewer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShowReportBtn);
            this.panel1.Controls.Add(this.idLists);
            this.panel1.Controls.Add(this.AddNewItemBtn);
            this.panel1.Controls.Add(this.ListOfItem);
            this.panel1.Controls.Add(this.SourceComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PoleCombobox);
            this.panel1.Controls.Add(this.dateTimePickerLocal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 38);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // idLists
            // 
            this.idLists.AutoSize = true;
            this.idLists.BackColor = System.Drawing.Color.Transparent;
            this.idLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idLists.ForeColor = System.Drawing.Color.Transparent;
            this.idLists.Location = new System.Drawing.Point(870, 24);
            this.idLists.Name = "idLists";
            this.idLists.Size = new System.Drawing.Size(0, 2);
            this.idLists.TabIndex = 29;
            // 
            // AddNewItemBtn
            // 
            this.AddNewItemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewItemBtn.Location = new System.Drawing.Point(842, 7);
            this.AddNewItemBtn.Name = "AddNewItemBtn";
            this.AddNewItemBtn.Size = new System.Drawing.Size(22, 26);
            this.AddNewItemBtn.TabIndex = 28;
            this.AddNewItemBtn.Text = ">";
            this.AddNewItemBtn.UseVisualStyleBackColor = true;
            this.AddNewItemBtn.Click += new System.EventHandler(this.AddNewItemBtn_Click);
            // 
            // ListOfItem
            // 
            this.ListOfItem.AutoSize = true;
            this.ListOfItem.BackColor = System.Drawing.Color.Transparent;
            this.ListOfItem.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListOfItem.Location = new System.Drawing.Point(863, 10);
            this.ListOfItem.Name = "ListOfItem";
            this.ListOfItem.Size = new System.Drawing.Size(0, 21);
            this.ListOfItem.TabIndex = 27;
            this.ListOfItem.DoubleClick += new System.EventHandler(this.ListOfItem_DoubleClick);
            // 
            // SourceComboBox
            // 
            this.SourceComboBox.ColumnWidth = null;
            this.SourceComboBox.DataSource = null;
            this.SourceComboBox.DisplayColumnNo = 1;
            this.SourceComboBox.DropDownHeight = 200;
            this.SourceComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SourceComboBox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.SourceComboBox.Location = new System.Drawing.Point(334, 7);
            this.SourceComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SourceComboBox.Name = "SourceComboBox";
            this.SourceComboBox.SelectedItem = null;
            this.SourceComboBox.ShowHeader = true;
            this.SourceComboBox.Size = new System.Drawing.Size(175, 26);
            this.SourceComboBox.SourceDataHeader = null;
            this.SourceComboBox.SourceDataString = null;
            this.SourceComboBox.TabIndex = 25;
            this.SourceComboBox.ValueColumnNo = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(531, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Consommateur";
            // 
            // ShowReportBtn
            // 
            this.ShowReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowReportBtn.Location = new System.Drawing.Point(1037, 4);
            this.ShowReportBtn.Name = "ShowReportBtn";
            this.ShowReportBtn.Size = new System.Drawing.Size(75, 31);
            this.ShowReportBtn.TabIndex = 2;
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
            this.PoleCombobox.Location = new System.Drawing.Point(667, 7);
            this.PoleCombobox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PoleCombobox.Name = "PoleCombobox";
            this.PoleCombobox.SelectedItem = null;
            this.PoleCombobox.ShowHeader = true;
            this.PoleCombobox.Size = new System.Drawing.Size(175, 26);
            this.PoleCombobox.SourceDataHeader = null;
            this.PoleCombobox.SourceDataString = null;
            this.PoleCombobox.TabIndex = 1;
            this.PoleCombobox.ValueColumnNo = 0;
            // 
            // dateTimePickerLocal
            // 
            this.dateTimePickerLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerLocal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerLocal.Location = new System.Drawing.Point(70, 8);
            this.dateTimePickerLocal.MaxDate = new System.DateTime(2200, 2, 5, 0, 0, 0, 0);
            this.dateTimePickerLocal.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerLocal.Name = "dateTimePickerLocal";
            this.dateTimePickerLocal.Size = new System.Drawing.Size(175, 26);
            this.dateTimePickerLocal.TabIndex = 0;
            this.dateTimePickerLocal.Value = new System.DateTime(2021, 10, 1, 16, 27, 33, 102);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(267, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Source";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Date";
            // 
            // raportJournalier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 410);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rptViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "raportJournalier";
            this.Opacity = 0.98D;
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
        private VMultiColumnComboBox.MultiColumComboBox SourceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddNewItemBtn;
        private System.Windows.Forms.Label ListOfItem;
        private System.Windows.Forms.Label idLists;
    }
}