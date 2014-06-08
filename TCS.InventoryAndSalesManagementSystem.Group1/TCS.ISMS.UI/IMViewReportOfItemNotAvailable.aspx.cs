//File Description	: This is the Code Behind File for ViewReportOfItemNotAvailable page
// ---------------------------------------------------------------------------------
//	Date Created		: May, 2013
//	Author			    : Naincy Jain, Tata Consultancy Services
//
/////////////////////////////////////////////////////////////////////////////////////

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
    public partial class IMViewReportOfItemNotAvailable : System.Web.UI.Page
    {
        /// <summary>
        /// This is the page load method of ViewReportOfItemNotAvailable page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            gvItemDetailList.DataSource = objBLL.ViewRportGeneratedBySP();
            gvItemDetailList.DataBind();

        }

    }
}