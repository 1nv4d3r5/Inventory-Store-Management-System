//File Description	: This page shows Money Transaction BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:2 May, 2013
//	Author			    :Suman Pradhan, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.BO;

namespace TCS.ISMS.BOFactory
{
    public class ViewMoneyTransactionBOFactory
    {
        public static IViewMoneyTransaction CreateViewMoneyTransactionObject()
        {
            IViewMoneyTransaction objViewMoneyTrans = new ViewMoneyTransaction();
            return objViewMoneyTrans;
        }
    }
}
