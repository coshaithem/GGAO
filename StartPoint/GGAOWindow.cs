using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO
{
    public partial class GGAOWindow : Form
    {
        private BindingSource lastSelectedBindingSource = null;
        public GGAOWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gGAODataSet.Engine' table. You can move, or remove it, as needed.
            this.engineTableAdapter.Fill(this.gGAODataSet.Engine);
            // TODO: This line of code loads data into the 'gGAODataSet.Produit' table. You can move, or remove it, as needed.
            this.produitTableAdapter.Fill(this.gGAODataSet.Produit);

            // TODO: This line of code loads data into the 'gGAODataSet.Pole' table. You can move, or remove it, as needed.
            this.poleTableAdapter.Fill(this.gGAODataSet.Pole);
            // TODO: This line of code loads data into the 'gGAODataSet.Driver' table. You can move, or remove it, as needed.
            this.driverTableAdapter.Fill(this.gGAODataSet.Driver);


        }


        private void FillMainGridWith(BindingSource outSource)
        {
            if (lastSelectedBindingSource != outSource)
            {
                this.DGVMain.Columns.Clear();
                this.DGVMain.AutoGenerateColumns = true;
                this.DGVMain.DataSource = outSource; //driverBindingSource
                lastSelectedBindingSource = outSource;
            }
        }


        private void DriverBtn_Click(object sender, EventArgs e)
        {
            this.FillMainGridWith(this.driverBindingSource);
        }
        private void PoleBtn_Click(object sender, EventArgs e)
        {
            this.FillMainGridWith(this.poleBindingSource);
        }

        private void randomClearAction(object sender, EventArgs e)
        {

            this.DGVMain.Columns.Clear();
            this.DGVMain.Rows.Clear();

            this.DGVMain.AutoGenerateColumns = true;
            //this.DGVMain.DataSource = null; // this.driverBindingSource; //driverBindingSource

        }

        private void OilInBtn_Click(object sender, EventArgs e)
        {

        }

        private void ProductBtn_Click(object sender, EventArgs e)
        {
            this.FillMainGridWith(this.produitBindingSource);
        }

        private void EngineBtn_Click(object sender, EventArgs e)
        {
            this.FillMainGridWith(this.engineBindingSource);
        }

        private void DGVMain_SortStringChanged(object sender, EventArgs e)
        {
            if (lastSelectedBindingSource != null)
            {
                lastSelectedBindingSource.Sort = this.DGVMain.SortString; 
                this.updateTotalRow();
            }
        }

        private void DGVMain_FilterStringChanged(object sender, EventArgs e)
        {
            if (lastSelectedBindingSource != null)
            {
                lastSelectedBindingSource.Filter = this.DGVMain.FilterString;
                this.updateTotalRow();
            }
        }

        private void updateTotalRow()
        {
            this.totalRow.Text = string.Format("Total row {0}",
                this.lastSelectedBindingSource.List.Count
                );
        }
    }
}
