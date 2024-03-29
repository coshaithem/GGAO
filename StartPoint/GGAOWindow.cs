﻿using System;
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
using GGAO.Engine;
using GGAO.NaftalCard;
using GGAO.Consommation;
using GGAO.Alimentation;
using GGAO.Stock.Transfer;
using GGAO.Stock.Consommation;

namespace GGAO
{
    public partial class GGAOWindow : Form
    {
        enum Table
        {
            NONE,
            ALIMENTATION,
            CONSOMMATION,
            TRANSFER,
            PRODUIT,
            POLE,
            DRIVER,
            ENGINE,
            NaftalCard,
        }
        DateTime dateFrom, dateTo;
        private const bool V = true;
        SqlConnection con = new SqlConnection(GGAO.Properties.Settings.Default.GGAOConnectionString);
        private Table selectedTable = Table.NONE;
        /*
         0 - none 
         1 - alimentation
         2 - consommation
         3 - produit
         4 - pole
         5 - Driver
         6 - engine
         7 - NaftalCard
         
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
        
            getTheMainGrid().AutoGenerateColumns = true; 
         
            if (lastSelectedBindingSource != null) { 
                lastSelectedBindingSource = null;
                getTheMainGrid().DataSource = null;
            }
        }

         private void LoadVisible( Table table )
        { 
            resetDGVMain();
            BindingSource MyOwnBindingSource = new BindingSource();
            switch ( table)
            {
                case Table.DRIVER : MyOwnBindingSource.DataSource = DriverCRUDOps.getVisibleDriver(); break;
                case Table.PRODUIT : MyOwnBindingSource.DataSource = ProductCRUDOps.getVisibleProduct(); break;
                case Table.POLE : MyOwnBindingSource.DataSource = PoleCRUDOps.getVisiblePole(true,"ALL") ; break;
                case Table.ENGINE : MyOwnBindingSource.DataSource = EngineCRUDOps.getVisibleEngine() ; break;
                case Table.TRANSFER: MyOwnBindingSource.DataSource = TransferCRUDOps.getVisibleTransfer(); updateCurrentStock(); break;
                case Table.ALIMENTATION: MyOwnBindingSource.DataSource = AlimentationCRUDOps.getVisibleAlimentation(); updateCurrentStock(); break;
                case Table.CONSOMMATION:
                    

                    DataTable tbl = ConsommationCRUDOps.getVisibleConsommation("SELECTALL",dateFrom,dateTo);  //SELECTALL
                    //MessageBox.Show(tbl.Rows.Count.ToString() );
                    tbl.Merge(ConsommationCRUDOps.getVisibleConsommation("SELECTALLCARD", dateFrom, dateTo));
                    //MessageBox.Show(tbl.Rows.Count.ToString());
                    DataView dv = tbl.DefaultView;
                    dv.Sort = "date desc";
                    //tbl= dv.ToTable() ;
                    MyOwnBindingSource.DataSource = dv.ToTable();
                    updateCurrentStock(); 
                    break;
                case Table.NaftalCard: MyOwnBindingSource.DataSource = NaftalCardCRUDOps.getVisibleNaftalCard();   break;
            }


            if (this.selectedTable == table )
            { // to reApply the sort && filter string after the new record
                MyOwnBindingSource.Sort = getTheMainGrid().SortString;
                MyOwnBindingSource.Filter = getTheMainGrid().FilterString;
            }
            //MessageBox.Show(MyOwnBindingSource.Filter + " | " + MyOwnBindingSource.Sort);
            lastSelectedBindingSource = MyOwnBindingSource;
            
            getTheMainGrid().DataSource = MyOwnBindingSource;
            GGAOWindow.localds =( DataTable )( MyOwnBindingSource.DataSource ) ;
            getTheMainGrid().Columns[0].Visible = false;
            if ( table == Table.CONSOMMATION )
            {
                //getTheMainGrid().Columns[10].Visible = false; // hide printing option
                //getTheMainGrid().Columns[11].Visible = false; // hide calculate option
            }
            ResetColumnWidths();
            // you should add Status Label .text here
            this.StatusLabel.Text = string.Format("Mise a jour "+table.ToString()+"  {0}",
                DateTime.Now.ToString("hh:mm:ss")
            );
        }
        public void ResetColumnWidths()
        {
            if (getTheMainGrid() != null)
            {
                foreach (DataGridViewColumn col in getTheMainGrid().Columns)
                {
                    //col.Resizable = DataGridViewTriState.True ; #madehere
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
                }
                
                getTheMainGrid().Columns[getTheMainGrid().Columns.Count -1 ].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            }
        }
        private void NewDriverBtn_Click(object sender, EventArgs e)
        {  
            //Table.DRIVER
            if ( this.selectedTable == Table.DRIVER ) {
                InsertUpdateDriver form = new InsertUpdateDriver(true);
                form.ShowDialog();
                LoadVisible(Table.DRIVER);
                this.updateFooterInfo();
            }
        }
 
        private void NewOilInBtn_Click(object sender, EventArgs e)
        {
            //Table.DRIVER
            if (this.selectedTable == Table.ALIMENTATION)
            {
                InsertUpdateAlimentation form = new InsertUpdateAlimentation(true);
                form.ShowDialog();
                LoadVisible(Table.ALIMENTATION);
                this.updateFooterInfo();
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
            LoadVisible(Table.DRIVER );
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
             this.toggleFilterAndSort();
            this.selectedTable = Table.DRIVER; //this.selectedTable == Table.DRIVER 

            this.updateFooterInfo();
        }

        
        int selectedRowIndex = -1, selectedColIndex = -1;
        private void DGVMain_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             // single selecttion
           selectedColIndex = e.ColumnIndex;
            selectedRowIndex = e.RowIndex;
            //MessageBox.Show(DGVMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), " selected ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

       

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(lastSelectedBindingSource.Sort + " | "+ lastSelectedBindingSource.Filter, " selected ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //lastSelectedBindingSource.Sort = "";
            //lastSelectedBindingSource.Filter = "";

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
                //MessageBox.Show(DGVMain.FilterString);
                this.toggleFilterAndSort();
            }

            
        }

        private void toggleFilterAndSort()
        {
            bool filter = DGVMain.FilterAndSortEnabled;
            if ( filter )
            {
                this.allowUserToActivateFilter();
                getFiltredQuantity().Text = "";
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
            //DGVMain.FilterAndSortEnabled = false;
            DGVMain.CleanFilterAndSort();
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
        private int updateSumOfFilteredQuantities()
        {
            int sum = 0;
            if (this.selectedTable == Table.TRANSFER || this.selectedTable == Table.ALIMENTATION || this.selectedTable == Table.CONSOMMATION)
            { 
                for (int i = 0; i < getTheMainGrid().Rows.Count; i++)
                {
                    // MessageBox.Show(getTheMainGrid().Rows[i].Cells[5].Value.ToString());
                    //if (getTheMainGrid().Rows[i].Cells[2].Value.ToString() != "Carte Naftal") // calculer even if its Card
                    sum += Convert.ToInt32(getTheMainGrid().Rows[i].Cells[5].Value.ToString().Trim());
                    //MessageBox.Show(getTheMainGrid().Rows[i].Cells[5].Value.ToString());
                }
                //MessageBox.Show(sum.ToString());
                getFiltredQuantity().Text = "Quantité : " + sum.ToString("N1", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                getFiltredQuantity().Text = "";
            }

            return sum;
        }
        private void DGVMain_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            if (lastSelectedBindingSource != null)
            {
                //loading all filtred records then apply the sum filter
                //LoadVisible(selectedTable);
                lastSelectedBindingSource.Filter = DGVMain.FilterString; 
                this.updateFooterInfo();
            }
        }

        private void ProductBtn_Click(object sender, EventArgs e)
        {
            LoadVisible(Table.PRODUIT);
            this.selectedTable = Table.PRODUIT; // 3 Table.DRIVER
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();

            this.updateFooterInfo();
        }

        private void NewProductBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.PRODUIT )
            { //InsertUpdateDriver form = new InsertUpdateDriver(true);
                InsertUpdateProduct form = new InsertUpdateProduct(true);
                form.ShowDialog(); 
                 LoadVisible(Table.PRODUIT);
            }
        } 
        private void EditProductBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.PRODUIT)
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

                    LoadVisible(Table.PRODUIT);
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
            LoadVisible(Table.POLE);
            this.selectedTable =  Table.POLE  ;
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();

            this.updateFooterInfo();
        }

        private void OilInBtn_Click(object sender, EventArgs e)
        {
            LoadVisible(Table.ALIMENTATION);
            this.selectedTable = Table.ALIMENTATION ;
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();
            this.updateFooterInfo();
        }

        private void EngineBtn_Click(object sender, EventArgs e)
        {

            LoadVisible(Table.ENGINE);
            this.selectedTable = Table.ENGINE;
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();
            this.updateFooterInfo();
        }


        private void NewPoleBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.POLE)
            { //InsertUpdateDriver form = new InsertUpdateDriver(true);
              // InsertUpdateProduct form = new InsertUpdateProduct(true);
                InsertUpdatePole form = new InsertUpdatePole(true);
                form.ShowDialog();
                LoadVisible(Table.POLE);
                this.updateFooterInfo();
            }
        } 

        private void EditPoleBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.POLE)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , lib = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                    , addr = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , desc = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString();

                    //InsertUpdateDriver form = new InsertUpdateDriver(false);
                    InsertUpdatePole form = new InsertUpdatePole(false);
                    form.setDefaultValueforFields(ID, lib, addr, desc);
                    form.ShowDialog();
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible(Table.POLE);
                    this.updateFooterInfo();
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
            if (this.selectedTable == Table.DRIVER ) 
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

                    LoadVisible(Table.DRIVER);

                    this.updateFooterInfo();
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
            if (this.selectedTable == Table.POLE )
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
                    LoadVisible(Table.POLE);
                    this.updateFooterInfo();
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
            if (this.selectedTable == Table.DRIVER )
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
                    LoadVisible(Table.DRIVER);

                    this.updateFooterInfo();
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void NewEngineBtn_Click(object sender, EventArgs e)
        {
            //Table.DRIVER
            if (this.selectedTable == Table.ENGINE)
            {
                InsertUpdateEngine form = new InsertUpdateEngine(true);
                form.ShowDialog();
                LoadVisible(Table.ENGINE);
                this.updateFooterInfo();
            }
        } 
        private void EditOilInBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.ALIMENTATION)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , Ref = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                    , type = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , date = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString()
                    , kilo = DGVMain.Rows[selectedRowIndex].Cells[4].Value.ToString()
                    , quantity = DGVMain.Rows[selectedRowIndex].Cells[5].Value.ToString()
                    , _engine = DGVMain.Rows[selectedRowIndex].Cells[6].Value.ToString()
                    , _produit = DGVMain.Rows[selectedRowIndex].Cells[7].Value.ToString()
                    , _pole = DGVMain.Rows[selectedRowIndex].Cells[8].Value.ToString()
                    , _driver = DGVMain.Rows[selectedRowIndex].Cells[9].Value.ToString() ;

                    InsertUpdateAlimentation form = new InsertUpdateAlimentation(false);
                    form.setDefaultValueforFields(ID, Ref, type, date, quantity,kilo,_driver,_pole,_produit,_engine);
                    form.ShowDialog();
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible(Table.ALIMENTATION);
                    this.updateFooterInfo();
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }
        private void EditCarBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.ENGINE )
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , Libelle = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , Marque = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString()
                    , Code = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString() 
                    , Matricule = DGVMain.Rows[selectedRowIndex].Cells[5].Value.ToString() 
                    , PoleId = DGVMain.Rows[selectedRowIndex].Cells[7].Value.ToString()
                    , Color = DGVMain.Rows[selectedRowIndex].Cells[8].Value.ToString()
                    , type = DGVMain.Rows[selectedRowIndex].Cells[4].Value.ToString()
                    , serie = DGVMain.Rows[selectedRowIndex].Cells[6].Value.ToString();
                    //MessageBox.Show(ID + " " + Libelle + " " + Matricule + " " + Code + " " + Marque + " " + Color + " " + PoleId);
                    InsertUpdateEngine form = new InsertUpdateEngine(false);
                    form.setDefaultValueforFields(ID, Libelle, Matricule, Code, Marque, Color, PoleId, type, serie);
                    form.ShowDialog();
                    
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible(Table.ENGINE);
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void DelCarBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.ENGINE )
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        EngineCRUDOps.deleteEngine(ID);
                        //ProductCRUDOps.deleteProduct(ID);
                        // DriverCRUDOps.deleteDriver(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible(Table.ENGINE);
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }


        private void DelOilInBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.ALIMENTATION )
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        //ProductCRUDOps.deleteProduct(ID);
                        // DriverCRUDOps.deleteDriver(ID);
                        AlimentationCRUDOps.deleteAlimentation(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible(Table.ALIMENTATION);
                    this.updateFooterInfo();
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }
        private void updateFooterInfo()
        {
            this.updateSumOfFilteredQuantities();
            this.updateTotalRow();
        }
        private void OilOutBtn_Click(object sender, EventArgs e)
        { 
            this.dateTo = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 20);
            this.dateFrom = this.dateTo.AddMonths(-3);

            LoadVisible(Table.CONSOMMATION );
            this.selectedTable = Table.CONSOMMATION ;
           
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();
            this.updateFooterInfo();
        }

        private void NewOilOutBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.CONSOMMATION )
            {
                InsertUpdateConsommation form = new InsertUpdateConsommation(true);
                form.ShowDialog();
                LoadVisible( Table.CONSOMMATION );
                this.updateFooterInfo();
            }
        }

        private void EditOilOutBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.CONSOMMATION )
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , Ref = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                    , type = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , date = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString()
                    , kilo = DGVMain.Rows[selectedRowIndex].Cells[4].Value.ToString()
                    , quantity = DGVMain.Rows[selectedRowIndex].Cells[5].Value.ToString()
                    , _engine = DGVMain.Rows[selectedRowIndex].Cells[6].Value.ToString()
                    , _produit = DGVMain.Rows[selectedRowIndex].Cells[7].Value.ToString()
                    , _pole = DGVMain.Rows[selectedRowIndex].Cells[8].Value.ToString()
                    , _driver = DGVMain.Rows[selectedRowIndex].Cells[9].Value.ToString();

                    //bool print = Convert.ToBoolean( DGVMain.Rows[selectedRowIndex].Cells[10].Value.ToString()),
                    //    calc = Convert.ToBoolean( DGVMain.Rows[selectedRowIndex].Cells[11].Value.ToString() );

                    InsertUpdateConsommation form = new InsertUpdateConsommation(false);
                    form.setDefaultValueforFields(ID, Ref, type, date, quantity, kilo, _driver, _pole, _produit, _engine); //, print, calc
                    form.ShowDialog();
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible(Table.CONSOMMATION);
                    this.updateFooterInfo();

                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void DelOilOutBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.CONSOMMATION )
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        //ProductCRUDOps.deleteProduct(ID);
                        // DriverCRUDOps.deleteDriver(ID);
                        //AlimentationCRUDOps.deleteAlimentation(ID);
                        ConsommationCRUDOps.deleteConsommation(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible(Table.CONSOMMATION);
                    this.updateFooterInfo();
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void ribbonButton5_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for ( int i = 0; i < getTheMainGrid().Rows.Count; i++)
            {
               // MessageBox.Show(getTheMainGrid().Rows[i].Cells[5].Value.ToString());
                sum += Convert.ToInt32(getTheMainGrid().Rows[i].Cells[5].Value.ToString().Trim());
               // MessageBox.Show(getTheMainGrid().Rows[i].Cells[2].Value.ToString());
            }
            MessageBox.Show( sum.ToString() ) ;
        }
  
        private void GGAOWindow_Load(object sender, EventArgs e)
        {
            updateCurrentStock();
        }
        private void updateCurrentStock()
        {
            // "1007" C01-OUMACHE STOCK PRINCIPAL
            int transferOut = TransferCRUDOps.GetSumOfQuantities(TransferCRUDOps.Target.Destination, "1007");
            int transferIn = TransferCRUDOps.GetSumOfQuantities(TransferCRUDOps.Target.Source, "1007");
            int cons = ConsommationCRUDOps.getSumOfQuantities("1007"); // ** hello
            int alim = AlimentationCRUDOps.getSumOfQuantities("1007");
            getTheActuelStock().Text = ((alim + transferIn) - (cons + transferOut)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture);
        }
        private string updateCurrentStockInAllUnites()
        {
            DataTable tbl = PoleCRUDOps.getVisiblePole(true, "select");
            // "1007" C01-OUMACHE STOCK PRINCIPAL
            string s = "";
            foreach ( DataRow dr in tbl.Rows )
            {
                string id = dr["ID"].ToString();
                string libelle = dr["Libelle"].ToString();
                // s +=dr["ID"].ToString()+"\n";
                int transferOut = TransferCRUDOps.GetSumOfQuantities(TransferCRUDOps.Target.Destination, id);
                int transferIn = TransferCRUDOps.GetSumOfQuantities(TransferCRUDOps.Target.Source, id );
                int cons = ConsommationCRUDOps.getSumOfQuantities(id); // ** hello
                int alim = AlimentationCRUDOps.getSumOfQuantities(id);

                s +=  ( libelle+Utilities.Tools.Spaces(30,' ') ).ToString().Substring(0,30) +"  "
                    + (  ((alim + transferIn) - (cons + transferOut)).ToString()  ) 
                    + "\n";
            }
            /*
            int transferOut = TransferCRUDOps.GetSumOfQuantities(TransferCRUDOps.Target.Destination, "1007");
            int transferIn = TransferCRUDOps.GetSumOfQuantities(TransferCRUDOps.Target.Source, "1007");
            int cons = ConsommationCRUDOps.getSumOfQuantities("1007"); // ** hello
            int alim = AlimentationCRUDOps.getSumOfQuantities();
            getTheActuelStock().Text = ((alim + transferIn) - (cons + transferOut)).ToString("N1", System.Globalization.CultureInfo.InvariantCulture);
            */
            return s;
            }
        
