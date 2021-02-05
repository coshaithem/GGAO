using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO
{
    public class AlimentationCRUDOps
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);

        public static DataTable getVisibleAlimentation()
        {
            DataTable dt = new DataTable(); 
            System.Data.DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUDAlimentation", con);
                cmd.Parameters.AddWithValue("@choise", SqlDbType.NVarChar).Value = "SELECTALL";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill( ds );  
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "List des bons Alimentation", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); 
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            return ds.Tables[0];
        }
        public static void createAlimentation(String Ref ,String Type ,DateTime DocDate ,String engineID ,String productID, string poleID,
            string driverID, string kilo, string quanity )
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDAlimentation", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ref", SqlDbType.NVarChar).Value = Ref; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = Type;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@DocDate", SqlDbType.DateTime).Value = DocDate ;
                cmd.Parameters.AddWithValue("@engineID", SqlDbType.NVarChar).Value = engineID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@productID", SqlDbType.NVarChar).Value = productID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.NVarChar).Value = poleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@driverID", SqlDbType.NVarChar).Value = driverID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@kilo", SqlDbType.NVarChar).Value = kilo; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@quanity", SqlDbType.NVarChar).Value = quanity; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "INSERT";
 
                cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le nouveau bon a été enregistré. ",
                                   "Nouveau Bon", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Nouveau Bon", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        public static void UpdateAlimentation(string ID, String Ref, String Type, DateTime DocDate, String engineID, String productID, string poleID,
            string driverID, string kilo, string quanity)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDAlimentation", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Ref", SqlDbType.NVarChar).Value = Ref; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = Type;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@DocDate", SqlDbType.DateTime).Value = DocDate;
                cmd.Parameters.AddWithValue("@engineID", SqlDbType.NVarChar).Value = engineID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@productID", SqlDbType.NVarChar).Value = productID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.NVarChar).Value = poleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@driverID", SqlDbType.NVarChar).Value = driverID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@kilo", SqlDbType.NVarChar).Value = kilo; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@quanity", SqlDbType.NVarChar).Value = quanity; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "UPDATE";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("le bon a été enregistré. ",
                                   "Metre a jour un bon", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Metre a jour un chaffeure", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        
        public static void deleteAlimentation(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDAlimentation", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "DELETE";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("le bon a été supprimer. ",
                                   "Suppression d'un bon", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Suppression d'un bon", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
    
    }
}
