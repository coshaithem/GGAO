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
    public partial class RapportEngine : Form
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);

        public RapportEngine()
        {
            InitializeComponent();
        }

        private void RapportEngine_Load(object sender, EventArgs e)
        {
            DataTable EngineDTrj = GGAO.EngineCRUDOps.getVisibleEngine(); 

            this.EngineComboBox.Clear();

            EngineComboBox.SourceDataString = GGAO.Utilities.Tools.ConvColNametoArray(EngineDTrj.Columns);

            EngineComboBox.DataSource = EngineDTrj;

            EngineComboBox.setTextBox("");

            this.EngineComboBox.setFilter(new int[] { 1, 2, 5, 7 });
            //this.reportViewer1.RefreshReport();
        }

        private void ShowRptBtn_Click(object sender, EventArgs e)
        {
            if ( this.EngineComboBox.SelectedItem != null)
            {
 
                DataTable dt1 = getData(
                    new System.DateTime(dateTimePicker.Value.Year, (dateTimePicker.Value.AddMonths(-1)).Month ,21), 
                    new System.DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month  ,05), 
                    EngineComboBox.SelectedItem.Value );                
                DataTable dt2 = getData(
                    new System.DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month ,06), 
                    new System.DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month  ,20), 
                    EngineComboBox.SelectedItem.Value );

                if ((dt1 == null || dt1.Rows.Count <= 0) && (dt2 == null || dt2.Rows.Count <= 0))
                {
                    MessageBox.Show("Aucun enregistrement trouvé", " Report ", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    this.ShowReport(dt1, dt2);
                    this.rptViewer.RefreshReport();
                }

            }
        }
        private DataTable tmpgetData()
        {
            DataTable dt = new DataTable(); try
            {
                //con.Open();
                SqlCommand cmd = new SqlCommand("CRUDEngine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Fdate", SqlDbType.DateTime).Value = from;
                 cmd.Parameters.AddWithValue("@choice", SqlDbType.VarChar).Value = "SELECT";
                //DateTime.Parse("12-03-2021");  new System.DateTime(2021, 03, 12); 
                // disable that for test purposes EngineConsumption
                //cmd.Parameters.AddWithValue("@EngineID", SqlDbType.Int).Value = int.Parse(engineId);

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
        private DataTable getData(DateTime from, DateTime To, string engineId)
        {
            DataTable dt = new DataTable();
            //System.Data.DataSet ds = new DataSet();
            try
            { 
                //con.Open();
                SqlCommand cmd = new SqlCommand("EngineConsumption", con); // EngineConsumptionALL
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fdate", SqlDbType.DateTime).Value = from;
                cmd.Parameters.AddWithValue("@Tdate", SqlDbType.DateTime).Value = To;
                //DateTime.Parse("12-03-2021");  new System.DateTime(2021, 03, 12); 
                // disable that for test purposes EngineConsumption
                cmd.Parameters.AddWithValue("@EngineID", SqlDbType.Int).Value = int.Parse(engineId);

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

        private void ShowReport(DataTable dt1, DataTable dt2)
        {
            // Reset 
            rptViewer.Reset();

            // DataSource
            int year = dateTimePicker.Value.Year,
                Month = dateTimePicker.Value.Month;
            //DataTable dt = getData(dateTimePickerLocal.Value, PoleCombobox.SelectedItem.Value);
            /*DataRow row = this.SearchByDate(dt1, new System.DateTime(year, Month - 1, 31));
            if (row == null)
            {
                this.AddNewRow(dt1, new System.DateTime(year, Month - 1, 31 ) );
            }
            */
            //String tmpVar = (dt1.Rows[0]["MatriculeIntern"].ToString().Trim() == "") ? dt2.Rows[0]["MatriculeIntern"].ToString() : dt1.Rows[0]["MatriculeIntern"].ToString();

            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("Mois",this.dateTimePicker.Value.ToString()  ),
                new ReportParameter("Code",
                    (dt1.Rows.Count == 0 || dt1.Rows[0]["MatriculeIntern"].ToString().Trim() == "") ? dt2.Rows[0]["MatriculeIntern"].ToString() : dt1.Rows[0]["MatriculeIntern"].ToString()
                ),
                new ReportParameter("Dest",
                    (dt1.Rows.Count == 0 ||  dt1.Rows[0]["Libelle"].ToString().Trim() == "") ? dt2.Rows[0]["Libelle"].ToString() : dt1.Rows[0]["Libelle"].ToString() 
                ),
                new ReportParameter("Marque",
                    (dt1.Rows.Count == 0 ||  dt1.Rows[0]["Marque"].ToString().Trim() == "") ? dt2.Rows[0]["Marque"].ToString() : dt1.Rows[0]["Marque"].ToString() 
                ),
                new ReportParameter("Type",
                    (dt1.Rows.Count == 0 ||  dt1.Rows[0]["TYPE"].ToString().Trim() == "") ? dt2.Rows[0]["TYPE"].ToString() : dt1.Rows[0]["TYPE"].ToString() 
                ),
                new ReportParameter("CmptStart", this.getFirstCmpt(dt1,dt2)  ),
                new ReportParameter("CmptEnd", this.getLastCmpt(dt1,dt2)  )
            };
            ReportDataSource rds = new ReportDataSource("DataSet1Part",
                    DataTableProcessing(dt1,
                    new System.DateTime(year, Month -1 , 21),
                    new System.DateTime(year, Month, 05))
                );
            rptViewer.LocalReport.DataSources.Add(rds);
            ReportDataSource rds2 = new ReportDataSource("DataSet2Part",
                    DataTableProcessing(dt2,
                    new System.DateTime(year, Month, 06),
                    new System.DateTime(year, Month, 20))
                );  
            rptViewer.LocalReport.DataSources.Add(rds2);
            
            ReportDataSource rds3 = new ReportDataSource("dsEngine",
                   tmpgetData()
                );  
            rptViewer.LocalReport.DataSources.Add(rds3);
            
            //path
            rptViewer.LocalReport.ReportPath = "RptEngineConsumption.rdlc"; //RptEngineConsumptionALL.rdlc
            /* */
            // Parameters

            //MessageBox.Show( dt2.Rows.Count.ToString()  );
            //#hotfix2

            rptViewer.LocalReport.SetParameters(rptParams);

            //Refresh 
            rptViewer.Refresh();
        }
        private DataTable DataTableProcessing(DataTable dtLocal, DateTime dFrom, DateTime dTo)
        {
            //DataRow FirstDR = (dt == null || dt.Rows.Count == 0)?dt.NewRow():dt.Rows[0] ;
            //MessageBox.Show(" From " + dFrom.ToShortDateString() + "  To " + dTo.ToShortDateString());
            for (DateTime i = dFrom ; i <= dTo ; i = i.AddDays(1) )
            {

                //  MessageBox.Show(" Processecing " + i.ToShortDateString());
                // DateTime obj = System.DateTime.Now ;
                /*bool isDate = DateTime.TryParse(FirstDR["Date"].ToString(), out obj );
                if ( !isDate || i.Day != DateTime.Parse(FirstDR["Date"].ToString()).Day) //!= FirstDR["Date"].Value
                {

                    DataRow row = dt.NewRow();
                    row["Ref"] = FirstDR["Ref"];
                    row["Date"] = i.ToShortDateString();
                    row["Quantité"] = 0;
                    */
                
                DataRow row = this.SearchByDate(dtLocal, i);
                if (row == null)
                {
                    this.AddNewRow(dtLocal, i);
                    /*DataRow dr2 = dtLocal.NewRow();

                    dr2["Ref"] = "";
                    dr2["Date"] = i.ToShortDateString();
                    dr2["Quantité"] = 0;

                    dtLocal.Rows.Add( dr2 );
                    */
                    //this.AddNewRow(dtLocal, i);

                }
                
                //MessageBox.Show("inserted : "+row["Date"].ToString());
            }
            /*
            DataRow row = this.SearchByDate(dtLocal, new System.DateTime(dFrom.Year,dFrom.Month,31) );
            if (row == null)
            {
                DataRow dr2 = dtLocal.NewRow();

                dr2["Ref"] = "";
                dr2["Date"] = new System.DateTime(dFrom.Year, dFrom.Month, 31).ToShortDateString();
                dr2["Quantité"] = 0;

                dtLocal.Rows.Add(dr2);
            }
            */
            DataView dv = dtLocal.DefaultView;
            dv.Sort = "Date asc";
            dtLocal = dv.ToTable();
            //MessageBox.Show( i.ToString() );
            return dtLocal;
        }
        private string getCmpt(DataTable dt, string ord)
        { // method to get the millage of the car
            DataView dv = dt.DefaultView;
            dv.Sort = "Date "+ ord + " ,  recordInsertedIn "+ ord;
            dt = dv.ToTable();
            foreach (DataRow dr in dt.Rows)
            {
                string STRIMEDKM = dr["Kilometrage"].ToString().Trim().ToLower();
                if (STRIMEDKM.Length > 2 )
                {
                    // && (   int.TryParse(STRIMEDKM.Substring(0, STRIMEDKM.Length - 2 ),out int a ) )
                    // unfortunatly the condition is not accurate
                    // #hotfix
                    return dr["Kilometrage"].ToString().Trim();
                }
            }
            return "";
        }
        private string getFirstCmpt(DataTable firstTable, DataTable SecondTable)
        {
            string firstCmpt = getCmpt(firstTable, "ASC ");

            if (firstCmpt == "")
            {
                return getCmpt(SecondTable, "ASC ");
            }
            else
                return firstCmpt;
        }
        private string getLastCmpt(DataTable firstTable, DataTable SecondTable)
        {
            string LastCmpt = getCmpt(SecondTable , "DESC ");

            if (LastCmpt == "")
            {
                return getCmpt(firstTable, "DESC ");
            }
            else
                return LastCmpt;
        }
        private void AddNewRow(DataTable dtLocal  , DateTime dtNow )
        {
                DataRow dr2 = dtLocal.NewRow();
                dr2["Ref"] = "";
                dr2["Date"] = dtNow.ToShortDateString();
                //dr2["Quantité"] = 0;

                dtLocal.Rows.Add(dr2);
            

        }
        private DataRow SearchByDate(DataTable dt, DateTime datetime)
        {
            foreach (DataRow dr in dt.Rows)
            {
                DateTime localDT = DateTime.Parse(dr["Date"].ToString());
                if ((datetime.Day == localDT.Day) && (datetime.Month == localDT.Month) && (datetime.Year == localDT.Year))
                {
                    //MessageBox.Show(localDT.ToShortDateString() + " Found it ");
                    return dr;
                } 
            }
            

            return null ;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
               EngineComboBox.setTextBox("");
                EngineComboBox.Enabled = !ToutChkBox.Checked ;
            ShowRptBtn.Text = ( EngineComboBox.Enabled == true ) ? "Afficher" : "Imprimer";


        }
    }

}