        private void RapportJournalierWindow(object sender, EventArgs e)
        {
            //SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            
            GGAO.Reports.raportJournalier test = new GGAO.Reports.raportJournalier();
            test.Show();
        }

        private void infoBtn_Click(object sender, EventArgs e)
        {
            Utilities.About form = new Utilities.About();
            form.ShowDialog();
        }
         

        private void RapportMonthlyWindow(object sender, EventArgs e)
        {
            GGAO.Reports.ReportMonsuelle test = new GGAO.Reports.ReportMonsuelle();
            test.Show();
        }

        private void OilTransferBtn_Click(object sender, EventArgs e)
        {
            LoadVisible(Table.TRANSFER);
            this.selectedTable = Table.TRANSFER;
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();
            this.updateFooterInfo();
        }

        private void NewOilTransferBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.TRANSFER)
            {
                //GGAO.Stock.TRANSFER.InsertUpdateTransfer form = new GGAO.Stock.TRANSFER.InsertUpdateTransfer(true);
                InsertUpdateTransfer form = new InsertUpdateTransfer(true);
                form.ShowDialog();
                LoadVisible(Table.TRANSFER);
                this.updateFooterInfo();

            }
        }

        private void EditOilTransferBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.TRANSFER)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , Ref = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                    , type = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , date = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString()
                    , kilo = DGVMain.Rows[selectedRowIndex].Cells[4].Value.ToString()
                    , quantity = DGVMain.Rows[selectedRowIndex].Cells[5].Value.ToString()
                    , _pole = DGVMain.Rows[selectedRowIndex].Cells[6].Value.ToString()

                    
                    , _engine = DGVMain.Rows[selectedRowIndex].Cells[7].Value.ToString()
                    , _produit = DGVMain.Rows[selectedRowIndex].Cells[8].Value.ToString()
                   
                    , _driver = DGVMain.Rows[selectedRowIndex].Cells[9].Value.ToString()
                    , _toPole = DGVMain.Rows[selectedRowIndex].Cells[10].Value.ToString();
                   
                    InsertUpdateTransfer form = new InsertUpdateTransfer(false);
                    form.setDefaultValueforFields(ID, Ref, type, date, quantity, kilo, _driver, _pole, _toPole, _produit, _engine ) ;
                    form.ShowDialog();
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible(Table.TRANSFER);
                    this.updateFooterInfo();
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void DelOilTransferBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.TRANSFER )
            {
                // get the ID of the selected row
                if ( selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        //ProductCRUDOps.deleteProduct(ID);
                        // DriverCRUDOps.deleteDriver(ID);
                        //AlimentationCRUDOps.deleteAlimentation(ID);
                        TransferCRUDOps.deleteTransfer(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible(Table.TRANSFER);
                    this.updateFooterInfo();
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void ExcelExportBtn_Click(object sender, EventArgs e)
        {

            if ( getTheMainGrid().Rows.Count > 0)
            {
                if ( DGVMain.FilterAndSortEnabled == true )
                {
                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);

                    for (byte i = 1; i < getTheMainGrid().Columns.Count; i++)
                    {
                        xcelApp.Cells[1, i] = getTheMainGrid().Columns[i].HeaderText;
                    }

                    for (byte i = 0; i < getTheMainGrid().Rows.Count; i++)
                    {
                        if (getTheMainGrid().Rows[i].Visible == true)
                        {
                            for (byte j = 1; j < getTheMainGrid().Columns.Count; j++)
                            {

                                xcelApp.Cells[i + 2, j] = getTheMainGrid().Rows[i].Cells[j].Value.ToString();

                            }
                        }
                    }

                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }
            }
        }
         

        private void StatistiqueBtn_Click(object sender, EventArgs e)
        {

            MessageBox.Show(updateCurrentStockInAllUnites(), "Stock Actuel");
        }

        private void GGAOWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void EngineConsumption_Click(object sender, EventArgs e)
        {

            GGAO.Reports.RapportEngine test = new GGAO.Reports.RapportEngine();
            test.Show();
        }

        private void NaftalCardBtn_Click(object sender, EventArgs e)
        {
            LoadVisible(Table.NaftalCard);
            this.selectedTable = Table.NaftalCard;
            // toggle Sort and Filter stat
            if (DGVMain.FilterAndSortEnabled == true)
                this.toggleFilterAndSort();
            this.updateFooterInfo();
        }

        private void newNaftalCardBtn_Click(object sender, EventArgs e)
        {
            //Table.naftalCard
            if (this.selectedTable == Table.NaftalCard)
            {
                InsertUpdateNaftalCard form = new InsertUpdateNaftalCard(true);
                form.ShowDialog();
                LoadVisible(Table.NaftalCard);
                this.updateFooterInfo();
            }
        }
 
        private void delNaftalCardBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.NaftalCard)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString();

                    // ask comfirmation from the user  
                    if (MessageBox.Show("Voulez-vous vraiment supprimer cet enregistrement...?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        NaftalCardCRUDOps.deleteNaftalCard(ID);
                        //ProductCRUDOps.deleteProduct(ID);
                        // DriverCRUDOps.deleteDriver(ID);
                    }
                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;
                    LoadVisible(Table.NaftalCard);
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour supprimer",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }

        private void editNaftalCardBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.NaftalCard)
            {
                // get the ID of the selected row
                if (selectedRowIndex >= 0)
                {
                    string ID = DGVMain.Rows[selectedRowIndex].Cells[0].Value.ToString()
                    , CODE = DGVMain.Rows[selectedRowIndex].Cells[1].Value.ToString()
                    , NUM = DGVMain.Rows[selectedRowIndex].Cells[2].Value.ToString()
                    , LIB = DGVMain.Rows[selectedRowIndex].Cells[3].Value.ToString()
                    , DATE = DGVMain.Rows[selectedRowIndex].Cells[4].Value.ToString();

                    InsertUpdateNaftalCard form = new InsertUpdateNaftalCard(false);
                    form.setDefaultValueforFields(ID, CODE, NUM, LIB, DATE);
                    form.ShowDialog();

                    // to  obligate the user to reselect
                    selectedRowIndex = -1;
                    selectedColIndex = -1;

                    LoadVisible(Table.NaftalCard);
                }
                else
                {
                    MessageBox.Show("Selectioner une ligne pour modifier",
                       "Action incorrect", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                }
            }
        }
         
        private void SecondBtnd_Click(object sender, EventArgs e)
        { 
            DateIntervalleSelector form = new DateIntervalleSelector() ;
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.dateFrom = form.dialogFromDate.Date;            //values preserved after close
                this.dateTo = form.dialogToDate.Date;            //values preserved after close

                LoadVisible(Table.CONSOMMATION);
                this.selectedTable = Table.CONSOMMATION;

                // toggle Sort and Filter stat
                if (DGVMain.FilterAndSortEnabled == true)
                    this.toggleFilterAndSort();
                this.updateFooterInfo();
            }

            
        }

        private void DelProductBtn_Click(object sender, EventArgs e)
        {
            if (this.selectedTable == Table.PRODUIT)
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
                    LoadVisible(Table.PRODUIT);
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
