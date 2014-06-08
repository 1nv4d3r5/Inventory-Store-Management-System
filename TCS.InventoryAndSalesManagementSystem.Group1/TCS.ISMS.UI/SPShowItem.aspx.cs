//File Description	: This is the Code Behind File for Showing Item
// ---------------------------------------------------------------------------------
//	Date Created		: Apr 26, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 27, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Binded Drop Down List
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 7, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added Cancel Button
//
/////////////////////////////////////////////////////////////////////////////////////////
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
    public partial class SPShowItem : System.Web.UI.Page
    {
        /// <summary>
        /// This is the Page Load method for showing list of items
        /// </summary>

        protected void Page_Load(object sender, EventArgs e)
        {
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();

            List<IItemCategory> itemList = objBLL.GetItemCategoryList();

            if (!IsPostBack)
            {
                ddlCategory.DataSource = itemList;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
            }
        }


        /// <summary>
        /// This method displays the item details based on category in the database
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvShowItemList.Visible = true;

            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            string name = string.Empty;
            if (!((ddlCategory.SelectedIndex != 0) && (txtItemName.Text != "")))
            {
                lblMessage.Text = "Please enter item name or select item category";

                if (!(ddlCategory.SelectedIndex == 0))
                {
                    lblMessage.Text = "";
                    gvShowItemList.DataSource = objBLL.GetItemList(Convert.ToInt32(ddlCategory.SelectedItem.Value));
                    gvShowItemList.DataBind();
                }
                else if (!(txtItemName.Text == ""))
                {
                 
                    lblMessage.Text = "";
                    name = txtItemName.Text;
                    gvShowItemList.DataSource = objBLL.SearchItembyName(name);
                    gvShowItemList.DataBind();
                }

                else if ((ddlCategory.SelectedIndex != 0) && (gvShowItemList.Rows.Count == 0))
                {
                    lblMessage.Text = "No items found in this category";
                }

                else
                {
                    gvShowItemList.Visible = false;

                }
            }
            
            else
            {
                name = txtItemName.Text;
                int categoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                gvShowItemList.DataSource = objBLL.GetItemList(categoryId, name);
                gvShowItemList.DataBind();
            }
        }

        /// <summary>
        /// This method redirects to home page
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        /// <summary>
        /// This method resets the drop down list
        /// </summary>
        
        /// <summary>
        /// Function to bind gridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvShowItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShowItemList.PageIndex = e.NewPageIndex;
            DataBind();
        }

        /// <summary>
        /// Function to bind the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataBind()
        {
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            string name = string.Empty;
            if (!((ddlCategory.SelectedIndex != 0) && (txtItemName.Text != "")))
            {


                if (!(ddlCategory.SelectedIndex == 0))
                {
                    gvShowItemList.DataSource = objBLL.GetItemList(Convert.ToInt32(ddlCategory.SelectedItem.Value));
                    gvShowItemList.DataBind();
                }
                else if (!(txtItemName.Text == ""))
                {
                    name = txtItemName.Text;
                    gvShowItemList.DataSource = objBLL.SearchItembyName(name);
                    gvShowItemList.DataBind();
                }

                else
                {
                    gvShowItemList.Visible = false;

                }
            }
            else
            {
                name = txtItemName.Text;
                int categoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                gvShowItemList.DataSource = objBLL.GetItemList(categoryId, name);
                gvShowItemList.DataBind();
            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtItemName.Text = "";
        }

        protected void txtItemName_TextChanged(object sender, EventArgs e)
        {
            ddlCategory.SelectedIndex = 0;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear_Field();
        }

        protected void Clear_Field()
        {
            txtItemName.Text = "";
            ddlCategory.SelectedIndex = 0;
            lblMessage.Text = "";
        }
    }
}

