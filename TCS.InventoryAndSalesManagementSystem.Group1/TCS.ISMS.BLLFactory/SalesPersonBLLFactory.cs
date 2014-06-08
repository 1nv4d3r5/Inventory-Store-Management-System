////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an SalesPersonBLLFactory class.
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
    public class SalesPersonBLLFactory
    {
        public static ISalesPersonBLL CreateSalesPersonBLLObject()
        {
            ISalesPersonBLL objBLL = new SalesPersonBLL();
            return objBLL;
        }
    }
}
