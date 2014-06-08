//File Description	: This page has BO for Customer Details
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Arshin Saluja, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
namespace TCS.ISMS.BO
{
    public class Customer : ICustomer
    {
        string customerName;
        int customerId;
        long customerPhnNumber;
        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public long CustomerPhnNumber
        {
            get { return customerPhnNumber; }
            set { customerPhnNumber = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        #endregion
    }
}
