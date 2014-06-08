//File Description	: This page shows Bill Details BO Factory.
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
    public class BillDetailsBOFactory
    {
        public static IBillDetails CreateBillDetailsObject()
        {
            IBillDetails objBillDetails = new BillDetails();
            return objBillDetails;
        }
    }
}
