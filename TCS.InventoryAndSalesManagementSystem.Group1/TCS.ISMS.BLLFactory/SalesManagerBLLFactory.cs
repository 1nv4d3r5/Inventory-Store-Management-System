////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an SalesManagerBLLFactory class.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
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
    public class SalesManagerBLLFactory
    {
        public static ISalesManagerBLL CreateSalesManagerBLLObject()
        {
            ISalesManagerBLL objBLL = new SalesManagerBLL();
            return objBLL;
        }
    }
}
