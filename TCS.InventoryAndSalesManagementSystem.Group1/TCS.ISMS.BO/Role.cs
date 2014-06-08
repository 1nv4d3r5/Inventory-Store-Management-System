//File Description	: This page has BO for Role
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class Role : IRole
    {
        int roleId;
        string roleName;
        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        public string RoleName
        {
            get { return roleName; }
            set {roleName = value; }
        }
        #endregion
    }
}
