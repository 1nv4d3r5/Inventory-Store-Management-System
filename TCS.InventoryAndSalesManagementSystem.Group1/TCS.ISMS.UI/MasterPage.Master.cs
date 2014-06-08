using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.Types;
using TCS.ISMS.BOFactory;

namespace TCS.ISMS.UI
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            ILogon user = (ILogon)Session["ObjUserInfo"];
            if (user != null)
            {
                lblUserName.Text = user.EmployeeName;
                lblRolrTag.Text = user.RoleName;
                foreach (IMenu menuItem in user.MenoBo)
                {
                    MenuItem menu = new MenuItem(menuItem.MenuName, menuItem.MenuId.ToString());
                    menu.NavigateUrl = menuItem.NavigationUrl;
                    menu.ToolTip = menuItem.ToolTip;

                    DynamicSideMenu.Items.Add(menu);

                }
            }
            else Response.Redirect("LoginPage.aspx");

        }
      

        protected void Method_Logout(object sender, ImageClickEventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }


    }
}