
//	File Description	: This file contains an List of Returned Items.This class implements IReturnedItems.
// ---------------------------------------------------------------------------------
//	Date Created		: April 17, 2013
//	Author			    :     Amit Nadkarni, Tata Consultancy Services
///////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class ReturnedItems:IReturnedItems
    {

        private int billNo;
        private int itemID;
        private string name;
        private double quantity;
        private string remarks;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties

        public int BillNo
        {
            get { return billNo; }
            set { billNo=value; }
        }
        public int ItemID
        {
            get { return itemID; }
            set { itemID=value; }
        }
        public string Name
        {
            get { return name; }
            set { name=value; }
        }
        public double Quantity
        {
            get { return quantity; }
            set {quantity=value; }
        }
        public string Remarks
        {
            get { return remarks; }
            set { remarks=value; }
        }


    }
}
        #endregion
