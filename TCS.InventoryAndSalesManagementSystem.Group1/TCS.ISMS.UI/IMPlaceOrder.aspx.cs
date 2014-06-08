//File Description	: This is the Code Behind File for Place Order page
// ---------------------------------------------------------------------------------
//	Date Created		: May 2, 2013
//	Author			    : Amit Nadkarni, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Amit Nadkarni
//	Change Description  : Binded Drop Down Lists
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
using TCS.ISMS.BOFactory;


namespace TCS.ISMS.UI
{
    public partial class IMPlaceOrder : System.Web.UI.Page
    {
        //List<List<IVendor>> vendorListForDDL = new List<List<IVendor>>();

        static List<IItem> ItemList = new List<IItem>();
        /// <summary>
        /// This is the Page Load method for Place Order
        /// </summary>
         DateTime date = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
                gvItemDetailList.DataSource = objBLL.ViewRportGeneratedBySP();
                gvItemDetailList.DataBind();
               
                lblDisplayDate.Text = (date).ToString();
                ItemList.Clear();

            }
        }
        /// <summary>
        /// This method will bind the data.
        /// </summary>
        protected void DataBind()
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            gvItemDetailList.DataSource = objBLL.ViewRportGeneratedBySP();
            gvItemDetailList.DataBind();

        }

        /// <summary>
        /// This method redirects to the Home Page
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        /// <summary>
        /// This method displays the non available item details based on category in the database
        /// </summary>

       

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            bool isSelected = false;
            List<IItem> selectedItemList = new List<IItem>();
            List<int> selectedCat = new List<int>();


            for (int i = 0; i < gvItemDetailList.Rows.Count; i++)
            {
                GridViewRow gvItemRow = gvItemDetailList.Rows[i];

                isSelected = ((CheckBox)gvItemRow.FindControl("chkItemID")).Checked;
                if (isSelected)
                {
                    IItem billItem = ViewItemBOFactory.CreateItemobject();
                    billItem.ItemID = Convert.ToInt32(gvItemRow.Cells[1].Text);
                    billItem.ItemName = (gvItemRow.Cells[2].Text);
                    billItem.ItemPrice = Convert.ToDouble(gvItemRow.Cells[4].Text);
                    billItem.ItemCategory = Convert.ToInt32(gvItemRow.Cells[3].Text);
                    //vendorListForDDL.Add(objBLL.GetVendorDetailsCategoryWise(billItem.ItemCategory));

                    selectedItemList.Add(billItem);

                }

            }


            foreach (IItem item in selectedItemList)
            {
                IItem items = ItemList.Find(x => (x.ItemID == item.ItemID));
                if (ItemList.Contains(items))
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Item Already Selected";
                    continue;
                }

                else
                {
                    lblMessage.Visible = false ;
                    ItemList.Add(item); }

            }
            gvShowItems.DataSource = ItemList;
            gvShowItems.DataBind();
            //  gvshowItems.Controls.AddAt(5, );
            btnPlaceOrder.Visible = true;
            btnReset.Visible = true;
            btnDelete.Visible = true;
            btnCalcAmnt.Visible = true;
            btnCancel.Visible = true;
            if (gvShowItems.Rows.Count == 0)
            {
                btnPlaceOrder.Visible = false;
                btnReset.Visible = false;
                btnDelete.Visible = false;
                btnCalcAmnt.Visible = false;
                btnCancel.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "No Items Available";
            }

        }

        protected void gvItemDetailList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItemDetailList.PageIndex = e.NewPageIndex;
            DataBind();
        }

        /// <summary>
        /// This method will bind the gridview
        /// </summary>
        protected void OnGridViewDataBinding(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //skip header row
            {
                IItem objItem = (IItem)e.Row.DataItem;

                IInventoryManagerBLL objInventoryManagerBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
                List<IVendor> objVendorColl = objInventoryManagerBLL.GetVendorDetailsCategoryWise(objItem.ItemCategory);

                DropDownList drpVendor = (DropDownList)e.Row.FindControl("ddlVendor");

                if (drpVendor != null)
                {
                    drpVendor.DataSource = objVendorColl;
                    drpVendor.DataTextField = "NameOfContactPerson";
                    drpVendor.DataValueField = "VendorId";
                    drpVendor.DataBind();
                }
            }
        }

        /// <summary>
        /// This method will redirects to same page and clear the lists.
        /// </summary>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ItemList.Clear();
            Response.Redirect("IMPlaceOrder.aspx");
        }
        /// <summary>
        /// This method will remove items from gridview.
        /// </summary>
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            bool isSelected = false;
            List<int> selectedItemList = new List<int>();
            for (int i = 0; i < gvShowItems.Rows.Count; i++)
            {
                GridViewRow gvItemRow = gvShowItems.Rows[i];
                isSelected = ((CheckBox)gvItemRow.FindControl("chkItemID")).Checked;
                if (isSelected)
                {
                    int itemId;
                    itemId = Convert.ToInt32(gvItemRow.Cells[1].Text);
                    selectedItemList.Add(itemId);

                }
                foreach (int selectedItem in selectedItemList)
                {
                    IItem item = ViewItemBOFactory.CreateItemobject();

                    item = ItemList.Find(x => (x.ItemID == selectedItem));
                    ItemList.Remove(item);

                }


            } gvShowItems.DataSource = ItemList;
            gvShowItems.DataBind();

            if (gvShowItems.Rows.Count == 0)
            {
                btnPlaceOrder.Visible = false;
                btnReset.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = false;
                btnCalcAmnt.Visible = false;
                lbltotalAmount.Visible = false;
                lbltotalAmnt.Visible = false;
            }
        }
        /// <summary>
        /// This method will calculate the bill generated.
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {

            double totalAmount = 0;
            for (int j = 0; j < gvShowItems.Rows.Count; j++)
            {
                GridViewRow gvBillsItemRow = gvShowItems.Rows[j];

                ItemList[j].ItemQuantity = Convert.ToInt32(((TextBox)(gvBillsItemRow.FindControl("txtOrderQuantity"))).Text);
                double price = Convert.ToDouble(gvBillsItemRow.Cells[4].Text);


                totalAmount = totalAmount + ItemList[j].ItemQuantity * price;



            }

            lbltotalAmnt.Text = totalAmount.ToString();
            lbltotalAmount.Visible = true;
            lbltotalAmnt.Visible = true;
        }
        /// <summary>
        /// This method will place an order for the selected item.
        /// </summary>
        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            IInventoryManagerBLL objInventoryManagerBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
          //  Iorder objOrder = BOFactory.OrderBOFactory.CreateOrderObject();
            //for (int j = 0; j < gvshowItems.Rows.Count; j++)
            //objOrder.OrderDate = date;

            bool isPlaced = false;
            List<Iorder> lstOrders = new List<Iorder>();
            List<IOrderedItems> lstOrderItems = new List<IOrderedItems>();

            try
            {
                for (int i = 0; i < gvShowItems.Rows.Count; i++)
                {
                    GridViewRow gvEmployeeRow = gvShowItems.Rows[i];

                    Iorder objOrders = OrderBOFactory.CreateOrderObject();
                    objOrders.VendorId = Convert.ToInt32(((DropDownList)gvEmployeeRow.FindControl("ddlVendor")).SelectedItem.Value);                    //objOrders.OrderDate = (gvEmployeeRow.Cells[2].Text);
                    objOrders.OrderDate = date;
                    //objOrders. = (gvEmployeeRow.Cells[3].Text);

                    
                    //objEmployee.MobileNumber = Convert.ToInt64(gvEmployeeRow.Cells[5].Text);
                       lstOrders.Add(objOrders);

                }



                for (int i = 0; i < gvShowItems.Rows.Count; i++)
                {
                    GridViewRow gvEmployeeRow = gvShowItems.Rows[i];

                    IOrderedItems objOrderItems = OrderedItemsBOFactory.CreateOrderedItemsObject();
                    
                    objOrderItems.ItemCategory=Convert.ToInt32(gvEmployeeRow.Cells[3].Text);
                    objOrderItems.ItemId = Convert.ToInt32(gvEmployeeRow.Cells[1].Text);
                    objOrderItems.ItemName = gvEmployeeRow.Cells[2].Text;
                    objOrderItems.ItemQuantity = Convert.ToInt32(((TextBox)gvEmployeeRow.FindControl("txtOrderQuantity")).Text);
                    
                    //objOrders. = (gvEmployeeRow.Cells[3].Text);


                    //objEmployee.MobileNumber = Convert.ToInt64(gvEmployeeRow.Cells[5].Text);

                   lstOrderItems.Add(objOrderItems);
                    

                }
                isPlaced=objInventoryManagerBLL.PlaceOrder(lstOrders, lstOrderItems);
               
                if (isPlaced)
                {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Ordered Placed Successfully";
                    
 
                }

                //List<Iorder> list = new List<Iorder>();
                //list = lstOrders.Distinct().ToList();

                //for (int i = 0; i < list.Count;i++ )
                //{
                //    List<IOrderedItems> orderList = new List<IOrderedItems>();
                //    foreach (IOrderedItems item in lstOrderItems)
                //    { 
                    
                //    }
                //}


                //objEmployee.RoleId =Convert.ToInt32(ddlNewRole.SelectedValue);

            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while updating Employee details";
            }
            finally
            {
                //objOrder = null;
                objInventoryManagerBLL = null;
            }


        }
        /// <summary>
        /// This method redirects to the Home Page
        /// </summary>
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}
