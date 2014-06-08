////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This is the code behind file for add new employee.
// ---------------------------------------------------------------------------------
//	Date Created		:     April 19, 2013
//	Author			    :     Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		 :  April 26, 2013
//	Changed By		     :  Arshin Saluja
//	Change Description   :  Binded Drop Down List.
//
//-------------------------------------------------------------------------------------
//
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.Types;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.BOFactory;

namespace TCS.ISMS.UI
{
    public partial class AddNewEmployee : System.Web.UI.Page
    {

        /// <summary>
        /// This is the page load method for add/ update employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            calenderDOB.StartDate = Convert.ToDateTime("01/01/1960");
            calenderDOB.EndDate = Convert.ToDateTime("01 / 01 / 2005");
            calenderDOJ.StartDate = DateTime.Today.AddMonths(-1);
            calenderDOJ.EndDate = DateTime.Today;

            calenderDOJ.SelectedDate = DateTime.Today;
            
            

            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();

            List<IRole> lstRole = objBLL.GetRoleList();
            
            if (!IsPostBack)
            {
                ddlRole.DataSource = lstRole;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";
                ddlRole.DataBind();
            }
        }

        /// <summary>
        /// This method populates the city drop down on selecting the state drop down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlState.SelectedItem.Text.ToUpper() == "MAHARASHTRA")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("Mumbai");
                ddlCity.Items.Add("Nagpur");
                ddlCity.Items.Add("Gondia");
            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "GUJRAT")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("Ahmedabad");
                ddlCity.Items.Add("Surat");
                ddlCity.Items.Add("Gandhi Nagar");
            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "MADHYA PRADESH")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("Bhopal");
                ddlCity.Items.Add("Indore");
                ddlCity.Items.Add("Jabalpur");
            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "CHHATTISGARH")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("Raipur");
                ddlCity.Items.Add("Durg");
                ddlCity.Items.Add("Bhilai");
            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "PUNJAB")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("Amritsar");
                ddlCity.Items.Add("Ludhiyana");
                ddlCity.Items.Add("Chandigarh");
            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "ANDHRA PRADESH")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("Banglore");
                //ddlCity.Items.Add("Surat");
                //ddlCity.Items.Add("Gandhi Nagar");
            }
            else
            {
                ddlCity.Items.Clear();
            }
        }


        /// <summary>
        /// This method saves the employee cdetails in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_Click(object sender, EventArgs e)
        {

            IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            ILogin objLogin = LoginBOFactory.CreateLoginObject();

            try
            {
                objEmployee.FirstName = txtFirstName.Text;
                objEmployee.LastName = txtLastName.Text;
                objEmployee.RoleId =Convert.ToInt32(ddlRole.SelectedValue);
                objEmployee.Dob = Convert.ToDateTime(txtDOB.Text);
                objEmployee.Doj = Convert.ToDateTime(txtDOJ.Text);
                objEmployee.Address = (txtAddress.Text);
                objEmployee.State = Convert.ToString(ddlState.SelectedItem);
                objEmployee.City = Convert.ToString(ddlCity.SelectedItem);
                objEmployee.MobileNumber = Convert.ToInt64(txtContact.Text);
                
                bool IsAdded = objBLL.AddEmployeeDetails(objEmployee);
                lblMessage.Text = "Employee details saved successfully. The Employee Id is : " + objEmployee.EmployeeId;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while saving Employee details";
            }
            finally
            {
                objEmployee = null;
                objBLL = null;
            }
            clearInput(Page.Controls);
        }


        /// <summary>
        /// This method reset the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ddlCity.SelectedItem.Text = "----------";
            lblMessage.Text = string.Empty;
            clearInput(Page.Controls);
        }

        /// <summary>
        /// This method redirects the User the home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageEmployee.aspx");
        }

        public void clearInput(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }

                //if (ctrl is Label)
                //{
                //    (lblMessage).Text = string.Empty;
               // }
                if (ctrl is DropDownList)
                { 
                    ((DropDownList)ctrl).SelectedIndex = 0;
                }
                clearInput(ctrl.Controls);
            }
        
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
        }



        

    }
}