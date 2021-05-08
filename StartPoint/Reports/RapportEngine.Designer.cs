namespace GGAO.Reports
{
    partial class RapportEngine
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShowRptBtn = new System.Windows.Forms.Button();
            this.EngineComboBox = new VMultiColumnComboBox.MultiColumComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShowRptBtn);
            this.panel1.Controls.Add(this.EngineComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 45);
            this.panel1.TabIndex = 0;
            // 
            // ShowRptBtn
            // 
            this.ShowRptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowRptBtn.Location = new System.Drawing.Point(910, 6);
            this.ShowRptBtn.Name = "ShowRptBtn";
            this.ShowRptBtn.Size = new System.Drawing.Size(94, 32);
            this.ShowRptBtn.TabIndex = 4;
            this.ShowRptBtn.Text = "Afficher";
            this.ShowRptBtn.UseVisualStyleBackColor = true;
            this.ShowRptBtn.Click += new System.EventHandler(this.ShowRptBtn_Click);
            // 
            // EngineComboBox
            // 
            this.EngineComboBox.ColumnWidth = null;
            this.EngineComboBox.DataSource = null;
            this.EngineComboBox.DisplayColumnNo = 1;
            this.EngineComboBox.DropDownHeight = 200;
            this.EngineComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EngineComboBox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            this.EngineComboBox.Location = new System.Drawing.Point(284, 9);
            this.EngineComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.EngineComboBox.Name = "EngineComboBox";
            this.EngineComboBox.SelectedItem = null;
            this.EngineComboBox.ShowHeader = true;
            this.EngineComboBox.Size = new System.Drawing.Size(166, 29);
            this.EngineComboBox.SourceDataHeader = null;
            this.EngineComboBox.SourceDataString = null;
            this.EngineComboBox.TabIndex = 3;
            this.EngineComboBox.ValueColumnNo = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Engine";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mois";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "MMM yyyy";
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(61, 10);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(135, 29);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.Value = new System.DateTime(2021, 5, 2, 12, 51, 54, 343);
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 45);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ServerReport.BearerToken = null;
            this.rptViewer.Size = new System.Drawing.Size(1016, 389);
            this.rptViewer.TabIndex = 1;
            // 
            // RapportEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 434);
            this.Controls.Add(this.rptViewer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RapportEngine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RapportEngine";
            this.Load += new System.EventHandler(this.RapportEngine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button ShowRptBtn;
        private VMultiColumnComboBox.MultiColumComboBox EngineComboBox;
        private System.Windows.Forms.Label label2;
    }
}