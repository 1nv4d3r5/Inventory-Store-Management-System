

///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : Manage vendor code behind page
// ---------------------------------------------------------------------------------
// Date Created  : Apr 25, 2013
// Author   :Amit Nadkarni, Tata Consultancy Services
// ---------------------------------------------------------------------------------
//  Change History : <List of Dev(s) making the change> 
//  Change Description# : <Change description in Details>  
// Changed By  : <Person Changing>
// Date Modified  : <Modification Date>
//
///////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.Types;

namespace TCS.ISMS.UI
{
    public partial class IMViewVendorList2 : System.Web.UI.Page
    {   /// <summary>
        /// This is the page load method for view vendor list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
                gvVendorDetailList.DataSource = objBLL.GetVendorDetails();
                gvVendorDetailList.DataBind();

            }
        }
        /// <summary>
        /// Function to bind the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataBind()
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            gvVendorDetailList.DataSource = objBLL.GetVendorDetails();
            gvVendorDetailList.DataBind();
 
        }

        /// <summary>
        /// Function to add a vendor .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddVendor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewVendor.aspx");
        }
        /// <summary>
        /// Function to redirect to home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        /// <summary>
        /// Function to delete a vendor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelVendor_Click(object sender, EventArgs e)
        {
            bool isDeleted = false;
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            try
            {
                bool isVendorSelected = false;
                List<int> selectedItemList1 = new List<int>();


                //loop through the grid to find the selected item
                for (int i = 0; i < gvVendorDetailList.Rows.Count; i++)
                {
                    GridViewRow gvVendorRow = gvVendorDetailList.Rows[i];
                    isVendorSelected = ((CheckBox)gvVendorRow.FindControl("chkVendorID")).Checked;
                    if (isVendorSelected)
                    {
                        selectedItemList1.Add(Convert.ToInt32(gvVendorDetailList.Rows[i].Cells[1].Text));
                    }
                }

                isDeleted= objBLL.DeleteVendor(selectedItemList1);
                gvVendorDetailList.DataSource = objBLL.GetVendorDetails();
                gvVendorDetailList.DataBind();

                if (isDeleted)
                { lblMessage.Text = "Deleted Successfully";
                lblMessage.Visible = true;
                }
                
                 
                
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;

            }
        }

        /// <summary>
        /// Function to update the selected vendor details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdateVendor_Click(object sender, EventArgs e)
        {



            bool isItemSelected = false;
            List<int> selectedItemList = new List<int>();
            GridViewRow gvItemRow = null;
            int vendorId = 0;
            for (int i = 0; i < gvVendorDetailList.Rows.Count; i++)
            {
                gvItemRow = gvVendorDetailList.Rows[i];
                isItemSelected = (Boolean)((CheckBox)gvItemRow.FindControl("chkVendorID")).Checked;                
                if (isItemSelected)
                {
                    //int itemId = 0;
                    vendorId = Convert.ToInt32(gvItemRow.Cells[1].Text);
                    selectedItemList.Add(vendorId);
                }
            }
            if (selectedItemList.Count == 1)
            {
                Response.Redirect("AddNewVendor.aspx?VendorId=" + selectedItemList[0]); //this.gvItemList.Rows[i].Cells[1]);
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

        /// <summary>
        /// Function to bind gridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvVendorDetailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVendorDetailList.PageIndex = e.NewPageIndex;
            DataBind();
        }
            
        }
    }

