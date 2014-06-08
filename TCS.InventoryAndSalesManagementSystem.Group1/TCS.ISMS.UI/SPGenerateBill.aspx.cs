
///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : Generate bill code behind page
// ---------------------------------------------------------------------------------
// Date Created  : Apr 25, 2013
// Author   : Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
//  Change History : <List of Dev(s) making the change> 
// Change Description# : Added textboxes, buttons, edited gridview. 
// Changed By  : Sandeep Kothawade
// Date Modified  : Apr 29, 2013
// Change Description# : <Change description in Details>  
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
using TCS.ISMS.Types;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.BOFactory;

namespace TCS.ISMS.UI
{
    public partial class SPGenerateBill : System.Web.UI.Page
    {

         static List<IItem> billItemList = new List<IItem>();
         static int customerID = 1;
       // static List<IItem> billsItems = new List<IItem>();
         /// <summary>
         /// This is the page load method for generating Bill.
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

           
                ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();

                List<IItemCategory> itemList = objBLL.GetItemCategoryList();
                DateTime date = DateTime.Now;

                if (!IsPostBack)
                {

                    int salesPersonId = Convert.ToInt32(Session["userID"]);

                    lblBillsDate.Text = (date).ToString();
                    lblSalesPersonID.Text = salesPersonId.ToString();
                    lblBillNumberLabel.Visible = false;
                    btnAddItemToBill.Visible = false;
                    btnDelete.Visible = false;
                    btnCalcBill.Visible = false;
                    lblTotalPrice.Visible = false;
                    lblTotalPriceLabel.Visible = false;
                    lblMoneyIn.Visible = false;
                    txtMoneyIn.Visible = false;
                    lblReturnAmountLabel.Visible = false;
                    lblReturnAmount.Visible = false;
                    btnGenerateButton.Visible = false;
                }
            if (!IsPostBack)
            {
                ddlCategory.DataSource = itemList;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
            }
        }

        
        /// <summary>
        /// Function to search items from inventory according to values inserted or category selected or both
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            lblMessage1.Text = "";
            btnAddItemToBill.Visible = false;
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
           
           
            string name=string.Empty;
            if (!((ddlCategory.SelectedIndex != 0) && (txtItemName.Text != "")))
            {

                
                if (!(ddlCategory.SelectedIndex == 0))
                {
                    List<IItem> lstItems = objBLL.GetItemList(Convert.ToInt32(ddlCategory.SelectedItem.Value));
                    foreach (IItem item in lstItems)
                    {
                        if (item.ItemQuantity == 0)
                            lstItems.Remove(item);
                    }
                   
                     if (lstItems.Count == 0)
                    {
                        lblMessage1.Text = "No Items In this Category";
                        btnAddItemToBill.Visible = false;
                    }
                    gvshowItemList.DataSource = lstItems;
                    gvshowItemList.DataBind();
                    btnAddItemToBill.Visible = true;
                }
                else if (!(txtItemName.Text == ""))
                {
                    name = txtItemName.Text;
                    gvshowItemList.DataSource = objBLL.SearchItembyName(name);
                    gvshowItemList.DataBind();
                    btnAddItemToBill.Visible = true;
                }
                else
                {
                    lblErrorMsg.Text = "Please Select Category/Enter Name ";
                }
            }
            else
            {
                btnAddItemToBill.Visible = true; 
                name = txtItemName.Text;
                int categoryId=Convert.ToInt32(ddlCategory.SelectedItem.Value);
                gvshowItemList.DataSource = objBLL.GetItemList(categoryId,name);
                gvshowItemList.DataBind();
            }
        }


        /// <summary>
        /// Function to add selected item(s) to bill list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddItemToBill_click(object sender, EventArgs e)
        {
            btnAddItemToBill.Visible = true;
            bool isSelected = false;
            List<IItem> selectedItemList=new List<IItem>(); 
            for (int i = 0; i < gvshowItemList.Rows.Count ; i++)
            {
                GridViewRow gvItemRow = gvshowItemList.Rows[i];
                isSelected = ((CheckBox)gvItemRow.FindControl("chkItemID")).Checked;
                if (isSelected)
                {
                    IItem billItem = ViewItemBOFactory.CreateItemobject();
                    billItem.ItemID = Convert.ToInt32(gvItemRow.Cells[1].Text);
                    billItem.ItemName = (gvItemRow.Cells[2].Text);
                    billItem.ItemQuantity = Convert.ToInt32(gvItemRow.Cells[3].Text);
                    billItem.ItemDiscount = Convert.ToInt32(gvItemRow.Cells[5].Text);
                    //billItem.ItemCategory = Convert.ToInt32(gvItemRow.FindControl("Category"));
                    
                    
                   

                    billItem.ItemPrice = Convert.ToDouble(gvshowItemList.Rows[i].Cells[4].Text);
                 
                 
                    selectedItemList.Add(billItem);
                }

            }
           



                foreach (IItem item in selectedItemList)
                {
                    IItem items = billItemList.Find(x => (x.ItemID == item.ItemID));
                    if (billItemList.Contains(items))
                    {
                       
                        continue;
                    }

                    else
                    {
                       
                        billItemList.Add(item);
                    }

                }

            gvBillWindow.DataSource = billItemList;
            gvBillWindow.DataBind();
            btnDelete.Visible = true;
            btnCalcBill.Visible = true;

           
        }

        /// <summary>
        /// Function to reset the billlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReset_Click(object sender, EventArgs e)
        {

            Response.Redirect("SPGenerateBill.aspx");
           
        }

        /// <summary>
        /// Function to generate bill
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GenerateButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(lblTotalPrice.Text) == 0)
                lblErrorMsg.Text = "Can not generate Bill for zero Bill amount";

            else
            {
                gvshowItemList.EnableViewState = false;
                ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();

                ICustomerBill custBill = CustomerBillBOFactory.CreateCustomerBillObject();

                DateTime date = DateTime.Now;
                lblBillsDate.Text = (date).ToString();

               
                custBill.BillDate = date;
                custBill.BoughtItemList = billItemList;
                //customerID++;
                custBill.CustomerId = customerID;
                custBill.CustomerName = txtCustomerName.Text;
                custBill.BillStatus = "ok";
                custBill.EmployeeId = Convert.ToInt32(lblSalesPersonID.Text);
                custBill.MoneyIn = Convert.ToInt32(txtMoneyIn.Text);
                custBill.MoneyOut = 0;
                custBill.TotalBillAmount = Convert.ToDouble(lblTotalPrice.Text);
                custBill.TotalMoneyReturned = Convert.ToInt32(lblReturnAmount.Text);


                objBLL.CreateBill(custBill);
                lblBillNumberLabel.Visible = true;
                lblBillNumber.Text = (custBill.BillNumber).ToString();
             
                clearAllFields();
            }
        }

     
        /// <summary>
        /// Function to calculate the total bill amount (including discount) of items in bill list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CalculateTotal(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            lblMessage.Text = "";
            btnDelete.Visible = true;
            btnCalcBill.Visible = true;
            btnAddItemToBill.Visible = true; 
            lblTotalPrice.Visible = true;
            lblTotalPriceLabel.Visible = true;
            lblMoneyIn.Visible = true;
            txtMoneyIn.Visible = true;
            lblReturnAmountLabel.Visible = true;
            lblReturnAmount.Visible = true;
            btnGenerateButton.Visible = true;
            lblTotalPriceLabel.Visible = true;

            bool isNotAllowed = false;
            double totalAmount = 0;
            for (int j = 0; j < gvBillWindow.Rows.Count; j++)
            {
                GridViewRow gvBillsItemRow = gvBillWindow.Rows[j];
                //IItem item = ViewItemBOFactory.CreateItemobject();
                int quantity = billItemList[j].ItemQuantity;
                billItemList[j].ItemQuantity = Convert.ToInt32(((TextBox)(gvBillsItemRow.FindControl("txtOrderQuantity"))).Text);
                double price = Convert.ToDouble(gvBillsItemRow.Cells[3].Text);
                //int quantity = Convert.ToInt32(gvBillsItemRow.Cells[3].Text);
                double discount = Convert.ToDouble(gvBillsItemRow.Cells[4].Text);

                totalAmount = totalAmount + billItemList[j].ItemQuantity * (price - (price * (discount / 100)));
                if (quantity < billItemList[j].ItemQuantity)
                {
                    lblMessage.Text = "Quantity ordered can not be grater than available quantity";
                    isNotAllowed = true;
                    break;
                    
                }

                //item.ItemID = Convert.ToInt32(gvBillsItemRow.Cells[1].Text);
                //item.ItemName = (gvBillsItemRow.Cells[2].Text).ToString();
                //item.ItemQuantity = quantity;
                //item.ItemPrice = price;
                //item.ItemDiscount = (Int32)discount;

                //  billsItems.Add(item);

            }
            if(!isNotAllowed)
            lblTotalPrice.Text = totalAmount.ToString();
            if (totalAmount == 0)
            {
                lblErrorMsg.Text = "No items in the cart";
            }
        }

        /// <summary>
        /// Function to display the amount to be returned to the customer when customer makes payment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtMoneyIn_TextChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            double moneyIni=(double)(Convert.ToInt32(txtMoneyIn.Text));
            double totalP=Convert.ToDouble(lblTotalPrice.Text);
            if (moneyIni < totalP)
            {
                lblErrorMsg.Text = "You can not pay less than total bill amount";
                btnGenerateButton.Visible = false;
            }
            else
            {
                btnGenerateButton.Visible = true;
                lblReturnAmount.Text = "" + (Convert.ToDouble(txtMoneyIn.Text) - Convert.ToDouble(lblTotalPrice.Text)).ToString();
                btnDelete.Visible = true;
                btnCalcBill.Visible = true;
                btnAddItemToBill.Visible = true;
                lblTotalPriceLabel.Visible = true;
                lblTotalPrice.Visible = true;
                lblMoneyIn.Visible = true;
                txtMoneyIn.Visible = true;
                lblReturnAmount.Visible = true;
                lblReturnAmount.Visible = true;
                btnGenerateButton.Visible = true;
            }
        }

        /// <summary>
        /// Function to delete any selected item(s) from the bill list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            bool isSelected = false;
            List<int> selectedItemList = new List<int>();
            for (int i = 0; i <  gvBillWindow.Rows.Count; i++) 
            {
                GridViewRow gvItemRow = gvBillWindow.Rows[i];
                isSelected = ((CheckBox)gvItemRow.FindControl("chkItemID")).Checked;
                if (isSelected)
                {
                    int itemId;
                    itemId = Convert.ToInt32(gvItemRow.Cells[1].Text);
                    selectedItemList.Add(itemId);

                }
                foreach (int selectedItem in selectedItemList)
                {
                     IItem item=ViewItemBOFactory.CreateItemobject();

                        item = billItemList.Find( x => (x.ItemID==selectedItem) ) ;
                        billItemList.Remove(item);
                      
                }


            } gvBillWindow.DataSource = billItemList;
            gvBillWindow.DataBind();
        }

        /// <summary>
        /// Function to redirect user to his home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelButton_Click(object sender, EventArgs e)
        {
            billItemList.Clear();
            Response.Redirect("HomePage.aspx");
        }

        protected void clearAllFields()
        {
            txtCustomerName.Text = "";
            txtItemName.Text = "";
            txtMoneyIn.Text = "";
            lblReturnAmount.Text = "";
            lblTotalPrice.Text = "";
            billItemList.Clear();
            lblMessage1.Text = "";
            gvshowItemList.EnableViewState = false;
            gvBillWindow.EnableViewState = false;
            lblMessage.Text = "";
           
            ddlCategory.SelectedIndex = 0;
        }

        //protected void txtReturnAmount_TextChanged(object sender, EventArgs e)
        //{
        //    btnDelete.Visible = true;
        //    btnCalcBill.Visible = true;
        //    btnAddItemToBill.Visible = true;
        //    lblTotalPriceLabel.Visible = true;
        //    lblTotalPriceLabel.Visible = true;
        //    lblMoneyIn.Visible = true;
        //    txtMoneyIn.Visible = true;
        //    lblReturnAmount.Visible = true;
        //    txtReturnAmount.Visible = true;
        //    btnGenerateButton.Visible = true;
        //}
     

       

      
    }
}