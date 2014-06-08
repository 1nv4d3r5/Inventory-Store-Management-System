//File Description	: This page shows Order BO Factory.
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
    public class OrderBOFactory
    {
        public static Iorder CreateOrderObject()
        {
           Iorder objOrder = new Order();
            return objOrder;

        }
    }
}
