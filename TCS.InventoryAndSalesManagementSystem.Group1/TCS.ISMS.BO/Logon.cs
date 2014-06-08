//File Description	: This page has BO for Logon
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 5 May, 2013
//	Changed By		    : Sandeep Kothawade
//	Change Description   : Added Attribute roleName
// 
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class Logon : ILogon
    {
        int employeeId;
        string employeeName;
        string roleName;
        List<IMenu> menubo;
        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public List<IMenu> MenoBo
        {
            get { return menubo; }
            set { menubo = value; }
        }

        #endregion

    }
}
