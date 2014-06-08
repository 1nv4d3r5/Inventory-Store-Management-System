////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an ordered items class which implements an interface IOrderedItems.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    :     Susmita Rana, Tata Consultancy Services
//
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
namespace TCS.ISMS.BO
{
    public class OrderedItems : IOrderedItems
    {
        string itemName;
        int itemCategory;
        int itemQuantity;
        int itemId;
        int orderId;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
       
         public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public int ItemCategory
        {
            get { return itemCategory; }
            set { itemCategory = value; }
        }
        public int ItemQuantity
        {
            get { return itemQuantity; }
            set { itemQuantity = value; }
        }
        #endregion
    }
}
