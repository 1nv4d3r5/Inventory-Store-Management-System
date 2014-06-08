using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.Types;

namespace TCS.ISMS.UI
{
    public partial class SMViewReturnedItem : System.Web.UI.Page
    {
        /// <summary>
        /// This function wil display the returned items on selected date.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void DataBind()
        {
            DateTime date = Convert.ToDateTime(txtDate.Text);
            ISalesManagerBLL objBLL = BLLFactory.SalesManagerBLLFactory.CreateSalesManagerBLLObject();
            gvShowReturnedItemList.DataSource = objBLL.GetReturnedItemList(date);
            gvShowReturnedItemList.DataBind();

        }
        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            ISalesManagerBLL objBLL = BLLFactory.SalesManagerBLLFactory.CreateSalesManagerBLLObject();

            DateTime date = Convert.ToDateTime(txtDate.Text);
            List<IReturnedItems> returnedItemsList = objBLL.GetReturnedItemList(date);

            gvShowReturnedItemList.DataSource = returnedItemsList;
            gvShowReturnedItemList.DataBind();
            if (returnedItemsList.Count == 0)
            {
                lblMessage.Text = "No Items to Display";
            }
        }
       

        protected void gvReturnedItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShowReturnedItemList.PageIndex = e.NewPageIndex;
            DataBind();
        }

    }
}