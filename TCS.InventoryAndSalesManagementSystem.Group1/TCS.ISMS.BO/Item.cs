////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains Items details BO.
// ---------------------------------------------------------------------------------
//	Date Created		: April 17, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
//---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 6 May, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added categoryName attribute
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    
    public class Item : IItem
    {
        int itemID;
        string itemName;
        int itemCategory;
        int itemQuantity;
        double itemPrice;
        int itemClosingCount;
        int itemDiscount;
        string categoryName;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region Properties
        public int ItemID
        {
            get
            { 
                return itemID;
            }
            set
            {
                itemID = value;
            }
        }
        public string ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
            }
        }
        public int ItemCategory
        {
            get
            {
                return itemCategory;
            }
            set
            {
                itemCategory = value;
            }
        }
        public int ItemQuantity
        {
            get
            {
                return itemQuantity;
            }
            set
            {
                itemQuantity = value;
            }
        }
        public double ItemPrice
        {
            get
            {
                return itemPrice;
            }
            set
            {
                itemPrice = value;
            }
        }
        public int ItemClosingCount
        {
            get
            {
                return itemClosingCount;
            }
            set
            {
                itemClosingCount = value;
            }
        }
        public int ItemDiscount
        {
            get
            {
                return itemDiscount;
            }
            set
            {
                itemDiscount = value;
            }
        }
        public string CategoryName
        {
            get 
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }
        #endregion
    }
}
