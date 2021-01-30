using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO.Pole
{
    public partial class InsertUpdatePole : Form
    {
        private bool InsertOrUpdate = true;
        private string selectedID = "";
        public InsertUpdatePole(bool roleInsertOrUpdate)
        {
            InitializeComponent();
            setTitle(roleInsertOrUpdate); // false means update
            InsertOrUpdate = roleInsertOrUpdate;
        }

        public void setDefaultValueforFields(string _id, string _nom, string _addrs, string _desc)
        {
            this.selectedID = _id;
            this.setInitialValue(_nom, _addrs, _desc);

        }
        private void InsertUpdatePole_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.LibelletextBox.Text.Trim() == "")
            {
                MessageBox.Show("Vous devez remplir les champs nécessaires", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (InsertOrUpdate == true) // means Insert new record
                {
                    PoleCRUDOps.createPole(
                        this.LibelletextBox.Text.Trim(),
                        this.AddresstextBox.Text.Trim(),
                        this.DescriptiontextBox.Text.Trim()
                        );

                }
                else // means Update existing record
                {
                    PoleCRUDOps.UpdatePole(
                        this.selectedID,
                        this.LibelletextBox.Text.Trim(),
                        this.AddresstextBox.Text.Trim(),
                        this.DescriptiontextBox.Text.Trim()
                        );
                }
            }
        }
    }
}
