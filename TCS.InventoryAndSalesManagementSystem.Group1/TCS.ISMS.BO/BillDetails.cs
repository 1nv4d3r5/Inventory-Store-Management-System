//File Description	: This page shows Bill Details
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 3 May, 2013
//	Changed By		    : Sandeep Kothawade
//	Change Description   : Editted Attribute Name
// 
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class BillDetails: IBillDetails
    {
        int billNumber;
        string itemName;
        int itemCategory;
        int quantityPurchsed;
        double linetotal;
        double discount;
        string itemStatus;
        int quantituReturned;
        string remarks;
        double linetotalofreturnedItems;
        int itemID;
        /// <summary>
        /// Properties of BO
        /// </summary>
#region properties
        public int BillNumber
        {
            get { return billNumber; }
            set { billNumber = value; }
        }

        public int QuantityPurchased
        {
            get { return quantityPurchsed; }
            set { quantityPurchsed= value; }
        }
        public int QuantityReturned
        {
            get { return quantituReturned; }
            set { quantituReturned= value; }
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
        public string Remarks
        {
            get { return remarks; }
            set { remarks= value; }
        }
        public string ItemStatus
        {
            get { return itemStatus; }
            set {itemStatus= value; }
        }
        public double Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public double LineTotal
        {
            get { return linetotal; }
            set { linetotal = value; }
        }
        public double LineTotalofReturnedItems
        {
            get { return linetotalofreturnedItems; }
            set { linetotalofreturnedItems = value; }
        }


        public int ItemID 
        {
            get { return itemID; }
            set { itemID = value; }
        }
        
#endregion

    }
}
