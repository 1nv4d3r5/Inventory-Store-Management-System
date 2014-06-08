// File Summary  : This is the Code Behind File for Report of Highest and Lowest Rolling Items
// ---------------------------------------------------------------------------------
// File Summary  : Highest And Lowest Rolling Items
// Date Created  : 24'April'2013
// Author   : Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added out parameter to the function
// Changed By  : NAincy Jain
// Date Modified  : 06'May'2013
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Ajax Calender Valodation to the Page
// Changed By  : NAincy Jain
// Date Modified  : 07'May'2013
//..................................................................................
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.Types;
using TCS.ISMS.BOFactory;

namespace TCS.ISMS.UI
{
    public partial class IMHRLR : System.Web.UI.Page
    {
        DateTime frm;
        DateTime to;

       
        /// <summary>
        /// This is the page load method of IMHRLR page
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            lblHigh.Visible = false;
            lblLow.Visible = false;
            calendarFromDate.StartDate = Convert.ToDateTime("04/15/2013");
            calendarFromDate.EndDate = DateTime.Today;
            calendarToDate.StartDate = frm;
            calendarToDate.EndDate = DateTime.Today;
            //if (!IsPostBack)
            //{
                
            //    IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            //    List<IHRLR> ITEMLIST = new List<IHRLR>();
            //       ITEMLIST =  objBLL.GetHighestAndLowestRollingItems();
            //       List<IHRLR> hrl = new List<IHRLR>(); int count = 0;
            //       foreach (IHRLR items in ITEMLIST)
            //       {
            //           hrl.Add(items);
            //           count++;
            //           if (count == 3)
            //               break;
            //       }
            //       List<IHRLR> lrl = new List<IHRLR>();
              
            //       for (int i = 3; i < 6; i++)
            //       {
            //           IHRLR a = ITEMLIST[i];
            //           lrl.Add(a);
            //       }
            //       gvHighestRolling.DataSource = hrl;
            //    gvHighestRolling.DataBind();


            //    gvLowestRolling.DataSource =lrl;
            //    gvLowestRolling.DataBind();

               

            //}
            calendarFromDate.StartDate = Convert.ToDateTime("01/01/2000");
            calendarFromDate.EndDate = DateTime.Today;
            calendarToDate.StartDate = Convert.ToDateTime("01/01/2000");
            calendarToDate.EndDate = DateTime.Today;
        }

        /// <summary>
        /// This method takes an input as a DateTime
        /// </summary>
        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
          frm = Convert.ToDateTime(txtFrom.Text);
         
        }


        /// <summary>
        /// This method takes an input as a DateTime
        /// </summary>
        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
       
            to = Convert.ToDateTime(txtTo.Text);
           
        }


        /// <summary>
        /// This method displays highest and lowest rolling item
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            frm = Convert.ToDateTime(txtFrom.Text);
            to = Convert.ToDateTime(txtTo.Text);
           
            //if (!IsPostBack)
            {
                IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
                List<IHRLR> hrl = new List<IHRLR>();
                List<IHRLR> lrl = new List<IHRLR>();
                if (to < frm)
                {
                    lblMessage.Text = "End Date cannot be greater than From Date.";
                }
                else
                {
                    lblHigh.Visible = true;
                    lblLow.Visible = true;
                    hrl = objBLL.GetHighestAndLowestRollingItems(frm, to, out lrl);


                    gvHighestRolling.DataSource = hrl;
                    gvHighestRolling.DataBind();
                   
                    

                    gvLowestRolling.DataSource = lrl;
                    gvLowestRolling.DataBind();
                   
                    if (hrl.Count == 0)
                    {
                        lblMessage.Text = "No Items to Display ";
                    }

                }
            }
        }


        /// <summary>
        /// This method resets all inputs using clearInputs function
        /// </summary>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            gvHighestRolling.DataSource = null;
            gvHighestRolling.DataBind();
            gvLowestRolling.DataSource = null;
            gvLowestRolling.DataBind();
            clearInputs(Page.Controls);
        }


        /// <summary>
        /// This method resets all inputs
        /// </summary>
        void clearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = String.Empty;
                }
                if (ctrl is Label)
                {
                    lblMessage.Text = String.Empty;
                    lblHigh.Text = String.Empty;
                    lblLow.Text = String.Empty;
                }
                clearInputs(ctrl.Controls);
            
            }
        
        }
    }
}