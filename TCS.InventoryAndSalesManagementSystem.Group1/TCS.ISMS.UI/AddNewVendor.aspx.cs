//File Description	: This is the Code Behind File for Adding a Vendor
// ---------------------------------------------------------------------------------
//	Date Created		:Apr 19, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Naincy Jain
//	Change Description   :Binded CheckBox List
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added GetItemCategory Function
// ---------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCS.ISMS.BOFactory;
using TCS.ISMS.BLLFactory;
using TCS.ISMS.Types;

namespace TCS.ISMS.UI
{
    public partial class AddNewVendor : System.Web.UI.Page
    {
        /// <summary>
        /// This is the Page Load method for adding a vendor
        /// </summary>
        IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
        IVendor objVendor = VendorBOFactory.CreateVendorObject();


        protected void Page_Load(object sender, EventArgs e)
        {

            IInventoryManagerBLL objBLL = InventoryManagerBLLFactory.CreateInventoryManagerBLLObject();
            IItemCategory objcategory1 = ItemCategotyBOFactory.CreateItemCategoryObject();
            //List<IVendor> vendorList = objBLL.GetVendorDetails();
            List<IItemCategory> cateogies = new List<IItemCategory>();
            int vendorid = Convert.ToInt32(Request.QueryString["VendorID"]);
            if (!IsPostBack)
            {
                cateogies = objBLL.GetItemCategory();
                chkVendorItemCategory.DataSource = cateogies;
                chkVendorItemCategory.DataTextField = "CategoryName";
                chkVendorItemCategory.DataValueField = "CategoryID";
                chkVendorItemCategory.DataBind();

                if (vendorid != 0)//update
                {
                    IVendor objVendor = VendorBOFactory.CreateVendorObject();
                    objVendor = objBLL.GetVendorByVendorId(vendorid);
                    lblMessage2.Text = "Vendor Id is:" + objVendor.VendorId;
                    vendorid = Convert.ToInt32(Request.QueryString["VendorID"]);


                    objVendor.VendorId = vendorid;

                    txtOrganization.Text = Convert.ToString(objVendor.NameOfOrganisation);
                    objVendor.CategoryList =objBLL.getVendorCategoryList(objVendor.VendorId);

                   
                   
                    for (int i = 0; i < chkVendorItemCategory.Items.Count; i++)
                    {
                        int categoryId = objVendor.CategoryList.Find(delegate(int cID) { return cID == Convert.ToInt32(chkVendorItemCategory.Items[i].Value); });
                        if (categoryId != 0)
                            chkVendorItemCategory.Items[i].Selected = true;
                    }
                    chkVendorItemCategory.SelectedValue = Convert.ToString(objVendor.CategoryList);

                    txtName.Text = Convert.ToString(objVendor.NameOfContactPerson);
                    txtAddress.Text = Convert.ToString(objVendor.Address);
                    txtEmail.Text = Convert.ToString(objVendor.EmailId);
                    ddlState.SelectedItem.Text = Convert.ToString(objVendor.State);
                    ddlState_SelectedIndexChanged(sender, e);



                    ddlCity.SelectedItem.Text = Convert.ToString(objVendor.City);
                    txtContact.Text = Convert.ToString(objVendor.ContactNumber);

                    ddlType.SelectedItem.Text = Convert.ToString(objVendor.VendorType);
                 

                }
                else//add
                {


                    
                    chkVendorItemCategory.SelectedValue = Convert.ToString(objVendor.CategoryList);
                    txtOrganization.Text = Convert.ToString(objVendor.NameOfOrganisation);
                    txtName.Text = Convert.ToString(objVendor.NameOfContactPerson);
                    txtAddress.Text = Convert.ToString(objVendor.Address);
                    txtEmail.Text = Convert.ToString(objVendor.EmailId);
                    ddlState.SelectedValue = Convert.ToString(objVendor.State);
                   



                    ddlCity.SelectedValue = Convert.ToString(objVendor.City);
                    txtContact.Text = Convert.ToString(objVendor.ContactNumber);

                    ddlType.SelectedValue = Convert.ToString(objVendor.VendorType);
                   

                }


            }
        }

