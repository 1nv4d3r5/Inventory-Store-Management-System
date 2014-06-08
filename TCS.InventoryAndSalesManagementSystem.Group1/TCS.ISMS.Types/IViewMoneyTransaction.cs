//File Description	: This page shows interface of money transaction.
// ---------------------------------------------------------------------------------
//	Date Created		:2 May, 2013
//	Author			    :Suman Pradhan, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
   public interface IViewMoneyTransaction
    {
       int BillNo { get; set; }
       double AmountReceived { get; set; }
       double TotalPrice { get; set; }
       double AmountReturned { get; set; }
    }
}
