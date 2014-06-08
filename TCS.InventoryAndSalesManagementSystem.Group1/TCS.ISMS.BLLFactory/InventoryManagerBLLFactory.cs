////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an InventoryManagerBLLFactory class.
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
using TCS.ISMS.BLL;

namespace TCS.ISMS.BLLFactory
{
    public class InventoryManagerBLLFactory
    {
        public static IInventoryManagerBLL CreateInventoryManagerBLLObject()
        {
            IInventoryManagerBLL objBLL = new InventoryManagerBLL();
            return objBLL;
        }
    }
}
