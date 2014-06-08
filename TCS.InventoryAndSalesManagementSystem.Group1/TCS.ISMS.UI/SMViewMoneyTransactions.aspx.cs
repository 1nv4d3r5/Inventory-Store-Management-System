//File Description	: This is the Code Behind File for view money transaction.
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 2, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Binded Data to the page.
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 7, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added Ajax Control to the page.
///////////////////////////////////////////////////////////////////////////////////// -->

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
    public partial class SMViewMoneyTransactions : System.Web.UI.Page
    {
        List<IViewMoneyTransaction> viewMoneyTranslist = new List<IViewMoneyTransaction>();
        /// <summary>
        /// Function will display the money transaction takes place on selected date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnViewMoneyTransaction_Click(object sender, EventArgs e)
        {
            lblLineTotal.Visible = true;
            lbllinetotals.Visible = true;
            lblnumberbill.Visible = true;
            lblNumberBills.Visible = true;
            double sum=0;
            ISalesManagerBLL objBLL = SalesManagerBLLFactory.CreateSalesManagerBLLObject();
          
            DateTime date = Convert.ToDateTime(txtDate.Text);
            viewMoneyTranslist = objBLL.GetMoneyTransaction(date);
         //  viewMoneyTranslist = objBLL.GetMoneyTransaction(Calendar1.SelectedDate);
            int count = viewMoneyTranslist.Count();

            lblnumberbill.Text = count.ToString();
            gvShowBillDetails.DataSource = viewMoneyTranslist;
            gvShowBillDetails.DataBind();
            double totalAmount=0;
            for (int i = 0; i < gvShowBillDetails.Rows.Count; i++)
            {
                 GridViewRow gvShowBillsRow = gvShowBillDetails.Rows[i];
                 
                    totalAmount += Convert.ToDouble(gvShowBillsRow.Cells[3].Text);
                 sum = sum + totalAmount;
            }
            lbllinetotals.Text = totalAmount.ToString();
           
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

        protected void Page_Load(object sender, EventArgs e)
        {

            calendarMoney.EndDate = DateTime.Today;
            lblLineTotal.Visible = false;
            lbllinetotals.Visible = false;
            lblnumberbill.Visible = false;
            lblNumberBills.Visible = false;
        }


        protected void gvShowBillDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShowBillDetails.PageIndex = e.NewPageIndex;
            DataManageEmployeeBinding();
        }

        protected void DataManageEmployeeBinding()
        {
            ISalesManagerBLL objBLL = SalesManagerBLLFactory.CreateSalesManagerBLLObject();
            DateTime date = Convert.ToDateTime(txtDate.Text);
            viewMoneyTranslist = objBLL.GetMoneyTransaction(date);
            gvShowBillDetails.DataSource = viewMoneyTranslist;
            gvShowBillDetails.DataBind();

        }

       
    }
}
