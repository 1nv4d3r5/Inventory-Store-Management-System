////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an interface IItem which is implemented by Item class.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    :     Susmita Rana, Tata Consultancy Services
//
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
   public interface IItem
    {
        int ItemID { get; set; }
        string ItemName { get; set;}
        int ItemCategory{ get; set;}
        int ItemQuantity{ get; set;}
        double ItemPrice { get; set; }
        int ItemClosingCount { get; set; }
        int ItemDiscount { get; set; }
        string CategoryName { get; set; }
    }
}
