////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an interface employee for employee.
// ---------------------------------------------------------------------------------
//	Date Created		:     April 19, 2013
//	Author			    :     Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		 :  April 26, 2013
//	Changed By		     :  Arshin Saluja
//	Change Description   :  Changed the role name to role Id.
//
//-------------------------------------------------------------------------------------
//
//  Date Modified		 : April 29, 2013
//	Changed By		     : Arshin Saluja
//	Change Description   : Added a new attribute role name.
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IEmployee
    {
        #region properties

        int EmployeeId
        {
            get;
            set;
        }

        string FirstName
        {
            get;
            set;
        }

        string LastName
        {
            get;
            set;
        }

        int RoleId
        {
            get;
            set;
        }

        string Address
        {
            get;
            set;
        }

        string City
        {
            get;
            set;
        }

        string State
        {
            get;
            set;
        }

        DateTime Dob
        {
            get;
            set;
        }

        DateTime Doj
        {
            get;
            set;
        }

        long MobileNumber
        {
            get;
            set;
        }
        string RoleName
        {
            get;
            set;
        }
        #endregion

    }
}
