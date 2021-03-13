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
    public class ConsommationCRUDOps
    {
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);

        public static DataTable getVisibleConsommation()
        {
            DataTable dt = new DataTable(); 
            System.Data.DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUDConsommation", con);
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
        public static void createConsommation(String Ref ,String Type ,DateTime DocDate ,String engineID ,String productID, string poleID,
            string driverID, string kilo, string quanity, bool print, bool calc )
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDConsommation", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ref", SqlDbType.NVarChar).Value = Ref; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = Type;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = DocDate ;
                cmd.Parameters.AddWithValue("@engineID", SqlDbType.NVarChar).Value = engineID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@productID", SqlDbType.NVarChar).Value = productID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.NVarChar).Value = poleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@driverID", SqlDbType.NVarChar).Value = driverID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@kilo", SqlDbType.NVarChar).Value = kilo; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@quant", SqlDbType.NVarChar).Value = quanity; // this.mobileTextBox.Text.Trim();
                
                cmd.Parameters.AddWithValue("@print", SqlDbType.Bit ).Value = print; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@calc", SqlDbType.Bit ).Value = calc; // this.mobileTextBox.Text.Trim();


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
        public static void UpdateConsommation(string ID, String Ref, String Type, DateTime DocDate, String engineID, String productID, string poleID,
            string driverID, string kilo, string quanity, bool print, bool calc)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDConsommation", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Ref", SqlDbType.NVarChar).Value = Ref; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = Type;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = DocDate;
                cmd.Parameters.AddWithValue("@engineID", SqlDbType.NVarChar).Value = engineID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@productID", SqlDbType.NVarChar).Value = productID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.NVarChar).Value = poleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@driverID", SqlDbType.NVarChar).Value = driverID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@kilo", SqlDbType.NVarChar).Value = kilo; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@quant", SqlDbType.NVarChar).Value = quanity; // this.mobileTextBox.Text.Trim();

                cmd.Parameters.AddWithValue("@print", SqlDbType.Bit).Value = print; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@calc", SqlDbType.Bit).Value = calc; // this.mobileTextBox.Text.Trim();
                

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
        public static void deleteConsommation(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDConsommation", con);
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
    
        public static int getSumOfQuantities()
        {
            int sum = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDConsommation", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "SUMQuanity";
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                int mySum = 0;
                if (rdr.GetValue(0) != System.DBNull.Value )
                    mySum = Convert.ToInt32(rdr[0]);
                //MessageBox.Show("The sum is: " + mySum.ToString());

                sum = mySum;
            }
            catch (Exception exs)
            { //2007 DEBUT OUMACHE
                MessageBox.Show(exs.ToString()," ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
            return sum; 
        }
    }
}
