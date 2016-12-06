/* ******************************************************************
 * Nathan Durst
 * December 6, 2016
 * CPL C# - Stringfellow
 * Program 7 - Medical MDI - LoginUserControl
 * ******************************************************************
 * This class is the first window to be displayed when the application
 * is running. It requires the user to input a username and password
 * before making any other part of the application available
 * ******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_7___Medical_Supplies
{
    public partial class loginPasswordUserControl1 : UserControl
    {
        public loginPasswordUserControl1()
        {
            InitializeComponent();
        }

        /*********************************************************************8
         * EVENT HANDLER for LOGIN BUTTON */
        private void button1_Click(object sender, EventArgs e)
        {
            Main main = (Main)this.Parent;
            //set up so any string will be accepted. If empty, propts user to try again
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Please enter username/passwword\n\nHint: Any string will work.",
                    "Login Error");
            else
            {
                //Enables the tool strip menu options for the user to use the app
                this.Parent.Controls.Remove(this);
                main.fileToolStripMenuItem.Enabled = true;
                main.editToolStripMenuItem.Enabled = true;
            }
        }
    }
}
