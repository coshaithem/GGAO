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
namespace GGAO.Engine
{
    public partial class InsertUpdateEngine : Form
    {
        private bool InsertOrUpdate = true;
        private string selectedID = "";
        private string selectedPoleLibelle = "";
        public InsertUpdateEngine(bool roleInsertOrUpdate)
        {
            InitializeComponent();
            setTitle(roleInsertOrUpdate); // false means update
            InsertOrUpdate = roleInsertOrUpdate;
        }

        public void setDefaultValueforFields(string _id, string _libelle, string _Matr, string _code, string _marque , string _Color, string _poleLibelle)
        {
            this.selectedID = _id;
            this.selectedPoleLibelle = _poleLibelle;
            this.setInitialValue( _libelle,  _Matr, _code, _marque, _Color,  _poleLibelle);
            // _libelle,  _Matr, _code,  _marque , _Color,  _poleLibelle

        }
        private void InsertUpdateEngine_Load(object sender, EventArgs e)
        {
            
            // load POLE table
              DataTable dt =   GGAO.PoleCRUDOps.getVisiblePole();
            // scrap column names of  the table 
            /*List<string> ColumnNames = new List<string>();
            string collect = "";
            foreach (DataColumn DTC in dt.Columns)
            {
                ColumnNames.Add(DTC.ColumnName.Trim());
                collect += DTC.ColumnName.Trim() +" ";
            }*/
            // set up the MulticolumnComboBox
            multiColumComboBox.Clear();
            // auto generate this column
            //multiColumComboBox.SourceDataString = ColumnNames.ToArray();
            multiColumComboBox.SourceDataString = Tools.ConvColNametoArray(dt.Columns);
            //MessageBox.Show(collect);
            //multiColumComboBox.ColumnWidth = new string[3] { "30", "200", "50" };  
            //multiColumComboBox.ColumnWidth = GetColumnWidths(3, "30");

            /*
             * multiColumComboBox.ShowHeader = true;
            multiColumComboBox.GridLines = VMultiColumnComboBox.GridLines.Horizontal;
            multiColumComboBox.DropDownHeight = 200; //Convert.ToInt32(textBox1.Text);
            multiColumComboBox.DisplayColumnNo = 1; // Convert.ToInt32(textBox2.Text);
            multiColumComboBox.ValueColumnNo = 0; // Convert.ToInt32(textBox3.Text);
            */
            // set up the datasource of MultiColumnBox
            multiColumComboBox.DataSource = dt;
            multiColumComboBox.setTextBox( this.selectedPoleLibelle.Trim() );
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(    string.IsNullOrEmpty(this.MatrtextBox.Text.Trim()).ToString()   );
            //MessageBox.Show(    string.IsNullOrEmpty(this.CodetextBox.Text.Trim()).ToString()   );
            if (
                    string.IsNullOrEmpty(this.LibelletextBox.Text.Trim()) ||
                    (string.IsNullOrEmpty(this.CodetextBox.Text.Trim()) &&  string.IsNullOrEmpty(this.MatrtextBox.Text.Trim()) )
                )
            {
                MessageBox.Show("Vous devez remplir les champs nécessaires", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string selectedPoleID = "0"; // means not affected
                if (multiColumComboBox.SelectedItem != null)
                    selectedPoleID = multiColumComboBox.SelectedItem.Value;

                if (InsertOrUpdate == true) // means Insert new record
                {
                    
                    EngineCRUDOps.createEngine(
                        this.LibelletextBox.Text.Trim(),
                        this.CodetextBox.Text.Trim(),
                        this.MatrtextBox.Text.Trim(),
                        this.MarquetextBox.Text.Trim(),
                        this.ColortextBox.Text.Trim(),
                        selectedPoleID  // this is supose to get the ID 

                        );
                }
                else // means Update existing record
                {
                    EngineCRUDOps.UpdateEngine (

                        this.selectedID,
                        this.LibelletextBox.Text.Trim(),
                        this.CodetextBox.Text.Trim(),
                        this.MatrtextBox.Text.Trim(),
                        this.MarquetextBox.Text.Trim(),
                        this.ColortextBox.Text.Trim(),
                        (selectedPoleID == "0")?null: selectedPoleID  // this is supose to get the ID 

                        );
                }
            }
        }

    }
}
