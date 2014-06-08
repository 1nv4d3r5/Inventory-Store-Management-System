///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : Report Price wise code behind page
// ---------------------------------------------------------------------------------
// Date Created  : Apr 25, 2013
// Author        : Amit Nadkarni, Tata Consultancy Services
///////////////////////////////////////////////////////////////////////////////////////////////
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
    public partial class IMReportPriceWise : System.Web.UI.Page
    {   
        /// <summary>
        /// This is the page load method for report price wise.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
                gvPriceWiseReport.DataSource = objBLL.GeneratePriceWiseReport();
                gvPriceWiseReport.DataBind();

            }

        }
        /// <summary>
        /// Function will redirect to home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void PricewiseDataBind()
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            gvPriceWiseReport.DataSource = objBLL.GeneratePriceWiseReport(); 
            gvPriceWiseReport.DataBind();
        }

        protected void gvPriceWiseReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPriceWiseReport.PageIndex = e.NewPageIndex;
            PricewiseDataBind();
        }
    }
}