////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an AdminBLLFactory class.
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
    public class AdminBLLFactory
    {
        public static IAdminBLL CreateAdminBLLObject()
        {
            IAdminBLL objBLL = new AdminBLL();
            return objBLL;
        }
    }
}
