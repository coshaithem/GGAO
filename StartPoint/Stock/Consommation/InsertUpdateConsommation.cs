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
            // load the tables
            DataTable poleDtDES = GGAO.PoleCRUDOps.getVisiblePole(true, "SELECT");
            DataTable driverDt = GGAO.DriverCRUDOps.getVisibleDriver();
            DataTable engineDt = GGAO.EngineCRUDOps.getVisibleEngine();
            DataTable produitDt = GGAO.ProductCRUDOps.getVisibleProduct();

            this.PoleCombobox.Clear();
            this.DriverCombobox.Clear();
            this.EngineCombobox.Clear();
            this.ProductCombobox.Clear();
            // auto generate this column
            //multiColumComboBox.SourceDataString = ColumnNames.ToArray();
            PoleCombobox.SourceDataString = Tools.ConvColNametoArray(poleDtDES.Columns);
            DriverCombobox.SourceDataString = Tools.ConvColNametoArray(driverDt.Columns);
            EngineCombobox.SourceDataString = Tools.ConvColNametoArray(engineDt.Columns);
            ProductCombobox.SourceDataString = Tools.ConvColNametoArray(produitDt.Columns);

            PoleCombobox.DataSource = poleDtDES;
            DriverCombobox.DataSource = driverDt;
            EngineCombobox.DataSource = engineDt;
            ProductCombobox.DataSource = produitDt;
            //multiColumComboBox.setTextBox(this.selectedPoleLibelle.Trim());
            DriverCombobox.setTextBox(this.selectedDriverLib);
            PoleCombobox.setTextBox(this.selectedPoleLib);
            ProductCombobox.setTextBox(this.selectedProductLib);
            //_Engine.Split('-')[0].Trim();
            EngineCombobox.setTextBox(this.selectedEngineLib.Split('-')[0].Trim());
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
                    ConsommationCRUDOps.createConsommation(
                        ReftextBox.Text.Trim(),
                        TypeComboBox.Text.Trim(),
                        dateTimePicker.Value,  
                         (EngineCombobox.SelectedItem == null) ? "0" : EngineCombobox.SelectedItem.Value,
                         (ProductCombobox.SelectedItem == null) ? "2" : ProductCombobox.SelectedItem.Value,
                         (PoleCombobox.SelectedItem == null) ? "1007" : PoleCombobox.SelectedItem.Value,
                         (DriverCombobox.SelectedItem == null) ? "0" : DriverCombobox.SelectedItem.Value,
                         KilotextBox.Text.Trim(),
                         QuanitytextBox.Text.Trim()
                         //checkBoxPrinting.Checked,
                         //checkBoxCalc.Checked

                        );
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
                         QuanitytextBox.Text.Trim()
                         //checkBoxPrinting.Checked,
                         //checkBoxCalc.Checked

                        );
                    this.Close();
                }
                this.ResetFields();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
