using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GGAO.Utilities;
namespace GGAO.Stock.Transfer
{
    public partial class InsertUpdateTransfer : Form
    {
        private bool InsertOrUpdate = true; // insert 
        private string selectedID = "";
        private string selectedDriverLib = "";
        private string selectedPoleLib = "";
        private string selectedToPoleLib = "";
        private string selectedProductLib = "";
        private string selectedEngineLib = "";
        public InsertUpdateTransfer(bool roleInsertOrUpdate)
        {
            InitializeComponent(); 
            setTitle(roleInsertOrUpdate); // false means update
            InsertOrUpdate = roleInsertOrUpdate;
        }
        public void setDefaultValueforFields(string _id, string _Ref, string _type, string date, string _quanity, string _kilo,
    string _Driver, string _Pole, string _ToPole, string _Product, string _Engine)
        { 
            this.selectedID = _id;
            this.selectedDriverLib = _Driver;
            this.selectedPoleLib = _Pole;
            this.selectedToPoleLib = _ToPole;
            this.selectedProductLib = _Product;
            this.selectedEngineLib = _Engine;
            this.setInitialValue(_Ref, _type, date, _quanity, _kilo,
             _Driver, _Pole, _ToPole, _Product, _Engine );
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
                    TransferCRUDOps.createTransfer(
                        ReftextBox.Text.Trim(),
                        TypeComboBox.Text.Trim(),
                        dateTimePicker.Value,
                         (EngineCombobox.SelectedItem == null) ? "0" : EngineCombobox.SelectedItem.Value,
                         (ProductCombobox.SelectedItem == null) ? "2" : ProductCombobox.SelectedItem.Value,
                         (PoleCombobox.SelectedItem == null) ? "0" : PoleCombobox.SelectedItem.Value,
                         (ToPoleCombobox.SelectedItem == null) ? "0" : ToPoleCombobox.SelectedItem.Value,
                         (DriverCombobox.SelectedItem == null) ? "0" : DriverCombobox.SelectedItem.Value,
                         KilotextBox.Text.Trim(),
                         QuanitytextBox.Text.Trim()

                        );
                }
                else // means Update existing record
                {
                    TransferCRUDOps.UpdateTransfer(
                        this.selectedID,
                        ReftextBox.Text.Trim(),
                        TypeComboBox.Text.Trim(),
                        dateTimePicker.Value,
                         (EngineCombobox.SelectedItem == null) ? null : EngineCombobox.SelectedItem.Value,
                         (ProductCombobox.SelectedItem == null) ? null : ProductCombobox.SelectedItem.Value,
                         (PoleCombobox.SelectedItem == null) ? null : PoleCombobox.SelectedItem.Value,
                         (ToPoleCombobox.SelectedItem == null) ? null : ToPoleCombobox.SelectedItem.Value,
                         (DriverCombobox.SelectedItem == null) ? null : DriverCombobox.SelectedItem.Value,
                         KilotextBox.Text.Trim(),
                         QuanitytextBox.Text.Trim()

                        );
                    this.Close();
                }
                ResetFields();
            }
        }

        private void InsertUpdateTransfer_Load(object sender, EventArgs e)
        {
            // load the tables
            DataTable poleDt = GGAO.PoleCRUDOps.getVisiblePole();
            DataTable driverDt = GGAO.DriverCRUDOps.getVisibleDriver();
            DataTable engineDt = GGAO.EngineCRUDOps.getVisibleEngine();
            DataTable produitDt = GGAO.ProductCRUDOps.getVisibleProduct();

            this.PoleCombobox.Clear();
            this.ToPoleCombobox.Clear();
            this.DriverCombobox.Clear();
            this.EngineCombobox.Clear();
            this.ProductCombobox.Clear();
            // auto generate this column
            //multiColumComboBox.SourceDataString = ColumnNames.ToArray();
            PoleCombobox.SourceDataString = Tools.ConvColNametoArray(poleDt.Columns);
            ToPoleCombobox.SourceDataString = Tools.ConvColNametoArray(poleDt.Columns);
            DriverCombobox.SourceDataString = Tools.ConvColNametoArray(driverDt.Columns);
            EngineCombobox.SourceDataString = Tools.ConvColNametoArray(engineDt.Columns);
            ProductCombobox.SourceDataString = Tools.ConvColNametoArray(produitDt.Columns);

            PoleCombobox.DataSource = poleDt;
            ToPoleCombobox.DataSource = poleDt;
            DriverCombobox.DataSource = driverDt;
            EngineCombobox.DataSource = engineDt;
            ProductCombobox.DataSource = produitDt;
            //multiColumComboBox.setTextBox(this.selectedPoleLibelle.Trim());
            DriverCombobox.setTextBox(this.selectedDriverLib);
            PoleCombobox.setTextBox(this.selectedPoleLib);
            ToPoleCombobox.setTextBox(this.selectedToPoleLib);
            ProductCombobox.setTextBox(this.selectedProductLib);
            //_Engine.Split('-')[0].Trim();
            EngineCombobox.setTextBox(this.selectedEngineLib.Split('-')[0].Trim());
        }
    }
}
