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
    public partial class ReportWindow : Form
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        DataTable dt = null;
        public ReportWindow(DataTable externDt)
        {
            InitializeComponent();
            dt = externDt;
        }

        private void ReportWindow_Load(object sender, EventArgs e)
        {

            //this.rptViewer.RefreshReport();
            this.ShowReport();
            this.rptViewer.RefreshReport();
        }
        private void ShowReport()
        {
            // Reset 
            rptViewer.Reset();

            // DataSource

            //DataTable dt = getData();
            ReportDataSource rds = new ReportDataSource("DataSetReportConsumption", dt);
            rptViewer.LocalReport.DataSources.Add(rds);

            //path
            rptViewer.LocalReport.ReportPath = "RptConsumption.rdlc";
            /* */
            // Parameters
            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("date", myDateTxt.Text ),
                new ReportParameter("pole", poleTxt.Text )
            };
            rptViewer.LocalReport.SetParameters(rptParams);
            
            //Refresh
            rptViewer.Refresh();
        }
        /*
        private DataTable getData()
        {
            DataTable dt = new DataTable();
            //System.Data.DataSet ds = new DataSet();
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("ConsumptionByDateAndPole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime ).Value = DateTime.Parse(myDateTxt.Text);
                //DateTime.Parse("12-03-2021");  new System.DateTime(2021, 03, 12); 
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.Int).Value = int.Parse( poleTxt.Text );

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
        */
        private void button1_Click(object sender, EventArgs e)
        {
            this.ShowReport();
            this.rptViewer.RefreshReport();
        }
    }
}
