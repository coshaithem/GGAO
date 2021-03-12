using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO.Driver
{
    public partial class InsertUpdateDriver : Form
    {
        private bool InsertOrUpdate = true;
        private string selectedID = "";
        public InsertUpdateDriver( bool roleInsertOrUpdate )
        {
            InitializeComponent();
            setTitle(roleInsertOrUpdate); // false means update
            InsertOrUpdate = roleInsertOrUpdate;
        }
        public void setDefaultValueforFields(string _id,string _nom, string _prenom, string _cin , string _date, string _lieu, string _mobile)
        {
            this.selectedID = _id;
            this.setInitialValue( _nom,  _prenom,  _cin,  _date,  _lieu,  _mobile);

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.nomTextBox.Text.Trim() == "" ||  this.prenomTextBox.Text.Trim() == "" )
            {
                MessageBox.Show("Vous devez remplir les champs nécessaires", "Alert",MessageBoxButtons.OK, MessageBoxIcon.Exclamation) ;
            }
            else { 
                if ( InsertOrUpdate == true ) // means Insert new record
                {
                    DriverCRUDOps.createDriver(
                        this.nomTextBox.Text.Trim(),
                        this.prenomTextBox.Text.Trim(),
                        this.cINTextBox.Text.Trim(),
                        this.dateNaissanceDateTimePicker.Value,
                        this.lieuNaissanceTextBox.Text.Trim(),
                        this.mobileTextBox.Text.Trim()
                      );
                }
                else // means Update existing record
                {
                    DriverCRUDOps.UpdateDriver(
                        selectedID,
                        this.nomTextBox.Text.Trim(),
                        this.prenomTextBox.Text.Trim(),
                        this.cINTextBox.Text.Trim(),
                        this.dateNaissanceDateTimePicker.Value,
                        this.lieuNaissanceTextBox.Text.Trim(),
                        this.mobileTextBox.Text.Trim()
                        );
                    this.Close();
                }
                this.ResetFields();
            }
        }
    }
}
