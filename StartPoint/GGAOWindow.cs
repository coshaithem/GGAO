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
using GGAO.Product;
using GGAO.Pole;
namespace GGAO
{
    public partial class GGAOWindow : Form
    {
        SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        private byte activeTable = 0 ;
        /*
         0 - none 
         1 - alimentation
         2 - consommation
         3 - produit
         4 - pole
         5 - Driver
         6 - engine
         
         */
        private BindingSource lastSelectedBindingSource = null;

        public GGAOWindow()
        {
            InitializeComponent();
             
        }

        private void resetDGVMain()
        {
            if (getTheMainGrid().Columns.Count >= 1)
                getTheMainGrid().Columns.Clear();

            if (getTheMainGrid().Rows.Count >= 1)
                getTheMainGrid().Rows.Clear();

            if (lastSelectedBindingSource != null) { 
                lastSelectedBindingSource = null;
                getTheMainGrid().DataSource = null;
            }
            getTheMainGrid().AutoGenerateColumns = true; 
 
        }

         private void LoadVisible( string table)
        {


            resetDGVMain();
            BindingSource MyOwnBindingSource = new BindingSource();
            switch ( table)
            {
                case "Driver": MyOwnBindingSource.DataSource = DriverCRUDOps.getVisibleDriver(); break;
                case "Product": MyOwnBindingSource.DataSource = ProductCRUDOps.getVisibleProduct(); break;
                case "Pole": MyOwnBindingSource.DataSource = PoleCRUDOps.getVisiblePole() ; break;
            }
            lastSelectedBindingSource = MyOwnBindingSource;
            getTheMainGrid().DataSource = MyOwnBindingSource;
            // you should add Status Label .text here
            this.StatusLabel.Text = string.Format("Mise a jour "+table+"  {0}",
                DateTime.Now.ToString("hh:mm:ss")
                );

        }
         
        private void NewDriverBtn_Click(object sender, EventArgs e)
        {
            if ( this.activeTable == 5) { 
                InsertUpdateDriver form = new InsertUpdateDriver(true);
                form.ShowDialog();
                LoadVisible("Driver");
            }

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
            LoadVisible("Driver");
            this.activeTable = 5;
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();

        }

        
        int selectedRowIndex = -1, selectedColIndex = -1;
        private void DGVMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             
           selectedColIndex = e.ColumnIndex;
            selectedRowIndex = e.RowIndex;
            //MessageBox.Show(DGVMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), " selected ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

       

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            
            bool filter = DGVMain.FilterAndSortEnabled;

            if ( DGVMain.Columns.Count >= 1)
            {

                //DGVMain.SetFilterEnabled(DGVMain.Columns[1], true);
                //MessageBox.Show(" NB Column " +  DGVMain.Columns.Count.ToString() );
                /*
                if (filter) // if its true means show the user the disable img
                {
                    this.clearFilterSortString();

                    
                }
                else // means show the user the enable img
                {
                    
                }*/
                this.toggleFilterAndSort();
            }

            
        }

        private void toggleFilterAndSort()
        {
            bool filter = DGVMain.FilterAndSortEnabled;
            if ( filter )
            {
                this.allowUserToActivateFilter();
            }
            else
            {
                this.allowUserToDisableFilter();
            }

            foreach (DataGridViewColumn col in DGVMain.Columns)
                DGVMain.SetFilterAndSortEnabled(col, !filter);
            DGVMain.FilterAndSortEnabled = !filter;
            this.clearFilterSortString();
        }

        private void clearFilterSortString()
        {
            // First disable filter and Sort
            lastSelectedBindingSource.Sort = "";
            lastSelectedBindingSource.Filter = "";
        }

        private void allowUserToActivateFilter()
        {
            // change the image
            this.FilterBtn.Image = global::GGAO.Properties.Resources.EnableFilter;
            this.FilterBtn.LargeImage = global::GGAO.Properties.Resources.EnableFilter; 
        }

        private void allowUserToDisableFilter()
        {
            this.FilterBtn.Image = global::GGAO.Properties.Resources.DisableFilter;
            this.FilterBtn.LargeImage = global::GGAO.Properties.Resources.DisableFilter;
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

        private void ProductBtn_Click(object sender, EventArgs e)
        {
            LoadVisible("Product");
            this.activeTable = 3; 
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();

        }

        private void NewProductBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 3)
            { //InsertUpdateDriver form = new InsertUpdateDriver(true);
                InsertUpdateProduct form = new InsertUpdateProduct(true);
                form.ShowDialog();
                LoadVisible("Product");
            }
        }

        private void EditProductBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 3)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , Nom = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                    , ptype = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , pdesc = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString();
                    InsertUpdateProduct form = new InsertUpdateProduct(false); 
                    form.setDefaultValueforFields(ID, Nom,ptype,pdesc);
                    form.ShowDialog();
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible("Product");
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        

        private void PoleBtn_Click(object sender, EventArgs e)
        {
            LoadVisible("Pole");
            this.activeTable = 4;
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();

        }

        private void NewPoleBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 4)
            { //InsertUpdateDriver form = new InsertUpdateDriver(true);
              // InsertUpdateProduct form = new InsertUpdateProduct(true);
                InsertUpdatePole form = new InsertUpdatePole(true);  
                form.ShowDialog();
                LoadVisible("Pole");
            }
        }

        private void EditPoleBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 4)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , lib = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                    , addr = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , desc = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString();

                    //InsertUpdateDriver form = new InsertUpdateDriver(false);
                    InsertUpdatePole form = new InsertUpdatePole(false);
                    form.setDefaultValueforFields(ID, lib, addr, desc);
                    form.ShowDialog();
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible("Pole");
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        

        private void EditDriverBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 5)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
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

                    LoadVisible("Driver");
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void DelPoleBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 4)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        PoleCRUDOps.deletePole(ID);
                        //DriverCRUDOps.deleteDriver(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible("Pole");
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }
        private void DelDriverBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 5)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        DriverCRUDOps.deleteDriver(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible("Driver");
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }
        private void DelProductBtn_Click(object sender, EventArgs e)
        {
            if (this.activeTable == 3)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        ProductCRUDOps.deleteProduct(ID);
                        // DriverCRUDOps.deleteDriver(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible("Product");
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }
    }
}
