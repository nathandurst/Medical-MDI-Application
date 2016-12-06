/* ******************************************************************
 * Nathan Durst
 * December 6, 2016
 * CPL C# - Stringfellow
 * Program 7 - Medical MDI - Insert Form Class
 * ******************************************************************
 * This class is used to display a form that allows the user to enter 
 * the variables that make up a record. 
 * ******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Program_7___Medical_Supplies
{
    public partial class insertForm : Form
    {
        int ID, qty, qtyReq;
        String name, practice;
        private List<Record> records = new List<Record>();
        //private BinaryFormatter reader = new BinaryFormatter();
        
        /***************************************************************
         * CONSTRUCTOR requires records list and clinic name*/
        public insertForm(List<Record> items, String clinic)
        {
            InitializeComponent();
            records = items;
            practice = clinic;
        }

        /***************************************************************
         * CANCEL closes the insert form */
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*****************************************************************
         * OK converts all of the strings that need to be intergers, as well
         * as determines if each data item of the record is formatted correctly
         * and puts it in the list of records */
        private void okButton_Click(object sender, EventArgs e)
        {
            //data is not entered
            if (qtyreqTextBox.Text == "" || nameTextBox.Text == "" ||
                qtystkTextBox.Text == "" || idTextBox.Text == "")
            {
                MessageBox.Show("Please enter all data.", "Error");
            }
            //name is too long to be displayed in the list box
            else if (nameTextBox.Text.Length > 15)
                MessageBox.Show("Please use less than 15 characters for Item Name", "Size Error");
            //store inputed data in a new record and close the form
            else
            {
                try
                {
                    ID = Convert.ToInt32(idTextBox.Text);
                    name = nameTextBox.Text;
                    qtyReq = Convert.ToInt32(qtyreqTextBox.Text);
                    qty = Convert.ToInt32(qtystkTextBox.Text);

                    Record r = new Record(ID, name, qtyReq, qty, practice);
                    records.Add(r);

                    this.Close();
                    

                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Type!", "Format Error");
                }
            }

        }

    }
}
