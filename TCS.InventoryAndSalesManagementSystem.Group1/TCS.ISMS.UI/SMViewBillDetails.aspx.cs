///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : This is the code behind page of View Bill Details
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Binded Data to the page.
// Changed By          : Susmita Rana
// Date Modified       : May 1, 2013
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Added Ajax Controls to the page.
// Changed By          : Susmita Rana
// Date Modified       : May 7, 2013
// 
////////////////////////////////////////////////////////////////////////////////////////////////

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
    public partial class SMViewBillDetails : System.Web.UI.Page
    {
        /// <summary>
        /// This is the method for Viewing Bill Details based on selected date
        /// </summary>
        protected void btnViewBill_Click(object sender, EventArgs e)
        {
                lblMessage.Text = "";
                ISalesManagerBLL objBLL = SalesManagerBLLFactory.CreateSalesManagerBLLObject();
                List<ICustomerBill> custlist = new List<ICustomerBill>();
                DateTime date = Convert.ToDateTime(txtDate.Text);
                custlist = objBLL.GetBillList(date);
                //custlist= objBLL.GetBillList(Calendar1.SelectedDate);
                int count = custlist.Count();

                lblnumberbill.Text = count.ToString();
                lblNumberBills.Visible = true;
                lblnumberbill.Visible = true;
                gvShowBillList.DataSource = custlist;
                gvShowBillList.DataBind();

                if (gvShowBillList.Rows.Count == 0)
                {
                    lblMessage.Text = "Bills Not Found";
                    lblNumberBills.Visible = false;
                    lblnumberbill.Visible = false;
                }
        }

        /// <summary>
        /// Function to bind the data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataBind()
        {
            ISalesManagerBLL objBLL = SalesManagerBLLFactory.CreateSalesManagerBLLObject();
            List<ICustomerBill> custlist = new List<ICustomerBill>();
            DateTime date = Convert.ToDateTime(txtDate.Text);
            custlist = objBLL.GetBillList(date);
            //custlist= objBLL.GetBillList(Calendar1.SelectedDate);
            int count = custlist.Count();

            lblnumberbill.Text = count.ToString();
            gvShowBillList.DataSource = custlist;
            gvShowBillList.DataBind();
            
        }

        /// <summary>
        /// This method redirects page to Home Page
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        /// <summary>
        /// Function to bind gridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvShowBillList_PageIndexChanging(object sender, GridViewPageEventArgs e)
                    {
                        gvShowBillList.PageIndex = e.NewPageIndex;
                        DataBind();

        }


        /// <summary>
        /// This is the page load method of ViewBillDetails page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calendarButtonExtender.EndDate = DateTime.Today;
                lblNumberBills.Visible = false;
            }
        }


        /// <summary>
        /// Function to clear label message after selecting txtDate field.
        /// </summary>
        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear_Field();
        }

        protected void Clear_Field()
        {
            txtDate.Text = "";
            lblMessage.Text = "";
        }
    }
}
