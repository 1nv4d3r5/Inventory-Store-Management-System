//File Description	: This is the Code Behind File for Generating Report of Not Avalable Items
// ---------------------------------------------------------------------------------
//	Date Created		:Apr 19, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
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
    public partial class SPGenerateItemReport : System.Web.UI.Page
    {
        static List<IItem> notavailableItemList = new List<IItem>();
        
        /// <summary>
        /// This is the Page Load method for generating item report
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnGenerateReport.Visible = false;
            btnReset.Visible = false;
            btnaddToReport.Visible = false;

            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            List<IItemCategory> itemList = objBLL.GetItemCategoryList();
            if (!IsPostBack)//For Binding CategoryId from Database
            {
                ddlCategory.DataSource = itemList;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
            }
            LblMessage.Text = "";
        }

        /// <summary>
        /// This method is used to display grid view of items available on selecting any category in dropdownlist
        /// </summary>
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            //On selecting category from ddl,respective item list should be displayed
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            List<IItem> listItems = new List<IItem>();
            List<IItem> listItem = objBLL.GetItemList(Convert.ToInt32(ddlCategory.SelectedValue));
            foreach (IItem item in listItem)
            {
                if (item.ItemQuantity < 50)
                {
                    listItems.Add(item);
                }
            }
            gvshowInventoryList.DataSource = listItems;

            gvshowInventoryList.DataBind();

            btnaddToReport.Visible = true;
            if (gvshowInventoryList.Rows.Count == 0)
            {
                LblMessage.Text = "No Items In this Category";
                btnaddToReport.Visible = false;
                return;
            }

        }



        /// <summary>
        /// This method is used to add checked items in report displayed in another grid view
        /// </summary>
        protected void addToReport_Click(object sender, EventArgs e)
        {
            bool isSelected = false;
            List<IItem> selectedItemList = new List<IItem>();
            for (int i = 0; i < gvshowInventoryList.Rows.Count; i++)
            {
                GridViewRow gvItemRow = gvshowInventoryList.Rows[i];
                isSelected = ((CheckBox)gvItemRow.FindControl("chkItems")).Checked;
                if (isSelected)
                {
                    IItem notavailableitemsObj = ViewItemBOFactory.CreateItemobject();
                    notavailableitemsObj.ItemID = Convert.ToInt32(gvItemRow.Cells[1].Text);
                    notavailableitemsObj.ItemName = (gvItemRow.Cells[2].Text);
                    //notavailableitemsObj.ItemDiscount = Convert.ToInt32(gvItemRow.Cells[5].Text);
                    //billItem.ItemCategory = Convert.ToInt32(gvItemRow.FindControl("Category"));
                    notavailableitemsObj.ItemPrice = Convert.ToDouble(gvshowInventoryList.Rows[i].Cells[3].Text);
                    notavailableitemsObj.ItemQuantity = Convert.ToInt32(gvItemRow.Cells[4].Text);
                    notavailableitemsObj.CategoryName = Convert.ToString(gvItemRow.Cells[5].Text);
                    notavailableitemsObj.ItemCategory = Convert.ToInt32(gvItemRow.Cells[6].Text);


                    selectedItemList.Add(notavailableitemsObj);
                }

            }
           
                foreach (IItem item in selectedItemList)
                {
                    IItem items = notavailableItemList.Find(x => (x.ItemID == item.ItemID));
                    if (notavailableItemList.Contains(items))
                    {

                        continue;
                    }

                    else
                    {

                        notavailableItemList.Add(item);
                    }

                }
           
            gvSPnotAvailableItems.DataSource = notavailableItemList;
            gvSPnotAvailableItems.DataBind();
            BtnGenerateReport.Visible = true;
            btnaddToReport.Visible = true;
            btnReset.Visible = true;

        }


        /// <summary>
        /// This method is used to generate report which is to be saved in database
        /// </summary>
        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {

            bool saved = false;
            //List<IItem> itemlst = new List<IItem>();
            ISalesPersonBLL objBLL = SalesPersonBLLFactory.CreateSalesPersonBLLObject();
            saved = objBLL.SaveReportofNotAvalableItems(notavailableItemList);
            if (saved)
                LblMessage.Text = "Saved Item Successfully";
            else
                LblMessage.Text = "Item Not Saved";

        }


        /// <summary>
        /// This method is used to reset all fields and lists
        /// </summary>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            notavailableItemList.Clear();

            gvshowInventoryList.DataSource = null;
            gvSPnotAvailableItems.DataSource = null;
            gvshowInventoryList.DataBind();
            gvSPnotAvailableItems.DataBind();
            clearInput(Page.Controls);
        }


        public void clearInput(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                

                if (ctrl is Label)
                {
                   (LblMessage).Text = string.Empty;
                 }
                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).SelectedIndex = 0;
                }
                if(ctrl is GridView)
                {
                gvSPnotAvailableItems.EnableViewState=false;
                gvshowInventoryList.EnableViewState = false;
                }
                clearInput(ctrl.Controls);
            }

        }


    }
}
