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
    public partial class SPReturnReceipt : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmitGridView.Visible = false;
            btnEdit.Visible = false;
            if (!IsPostBack)
            {
                btnCancel.Visible = false;
                btnSubmitGridView.Visible = false;
                btnSubmit.Visible = true;
            }
        }
        /// <summary>
        /// This method displays the bill details on entering the bill number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">returns void</param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            btnEdit.Visible = true;
            btnCalculate.Visible = false;
            btnCancel.Visible = true;
            //if (!IsPostBack)
            {
                IBillDetails objBillDetails = BillDetailsBOFactory.CreateBillDetailsObject();
                IOrderedItems objItem = OrderedItemsBOFactory.CreateOrderedItemsObject();
                ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
                int billNumber = Convert.ToInt32(txtBillNo.Text);
                List<IBillDetails> lstBillDetails = objBLL.GetBillDetails(billNumber);
                if (lstBillDetails.Count == 0)
                {
                    lblMessage.Text = "No Bill Found";
                }
                else
                {
                    gvshowBillItems.DataSource = lstBillDetails;
                    gvshowBillItems.DataBind();
                }
            }
        }
        /// <summary>
        /// This method will provide to edit the fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">returns void</param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnCancel.Visible = true;
            btnSubmitGridView.Visible = true;
            btnCalculate.Visible = true;
            IAdminBLL objBLL = AdminBLLFactory.CreateAdminBLLObject();
            gvshowBillItems.Visible = false;
            List<IBillDetails> selectedItemList1 = new List<IBillDetails>();

            try
            {
                bool isItemSelected = false;
                //bool isDeleted = false;



                //loop through the grid to find the selected item
                for (int i = 0; i < gvshowBillItems.Rows.Count; i++)
                {
                    GridViewRow gvItemRow = gvshowBillItems.Rows[i];
                    isItemSelected = (Boolean)((CheckBox)gvItemRow.FindControl("chkSelect")).Checked;
                    if (isItemSelected)
                    {
                        IBillDetails objBillDetails = BillDetailsBOFactory.CreateBillDetailsObject();
                        objBillDetails.ItemID = Convert.ToInt32(gvItemRow.Cells[1].Text);
                        objBillDetails.ItemName = Convert.ToString(gvItemRow.Cells[2].Text);
                        //objBillDetails.BillNumber = Convert.ToInt32(gvItemRow.Cells[3].Text);
                        objBillDetails.QuantityPurchased = Convert.ToInt32(gvItemRow.Cells[4].Text);

                        objBillDetails.LineTotal = Convert.ToInt32(gvItemRow.Cells[3].Text);
                        //objBillDetails.BillNumber = Convert.ToInt32(gvItemRow.Cells[1].Text);
                        //objBillDetails.BillNumber = Convert.ToInt32(gvItemRow.Cells[1].Text);



                        selectedItemList1.Add(objBillDetails);
                    }
                }

                gvSelectedItems.DataSource = selectedItemList1;
                gvSelectedItems.DataBind();

                if (selectedItemList1.Count == 0)
                    lblMessage.Text = "Please select Items to be returned";
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



            //ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            //int billNumber = Convert.ToInt32(txtBillNo.Text);
            //gvSelectedItems.DataSource = objBLL.GetBillDetails(billNumber);
            //gvSelectedItems.DataBind();
        }

        /// <summary>
        /// This method will update the details of return items to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">returns void</param>
        protected void btnSubmitGridView_Click(object sender, EventArgs e)
        {

            IBillDetails objBillDetails = BillDetailsBOFactory.CreateBillDetailsObject();
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();

            try
            {


                for (int j = 0; j < gvSelectedItems.Rows.Count; j++)
                {

                    GridViewRow gvBillsItemRow = gvSelectedItems.Rows[j];
                    objBillDetails.BillNumber = Convert.ToInt32(txtBillNo.Text);
                    objBillDetails.ItemID = Convert.ToInt32(gvBillsItemRow.Cells[0].Text);
                    objBillDetails.QuantityReturned = Convert.ToInt32(((TextBox)(gvBillsItemRow.FindControl("txtReturnedItemQuantity"))).Text);
                    objBillDetails.LineTotalofReturnedItems = Convert.ToInt32(((Label)(gvBillsItemRow.FindControl("txtReturnTotal"))).Text);
                    objBillDetails.Remarks = Convert.ToString(((TextBox)(gvBillsItemRow.FindControl("txtRemarks"))).Text);
                    
                    objBLL.TakeBackSoldItems(objBillDetails);
                    lblMessage.Text = "Details updated";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred while returning Items";
            }
            finally
            {
                objBillDetails = null;
                objBLL = null;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            IBillDetails objBillDetails = BillDetailsBOFactory.CreateBillDetailsObject();


            for (int j = 0; j < gvSelectedItems.Rows.Count; j++)
            {

                GridViewRow gvBillsItemRow = gvSelectedItems.Rows[j];

                objBillDetails.QuantityPurchased = Convert.ToInt32(gvBillsItemRow.Cells[3].Text);
                objBillDetails.QuantityReturned = Convert.ToInt32(((TextBox)(gvBillsItemRow.FindControl("txtReturnedItemQuantity"))).Text);
                
               

                if (objBillDetails.QuantityPurchased < objBillDetails.QuantityReturned)
                {
                    lblMessage.Text = "Return Quantity can not be greater than purchased quantity";
                    break;
                }
                
                //obj
                objBillDetails.LineTotal = Convert.ToInt32(gvBillsItemRow.Cells[2].Text);
                objBillDetails.LineTotalofReturnedItems = (objBillDetails.LineTotal/ objBillDetails.QuantityPurchased) *objBillDetails.QuantityReturned;
                objBillDetails.Remarks = Convert.ToString(((TextBox)(gvBillsItemRow.FindControl("txtRemarks"))).Text);
                gvBillsItemRow.Cells[5].Text = objBillDetails.LineTotalofReturnedItems.ToString();
            }

            btnSubmitGridView.Visible = true;
        }
    }
}
