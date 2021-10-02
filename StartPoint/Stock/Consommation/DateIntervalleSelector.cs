using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGAO.Stock.Consommation
{
    public partial class DateIntervalleSelector : Form
    {
        public DateTime dialogFromDate, dialogToDate;
        public DateIntervalleSelector()
        {
            InitializeComponent();
            dialogFromDate = System.DateTime.Now.Date;
            dialogToDate = dialogFromDate.AddDays(-1);
        }
         

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateIntervalleSelector.FromdateTime.Value < DateIntervalleSelector.TodateTime.Value)
            {

                dialogFromDate = DateIntervalleSelector.FromdateTime.Value.Date ;
                dialogToDate = DateIntervalleSelector.TodateTime.Value.Date ;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("les Dates sont incorrect","Error", MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
            }
        }
    }
}
