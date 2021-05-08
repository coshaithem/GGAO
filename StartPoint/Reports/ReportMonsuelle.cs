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
    public partial class ReportMonsuelle : Form
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        DataTable dt = null;
        public ReportMonsuelle(DataTable externDt)
        {
            InitializeComponent();
            dt = externDt;
        }
        public ReportMonsuelle()
        {
            InitializeComponent();
            
        }

        private void ReportWindow_Load(object sender, EventArgs e)
        {
            DataTable poleDtRM = GGAO.PoleCRUDOps.getVisiblePole(false,"SELECT");

            this.PoleCombobox.Clear();
            

            PoleCombobox.SourceDataString = GGAO.Utilities.Tools.ConvColNametoArray(poleDtRM.Columns);

            PoleCombobox.DataSource = poleDtRM;

            PoleCombobox.setTextBox("");
            this.PoleCombobox.setFilter(new int[] { 1, 2 });
            //this.rptViewer.RefreshReport();
            //this.ShowReport();
            //this.rptViewer.RefreshReport();
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
                //new ReportParameter("@FromDate", myDateTxt.Text ),
                //new ReportParameter("ToDate", myDateTxt.Text ),
                //new ReportParameter("PoleID", poleid )

                              
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
        private DataTable getData(DateTime frmDate, DateTime ToDate, string poleid)
        {
            DataTable dt = new DataTable();
            //System.Data.DataSet ds = new DataSet();
            try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("MonthlyConsumtion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FDate", SqlDbType.DateTime).Value = frmDate;
                cmd.Parameters.AddWithValue("@TDate", SqlDbType.DateTime).Value = ToDate;
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
        private void ShowReport(DataTable dt)
        {
            // Reset 
            rptViewer.Reset();

            // DataSource

            //DataTable dt = getData(dateTimePickerLocal.Value, PoleCombobox.SelectedItem.Value);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt); // DataSetReportConsumption
            rptViewer.LocalReport.DataSources.Add(rds);

            //path
            rptViewer.LocalReport.ReportPath = "RptMonsuelle.rdlc";
            /* */
            // Parameters
            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("fromDate", fromDatePkr.Value.ToString() ),
                new ReportParameter("ToDate", ToDatePkr.Value.ToString() ),
                new ReportParameter("PoleID", PoleCombobox.SelectedItem.Text)
            };
            rptViewer.LocalReport.SetParameters(rptParams);

            //Refresh 
            rptViewer.Refresh();
        }
        private void ShowReportBtn_Click(object sender, EventArgs e)
        {
            if (PoleCombobox.SelectedItem != null && ( fromDatePkr.Value < ToDatePkr.Value ) )
            {
                DataTable dt = getData(fromDatePkr.Value, ToDatePkr.Value , PoleCombobox.SelectedItem.Value); //PoleCombobox.SelectedItem.Value
                if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Aucun enregistrement trouvé", " Report ", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    dt = this.DataTableProcessing(dt);
                    this.ShowReport(dt);
                    this.rptViewer.RefreshReport();
                }

            }
            else
            {
                MessageBox.Show("les informations fournies sont erronées",
                                  " Report ", MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
            }
        }

        private DataTable DataTableProcessing(DataTable dt)
        {
            DataRow FirstDR = dt.Rows[0];
             
            for (DateTime i = fromDatePkr.Value; i <= ToDatePkr.Value; i=i.AddDays(1) )
            {
                //MessageBox.Show(" First " + FirstDR["Date"].ToString());
                if (i.Day != DateTime.Parse(FirstDR["Date"].ToString()).Day ) //!= FirstDR["Date"].Value
                {
                    DataRow row = dt.NewRow();
                    row["IMM_CODE"] = FirstDR["IMM_CODE"];
                    row["Libelle"] = FirstDR["Libelle"];
                    row["Date"] = i.ToShortDateString();
                    row["Quantité"] = 0;
                    dt.Rows.Add(row);
                    //MessageBox.Show("inserted : "+row["Date"].ToString());
                }
                //MessageBox.Show( i.ToString() );
            }
            return dt;
        }
    }
}
