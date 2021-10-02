using GGAO.Driver;
using GGAO.Engine;
using GGAO.NaftalCard;
using GGAO.Pole;
using GGAO.Product;
using GGAO.Utilities;
using System;
using System.Data;
using System.Windows.Forms;
namespace GGAO.Consommation
{
    public partial class InsertUpdateConsommation : Form
    {
        private bool InsertOrUpdate = true; // insert 
        private string selectedID = "";
        private string selectedDriverLib = "";
        private string selectedPoleLib = "";
        private string selectedProductLib = "";
        private string selectedEngineLib = "";
        public InsertUpdateConsommation(bool roleInsertOrUpdate)
        {
            InitializeComponent();
            setTitle(roleInsertOrUpdate); // false means update
            InsertOrUpdate = roleInsertOrUpdate;
        }
        public void setDefaultValueforFields(string _id, string _Ref, string _type, string date, string _quanity, string _kilo,
            string _Driver, string _Pole, string _Product, string _Engine) // , bool _print, bool _calc
        {
            this.selectedID = _id;
            this.selectedDriverLib = _Driver;
            this.selectedPoleLib = _Pole;
            this.selectedProductLib = _Product;
            this.selectedEngineLib = _Engine;
            this.setInitialValue(_Ref, _type, date, _quanity, _kilo,
             _Driver, _Pole, _Product, _Engine); // , _print, _calc
        }
        private void InsertUpdateConsommation_Load(object sender, EventArgs e)
        {

            this.loadPoleDataIntoCombo();
            this.loadDriverDataIntoCombo();
            this.loadEngineDataIntoCombo();
            this.loadProductDataIntoCombo();

        }
        private void loadProductDataIntoCombo()
        {
            DataTable produitDt = GGAO.ProductCRUDOps.getVisibleProduct();
            this.ProductCombobox.Clear();
            ProductCombobox.SourceDataString = Tools.ConvColNametoArray(produitDt.Columns);
            ProductCombobox.DataSource = produitDt;
             ProductCombobox.setTextBox(this.selectedProductLib);
        }
        private void loadEngineDataIntoCombo()
        {
            DataTable engineDt = GGAO.EngineCRUDOps.getVisibleEngine();
            this.EngineCombobox.Clear();
            EngineCombobox.SourceDataString = Tools.ConvColNametoArray(engineDt.Columns);
            EngineCombobox.DataSource = engineDt;
            EngineCombobox.setTextBox(this.selectedEngineLib.Split('-')[0].Trim());

        }
        private void loadDriverDataIntoCombo()
        {
            DataTable driverDt = GGAO.DriverCRUDOps.getVisibleDriver();
            this.DriverCombobox.Clear();
            DriverCombobox.SourceDataString = Tools.ConvColNametoArray(driverDt.Columns);
            DriverCombobox.DataSource = driverDt;
            DriverCombobox.setTextBox(this.selectedDriverLib);
        }
        private void loadCardDataIntoCombo()
        {
            DataTable poleDtDES = GGAO.NaftalCardCRUDOps.getVisibleNaftalCard();
            this.PoleCombobox.Clear();
            PoleCombobox.SourceDataString = Tools.ConvColNametoArray(poleDtDES.Columns);
            PoleCombobox.DataSource = poleDtDES;
            PoleCombobox.setTextBox(this.selectedPoleLib);
        }
        private void loadPoleDataIntoCombo()
        {
            DataTable poleDtDES = GGAO.PoleCRUDOps.getVisiblePole(true, "SELECT");
            this.PoleCombobox.Clear();
            PoleCombobox.SourceDataString = Tools.ConvColNametoArray(poleDtDES.Columns);
            PoleCombobox.DataSource = poleDtDES;
            PoleCombobox.setTextBox(this.selectedPoleLib);


        }
        private string getSelectedEngine()
        {
            string engineStr = "";

            if (EngineCombobox.SelectedItem != null)
            {
                //string strValue = "";
                //for (int index = 0; index < EngineCombobox.SelectedItem.ItemData.Count; index++)
                //{
                engineStr += EngineCombobox.SelectedItem.ItemData[2] + " - " +
                    EngineCombobox.SelectedItem.ItemData[5] + " - " +
                    EngineCombobox.SelectedItem.ItemData[7];
                //}
                //MessageBox.Show(strValue);
            }
            return engineStr;
        }
        private bool FindReccurence(string engine, string date)
        {
            bool check = false;
            DataTable tbl = GGAOWindow.getDataSource();
            if (tbl != null)
            {
                DataView dv = new DataView(tbl);
                dv.RowFilter = "([Engine] IN('" + engine + "') ) AND " +
                    "((Convert([Date], 'System.String') LIKE '%" + date + "%')) ";

                //MessageBox.Show(dv.RowFilter +" \n Count"+ dv.Count.ToString());
                return (dv.Count > 0) ? true : false;
            }
            else
                return check;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.fieldsAreEmpty(InsertOrUpdate))
            {
                MessageBox.Show("Vous devez remplir les champs nécessaires", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (InsertOrUpdate == true) // means Insert new record
                {
                    // before you insert notify the user if the engine take productin int he same day
                    // get the selected engine && date
                    // MessageBox.Show(this.getSelectedEngine());
                    bool OccExist = this.FindReccurence(this.getSelectedEngine(),
                        dateTimePicker.Value.ToShortDateString());
                    bool userConfirmation = false;
                    // search for the selected engine in gridView with same date
                    if (OccExist)
                    {
                        if (MessageBox.Show("Attention... \n" +
                            "Ce n'est pas la première fois pour cette véhicule dans ce jour!\nVous voulez validé", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            userConfirmation = true;
                        }

                    }
                    // if the user accept to insert so be it ;)
                    if (userConfirmation || !OccExist)
                    {
                        // MessageBox.Show(PoleCombobox.SelectedItem.Value);
                        ConsommationCRUDOps.createConsommation(
                            ReftextBox.Text.Trim(),
                            TypeComboBox.Text.Trim(),
                            dateTimePicker.Value,
                             (EngineCombobox.SelectedItem == null) ? "0" : EngineCombobox.SelectedItem.Value,
                             (ProductCombobox.SelectedItem == null) ? "2" : ProductCombobox.SelectedItem.Value,
                             (PoleCombobox.SelectedItem == null) ? "1007" : PoleCombobox.SelectedItem.Value,
                             (DriverCombobox.SelectedItem == null) ? "0" : DriverCombobox.SelectedItem.Value,
                             KilotextBox.Text.Trim(),
                             QuanitytextBox.Text.Trim(),
                          checkBoxPrinting.Checked,
                         checkBoxCalc.Checked
                        );
                        this.ResetFields();
                    }
                }
                else // means Update existing record
                {
                    ConsommationCRUDOps.UpdateConsommation(
                        this.selectedID,
                        ReftextBox.Text.Trim(),
                        TypeComboBox.Text.Trim(),
                        dateTimePicker.Value,
                         (EngineCombobox.SelectedItem == null) ? null : EngineCombobox.SelectedItem.Value,
                         (ProductCombobox.SelectedItem == null) ? null : ProductCombobox.SelectedItem.Value,
                         (PoleCombobox.SelectedItem == null) ? null : PoleCombobox.SelectedItem.Value,
                         (DriverCombobox.SelectedItem == null) ? null : DriverCombobox.SelectedItem.Value,
                         KilotextBox.Text.Trim(),
                         QuanitytextBox.Text.Trim(),
                         checkBoxPrinting.Checked,
                         checkBoxCalc.Checked
                        );
                    this.Close();
                    this.ResetFields();
                }

            }
        }

        private void TypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.PoleCombobox.Clear();
            this.PoleCombobox.setTextBox(""); 
            if (this.TypeComboBox.SelectedItem.ToString() == "Carte Naftal")
            {
                this.checkBoxCalc.Checked = false;
                this.checkBoxCalc.Enabled = false;
                DataTable cardDt = GGAO.NaftalCardCRUDOps.getVisibleNaftalCard();
                this.PoleCombobox.SourceDataString = Tools.ConvColNametoArray(cardDt.Columns);
                this.PoleCombobox.DataSource = cardDt;
                //#ERROR452
            }
            else
            {
                this.checkBoxCalc.Checked = true;
                this.checkBoxCalc.Enabled = true;
                DataTable poleDtDES = GGAO.PoleCRUDOps.getVisiblePole(true, "SELECT");
                this.PoleCombobox.SourceDataString = Tools.ConvColNametoArray(poleDtDES.Columns);
                this.PoleCombobox.DataSource = poleDtDES;
            }

            PoleCombobox.setTextBox(this.selectedPoleLib);
        }

        private void BtnNewSource_Click(object sender, EventArgs e)
        {
            if ( this.TypeComboBox.Text == "Carte Naftal")
            {
                InsertUpdateNaftalCard form = new InsertUpdateNaftalCard(true);
                form.ShowDialog();
                this.loadCardDataIntoCombo();
            }
            else
            {
                InsertUpdatePole form = new InsertUpdatePole(true);
                form.ShowDialog();
                this.loadPoleDataIntoCombo();

            }
        }

        private void BtnNewDriver_Click(object sender, EventArgs e)
        {
            InsertUpdateDriver form = new InsertUpdateDriver(true);
            form.ShowDialog();
            this.loadDriverDataIntoCombo();
        }

        private void BtnNewEngine_Click(object sender, EventArgs e)
        {
            InsertUpdateEngine form = new InsertUpdateEngine(true);
            form.ShowDialog();
            this.loadEngineDataIntoCombo();
        }

        private void BtnNewProduct_Click(object sender, EventArgs e)
        {
            InsertUpdateProduct form = new InsertUpdateProduct(true);
            form.ShowDialog();
            this.loadProductDataIntoCombo();
        }
    }
}