        /// <summary>
        /// This method populates the list of cities when a state is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlState.SelectedItem.Text.ToUpper() == "MAHARASHTRA")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("--Select--");
                ddlCity.Items.Add("Mumbai");
                ddlCity.Items.Add("Nagpur");
                ddlCity.Items.Add("Gondia");
                ddlCity.Items.Add("Pune");

            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "GUJRAT")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("--Select--");
                ddlCity.Items.Add("Ahmedabad");
                ddlCity.Items.Add("Surat");
                ddlCity.Items.Add("Gandhi Nagar");
                ddlCity.Items.Add("Udaipur");
            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "MADHYA PRADESH")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("--Select--");
                ddlCity.Items.Add("Bhopal");
                ddlCity.Items.Add("Indore");
                ddlCity.Items.Add("Jabalpur");

            }
            else if (ddlState.SelectedItem.Text.ToUpper() == "CHHATTISGARH")
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Add("--Select--");
                ddlCity.Items.Add("Bhilai");
                ddlCity.Items.Add("Raipur");
                ddlCity.Items.Add("Durg");

            }
            else
            {
                ddlCity.Items.Clear();
            }
        }
        /// <summary>
        /// This method saves the Vendor details in the database
        /// </summary>

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int vendorid = Convert.ToInt32(Request.QueryString["VendorID"]);
            if (vendorid != 0)//update
            {
                try
                {
                    for (int i = 0; i < chkVendorItemCategory.Items.Count; i++)
                    {
                        if (chkVendorItemCategory.Items[i].Selected)
                        {
                            objVendor.CategoryList.Add(Convert.ToInt32(chkVendorItemCategory.Items[i].Value));
                        }
                    }

                    if (objVendor.CategoryList.Count == 0)
                    {
                        lblMessage.Text = "Please select at least one category";
                        return;
                    }

                    objVendor.NameOfOrganisation = txtOrganization.Text;
                    objVendor.NameOfContactPerson = txtName.Text;
                    objVendor.Address = txtAddress.Text;
                    objVendor.City = Convert.ToString(ddlCity.SelectedItem);
                    objVendor.State = Convert.ToString(ddlState.SelectedItem);
                    objVendor.ContactNumber = Convert.ToInt32(txtContact.Text);
                    objVendor.VendorType = Convert.ToString(ddlType.SelectedItem);
                    objVendor.EmailId = txtEmail.Text;

                    bool update = objBLL.UpdateVendorDetails(objVendor, vendorid); 


                    lblMessage.Text = "Vendor details saved successfully";

                }
                catch (Exception)
                {
                    lblMessage.Text = "An error occurred while Updating Vendor details";
                }
                finally
                {
                    objVendor = null;
                    objBLL = null;
                }
            }

            else
            {
                try
                {

                    for (int i = 0; i < chkVendorItemCategory.Items.Count; i++)
                    {
                        if (chkVendorItemCategory.Items[i].Selected)
                        {
                            objVendor.CategoryList.Add(Convert.ToInt32(chkVendorItemCategory.Items[i].Value));
                        }
                    }

                    if (objVendor.CategoryList.Count == 0)
                    {
                        lblMessage.Text = "Please select at least one category";
                        return;
                    }

                    objVendor.NameOfOrganisation = txtOrganization.Text;
                    objVendor.NameOfContactPerson = txtName.Text;
                    objVendor.Address = txtAddress.Text;
                    objVendor.City = Convert.ToString(ddlCity.SelectedItem);
                    objVendor.State = Convert.ToString(ddlState.SelectedItem);
                    objVendor.ContactNumber = Convert.ToInt32(txtContact.Text);
                    objVendor.VendorType = Convert.ToString(ddlType.SelectedItem);
                    objVendor.EmailId = txtEmail.Text;

                    bool vendorAdd = objBLL.AddVendorDetails(objVendor);

                   

                    lblMessage.Text = "Vendor details saved successfully.";
                    lblMessage2.Text = "The Vendor ID is:" + objVendor.VendorId;

                }
                catch (Exception)
                {
                    lblMessage.Text = "An error occurred while saving Vendor details";
                    lblMessage2.Text = "";
                }
                finally
                {
                    objVendor = null;
                    objBLL = null;
                }
            }
        }
        /// <summary>
        /// This method resets the page 
        /// </summary>

        protected void btnreset_Click(object sender, EventArgs e)
        {
            clearInput(Page.Controls);
        }

        /// <summary>
        /// This method redirects to the Home Page
        /// </summary>

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        public void clearInput(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }

                if (ctrl is Label)
                {
                    (lblMessage).Text = string.Empty;
                }
                if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).SelectedIndex = 0;
                }
                if (ctrl is CheckBoxList)
                {
                    ((CheckBoxList)ctrl).SelectedIndex = -1; ;
                }
                clearInput(ctrl.Controls);
            }

        }

  

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        for (int i = 0; i < chkVendorItemCategory.Items.Count; i++)
        //        {
        //            if (chkVendorItemCategory.Items[i].Selected)
        //            {
        //                objVendor.CategoryList.Add(Convert.ToInt32(chkVendorItemCategory.Items[i].Value));
        //            }
        //        }

        //        if (objVendor.CategoryList.Count == 0)
        //        {
        //            lblMessage.Text = "Please select at least one category";
        //            return;
        //        }

        //        objVendor.NameOfOrganisation = txtOrganization.Text;
        //        objVendor.NameOfContactPerson = txtName.Text;
        //        objVendor.Address = txtAddress.Text;
        //        objVendor.City = Convert.ToString(ddlCity.SelectedItem);
        //        objVendor.State = Convert.ToString(ddlState.SelectedItem);
        //        objVendor.ContactNumber = Convert.ToInt32(txtContact.Text);
        //        objVendor.VendorType = Convert.ToString(ddlType.SelectedItem);
        //        objVendor.EmailId = txtEmail.Text;

        //        bool update = objBLL.UpdateVendorDetails(objVendor);


        //        lblMessage.Text = "Vendor details saved successfully";

        //    }
        //    catch (Exception)
        //    {
        //        lblMessage.Text = "An error occurred while Updating Vendor details";
        //    }
        //    finally
        //    {
        //        objVendor = null;
        //        objBLL = null;
        //    }

        //}
    }
}
