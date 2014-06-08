//File Description	: This is the Code Behind File for Checking Status of an Item
// ---------------------------------------------------------------------------------
//
// 	Change History
//	Date Modified		: May 1, 2013
//	Changed By		    : Suman Pradhan
//	Change Description   :Binded Drop Down List
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 7, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added Clear field function to the page.
/////////////////////////////////////////////////////////////////////////////////////
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
    public partial class IMCheckStatus : System.Web.UI.Page
    {
        /// <summary>
        /// This is the page load for Check status of an items
        /// </summary>
       
        protected void Page_Load(object sender, EventArgs e)
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();

            List<IItemCategory> itemList = objBLL.GetItemCategory();

            if (!IsPostBack)
            {
                ddlCategory.DataSource = itemList;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
            }
        }
        /// <summary>
        /// This method will check the status of an item.
        /// </summary>
       
        protected void btnCheckStatus_Click(object sender, EventArgs e)
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            showItemList.DataSource = objBLL.CheckStatusOfInventory(Convert.ToInt32(ddlCategory.SelectedValue));
            showItemList.DataBind();
        }
        /// <summary>
        /// This method redirects to home page.
        /// </summary>
       
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        
    }
}