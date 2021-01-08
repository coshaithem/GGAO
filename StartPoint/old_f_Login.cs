using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartPoint
{
    public partial class f_Login : Form
    {
        // this can be buggy
            int mov, movX, movY;
            private int idLoginUser = -1;
        public f_Login()
        {
            InitializeComponent();
        }

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

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if ( mov ==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (this.textBox1.PasswordChar == '\0')
            {
                this.textBox1.PasswordChar = '*';
                this.pictureBox1.Image = global::GGAO.Properties.Resources.show;
            }
            else
            {
                this.textBox1.PasswordChar = '\0';
                this.pictureBox1.Image = global::GGAO.Properties.Resources.hide;
            }
        }

        private void login_Click(object sender, EventArgs e)
        {   // temporary action
            this.Hide();
            f_Main mainForm = new f_Main();
            mainForm.Show();
            // check if the user && pass are  VALID
            if (  connectionWithServer()  == true )
            { 
                if ( UserAndPassValid() == true)
                {
                    // update loginUserID
                    
                    // dispose the f_login and switch to the f_main 



                }
            }
        }

        private bool UserAndPassValid()
        {
            // execute query to check if this user exist
            // make sure to surround this area with try catch
            return true;
        }

        private Boolean connectionWithServer()
        {
            // try to connect with the server 
            // make sure to surround this bloc with tr catch
            return true;
        }


        private void StartHere_Load(object sender, EventArgs e)
        {
            //Check the UserID is  
            // Test Connectin with the Server or the file


        }
    }
}
