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
using GGAO.Driver;
namespace GGAO
{
    public partial class GGAOWindow : Form
    {
        SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);

        
        private BindingSource lastSelectedBindingSource = null;

        public GGAOWindow()
        {
            InitializeComponent();
             
        }
        
        private void Form1_Load(object sender, EventArgs e)
        { 
            // TODO: This line of code loads data into the 'gGAODataSet.Driver' table. You can move, or remove it, as needed.
           // this.driverTableAdapter.Fill(this.gGAODataSet.Driver);
             

        }


        private  void resetDGVMain()
        {
            getTheMainGrid().Columns.Clear();
            getTheMainGrid().AutoGenerateColumns = true; 
 
        }

         

        public void LoadVisibleDriver()
        {
            resetDGVMain();
            /*
            SqlCommand cmd = new SqlCommand("CRUDDriver", con);
            cmd.Parameters.AddWithValue("@choise", SqlDbType.NVarChar).Value = "SELECT";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            */
            BindingSource MyOwnBindingSource = new BindingSource();
            MyOwnBindingSource.DataSource = DriverCRUDOps.getVisibleDriver();
            //this.MyOwnBindingSource.DataMember = "Driver";
            lastSelectedBindingSource = MyOwnBindingSource;
            getTheMainGrid().DataSource =  MyOwnBindingSource ;
            // you should add Status Label .text here
            this.StatusLabel.Text = string.Format("Mise a jour {0}",
                DateTime.Now.ToString("dd/MM/yyyy  hh:mm:ss") 
                );
        }


        private void NewDriverBtn_Click(object sender, EventArgs e)
        {
            InsertUpdateDriver form = new InsertUpdateDriver(true);
            
            form.ShowDialog();
            LoadVisibleDriver();
        }
 

        private void updateTotalRow()
        {
            this.StatusLabel.Text = string.Format("Total row {0}",
                this.lastSelectedBindingSource.List.Count
                );
        }

        private void ribbon1_Click(object sender, EventArgs e)
        {

        }

        private void AugmentFont_Click(object sender, EventArgs e)
        {
            float fontsize = DGVMain.DefaultCellStyle.Font.Size;
            if (fontsize < 30)
            {
                DGVMain.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", fontsize + 2);
                //DGVMain.RowTemplate.Height = DGVMain.RowTemplate.Height + 2;
               /* 
                foreach (DataGridViewRow x in DGVMain.Rows)
                {
                    x.Height = x.Height + 2 ;
                }
               */
            }
        }


        private void ReduireFont_Click(object sender, EventArgs e)
        {
            float fontsize = DGVMain.DefaultCellStyle.Font.Size;
            if ( fontsize > 16) 
            { 
                DGVMain.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", fontsize - 2 );
                //DGVMain.RowTemplate.Height = DGVMain.RowTemplate.Height - 2 ;
                /*
                foreach (DataGridViewRow x in DGVMain.Rows)
                {
                    x.Height = x.Height - 2;
                }
                */
            }
        }

     

        private void DriverBtn_Click(object sender, EventArgs e)
        {
            
            LoadVisibleDriver();
        }

        
        int selectedRowIndex = -1, selectedColIndex = -1;
        private void DGVMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             
           selectedColIndex = e.ColumnIndex;
            selectedRowIndex = e.RowIndex;
            //MessageBox.Show(DGVMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), " selected ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void DelDriverBtn_Click(object sender, EventArgs e)
        {
            // get the ID of the selected row
            if (selectedRowIndex >= 0)
            {
                string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString() ;

                // ask comfirmation from the user  
                if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation ) == DialogResult.Yes)
                {
                    DriverCRUDOps.deleteDriver(ID);
                }
                // to  obligate the user to reselect
                selectedRowIndex = -1;
                selectedColIndex = -1;
                LoadVisibleDriver();
            }
            else
            {
                MessageBox.Show("Selectioner une ligne pour supprimer",
                   "Action incorrect", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
           
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            
            bool filter = DGVMain.FilterAndSortEnabled;

            if ( DGVMain.Columns.Count >= 1)
            {
                foreach( DataGridViewColumn col in DGVMain.Columns  )
                   DGVMain.SetFilterAndSortEnabled(col  , !filter);

                //DGVMain.SetFilterEnabled(DGVMain.Columns[1], true);
                //MessageBox.Show(" NB Column " +  DGVMain.Columns.Count.ToString() );

                if (filter) // if its true means show the user the disable img
                {
                    // First disable filter and Sort
                    lastSelectedBindingSource.Sort = "";
                    lastSelectedBindingSource.Filter = "";
                    
                    // change the image
                    this.FilterBtn.Image = global::GGAO.Properties.Resources.EnableFilter;
                    this.FilterBtn.LargeImage = global::GGAO.Properties.Resources.EnableFilter;
                }
                else // means show the user the enable img
                {
                    this.FilterBtn.Image = global::GGAO.Properties.Resources.DisableFilter;
                    this.FilterBtn.LargeImage = global::GGAO.Properties.Resources.DisableFilter;
                }
                DGVMain.FilterAndSortEnabled = !filter;
            }

            
        }


        private void DGVMain_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            if (lastSelectedBindingSource != null)
            {
                lastSelectedBindingSource.Sort = DGVMain.SortString;
                this.updateTotalRow();  
            }
        }  

        private void DGVMain_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            if (lastSelectedBindingSource != null)
            {
                lastSelectedBindingSource.Filter = DGVMain.FilterString;
                this.updateTotalRow();
            }
        }

        private void EditDriverBtn_Click(object sender, EventArgs e)
        {
            // get the ID of the selected row
            if (selectedRowIndex >= 0) { 
                string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                , Nom = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                , Prenom = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                , CIN = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString()
                , DATE = DGVMain.Rows[selectedRowIndex].Cells[4].Value.ToString()
                , Lieu = DGVMain.Rows[selectedRowIndex].Cells[5].Value.ToString()
                , Mobile = DGVMain.Rows[selectedRowIndex].Cells[6].Value.ToString();

                InsertUpdateDriver form = new InsertUpdateDriver(false);
                form.setDefaultValueforFields(ID, Nom, Prenom, CIN, DATE, Lieu, Mobile);
                form.ShowDialog();
                // to  obligate the user to reselect
                selectedRowIndex = -1;
                selectedColIndex = -1;

                LoadVisibleDriver();
            }
            else
            {
                MessageBox.Show("Selectioner une ligne pour modifier",
                   "Action incorrect", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
        }
    }
}
