////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an Admin DAL factory which creates a DAL object.
// ---------------------------------------------------------------------------------
//	Date Created		:     April 19, 2013
//	Author			    :     Arshin Saluja, Tata Consultancy Services
//-----------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.DAL;

namespace TCS.ISMS.DALFactory
{
    public class AdminDALFactory
    {
        public static IAdminDAL CreateAdminDALObject()
        {
            IAdminDAL objDAL = new AdminDAL();
            return objDAL;
        }
    }
}
