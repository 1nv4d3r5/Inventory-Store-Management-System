////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an employee class which implements an interface IHRLR.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
//
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class HRLR:IHRLR
    {
        string itemName;
        string itemCategory;
        double itemSold;
        
        /// <summary>
        /// Properties of BO
        /// </summary>

        #region Properties
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public string ItemCategory
        {
            get { return itemCategory; }
            set { itemCategory = value; }
        }
        public double ItemSold
        {
            get { return itemSold; }
            set { itemSold = value; }
        }
        #endregion
    }
}
