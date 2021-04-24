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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            char p = this.passwordText.PasswordChar;
            if (  p == '*')
            {
                // disable visible
                this.passwordText.PasswordChar = '\0';

                this.ShowHidePicture.Image = global::GGAO.Properties.Resources.hide;
            }
            else
            {
                this.passwordText.PasswordChar = '*';
                this.ShowHidePicture.Image = global::GGAO.Properties.Resources.show;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( this.passwordText.Text.ToLower().Trim().Equals("g")) {
                button1.Enabled = false;
                GGAO.GGAOWindow a = new GGAO.GGAOWindow() ;
                a.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("le mot de pass est incorrect", "Login unauthorise");
            }
        }
    }
}
