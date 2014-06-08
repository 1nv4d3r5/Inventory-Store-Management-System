//File Description	: This page shows interface of datewise report of sales.
// ---------------------------------------------------------------------------------
//	Date Modified		: 5 May, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added Attributes ItemID and ItemName
// 
/////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TCS.ISMS.Types
{
    public interface IDateWiseSale
    {
         DateTime Date{get; set;}
         double TotalSales{get; set;}
         string ItemName { get; set; }
         int ItemId { get; set; }
        

    }
}
