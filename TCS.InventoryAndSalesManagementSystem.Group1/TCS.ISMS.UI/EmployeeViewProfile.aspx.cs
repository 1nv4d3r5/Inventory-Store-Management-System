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
    public partial class EmployeeViewProfile : System.Web.UI.Page
    {
        /// <summary>
        /// This is the page load for view employee profile.
        /// </summary>

        protected void Page_Load(object sender, EventArgs e)
        {

            ILogon user = (ILogon)Session["ObjUserInfo"];
            int employeeID = user.EmployeeId;
            if (!IsPostBack)
            {
                btnReset.Visible = false;
                btnUpdate.Visible = false;
                //viewTable.Visible = false;
                updateTable.Visible = false;
                IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
                IEmployee objEmployee = objBLL.GetEmployee(employeeID);
                lblFirstNamedynamic.Text = objEmployee.FirstName;
                lblLastNamedynamic.Text = objEmployee.LastName;
                lblAddressDynamic.Text = objEmployee.Address;
                lblRoleTagDynamic.Text = objEmployee.RoleName;
                lblStateDynamic.Text = objEmployee.State;
                lblCityDynamic.Text = objEmployee.City;
                lblContactDynamic.Text = Convert.ToString(objEmployee.MobileNumber);
                lblDOBDynamic.Text = Convert.ToString(objEmployee.Dob);
                lblDOJDynamic.Text = Convert.ToString(objEmployee.Doj);
                lblEmployeeIdDynamic.Text = Convert.ToString(objEmployee.EmployeeId);
            }
        }
        /// <summary>
        /// This method will provide to edit the some of text fields.
        /// </summary>

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                btnEdit.Visible = false;
                btnUpdate.Visible = true;
                btnReset.Visible = true;
                ILogon user = (ILogon)Session["ObjUserInfo"];
                int employeeID = user.EmployeeId;
                updateTable.Visible = true;
                viewTable.Visible = false;
                //btnEdit.Visible = false;
                IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
                IEmployee objEmployee = objBLL.GetEmployee(employeeID);
                lblFirstNamedynamic2.Text = objEmployee.FirstName;
                lblLastNamedynamic2.Text = objEmployee.LastName;
                txtAddress2.Text = objEmployee.Address;
                lblRoleTagDynamic2.Text = objEmployee.RoleName;
                //  ddlState2.SelectedItem.Text = objEmployee.State;
                // ddlCity2.SelectedItem.Text = objEmployee.City;
                txtContact2.Text = Convert.ToString(objEmployee.MobileNumber);
                lblDOBDynamic2.Text = Convert.ToString(objEmployee.Dob);
                lblDOJDynamic2.Text = Convert.ToString(objEmployee.Doj);
                lblEmployeeIdDynamic2.Text = Convert.ToString(objEmployee.EmployeeId);
            }
        }

        /// <summary>
        /// This method will bind the drop down list.
        /// </summary>

        protected void ddlState2_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                if (ddlState2.SelectedItem.Text.ToUpper() == "MAHARASHTRA")
                {
                    ddlCity2.Items.Clear();
                    ddlCity2.Items.Add("Mumbai");
                    ddlCity2.Items.Add("Nagpur");
                    ddlCity2.Items.Add("Gondia");
                }
                else if (ddlState2.SelectedItem.Text.ToUpper() == "GUJRAT")
                {
                    ddlCity2.Items.Clear();
                    ddlCity2.Items.Add("Ahmedabad");
                    ddlCity2.Items.Add("Surat");
                    ddlCity2.Items.Add("Gandhi Nagar");
                }
                else if (ddlState2.SelectedItem.Text.ToUpper() == "MADHYA PRADESH")
                {
                    ddlCity2.Items.Clear();
                    ddlCity2.Items.Add("Bhopal");
                    ddlCity2.Items.Add("Indore");
                    ddlCity2.Items.Add("Jabalpur");
                }
                else if (ddlState2.SelectedItem.Text.ToUpper() == "CHHATTISGARH")
                {
                    ddlCity2.Items.Clear();
                    ddlCity2.Items.Add("Raipur");
                    ddlCity2.Items.Add("Durg");
                    ddlCity2.Items.Add("Bhilai");
                }
                else if (ddlState2.SelectedItem.Text.ToUpper() == "PUNJAB")
                {
                    ddlCity2.Items.Clear();
                    ddlCity2.Items.Add("Amritsar");
                    ddlCity2.Items.Add("Ludhiyana");
                    ddlCity2.Items.Add("Chandigarh");
                }
                else if (ddlState2.SelectedItem.Text.ToUpper() == "ANDHRA PRADESH")
                {
                    ddlCity2.Items.Clear();
                    ddlCity2.Items.Add("Banglore");
                    //ddlCity.Items.Add("Surat");
                    //ddlCity.Items.Add("Gandhi Nagar");
                }
                else
                {
                    ddlCity2.Items.Clear();
                }
            }
        }
        /// <summary>
        /// This method will allow to update the edited fields.
        /// </summary>

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
            try
            {
                bool isUpdated = false;
                objEmployee.EmployeeId = Convert.ToInt32(lblEmployeeIdDynamic2.Text);
                objEmployee.Address = (txtAddress2).Text;
                objEmployee.State = Convert.ToString(ddlState2.SelectedItem);
                objEmployee.City = Convert.ToString(ddlCity2.SelectedItem);
                objEmployee.MobileNumber = Convert.ToInt64(txtContact2.Text);
                bool IsAdded = objBLL.UpdateEmployee(objEmployee);
                isUpdated = true;
                //objEmployee.EmployeeId = Convert.ToInt32(gvEmployeeRow.Cells[1].Text);
                //objEmployee.FirstName = (gvEmployeeRow.Cells[2].Text);
                //objEmployee.LastName = (gvEmployeeRow.Cells[3].Text);
                //objEmployee.RoleName = gvEmployeeRow.Cells[4].Text;
                //objEmployee.MobileNumber = Convert.ToInt64(gvEmployeeRow.Cells[5].Text);

                //selectedItemList1.Add(objEmployee);
                if (isUpdated)
                {
                    lblMessage.Text = "Updated successfully";
                }
                else
                {
                    lblMessage.Text = "Unable to update";
                }

            }

            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;

            }


        }
        /// <summary>
        /// This method will provide visibilty to one table at a time.
        /// </summary>

        protected void btnViewProfile_Click(object sender, EventArgs e)
        {
            viewTable.Visible = true;
            updateTable.Visible = false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlCity2.SelectedItem.Text = "----------";
            lblMessage.Text = string.Empty;
            clearInput(Page.Controls);
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
    }
}
    
