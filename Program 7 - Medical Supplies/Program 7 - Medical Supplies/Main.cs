/* ******************************************************************
 * Nathan Durst
 * December 6, 2016
 * CPL C# - Stringfellow
 * Program 7 - Medical MDI - Main Form
 * ******************************************************************
 * This is the main form of the program and implements the menu bar that
 * effects the rest of the forms. It is the parent form to the pracice
 * form class.
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
    public partial class Main : Form
    {
        public string practice = null;
        private BinaryFormatter bf = new BinaryFormatter();
        private FileStream reader, writer;
        private List<Record> records = new List<Record>();
        
        /**********************************************************************
         * DEFAULT CONSTRUCTOR initializes all components of the main form*/
        public Main()
        {
            InitializeComponent();
        }

        /**********************************************************************
         * EVENT HANDLER for the exit tab and closes the form (and all other forms) */
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**********************************************************************
         * EVENT HANDLER for the medical tab in the open tab. Assigns the name of the
         practice form to be created and loads the records from a file*/
        private void medicalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            practice = "Pickens Foot Clinic";
            loadRecords();
        }

        /**********************************************************************
         * EVENT HANDLER for the dental tab in the open tab. Assigns the name of the
         practice form to be created and loads the records from a file*/
        private void dentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            practice = "Lake Dental Clinic";
            loadRecords();
        }

        /**********************************************************************
         * CREATES A NEW INSTANCE OF PRACTICE FORM after the user chooses to open it.
         Also reads in the records from the file with same name as practice to be 
         inserted on the Practice form*/
        private void loadRecords()
        {
            PracticeForm P = this.ActiveMdiChild as PracticeForm;
            int numberOfChildren = this.MdiChildren.Length;

            //the form is already open
            if ((P != null && P.getPracticeName() == practice) || numberOfChildren == 2)
                MessageBox.Show("This form is already active.", "Error");
            //create a new child form and show it with the data from file
            else
            {
                P = new PracticeForm(records, practice);
                P.MdiParent = this;
                P.Show();
                
                string file = P.getPracticeName() + ".inv";
                records.Clear();

                //reads records from the file
                reader = new FileStream(file, FileMode.OpenOrCreate,
                            FileAccess.Read);
                if (reader.Length > 0)
                {
                    records = bf.Deserialize(reader) as List<Record>;
                }
                //displays the records on the list box
                P.refresh(records);
                reader.Close();
            }            
        }

        /**********************************************************************
         * EVENT HANDLER for the insert tab tha allows the user to insert a record
         to the active Practice Form*/
        private void insertToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PracticeForm P = this.ActiveMdiChild as PracticeForm;
            
            //there is an active child
            if (P != null)
            {
                records = P.getRecords();
                insertForm I = new insertForm(records, P.getPracticeName());
                I.ShowDialog();
                P.refresh(records);
                MessageBox.Show("Record has been added to the inventory list.", "Done!");
            }
            //there is not an active child
            else
                MessageBox.Show("No Clinic form available.", "Error");
        }

        /**********************************************************************
         * EVENT HANDLER that allows the user to delete a selected record from
         the active practice form*/
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeForm P = this.ActiveMdiChild as PracticeForm;
            
            //there is an active child
            if (P != null)
            {
                records = P.getRecords();
                //recieves the selected record
                int index = P.findIndex();
                if (index > 1)
                {
                    //removes it (but makes sure it isnt the header lines)
                    records.RemoveAt(index - 2);
                    P.refresh(records);
                    MessageBox.Show("Record has been removed from inventory list.", "Done!");
                }
            }
            //there is not an active child
            else
                MessageBox.Show("No clinic form available.", "Error");
        }

        /**********************************************************************
         * EVENT HANDLER for the save tab that saves all the records on the practice
         form to a file so it will be displayed if closed and re opened*/
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PracticeForm P = this.ActiveMdiChild as PracticeForm;
            //there is an active child
            if (P != null)
            {
                //write to the file
                string file = P.getPracticeName() + ".inv";
                writer = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write);
                records = P.getRecords();
                if (records.Count > 0)
                    bf.Serialize(writer, records);
                writer.Close();
                MessageBox.Show("Records have been saved to file name:\n"
                    + file, "Done!");
            }
            //there is not an active child
            else
                MessageBox.Show("No clinic form currently displayed.", "Error");
        }

        /**********************************************************************
         * EVENT HANDLER for the about tab that displays a message that explains the
         purpose of the application*/
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This application will allow an authorized user to access/update/save\n" +
                "the inventory list of two clinics, Lake Dental & Pickens Foot.", "About this application");
        }

    }
}
