/* ******************************************************************
 * Nathan Durst
 * December 6, 2016
 * CPL C# - Stringfellow
 * Program 7 - Medical MDI - Practice Form Class (Child Form)
 * ******************************************************************
 * This class is used when an instance of the clinic is called
 * to be opened or displayed. It shows the list of records and allows
 * the user to select specific records to delete.
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

namespace Program_7___Medical_Supplies
{
    public partial class PracticeForm : Form
    {
        private List<Record> records = new List<Record>();
        public String practice;
        public bool isOpen;

        /****************************************************************************
         * PARAMETERIZED CONSTRUCTOR */
        public PracticeForm(List<Record> items, String clinic)
        {
            InitializeComponent();
            records = items;
            practice = clinic;
            this.Text = clinic;
        }

        /******************************************************************************
         * refresh takes the given list of records and displays them in the list box for
         * the user to see */
        public void refresh(List<Record> items)
        {
            records = items;
            inventory.Items.Clear();
            inventory.Items.Add("Item ID \t\tName \t\t\tIn Stock \tRequired");
            inventory.Items.Add("--------------------------------------------------------"+
                "---------------------------------------------------------------------");
            if (records != null)
            {
                foreach (Record r in records)
                    inventory.Items.Add(r.ToString());
            }
        }

        /*****************************************************************************
         * Finds the current index of the selected item in the list box. Is used to determine
         * which item to delete. */
        public int findIndex()
        {
            int selected = inventory.SelectedIndex;
            return selected;

        }
        /*******************************************************************************
         * returns the list of records currently in the practice form class. */
        public List<Record> getRecords()
        {
            return records;
        }

        /*****************************************************************************
         * returns the name of the instance of the object asking for the project name */
        public String getPracticeName()
        {
            return practice;
        }
    }
}
