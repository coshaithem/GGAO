namespace GGAO
{
    partial class ReportWin
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ListOfEngineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GGAOEngineDataSet = new GGAO.Reports.GGAOEngineDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ListOfEngineTableAdapter = new GGAO.Reports.GGAOEngineDataSetTableAdapters.ListOfEngineTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ListOfEngineBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GGAOEngineDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ListOfEngineBindingSource
            // 
            this.ListOfEngineBindingSource.DataMember = "ListOfEngine";
            this.ListOfEngineBindingSource.DataSource = this.GGAOEngineDataSet;
            // 
            // GGAOEngineDataSet
            // 
            this.GGAOEngineDataSet.DataSetName = "GGAOEngineDataSet";
            this.GGAOEngineDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetReport";
            reportDataSource2.Value = this.ListOfEngineBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GGAO.Reports.RptEngine.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // ListOfEngineTableAdapter
            // 
            this.ListOfEngineTableAdapter.ClearBeforeFill = true;
            // 
            // ReportWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReportWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListOfEngineBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GGAOEngineDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ListOfEngineBindingSource;
        private GGAO.Reports.GGAOEngineDataSet GGAOEngineDataSet;
        private GGAO.Reports.GGAOEngineDataSetTableAdapters.ListOfEngineTableAdapter ListOfEngineTableAdapter;
    }
}