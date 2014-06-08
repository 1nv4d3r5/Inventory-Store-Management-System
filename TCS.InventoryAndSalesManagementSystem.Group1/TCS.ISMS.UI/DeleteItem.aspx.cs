//File Description	: This is the Code Behind File for Deleting an Item
// ---------------------------------------------------------------------------------
//	Date Created		:April 27, 2013
//	Author			    :Suman Pradhan, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: April 27, 2013
//	Changed By		    : Suman Pradhan
//	Change Description   :Binded Drop Down List
// ---------------------------------------------------------------------------------
//
//  Date Modified       :April 29, 2013
//  Changed By          :Suman Pradhan
//  Changed Description :Added method for binding grid view
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.Types;
using System.Threading;

namespace TCS.ISMS.UI
{
    public partial class DeleteItem : System.Web.UI.Page
    {
        /// <summary>
        /// This is the Page Load method for deleting an item
        /// </summary>
        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                lblMessage.Text = "";
                IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();

                List<IItemCategory> itemList = objBLL.GetCategoryList();

                ddlCategory.DataSource = itemList;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();


            }
        }

        /// <summary>
        /// This method deleted the Item details from the gridview list
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool isItemSelected = false;
            bool isdeleted = false;
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            try
            {

                List<int> selectedCategoryList = new List<int>();

                lblMessage.Text = "";
                
                //loop through the grid to find the selected item
                for (int i = 0; i < gvItemList.Rows.Count; i++)
                {
                    GridViewRow gvItem = gvItemList.Rows[i];
                    isItemSelected = ((CheckBox)gvItem.FindControl("chkItem")).Checked;
                    if (isItemSelected)
                    {
                        selectedCategoryList.Add(Convert.ToInt32(gvItemList.Rows[i].Cells[1].Text));

                    }
                    if (selectedCategoryList.Count >= 1)
                    {
                        isdeleted = objBLL.DeleteItemDetails(selectedCategoryList);
                        gvItemList.DataSource = objBLL.GetItemDetails(Convert.ToInt32(ddlCategory.SelectedValue));
                        gvItemList.DataBind();

                        BindGridView();

                        if (isdeleted)
                        {
                            lblMessage.Text = "Deleted Successfully";
                        }
                        else
                        {
                            lblMessage.Text = "Error";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Please select item to be deleted";
                    }
                }
                

            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while deleting item details";
            }
            finally
            {

                objBLL = null;
            }

        }



        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }
        /// <summary>
        /// This method Binds the gridview 
        /// </summary>
        private void BindGridView()
        {
            lblMessage.Text = "";
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            gvItemList.DataSource = objBLL.GetItemDetails(Convert.ToInt32(ddlCategory.SelectedValue));
            gvItemList.DataBind();
        }
        /// <summary>
        /// This method redirects to the Home Page
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           // IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
           
            try
            {
                lblMessage.Text = "";
                bool isItemSelected = false;
                List<int> selectedItemList = new List<int>();
                GridViewRow gvItemRow = null;
                int itemId = 0;
                for (int i = 0; i < gvItemList.Rows.Count; i++)
                {
                    gvItemRow = gvItemList.Rows[i];
                    isItemSelected = (Boolean)((CheckBox)gvItemRow.FindControl("chkItem")).Checked;

                    if (isItemSelected)
                    {
                        //int itemId = 0;
                        itemId = Convert.ToInt32(gvItemRow.Cells[1].Text);
                        selectedItemList.Add(itemId);
                    }
                }
                if (selectedItemList.Count == 1)
                {
                    //int id = selectedItemList[0];
                    Response.Redirect("AddItem.aspx?ItemID="+selectedItemList[0]);//this.gvItemList.Rows[i].Cells[1]);
                }
                else
                {

                    lblMessage.Text = "Please select one item at a time";
                }


                //if (selectedItemList.Count == 1)
                //{
                //    Response.Redirect("addItem.aspx?ItemId = " + this.gvItemList.Rows[i].);
                //}
                //else
                //{
                //    lblMessage.Text = "Please select one item at a time";
                //}

            }
            catch (ThreadAbortException tx)
            {
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;

            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            gvItemList.DataSource = null;
            gvItemList.DataBind();
            ddlCategory.SelectedIndex = 0;
            lblMessage.Text = "";
        }

      
    }
}
