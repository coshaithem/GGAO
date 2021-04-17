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
    public class DriverCRUDOps
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);

        public static DataTable getVisibleDriver()
        {
            DataTable dt = new DataTable(); 
            System.Data.DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUDDriver", con);
                cmd.Parameters.AddWithValue("@choise", SqlDbType.NVarChar).Value = "SELECT";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill( ds );  
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "List des chaffeures", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); 
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            return ds.Tables[0];
        }
        public static void createDriver( 	String Nom  ,String Prenom ,String CIN ,DateTime DateNaissance  ,String LieuNaissance ,String Mobile )
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDDriver", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom", SqlDbType.NVarChar).Value = Nom; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Prenom", SqlDbType.NVarChar).Value = Prenom;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@CIN", SqlDbType.NVarChar).Value = CIN; // this.cINTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@DateNaissance", SqlDbType.DateTime).Value = DateNaissance ;
                cmd.Parameters.AddWithValue("@LieuNaissance", SqlDbType.NVarChar).Value = LieuNaissance; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Mobile; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "INSERT";

                string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le nouveau chauffeure est enregistré. ",
                                   "Nouveau chaffeure", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Nouveau chaffeure", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        public static void UpdateDriver(string ID, String Nom, String Prenom, String CIN, DateTime DateNaissance, String LieuNaissance, String Mobile)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDDriver", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Nom", SqlDbType.NVarChar).Value = Nom; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Prenom", SqlDbType.NVarChar).Value = Prenom;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@CIN", SqlDbType.NVarChar).Value = CIN; // this.cINTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@DateNaissance", SqlDbType.DateTime).Value = DateNaissance;
                cmd.Parameters.AddWithValue("@LieuNaissance", SqlDbType.NVarChar).Value = LieuNaissance; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Mobile", SqlDbType.NVarChar).Value = Mobile; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "UPDATE";

                //string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                //cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le chauffeure est enregistré. ",
                                   "Metre a jour un chaffeure", MessageBoxButtons.OK,
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
        
        public static void deleteDriver(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDDriver", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "DELETE";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("le chauffeure a été supprimer. ",
                                   "Suppression d'un chaffeure", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Suppression d'un chaffeure", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
    
    }
}
