//File Description	: This is the Code Behind File for Cancel Bill
// ---------------------------------------------------------------------------------
//	Date Created		:2 May, 2013
//	Author			    :Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 6 May, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Edited Cancel Bill Button coding
// 
/////////////////////////////////////////////////////////////////////////////////////

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
    public partial class SPCancelBill : System.Web.UI.Page
    {
        static List<ICustomerBill> BillList = new List<ICustomerBill>();


        /// <summary>
        /// This method is used to search Bill Number
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            lblMessage.Text = "";
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            gvShowBillList.DataSource = objBLL.SearchBillDetails(Convert.ToInt32(txtBillNumber.Text));
            gvShowBillList.DataBind();
            if (txtBillNumber.MaxLength < 4)
            {
                lblErrorMessage.Text = "Invalid Bill Number";
            }
            else if (Convert.ToInt32(txtBillNumber.Text) >= 1000 && gvShowBillList.Rows.Count == 0)
            {
                lblErrorMessage.Text = "Bill Not Found";
            }
            else if (gvShowBillList.Rows.Count != 0)
            {
                btnCancel.Visible = true;
                btnReset.Visible = true;
            }
            
        }

        /// <summary>
        /// This method resets the fields to be entered by user by calling Clear_Field function
        /// </summary>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            //BillList.Clear();
            //Response.Redirect("SPCancelBill.aspx");
            Clear_Field();
        }

        /// <summary>
        /// This method cancels the searched bill
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
           // bool isBillSelected = false;
            bool isDeleted = false;
            
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            ICustomerBill custBill = CustomerBillBOFactory.CreateCustomerBillObject();
            try
            {
                int selectedBill = 0;
                custBill.BillNumber = Convert.ToInt32(txtBillNumber.Text);
                
                GridViewRow gvItem = gvShowBillList.Rows[0];
                //isBillSelected = ((RadioButton)gvItem.FindControl("rdbBillNumber")).Checked;
               // if (isBillSelected)
                //{
                    selectedBill.Equals(Convert.ToInt32(gvShowBillList.Rows[0].Cells[1].Text));
                //}
                custBill.Remarks = ((TextBox)gvItem.FindControl("txtRemark")).Text;
                if (custBill.BillStatus == "ok")
                {
                    isDeleted = objBLL.CancelBill(custBill);
                    gvShowBillList.DataBind();
                    if (isDeleted)
                    {
                        lblMessage.Text = "Cancelled Successfully";
                    }
                    else
                    {
                        lblErrorMessage.Text = "Error";
                    }

                }
                else
                {
                    lblErrorMessage.Text = "Bill already cancelled";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "An error occurred while cancelling bill details";
            }
            finally
            {

                objBLL = null;
            }
        }


        /// <summary>
        /// This method clears all fields that are needed to be entered by user
        /// </summary>
        protected void Clear_Field()
        {
            txtBillNumber.Text = "";
            lblMessage.Text = "";
            lblErrorMessage.Text = "";
            gvShowBillList.DataSource = null;
            gvShowBillList.DataBind();
            btnCancel.Visible = false;
            btnReset.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
    }
}
