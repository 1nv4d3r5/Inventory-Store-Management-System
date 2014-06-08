
///////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an GUI for Sales Person to Search Item by Name.
// ---------------------------------------------------------------------------------
//	Date Created		: April 27, 2013
//	Author			    : Amit Nadkarni, Tata Consultancy Services
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
   
    public partial class SPSearchItemByName : System.Web.UI.Page
    {
        
        /// <summary>
        /// On click of Cancel Button,User will be redirected to home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");

        }
      
        protected void gvItemSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// On click of Search Button Item name with Matching results will be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ISalesPersonBLL objBLL = TCS.ISMS.BLLFactory.SalesPersonBLLFactory.CreateSalesPersonBLLObject();
              
             string name = txtName.Text;
             gvItemSearch.DataSource = objBLL.SearchItembyName(name);
             gvItemSearch.DataBind();
        }
    }
}