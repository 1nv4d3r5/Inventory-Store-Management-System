//File Description	: This is the Code Behind File for viewing Cancelled Bill
// ---------------------------------------------------------------------------------
//	Date Created		:
//	Author			    :Sandeep Kothawade, Tata Consultancy Services
// ---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.BOFactory;
using TCS.ISMS.Types;
using TCS.ISMS.BLLFactory;

namespace TCS.ISMS.UI
{
    public partial class SMViewCancelledBill : System.Web.UI.Page
    {
        /// <summary>
        /// This is the Page Load method for Viewing Cancelled Bill
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            calendarCancelBill.EndDate = DateTime.Today;
            //DateTime t = DateTime.Today;

            //lblCancelledBill.Text = t.ToShortDateString() ;
            
        }

        //protected void btnViewCanceleldBill_Click(object sender, EventArgs e)
        //{
        //    ISalesManagerBLL objBLL = BLLFactory.SalesManagerBLLFactory.CreateSalesManagerBLLObject();
             
        //   DateTime date = Convert.ToDateTime(txtDate.Text);
        //   List<ICustomerBill> cancellBillList = objBLL.GetCancelledBillList(date);

        //   gvShowCancelledBills.DataSource = cancellBillList;
        //    gvShowCancelledBills.DataBind();
            
        //}

        /// <summary>
        /// This method is used to display cancelled bill list on selected date
        /// </summary>
        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ISalesManagerBLL objBLL = BLLFactory.SalesManagerBLLFactory.CreateSalesManagerBLLObject();

            DateTime date = Convert.ToDateTime(txtDate.Text);
            List<ICustomerBill> cancellBillList = objBLL.GetCancelledBillList(date);

            gvShowCancelledBills.DataSource = cancellBillList;


            gvShowCancelledBills.DataBind();
            if (cancellBillList.Count == 0)
            {
                lblMessage.Text = "No Bills to Display";
            }
            //else
            //{
            //    lblMessage.Text = "";
            //}
        }

        
    }
}
