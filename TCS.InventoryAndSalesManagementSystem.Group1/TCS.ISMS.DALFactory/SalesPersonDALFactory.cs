
////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains sales person DAL Factory class.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
//
////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.DAL;

namespace TCS.ISMS.DALFactory
{
    public class SalesPersonDALFactory
    {
        public static ISalesPersonDAL CreateSalesPersonDALObject()
        {
            ISalesPersonDAL objDAL = new SalesPersonDAL();
            return objDAL;
        }
    }
}
