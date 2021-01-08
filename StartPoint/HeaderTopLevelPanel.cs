using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartPoint
{
    public partial class HeaderTopLevelPanel : UserControl
    {
        public HeaderTopLevelPanel()
        {
            InitializeComponent();
        }

        // this can be buggy
        int mov, movX, movY;
        private int idLoginUser = -1;

        public int getLoginUserID()
        {
            return this.idLoginUser;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void About_Click(object sender, EventArgs e)
        {
            new f_About().Show();
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void About_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
               // this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

    }
}
