//File Description	: This page shows View Items BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:25 Apr, 2013
//	Author			    :Sushmita Rana, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.BO;

namespace TCS.ISMS.BOFactory
{
    public class ViewItemBOFactory
    {
        public static IItem CreateItemobject()
        {
            IItem objItem = new Item();
            return objItem;
        }
    }
}
