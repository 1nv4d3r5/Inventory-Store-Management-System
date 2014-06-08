///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : This is the code behind page of Report Category Wise Page
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Binded Data to the page.
// Changed By          : Susmita Rana
// Date Modified       : May 3, 2013
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Added Ajax Controls to the page.
// Changed By          : Susmita Rana
// Date Modified       : May 6, 2013
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Added Clear_Fields function to the page.
// Changed By          : Susmita Rana
// Date Modified       : May 6, 2013
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
    public partial class SMReportCategoryWise : System.Web.UI.Page
    {
        static List<ICategoryWiseSale> lstCategoryWiseReport = new List<ICategoryWiseSale>();

        /// <summary>
        /// This method displays category wise sales report done on particular date
        /// </summary>
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
            gvShowReportCategoryWise.DataSource = objBLL.GenerateReportCategoryWise(Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));
            gvShowReportCategoryWise.DataBind();
            if (gvShowReportCategoryWise.Rows.Count == 0)
            {
                lblMessage.Text = "Report Not Found On This Selected Date";
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          
                ISalesManagerBLL objBLL = SalesManagerBLLFactory.CreateSalesManagerBLLObject();
                gvShowReportCategoryWise.DataSource = objBLL.GenerateReportCategoryWise(Convert.ToDateTime(txtFrom.Text), Convert.ToDateTime(txtTo.Text));
                gvShowReportCategoryWise.DataBind();
                if (gvShowReportCategoryWise.Rows.Count == 0)
                {
                    lblMessage.Text = "Report Not Found On This Selected Date";
                }
            
        }


        /// <summary>
        /// This method is used to reset all fields by calling Clear_Fields method
        /// </summary>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            //lstCategoryWiseReport.Clear();
            //Response.Redirect("SMReportCategoryWise.aspx");
            Clear_Fields();

        }


        /// <summary>
        /// This method redirects page to Home Page
        /// </summary>
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }


        /// <summary>
        /// This method is used to clear all fields to be entered by the user
        /// </summary>
        protected void Clear_Fields()
        {
            txtFrom.Text = "";
            txtTo.Text = "";
            lblMessage.Text = "";
        }



        protected void gvShowReportCategoryWise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShowReportCategoryWise.PageIndex = e.NewPageIndex;
            DataBind();
        }

    }
}
