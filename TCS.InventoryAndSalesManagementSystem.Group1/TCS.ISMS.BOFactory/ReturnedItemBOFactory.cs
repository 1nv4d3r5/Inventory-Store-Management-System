//File Description	: This page shows Returned Items BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.BO;

namespace TCS.ISMS.BOFactory
{
    public class ReturnedItemBOFactory
    {
        public static IReturnedItems CreateReturnedItemsObject()
        {
            IReturnedItems objReturnedItems = new ReturnedItems();
            return objReturnedItems;

        }
    }
}
