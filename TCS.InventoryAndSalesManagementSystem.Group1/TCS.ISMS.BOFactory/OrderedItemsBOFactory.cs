//File Description	: This page shows Date Wise Sales BO Factory.
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
   public class OrderedItemsBOFactory
    {
        public static IOrderedItems CreateOrderedItemsObject()
        {
            IOrderedItems objOrderedItems = new OrderedItems();
            return objOrderedItems;

        }
    }
}
