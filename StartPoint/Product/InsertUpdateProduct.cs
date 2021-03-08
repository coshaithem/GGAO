using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO.Product
{
    public partial class InsertUpdateProduct : Form
    {
        private bool InsertOrUpdate = true;
        private string selectedID = "";
        public InsertUpdateProduct(bool roleInsertOrUpdate)
        {
            InitializeComponent();
            setTitle(roleInsertOrUpdate); // false means update
            InsertOrUpdate = roleInsertOrUpdate;
        }

        public void setDefaultValueforFields(string _id, string _nom, string _type, string _desc)
        {
            this.selectedID = _id;
            this.setInitialValue(_nom, _type, _desc);

        } 
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.textBoxProductName.Text.Trim() == ""  )
            {
                MessageBox.Show("Vous devez remplir les champs nécessaires", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (InsertOrUpdate == true) // means Insert new record
                {
                    ProductCRUDOps.createProduct(
                        this.textBoxProductName.Text.Trim(),
                        this.textBoxProductType.Text.Trim(),
                        this.textBoxProductDesc.Text.Trim()
                        );
                }
                else // means Update existing record
                {
                    ProductCRUDOps.UpdateProduct(
                        this.selectedID,
                        this.textBoxProductName.Text.Trim(),
                        this.textBoxProductType.Text.Trim(),
                        this.textBoxProductDesc.Text.Trim()
                        );
                }
                this.resetFields();
            }
        }

    }
    }

