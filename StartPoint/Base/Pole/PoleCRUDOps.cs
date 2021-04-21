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
    public class PoleCRUDOps
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        
        public static DataTable getVisiblePole(bool Stock,string choises)
        {
            DataTable dt = new DataTable(); 
            System.Data.DataSet ds = new DataSet();
            try
            {

                //MessageBox.Show(Stock.ToString()+"  "+ choises, "Liste des pôles", MessageBoxButtons.OK,  MessageBoxIcon.Error);

                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDPole", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = choises;

                //MessageBox.Show(cmd.Parameters.ToString() , "Liste des pôles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if ( choises.ToLower().Equals("select"))
                    cmd.Parameters.AddWithValue("@stoc", SqlDbType.Bit).Value = Stock;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill( ds );  
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Liste des pôles", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); 
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            
            return ds.Tables[0];
        }
        public static void createPole(  String Libelle  ,String address, String desc , bool stock )
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDPole", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Libelle", SqlDbType.NVarChar).Value = Libelle; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Addresse", SqlDbType.NVarChar).Value = address;
                cmd.Parameters.AddWithValue("@Descriptions", SqlDbType.NVarChar).Value = desc;
                cmd.Parameters.AddWithValue("@stoc", SqlDbType.NVarChar).Value = stock;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "INSERT";

                string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le nouveau pôle est enregistré. ",
                                   "Nouveau pôle", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Nouveau pôle", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        public static void UpdatePole(string ID, String Libelle, String address, String desc, bool stock)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDPole", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@Libelle", SqlDbType.NVarChar).Value = Libelle; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Addresse", SqlDbType.NVarChar).Value = address;
                cmd.Parameters.AddWithValue("@Descriptions", SqlDbType.NVarChar).Value = desc;

                cmd.Parameters.AddWithValue("@stoc", SqlDbType.NVarChar).Value = stock;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "UPDATE";

                //string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                //cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le pôle est enregistré. ",
                                   "Metre a jour un pôle", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Metre a jour un pôle", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        
        public static void deletePole(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDPole", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "DELETE";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("le pôle a été supprimer. ",
                                   "Suppression d'un pôle", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Suppression d'un pôle", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
    
    }
}
