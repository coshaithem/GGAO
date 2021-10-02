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
    public class NaftalCardCRUDOps
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        
        public static DataTable getVisibleNaftalCard()
        {
            DataTable dt = new DataTable(); 
            System.Data.DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUDNaftalCard", con);
                cmd.Parameters.AddWithValue("@choise", SqlDbType.NVarChar).Value = "SELECT";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill( ds );  
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Liste des Cartes", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); 
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            return ds.Tables[0];
        }
        public static void createNaftalCard(  String _code  ,String _numero, String _libelle, DateTime _date  )
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDNaftalCard", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Code", SqlDbType.NVarChar).Value = _code; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Numéro", SqlDbType.NVarChar).Value = _numero;
                cmd.Parameters.AddWithValue("@Libelle", SqlDbType.NVarChar).Value = _libelle;
                cmd.Parameters.AddWithValue("@expiredDate", SqlDbType.DateTime ).Value = _date ;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "INSERT";

                string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("la carte est enregistré. ",
                                   "Nouveau carte", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Nouveau carte", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        public static void UpdateNaftalCard(string ID, String _code, String _numero, String _libelle, DateTime _date)
        {
            try
            {
                con.Open();
                
                SqlCommand cmd = new SqlCommand("CRUDNaftalCard", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Code", SqlDbType.NVarChar).Value = _code; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Numéro", SqlDbType.NVarChar).Value = _numero;
                cmd.Parameters.AddWithValue("@Libelle", SqlDbType.NVarChar).Value = _libelle;
                cmd.Parameters.AddWithValue("@expiredDate", SqlDbType.DateTime).Value = _date;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "UPDATE";

                //string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                //cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("la carte est enregistré. ",
                                   "Mettre a jour une carte", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Mettre a jour la carte", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        
        public static void deleteNaftalCard(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDNaftalCard", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "DELETE";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("la carte a été supprimer. ",
                                   "Suppression la carte", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Suppression la carte", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
    
    }
}
