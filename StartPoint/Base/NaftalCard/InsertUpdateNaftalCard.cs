using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO.NaftalCard
{
    public partial class InsertUpdateNaftalCard : Form
    {
        private bool InsertOrUpdate = true;
        private string selectedID = "";
        public InsertUpdateNaftalCard(bool roleInsertOrUpdate)
        {
            InitializeComponent();
            setTitle(roleInsertOrUpdate); // false means update
            InsertOrUpdate = roleInsertOrUpdate;
        }

        public void setDefaultValueforFields(string _id, string _code, string _numero, string _libelle, string _date)
        {
            this.selectedID = _id;
            this.setInitialValue(_code, _numero, _libelle, _date);

        } 
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.textBoxNaftalCardCode.Text.Trim() == ""  )
            {
                MessageBox.Show("Vous devez remplir les champs nécessaires", "Alert", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                if (InsertOrUpdate == true) // means Insert new record
                {
                    NaftalCardCRUDOps.createNaftalCard(
                        this.textBoxNaftalCardCode.Text.Trim(),
                        this.textBoxNaftalCardNum.Text.Trim(),
                        this.textBoxNaftalCardLibelle.Text.Trim(),
                        this.dateExpNaftalCard.Value
                        );
                }
                else // means Update existing record
                {
                    NaftalCardCRUDOps.UpdateNaftalCard(
                        this.selectedID,
                        this.textBoxNaftalCardCode.Text.Trim(),
                        this.textBoxNaftalCardNum.Text.Trim(),
                        this.textBoxNaftalCardLibelle.Text.Trim(),
                        this.dateExpNaftalCard.Value
                        );
                    this.Close();
                }
                this.resetFields();
            }
        }

    }
    }

