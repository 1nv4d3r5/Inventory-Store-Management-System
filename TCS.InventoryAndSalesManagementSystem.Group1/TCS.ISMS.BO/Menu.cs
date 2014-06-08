//File Description	: This page has BO for Login Details
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
    public class Menu : IMenu
    {
        int menuId;
        string menuName;
        string navigationUrl;
        int parentMenuId;
        string description;
        string toolTip;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
        public int MenuId
        {
            get { return menuId; }
            set { menuId = value; }
        }

        public string MenuName
        {
            get { return menuName; }
            set { menuName = value; }
        }

        public string NavigationUrl
        {
            get { return navigationUrl; }
            set { navigationUrl = value; }
        }

        public int ParentMenuId
        {
            get { return parentMenuId; }
            set { parentMenuId = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string ToolTip
        {
            get { return toolTip; }
            set { toolTip= value; }
        }
        #endregion
    }
}
