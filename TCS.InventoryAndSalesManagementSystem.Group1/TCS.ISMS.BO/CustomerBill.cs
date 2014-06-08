////////////////////////////////////////////////////////////////////////////////////
//File Description	: This page has BO for Customer Details
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Arshin Saluja, Tata Consultancy Services
//..................................................................................
// 	Change History
//	Date Modified		: 26 Apr, 2013
//	Changed By		    : Sandeep Kothawade
//	Change Description   : Editted Property
// 	Change History
//	Date Modified		: 6 May, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added remarks attribute
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class CustomerBill : ICustomerBill
    {
        int billNumber;
        double totalBillAmount;
        string billStatus;
        DateTime billDate;
        double moneyIn;
        double moneyOut;
        double totalMoneyReturned;
        int customerId;
        string customerName;
        int salesPersonId;
        int employeeId;
        string remarks;
        List<IItem> boughtItemList;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties

        public int BillNumber
        {
            get { return billNumber; }
            set { billNumber = value; }
        }

        public double TotalBillAmount
        {
            get { return totalBillAmount; }
            set { totalBillAmount = value; }
        }
        public string BillStatus
        {
            get { return billStatus; }
            set { billStatus = value; }
        }

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public DateTime BillDate
        {
            get { return billDate; }
            set { billDate = value; }
        }

        public double MoneyIn
        {
            get { return moneyIn; }
            set { moneyIn = value; }
        }

        public double MoneyOut
        {
            get { return moneyOut; }
            set { moneyOut = value; }
        }

        public double TotalMoneyReturned
        {
            get { return totalMoneyReturned; }
            set { totalMoneyReturned = value; }
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        
        public int SalesPersonId
        {
            get { return salesPersonId; }
            set { salesPersonId = value; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

       public List<IItem> BoughtItemList
        {
            get { return boughtItemList; }
            set { boughtItemList = value; }
        }

        #endregion
    }
}
