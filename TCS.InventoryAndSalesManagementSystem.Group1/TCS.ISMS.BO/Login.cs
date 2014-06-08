//File Description	: This page has BO for Login Details
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 5 May, 2013
//	Changed By		    : Sandeep Kothawade
//	Change Description   : Added Attribute role
// 
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class Login : ILogin
    {
        int employeeId;
        string password;
        int role;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Role
        {
            get { return role; }
            set { role = value; }
        }
        #endregion
    }
    }

