////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains Inventory manager DAL Factory class.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    : Suman Pradhan, Tata Consultancy Services
//
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.DAL;

namespace TCS.ISMS.DALFactory
{
    public class InventoryManagerDALFactory
    {
        public static IInventoryManagerDAL CreateInventoryManagerDALObject()
        {
            IInventoryManagerDAL objDAL = new InventoryManagerDAL();
            return objDAL;
        }
    }
}
