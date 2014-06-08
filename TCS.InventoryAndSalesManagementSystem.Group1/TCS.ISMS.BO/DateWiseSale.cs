//File Description	: This page shows report of datewise sales.
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 5 May, 2013
//	Changed By		    : Suman Pradhan
//	Change Description   :Implemented IDateWiseSale interface
// 
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class DateWiseSale : IDateWiseSale
    {

       private DateTime date;
       private double totalSales;
       private string itemName;
       private int itemId;

       /// <summary>
       /// Properties of BO
       /// </summary>
        #region properties

       public DateTime Date
       {
           get { return date; }
           set {date= value ; }
       
       }

       public double TotalSales
       {
           get { return totalSales; }
           set { totalSales = value; }

       }
       public string ItemName
       {
           get { return itemName; }
           set { itemName = value; }

       }
       public int ItemId
       {
           get { return ItemId; }
           set { ItemId = value; }

       }
    }
}
        #endregion
