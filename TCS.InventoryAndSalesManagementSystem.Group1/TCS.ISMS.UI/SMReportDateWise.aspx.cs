// File Summary  : Report DateWise Page
// ---------------------------------------------------------------------------------
//
// Change History :
// Change Description# : Binding Data to the page
// Changed By          : Suman Pradhan
// Date Modified       : 3 May, 2013
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added ajax controls  to the report datewise page 
// Changed By          : Suman Pradhan
// Date Modified       : 6 May, 2013
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Clear field function  to the report datewise page 
// Changed By          : Suman Pradhan
// Date Modified       : 7 May, 2013
/////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.Types;

namespace TCS.ISMS.UI
{
    public partial class SMReportDateWise : System.Web.UI.Page
    {
        static List<IDateWiseSale> lstdateWiseSale = new List<IDateWiseSale>();
        /// <summary>
        /// Function to display the report of items on selected date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calendarButtonExtender.EndDate = DateTime.Today;
                calendarButtonExtender1.EndDate = DateTime.Today;
            }

        }

        protected void DataBind()
        {
            ISalesManagerBLL objBLL = SalesManagerBLLFactory.CreateSalesManagerBLLObject();
            gvShowReport.DataSource = objBLL.GenerateReportDateWise(Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));
            gvShowReport.DataBind();
 
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ISalesManagerBLL objBLL = SalesManagerBLLFactory.CreateSalesManagerBLLObject();
            gvShowReport.DataSource = objBLL.GenerateReportDateWise(Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));
            gvShowReport.DataBind();
            if (gvShowReport.Rows.Count == 0)
            {
                lblMessage.Text = "Report not found on selected date";
            }

        }
        /// <summary>
        /// Function to redirect to home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        /// <summary>
        /// Function to call other function which will clear the text fiels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click1(object sender, EventArgs e)
        {
            //lstdateWiseSale.Clear();
            //Response.Redirect("SMReportDateWise.aspx");
            lblMessage.Text = "";
            Clear_Field();

        }
        /// <summary>
        /// Function to clear all text fields.
        /// </summary>

        protected void Clear_Field()
        {
            txtFrom.Text = "";
            txtTo.Text = "";
        }

        protected void gvShowReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShowReport.PageIndex = e.NewPageIndex;
            DataBind();

        }

        /// <summary>
        /// This is the page load method for report date wise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

    }
}
