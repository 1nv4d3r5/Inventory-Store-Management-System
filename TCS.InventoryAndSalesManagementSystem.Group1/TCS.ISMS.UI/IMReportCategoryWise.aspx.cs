//File Description	: This is the Code Behind File of IMReportCategoryWise page
// ---------------------------------------------------------------------------------
//	Date Created		: May, 2013
//	Author			    : Arshin Saluja, Tata Consultancy Services
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

namespace TCS.ISMS.UI
{
    public partial class IMReportCategoryWise : System.Web.UI.Page
    {
        /// <summary>
        /// This is the page load method of CategoryWiseReport page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
                gvReportCategoryWise.DataSource = objBLL.GenerateCategoryWiseReport();
                gvReportCategoryWise.DataBind();
            }
        }
        protected void DataBind()
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            gvReportCategoryWise.DataSource = objBLL.GenerateCategoryWiseReport();
            gvReportCategoryWise.DataBind();
        }

        protected void gvReportCategoryWise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReportCategoryWise.PageIndex = e.NewPageIndex;
            DataBind();
        }
       
    }
}