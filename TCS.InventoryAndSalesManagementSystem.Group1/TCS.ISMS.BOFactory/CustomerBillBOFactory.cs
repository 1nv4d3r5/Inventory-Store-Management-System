//File Description	: This page shows category wise sales BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Arshin Saluja, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.BO;

namespace TCS.ISMS.BOFactory
{
  public class CustomerBillBOFactory
    {
        public static ICustomerBill CreateCustomerBillObject()
        {
            ICustomerBill objCustomerBill = new CustomerBill();
            return objCustomerBill;
        }
    }
}

