using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.Types;
using TCS.ISMS.BLLFactory;


namespace TCS.ISMS.UI
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int empID=Convert.ToInt32(txtEmployeeID.Text);
            bool isfound = false;
            IAdminBLL objBLL= BLLFactory.AdminBLLFactory.CreateAdminBLLObject();
            isfound = objBLL.CheckEmpID(empID);
            if (isfound)
            {
                lblSecurityQuestion.Visible = true;
                lblQuestion.Visible = true;
                lblAnswer.Visible = true;
                txtAnsr.Visible = true;
                btnSubmt.Visible = true;
               // btnClick.Visible = true;
                txtEmployeeID.ReadOnly = true;




            }
            else
            {
                lblMessage.Text = "Please Enter Valid Employee ID";
            }



        }

        protected void btnSubmt_Click(object sender, EventArgs e)
        {
            bool isvalidate = false;
            int empid = Convert.ToInt32(txtEmployeeID.Text);
            string answer = txtAnsr.Text;
            IAdminBLL obj = TCS.ISMS.BLLFactory.AdminBLLFactory.CreateAdminBLLObject();
            isvalidate=obj.ValidateSecurity(empid,answer);
            if (isvalidate)
            {
                lblNewPaswrd.Visible = true;
                txtNewPassword.Visible = true;
                txtNewPassword.Visible = true;
                txtConfirmPassword.Visible = true;
                btnSave.Visible = true;
                //btnCamcel.Visible = true;
                lblConfirmPasswrd.Visible = true;
                txtAnsr.ReadOnly = true;
                btnCancel.Visible = false;
                btnCancel2.Visible = true;

            }
            else
            {
                lblMessage.Text="Enter Correct Answer"; 
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isUpdated = false;
            int empid = Convert.ToInt32(txtEmployeeID.Text);
            string password = txtConfirmPassword.Text;
            IAdminBLL obj = TCS.ISMS.BLLFactory.AdminBLLFactory.CreateAdminBLLObject();
            isUpdated= obj.ChangePassword(empid,password);
            if (isUpdated)
            {
                lblMessage.Text = "Password Updated Successfully";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnCamcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnCancel2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}