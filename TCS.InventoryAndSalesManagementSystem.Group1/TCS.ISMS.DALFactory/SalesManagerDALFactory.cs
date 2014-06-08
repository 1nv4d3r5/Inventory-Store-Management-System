////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains sales manager DAL Factory class.
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
using TCS.ISMS.DAL;

namespace TCS.ISMS.DALFactory
{
    public class SalesManagerDALFactory
    {
        public static ISalesManager CreateSalesManagerDALObject()
        {
            ISalesManager objDAL = new SalesManagerDAL();
            return objDAL;
        }
    }
}
