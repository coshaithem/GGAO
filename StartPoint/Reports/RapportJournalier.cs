using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO.Reports
{
    public partial class raportJournalier : Form
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);

        public raportJournalier()
        {
            InitializeComponent();
        }

        private void raportJournalier_Load(object sender, EventArgs e)
        {
            DataTable poleDt = GGAO.PoleCRUDOps.getVisiblePole();

            this.PoleCombobox.Clear();

            PoleCombobox.SourceDataString = GGAO.Utilities.Tools.ConvColNametoArray(poleDt.Columns);

            PoleCombobox.DataSource = poleDt;

            PoleCombobox.setTextBox("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private DataTable getData(DateTime today, string poleid )
        {
            DataTable dt = new DataTable();
            //System.Data.DataSet ds = new DataSet();
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("ConsumptionByDateAndPole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime).Value = today;
                //DateTime.Parse("12-03-2021");  new System.DateTime(2021, 03, 12); 
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.Int).Value = int.Parse(poleid);

                //cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   " Report ", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            //MessageBox.Show(dt.Rows.Count.ToString());
            return dt;
        }
        private void ShowReport(DataTable dt )
        {
            // Reset 
            rptViewer.Reset();

            // DataSource

            //DataTable dt = getData(dateTimePickerLocal.Value, PoleCombobox.SelectedItem.Value);
            ReportDataSource rds = new ReportDataSource("DataSetReportConsumption", dt);
            rptViewer.LocalReport.DataSources.Add(rds);

            //path
            rptViewer.LocalReport.ReportPath = "RptJournalier.rdlc";
            /* */
            // Parameters
            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("date", dateTimePickerLocal.Value.ToString() ),
                new ReportParameter("pole", PoleCombobox.SelectedItem.Text)
            };
            rptViewer.LocalReport.SetParameters(rptParams);

            //Refresh 
            rptViewer.Refresh();
        }
        private void ShowReportBtn_Click(object sender, EventArgs e)
        {
            if (PoleCombobox.SelectedItem != null)
            {
                DataTable dt = getData(dateTimePickerLocal.Value, PoleCombobox.SelectedItem.Value);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Aucun enregistrement trouvé", " Report ", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    this.ShowReport(dt);
                    this.rptViewer.RefreshReport();
                }

            }
            
        }

        private void PoleCombobox_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerLocal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
