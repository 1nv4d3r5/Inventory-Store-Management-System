
////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an Inventory Cross Check class which implements an interface IIMCrossCheck.
// ---------------------------------------------------------------------------------
//	Date Created		: April 17, 2013
//	Author			    :     Amit Nadkarni, Tata Consultancy Services
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class IMCrossCheck:IIMCrossCheck
    {
        private string itemName;
        private double itemCount;
        private double lastSale;
        private double itemSold;
        private double difference;
        private int addedByAdmin;
        /// <summary>
        /// Properties of BO
        /// </summary>
        #region Properties

        public string ItemName
        { get { return itemName; }
            set {itemName=value; }
        }

        public double ItemCount
        {
            get { return itemCount; }
            set { itemCount=value; }
        }

        public double LastSale
        {
            get { return lastSale; }
            set { lastSale=value; }
        }

        public double ItemSold
        {
            get { return itemSold; }
            set { itemSold=value; }
        }

        public double Difference
        {
            get { return difference; }
            set { difference=value; }
        }

        public int AddedByAdmin
        {
            get { return addedByAdmin; }
            set { addedByAdmin = value; }
        }
    }
}

        #endregion
