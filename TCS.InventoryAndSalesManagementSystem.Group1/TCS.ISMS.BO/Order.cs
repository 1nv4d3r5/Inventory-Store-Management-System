////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an order class which implements an interface IOrder.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    :    Susmita Rana, Tata Consultancy Services
//
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
namespace TCS.ISMS.BO
{
    public class Order : Iorder

    {
        int orderId;
        string vendorName;
        int vendorId;
        DateTime orderDate;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public int VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }
        public string VendorName
        {
            get { return vendorName; }
            set { vendorName = value; }
        }
        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
        #endregion
    }
}
