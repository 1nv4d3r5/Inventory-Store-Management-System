
////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an View Money Transaction class which implements an IViewMoneyTransaction
// ---------------------------------------------------------------------------------
//	Date Created		: April 17, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Suman Pradhan
//	Change Description   : Changed datatype of bill number from double to int
///////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
   public class ViewMoneyTransaction:IViewMoneyTransaction
    {
       int billNo;
       double amountReceived;
       double totalPrice;
       double amountReturned;
       /// <summary>
       /// Properties of BO
       /// </summary>
       #region Properties
       public int BillNo
       {
           get { return billNo; }
           set { billNo = value; }
       }
       public double AmountReceived
       {
           get { return amountReceived; }
           set { amountReceived = value; }
       }
       public double TotalPrice
       {
           get { return totalPrice; }
           set { totalPrice = value; }
       }
       public double AmountReturned
       {
           get { return amountReturned; }
           set { amountReturned = value; }
       }
       #endregion

    }
}
