///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : Manage Employee Code behind page
// ---------------------------------------------------------------------------------
// Date Created  : Apr 25, 2013
// Author        : Arshin Saluja, Tata Consultancy Services
///////////////////////////////////////////////////////////////////////////////////////////////

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
    public partial class ManageEmployee : System.Web.UI.Page
    {
        List<IEmployee> selectedItemList1 = new List<IEmployee>();

        /// <summary>
        /// This is the page load method for managing employees.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //gvManageEmployee.Visible = true;
            if (!IsPostBack)
            {
                btnUP.Visible = false;
                IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
                gvManageEmployee.DataSource = objBLL.GetEmployeeDetailsList();
                gvManageEmployee.DataBind();
            }
        }
        /// <summary>
        /// Function to delete an employee from the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
           
            try
            {
                bool isEmployeeSelected = false;
                bool isDeleted = false;
                List<int> selectedItemList1 = new List<int>();


                //loop through the grid to find the selected item
                for (int i = 0; i < gvManageEmployee.Rows.Count; i++)
                {
                    GridViewRow gvEmployeeRow = gvManageEmployee.Rows[i];
                    isEmployeeSelected = (Boolean)((CheckBox)gvEmployeeRow.FindControl("chkSelect")).Checked;
                    if (isEmployeeSelected)
                    {
                        selectedItemList1.Add(Convert.ToInt32(gvManageEmployee.Rows[i].Cells[1].Text));
                    }
                }
                if (selectedItemList1.Count == 0)
                    lblMessage.Text = "Please select employee";
                else
                {
                    isDeleted = objBLL.DeleteEmployeeDetails(selectedItemList1);
                    gvManageEmployee.DataSource = objBLL.GetEmployeeDetailsList();
                    gvManageEmployee.DataBind();


                    //if (isEmployeeSelected)
                    //{
                    //    lblMessage.Text = "Please select an employee";
                    //}
                    if (isDeleted)
                    {
                        lblMessage.Text = "Employee(s) deleted successfully";
                    }

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;

            }
        }
        /// <summary>
        /// Function to redirect to the same page .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageEmployee.aspx");
        }
        /// <summary>
        /// Function to redirect to home page .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


        /// <summary>
        /// Function to bindings the grid view data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
          protected void OnGridViewDataBinding(object sender, GridViewRowEventArgs e)
          {
              if (e.Row.RowType == DataControlRowType.DataRow) //skip header row
              {
                  IEmployee objEmployee = (IEmployee)e.Row.DataItem;

                  IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
                  List<IRole> roleList = objBLL.GetRoleList();

                  DropDownList ddlRoleList = (DropDownList)e.Row.FindControl("ddlNewRole");

                  if (ddlRoleList != null)
                  {

                      ddlRoleList.AppendDataBoundItems = true;
                      ListItem lst = new ListItem("Select Role", "0");
                      ddlRoleList.Items.Add(lst);
                      ddlRoleList.DataSource = roleList;
                      ddlRoleList.DataTextField = "RoleName";
                      ddlRoleList.DataValueField = "RoleId";
                      ddlRoleList.DataBind();
                      
                  }
              }
          }
          /// <summary>
          /// Function will allow to update the employee details based on selected check box.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            gvManageEmployee.Visible = false;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnUP.Visible = true;
            try
            {
                bool isEmployeeSelected = false;
                //bool isDeleted = false;
               


                //loop through the grid to find the selected item
                for (int i = 0; i < gvManageEmployee.Rows.Count; i++)
                {
                    GridViewRow gvEmployeeRow = gvManageEmployee.Rows[i];
                    isEmployeeSelected = (Boolean)((CheckBox)gvEmployeeRow.FindControl("chkSelect")).Checked;
                    if (isEmployeeSelected)
                    {
                        IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
                        objEmployee.EmployeeId = Convert.ToInt32(gvEmployeeRow.Cells[1].Text);
                        objEmployee.FirstName = (gvEmployeeRow.Cells[2].Text);
                        objEmployee.LastName = (gvEmployeeRow.Cells[3].Text);
                        objEmployee.RoleName = gvEmployeeRow.Cells[4].Text;
                        objEmployee.MobileNumber = Convert.ToInt64(gvEmployeeRow.Cells[5].Text);

                        selectedItemList1.Add(objEmployee);
                    }
                }
                if(selectedItemList1.Count != 0)
               
                gvshowItems.DataSource = selectedItemList1;
                gvshowItems.DataBind();

                if (selectedItemList1.Count == 0)
                {
                    gvManageEmployee.Visible = true;
                    lblMessage.Text = "Please select employee";
                }
                //else
                //{
                //    //isDeleted = objBLL.DeleteEmployeeDetails(selectedItemList1);
                //    //if (!IsPostBack)
                //    //{   
                       
                //    //}

                //    //if (isEmployeeSelected)
                //    //{
                //    //    lblMessage.Text = "Please select an employee";
                //    //}
                //    //if (isDeleted)
                //    {
                //        //lblMessage.Text = "Employee(s) deleted successfully";
                //    }

                //
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;

            }

        }
        /// <summary>
        /// Function will update the new role allocated to the selected employee id in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUP_Click(object sender, EventArgs e)
        { 

            //IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            ILogin objLogin = LoginBOFactory.CreateLoginObject();
            List<IEmployee> lstEmp = new List<IEmployee>();
            
            try
            {   
                bool isNotSelected=false;
                  for (int i = 0; i < gvshowItems.Rows.Count; i++)
                {
                    GridViewRow gvEmployeeRow = gvshowItems.Rows[i];
                   
                        IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
                        objEmployee.EmployeeId = Convert.ToInt32(gvEmployeeRow.Cells[0].Text);
                        //objEmployee.FirstName = (gvEmployeeRow.Cells[2].Text);
                        //objEmployee.LastName = (gvEmployeeRow.Cells[3].Text);
                        
                        objEmployee.RoleId = Convert.ToInt32(((DropDownList)gvEmployeeRow.FindControl("ddlNewRole")).SelectedItem.Value);
                        //objEmployee.MobileNumber = Convert.ToInt64(gvEmployeeRow.Cells[5].Text);
                        if (objEmployee.RoleId == 10 || objEmployee.RoleId == 11 || objEmployee.RoleId == 12 || objEmployee.RoleId == 13)
                        {
                            lstEmp.Add(objEmployee);
                        }
                      
                   
                }
                //objEmployee.RoleId =Convert.ToInt32(ddlNewRole.SelectedValue);

                  bool IsUpdated = false;
                  if (!isNotSelected)
                  {
                      IsUpdated = objBLL.UpdateEmployeeDetails(lstEmp);
                  }
                if (IsUpdated)
                {
                    lblMessage.Text = "Employee details Updated successfully.";
                }
                else
                {
                    lblMessage.Text = "An error occurred while updating Employee details";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while updating Employee details";
            }
            finally
            {
                objBLL = null;
            }
        }


        //protected void gvshowItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvshowItems.PageIndex = e.NewPageIndex;
        //    DataBind();
        //}

        /// <summary>
        /// This method is used for paging.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvManageEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvManageEmployee.PageIndex = e.NewPageIndex;
            DataManageEmployeeBinding();
        }

        //protected void DataBind()
        //{
        //    //IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
        //    //gvVendorDetailList.DataSource = objBLL.GetVendorDetails();
        //    //gvVendorDetailList.DataBind();
        //    IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
        //    gvshowItems.DataSource = objBLL.GetEmployeeDetailsList();
        //    gvshowItems.DataBind();

        //}

        /// <summary>
        /// This method is used for dinding the data.
        /// </summary>
        protected void DataManageEmployeeBinding()
        {
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            gvManageEmployee.DataSource = objBLL.GetEmployeeDetailsList();
            gvManageEmployee.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string name= txtSearchBox.Text;
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            gvManageEmployee.DataSource = objBLL.GetEmployeeDetailsList(name);
            gvManageEmployee.DataBind();
        }
        }
    }
