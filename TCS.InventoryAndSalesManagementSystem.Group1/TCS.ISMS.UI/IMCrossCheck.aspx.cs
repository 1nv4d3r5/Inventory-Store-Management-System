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
    public partial class IMCrossCheck : System.Web.UI.Page
    {
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
                gvCrossCheck.DataSource = objBLL.CrossCheckInventoryWithSales();
                gvCrossCheck.DataBind();
            }

        }

        protected void DataBind()
        {
            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
           gvCrossCheck.DataSource = objBLL.CrossCheckInventoryWithSales();
           gvCrossCheck.DataBind();

        }

        protected void gvCrossCheck_PageIndexChanging(object sender, GridViewPageEventArgs e)
       {
           gvCrossCheck.PageIndex = e.NewPageIndex;
            DataBind();
     }
    }
}
