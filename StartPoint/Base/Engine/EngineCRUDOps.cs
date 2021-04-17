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
    public class EngineCRUDOps
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        
        public static DataTable getVisibleEngine()
        {
            DataTable dt = new DataTable(); 
            System.Data.DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUDEngine", con);
                cmd.Parameters.AddWithValue("@choise", SqlDbType.NVarChar).Value = "SELECTwithPole";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill( ds );  
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Liste des engines", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); 
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            return ds.Tables[0];
        }
        public static void createEngine(String Libelle, String MatriculeIn, String MatriculeNat, string marque, string color, string poleID
            , string type, string serie)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDEngine", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Libelle", SqlDbType.NVarChar).Value = Libelle; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@MatriculeIntern", SqlDbType.NVarChar).Value = MatriculeIn;
                cmd.Parameters.AddWithValue("@MatriculeNational", SqlDbType.NVarChar).Value = MatriculeNat ;
                cmd.Parameters.AddWithValue("@Marque", SqlDbType.NVarChar).Value = marque ;
                cmd.Parameters.AddWithValue("@Couleur", SqlDbType.NVarChar).Value = color;
                cmd.Parameters.AddWithValue("@TYPE", SqlDbType.NVarChar).Value = type;
                cmd.Parameters.AddWithValue("@SERIE", SqlDbType.NVarChar).Value = serie;
                int poleId;
                bool parseOps = int.TryParse(poleID, out poleId);
                if (!parseOps) poleId = -1;
                cmd.Parameters.AddWithValue("@PoleID", SqlDbType.Int).Value = poleId ;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "INSERT";

                string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le nouveau engine est enregistré. ",
                                   "Nouveau engine", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Nouveau engine", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        public static void UpdateEngine(string ID, String Libelle, String MatriculeIn, String MatriculeNat, string marque, string color, string poleID
            , string type, string serie)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDEngine", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@Libelle", SqlDbType.NVarChar).Value = Libelle; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@MatriculeIntern", SqlDbType.NVarChar).Value = MatriculeIn;
                cmd.Parameters.AddWithValue("@MatriculeNational", SqlDbType.NVarChar).Value = MatriculeNat;
                cmd.Parameters.AddWithValue("@Marque", SqlDbType.NVarChar).Value = marque;
                cmd.Parameters.AddWithValue("@Couleur", SqlDbType.NVarChar).Value = color;

                cmd.Parameters.AddWithValue("@TYPE", SqlDbType.NVarChar).Value = type;
                cmd.Parameters.AddWithValue("@SERIE", SqlDbType.NVarChar).Value = serie;

                if ( poleID != null) { 
                    int poleId;
                    bool parseOps = int.TryParse(poleID, out poleId);
                    if (!parseOps) poleId = 0;
                        cmd.Parameters.AddWithValue("@PoleID", SqlDbType.Int).Value = poleId;
                }
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "UPDATE";

                //string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                //cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le engine est enregistré. ",
                                   "Metre a jour un engine", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Metre a jour un engine", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        
        public static void deleteEngine(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDEngine", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "DELETE";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("l'engine a été supprimer. ",
                                   "Suppression d'engine", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Suppression d'engine", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
    
    }
}
