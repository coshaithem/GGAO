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
    public class ProductCRUDOps
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        
        public static DataTable getVisibleProduct()
        {
            DataTable dt = new DataTable(); 
            System.Data.DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUDProduct", con);
                cmd.Parameters.AddWithValue("@choise", SqlDbType.NVarChar).Value = "SELECT";

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill( ds );  
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Liste des Produits", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close(); 
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            return ds.Tables[0];
        }
        public static void createProduct(  String DESIGN  ,String PTYPE, String desc  )
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DESIGNATION", SqlDbType.NVarChar).Value = DESIGN; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@PTYPE", SqlDbType.NVarChar).Value = PTYPE;
                cmd.Parameters.AddWithValue("@DESCR", SqlDbType.NVarChar).Value = desc;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "INSERT";

                string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le nouveau produit est enregistré. ",
                                   "Nouveau produit", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "Nouveau produit", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        public static void UpdateProduct(string ID, String DESIGN, String PTYPE, String desc)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@DESIGNATION", SqlDbType.NVarChar).Value = DESIGN;  
                cmd.Parameters.AddWithValue("@PTYPE", SqlDbType.NVarChar).Value = PTYPE;
                cmd.Parameters.AddWithValue("@DESCR", SqlDbType.NVarChar).Value = desc;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "UPDATE";

                //string formattedTime = DateTime.Now.ToString("yyyy, MM, dd, hh, mm, ss");

                //cmd.Parameters.AddWithValue("@recordInsertedIn", SqlDbType.DateTime).Value = DateTime.Now;
                //cmd.Parameters.AddWithValue("@recordView", SqlDbType.Bit).Value = true;

                cmd.ExecuteNonQuery();

                MessageBox.Show("le produit est enregistré. ",
                                   "Metre a jour un produit", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Metre a jour un produit", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        
        public static void deleteProduct(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDProduct", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "DELETE";
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("le produit a été supprimer. ",
                                   "Suppression d'un produit", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                    "Suppression d'un produit", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
    
    }
}
