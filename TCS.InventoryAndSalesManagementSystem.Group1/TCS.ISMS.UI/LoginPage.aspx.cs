//File Description	: This is the Code Behind File for Log In page
// ---------------------------------------------------------------------------------
//	Date Created		:
//	Author			    : Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 2 May, 2013
//	Changed By		    : Sandeep Kothawade
//	Change Description  : 
//
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.Types;
using TCS.ISMS.BOFactory;

namespace TCS.ISMS.UI
{
    public partial class LoginPage : System.Web.UI.Page
    {

        /// <summary>
        /// This method enables user to log into the system
        /// </summary>
       
        protected void btnLogIn_Click1(object sender, EventArgs e)
        {
            
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            ILogin objLogin = LoginBOFactory.CreateLoginObject();

            try
            {
                objLogin.EmployeeId = Convert.ToInt32(txtUserName.Text);
                objLogin.Password = Convert.ToString(txtPassword.Text);

                int roleID = objBLL.ChkLogInCredentials(objLogin);
                if (roleID != 0)
                {
                    lblMessage.Text = "Role Id is " + roleID;
                    objLogin.Role = roleID;
                    Session["userID"] = objLogin.EmployeeId;
                    ILogon user = LogonBOFactory.CreateLogonObject();

                    user = objBLL.GetUserMenu(objLogin);
                    Session["ObjUserInfo"] = user;
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    lblMessage.Text = "Incorrect Id or password.";
                }
            }

            catch (Exception ex)
            {
                lblMessage.Text = "Incorrect User Id or password";
            }

        }

        /// <summary>
        /// This method redirects page to Log In Page
        /// </summary>
       
        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
    }
}
