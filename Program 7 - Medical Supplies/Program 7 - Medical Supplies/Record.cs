/* ******************************************************************
 * Nathan Durst
 * December 6, 2016
 * CPL C# - Stringfellow
 * Program 7 - Medical MDI - Record Class
 * ******************************************************************
 * This class is responsible for defining what a record is.
 *  A Record is a item in the inventory list that contains
 *  an ID, Description/name, quantity required, and quantity
 *  currently in stock.
 * ******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_7___Medical_Supplies
{
    [Serializable]
    public class Record
    {
        /****************************************************
        * DEFAULT CONSTRUCTOR (initializes to zero or null)*/
        public Record()
        {
            ID = 0;
            Name = null;
            QtyReq = 0;
            Qty = 0;
            Practice = null;
        }
        /***************************************************
         * PARAMETERIZED CONSTRUCTOR */
        public Record(int id, string name, int qtyreq, int qty,
            string practice)
        {
            ID = id;
            Name = name;
            QtyReq = qtyreq;
            Qty = qty;
            Practice = practice;
        }

        /*
         * CONVERTS TO STRING (to later be displayed on a listbox)*/
        public override string ToString()
        {
            if (Name.Length<8)
                return (ID.ToString() + "\t\t" + Name + "\t\t\t" + Qty.ToString() + '\t' + QtyReq.ToString());
            else
                return (ID.ToString() + "\t\t" + Name + "\t\t" + Qty.ToString() + '\t' + QtyReq.ToString());
        }

        /***************************************************
         * CLASS VARIABLES */
        public int ID;
        public string Name;
        public int QtyReq;
        public int Qty;
        public string Practice;
    }
}
