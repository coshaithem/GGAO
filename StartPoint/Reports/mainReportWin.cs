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
    public partial class ReportWin : Form
    {
        public ReportWin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'GGAOEngineDataSet.ListOfEngine' table. You can move, or remove it, as needed.
            this.ListOfEngineTableAdapter.Fill(this.GGAOEngineDataSet.ListOfEngine,null);

            this.reportViewer1.RefreshReport();
        }
    }
}
