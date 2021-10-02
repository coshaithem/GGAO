using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GGAO.Stock.Transfer
{
    class TransferCRUDOps
    {
        public enum Target{
            Source,
            Destination
            }
        static SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);

        public static DataTable getVisibleTransfer()
        {
            DataTable dt = new DataTable();
            System.Data.DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("CRUDTransfer", con);
                cmd.Parameters.AddWithValue("@choise", SqlDbType.NVarChar).Value = "SELECTALL";

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                   "List des bons Transfer", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            //MessageBox.Show(" DataSet Tables number " + ds.Tables.Count.ToString() + "   "+ds.Tables[0].TableName  );
            return ds.Tables[0];
        }
        public static void createTransfer(String Ref, String Type, DateTime DocDate, String engineID, String productID, string poleID, string toPoleID,
            string driverID, string kilo, string quanity)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDTransfer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ref", SqlDbType.NVarChar).Value = Ref; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = Type;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = DocDate;
                cmd.Parameters.AddWithValue("@engineID", SqlDbType.NVarChar).Value = engineID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@productID", SqlDbType.NVarChar).Value = productID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.NVarChar).Value = poleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@ToPoleID", SqlDbType.NVarChar).Value = toPoleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@driverID", SqlDbType.NVarChar).Value = driverID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@kilo", SqlDbType.NVarChar).Value = kilo; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@quant", SqlDbType.NVarChar).Value = quanity; // this.mobileTextBox.Text.Trim();

                //cmd.Parameters.AddWithValue("@print", SqlDbType.Bit).Value = print; // this.mobileTextBox.Text.Trim();
                //cmd.Parameters.AddWithValue("@calc", SqlDbType.Bit).Value = calc; // this.mobileTextBox.Text.Trim();


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
        public static void UpdateTransfer(string ID, String Ref, String Type, DateTime DocDate, String engineID, String productID, string poleID, string toPoleID,
            string driverID, string kilo, string quanity)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDTransfer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = ID; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Ref", SqlDbType.NVarChar).Value = Ref; // this.nomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Type", SqlDbType.NVarChar).Value = Type;// this.prenomTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@Date", SqlDbType.DateTime).Value = DocDate;
                cmd.Parameters.AddWithValue("@engineID", SqlDbType.NVarChar).Value = engineID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@productID", SqlDbType.NVarChar).Value = productID; // this.lieuNaissanceTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@poleID", SqlDbType.NVarChar).Value = poleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@ToPoleID", SqlDbType.NVarChar).Value = toPoleID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@driverID", SqlDbType.NVarChar).Value = driverID; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@kilo", SqlDbType.NVarChar).Value = kilo; // this.mobileTextBox.Text.Trim();
                cmd.Parameters.AddWithValue("@quant", SqlDbType.NVarChar).Value = quanity; // this.mobileTextBox.Text.Trim();

                //cmd.Parameters.AddWithValue("@print", SqlDbType.Bit).Value = print; // this.mobileTextBox.Text.Trim();
                //cmd.Parameters.AddWithValue("@calc", SqlDbType.Bit).Value = calc; // this.mobileTextBox.Text.Trim();


                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = "UPDATE";

                cmd.ExecuteNonQuery();

                MessageBox.Show("le bon a été enregistré. ",
                                   "Mettre a jour un bon", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
            }
            catch (Exception exs)
            {

                MessageBox.Show(exs.ToString(),
                                     "Mettre a jour un chaffeure", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
        }
        public static void deleteTransfer(string ID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDTransfer", con);
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

        public static int GetSumOfQuantities(Target choice,string poleID)
        {
            int sum = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CRUDTransfer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PoleID", SqlDbType.NVarChar).Value = poleID ;
                cmd.Parameters.AddWithValue("@choice", SqlDbType.NVarChar).Value = (choice == Target.Source) ? "SumQuantityIn" : "SumQuantityOut";
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                int mySum = 0;
                if (rdr.GetValue(0) != System.DBNull.Value)
                    mySum = Convert.ToInt32(rdr[0]);
                //MessageBox.Show("The sum is: " + mySum.ToString());

                sum = mySum;
            }
            catch (Exception exs)
            { //2007 DEBUT OUMACHE
                MessageBox.Show(exs.ToString(), " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                con.Close();
            }
            return sum;
        }
    }
}
