//File Description	: This is the Code Behind File for Adding an Item
// ---------------------------------------------------------------------------------
//	Date Created		:Apr 19, 2013
//	Author			    :Suman Pradhan, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 25, 2013
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
using TCS.ISMS.BLLFactory;
using TCS.ISMS.BOFactory;
using TCS.ISMS.Types;

namespace TCS.ISMS.UI
{
    public partial class AddItem : System.Web.UI.Page
    {
        /// <summary>
        /// This is the Page Load method for adding an item
        /// </summary>
       protected void Page_Load(object sender, EventArgs e)
        {
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();


            int itemId = Convert.ToInt32(Request.QueryString["ItemID"]);
            if (!IsPostBack)
            {
                List<IItemCategory> itemList = objBLL.GetCategoryList();
                
                ddlCategory.DataSource = itemList;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                if (itemId != 0)
                {

                    //itemId = Convert.ToInt32(Request.QueryString["ItemID"]);
                    IItem objItem = ViewItemBOFactory.CreateItemobject();
                    // IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
                    objItem = objBLL.GetItemByItemId(itemId);
                    objItem.ItemID = itemId;

                    txtItemName.Text = Convert.ToString(objItem.ItemName);
                    ddlCategory.SelectedValue = Convert.ToString(objItem.ItemCategory);
                    txtItemPrice.Text = Convert.ToString(objItem.ItemPrice);
                    txtItemQuantity.Text = Convert.ToString(objItem.ItemQuantity);
                    txtItemDiscount.Text = Convert.ToString(objItem.ItemDiscount);

                    //objBLL.UpdateItemDetails(objItem);

                }
             
         
                lblNewCat.Visible = false;
                btnCat.Visible = false;
                txtnewCat.Visible = false;
            }
            /*else
            {
                int itemId = Convert.ToInt32(tx);
            }*/
        

        }
       /// <summary>
       /// This method saves the Item details in the database
       /// </summary>
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            IItem objItem = BOFactory.ViewItemBOFactory.CreateItemobject();
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            int itemId = Convert.ToInt32(Request.QueryString["ItemID"]);
            try
            {
                if (itemId != 0)
                {
                    objItem.ItemName = txtItemName.Text;
                    objItem.ItemID = itemId;
                    objItem.ItemCategory = Convert.ToInt32(ddlCategory.SelectedValue);
                    objItem.ItemQuantity = Convert.ToInt32(txtItemQuantity.Text);
                    //objItem.ItemClosingCount = Convert.ToInt32(txtItemClosingCount.Text);
                    objItem.ItemDiscount = Convert.ToInt32(txtItemDiscount.Text);
                    objItem.ItemPrice = Convert.ToInt32(txtItemPrice.Text);

                    bool update = objBLL.UpdateItemDetails(objItem);
                    lblShowItemId.Text = "Item Details updated successfully.";
                }
                else if (Convert.ToInt32(txtItemDiscount.Text) > 50)
                {
                    lblShowItemId.Text = "";
                    lblShowMessage.Text = "Discount cannot be more than 50%";
                }
                else
                {
                    lblShowMessage.Text = "";
                    objItem.ItemName = txtItemName.Text;
                    objItem.ItemCategory = Convert.ToInt32(ddlCategory.SelectedValue);
                    objItem.ItemQuantity = Convert.ToInt32(txtItemQuantity.Text);
                    //objItem.ItemClosingCount = Convert.ToInt32(txtItemClosingCount.Text);
                    objItem.ItemDiscount = Convert.ToInt32(txtItemDiscount.Text);
                    objItem.ItemPrice = Convert.ToInt32(txtItemPrice.Text);
                    bool itemID = objBLL.AddItemDetails(objItem);
                    lblShowItemId.Text = "Item details saved successfully. The Item ID is " + objItem.ItemID;

                }

            }
            catch (Exception ex)
            {
                lblShowItemId.Text = "An error occurred while saving item details";
            }
            finally
            {
                objItem = null;
                objBLL = null;
            }
       
        }
        /// <summary>
        /// This method resets the page 
        /// </summary>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            lblShowItemId.Text = "";
            lblShowMessage.Text = "";
            Clear_Field();
        }

        protected void Clear_Field()
        {
            txtItemName.Text = "";
            ddlCategory.SelectedIndex = 0;
            txtItemPrice.Text = "";
            txtItemQuantity.Text = "";
            //txtItemClosingCount.Text = "";
            txtItemDiscount.Text = "";
        }
        
        /// <summary>
        /// This method redirects to the Home Page
        /// </summary>
        
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

     

        protected void btnCat_Click(object sender, EventArgs e)
        {
            string categoryName = txtnewCat.Text;
            IAdminBLL objBLL = BLLFactory.AdminBLLFactory.CreateAdminBLLObject();
            objBLL.SaveCategory(categoryName);

            lblNewCat.Visible = false;
            btnCat.Visible = false;
            txtnewCat.Visible = false;
            List<IItemCategory> itemList = objBLL.GetCategoryList();

            ddlCategory.DataSource = itemList;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();



        }

        protected void ddlCategory_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex==1)
            {
                lblNewCat.Visible = true;
                btnCat.Visible = true;
                txtnewCat.Visible = true;
            }
            else
            {
                lblNewCat.Visible = false;
                btnCat.Visible = false;
                txtnewCat.Visible = false;
            }
        }

        protected void txtItemDiscount_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtItemDiscount.Text) > 50)
            {
                lblShowItemId.Text = "";
                lblShowMessage.Text = "Discount cannot be more than 50% ";
            }

        }
    }
}
