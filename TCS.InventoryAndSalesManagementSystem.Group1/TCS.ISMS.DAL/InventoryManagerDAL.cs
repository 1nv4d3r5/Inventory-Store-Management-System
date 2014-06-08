//File Description	: This file Contains an InventoryManagerDal which has various functions and implements IInventoryManagerDAL
// ---------------------------------------------------------------------------------
//	Date Created		:Apr 19, 2013
//	Author			: Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 19, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added Function Declarations
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added GetItemCategory Function
// ---------------------------------------------------------------------------------
//  Change History
//	Date Modified		: Apr 19, 2013
//	Changed By		:Amit Nadkarni
//	Change Description   : Added GetVendorDetails Function
// ---------------------------------------------------------------------------------
// Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Amit Nadkarni
//	Change Description   : Added ViewVendorList Function
// ---------------------------------------------------------------------------------
// Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Amit Nadkarni
//	Change Description   : Added Delete Vendor Function
// ---------------------------------------------------------------------------------
//  Change History
//	Date Modified		: Apr 27, 2013
//	Changed By		: Susmita Rana
//	Change Description   : Added GetItemList Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 01, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added UpdateVendorDetails Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr'28, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added Report of Highest and Lowest Rolling Items
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr'27, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added Page of View Not Available Items
// ---------------------------------------------------------------------------------




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using System.Data.SqlClient;
using TCS.ISMS.BOFactory;


namespace TCS.ISMS.DAL
{
    public class InventoryManagerDAL : IInventoryManagerDAL
    {
        string strConnectionString =
             "Data Source=ingnrilpsql02;" +
             "Initial Catalog=AHD21_A104_Group1;" +
             "User id=a36;" +
             "Password=a36;";

/// <summary>
/// To Place order to the vendor
/// </summary>
/// <param name="lstOrders"></param>
/// <param name="listOrderItems"></param>
/// <returns>true/false</returns>
        public bool PlaceOrder(List<Iorder> lstOrders,List<IOrderedItems> listOrderItems)
        {
            bool isPlaced = false;
            int OrderID = -1;

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;


            try
            {
                for (int i = 0; i < lstOrders.Count; i++)
                {
                    objSQLConn = new SqlConnection(strConnectionString);

                    objSQLCommand = new SqlCommand("usp_AddOrder", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;


                    objSQLCommand.Parameters.AddWithValue("@VendorID", lstOrders[i].VendorId);
                    objSQLCommand.Parameters.AddWithValue("@Date", lstOrders[i].OrderDate);


                    objSQLCommand.Parameters.Add("@OrderID", System.Data.SqlDbType.Int);
                    objSQLCommand.Parameters["@OrderID"].Direction = System.Data.ParameterDirection.Output;
                    



                    objSQLConn.Open();
                    int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
                    //OrderID = Convert.ToInt32(objSQLCommand.Parameters["@OrderID"].Value);
                    if (noOfRowsAffected > 0)
                    {
                        OrderID = Convert.ToInt32(objSQLCommand.Parameters["@OrderID"].Value);

                        for (int j = i; j<=i; j++)
                        {
                            objSQLConn = new SqlConnection(strConnectionString);
                            objSQLConn.Open();
                            objSQLCommand = new SqlCommand("usp_addOrderItems", objSQLConn);
                            objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;


                            objSQLCommand.Parameters.AddWithValue("@ItemID", listOrderItems[j].ItemId);
                            objSQLCommand.Parameters.AddWithValue("@OrderID", OrderID);
                            objSQLCommand.Parameters.AddWithValue("@ItemName", listOrderItems[j].ItemName);
                            objSQLCommand.Parameters.AddWithValue("@Quantity", listOrderItems[j].ItemQuantity);
                            objSQLCommand.Parameters.AddWithValue("@CategoryID", listOrderItems[j].ItemCategory);

                            objSQLCommand.ExecuteNonQuery();
                            isPlaced = true;

                        }

                    }
                }


            }
            catch
            {

                throw;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }

            return isPlaced;

            
              
        }
        
        /// <summary>
        /// Generates report category wise
        /// </summary>
        /// <returns>list category wise</returns>
        public List<IReportCategoryWise> GenerateCategoryWiseReport()
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IReportCategoryWise> lstReportCategoryWise = new List<IReportCategoryWise>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_ReportCategoryWise", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IReportCategoryWise objReportCategoryWise = ReportCategoryWiseBOFactory.CreateReportCategoryWiseObject();
                    objReportCategoryWise.CategoryName = Convert.ToString(objSQLReader["CategoryName"]);
                    objReportCategoryWise.TotalAvailableItems = Convert.ToInt32(objSQLReader["totalItemCount"]);
                    lstReportCategoryWise.Add(objReportCategoryWise);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return lstReportCategoryWise;
        }
        /// <summary>
        /// Generates Report Price Wise
        /// </summary>
        /// <returns>List Price Wise</returns>
        public List<IReportPriceWise> GeneratePriceWiseReport()
        {
               
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IReportPriceWise> pricewiseList = new List<IReportPriceWise>();
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_ViewReportPriceWise", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                   IReportPriceWise objReport = ReportPriceWiseBOFactory.CreatePriceWiseObject();
                    //objReport.Price= Convert.ToInt32(objSQLReader["ItemPrice"]);
                    objReport.Range = objSQLReader["Range"].ToString();
                    objReport.TotalAvailable = Convert.ToInt32(objSQLReader["StockAvailable"]);

                    
                    pricewiseList.Add(objReport);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return pricewiseList;

        }

        

        public List<IItem> GenerateInventoryReport(IItemCategory objCategory)
        {
            List<IItem> itemList = new List<IItem>();

            return itemList;
        }

        /// <summary>
        /// To add the details of a new vendor
        /// </summary>
        /// <param name="intEmpId">objVendor object of vendor class</param>
        /// <returns>returns true/false</returns>
        public bool AddVendorDetails(IVendor objVendor)
        {


            bool isAdded = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            SqlTransaction objTran = null;

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_addVendorDetails", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@nameOfOrganization", objVendor.NameOfOrganisation);

                objSQLCommand.Parameters.AddWithValue("@nameOfContactPerson", objVendor.NameOfContactPerson);
                objSQLCommand.Parameters.AddWithValue("@vendorAddress", objVendor.Address);
                objSQLCommand.Parameters.AddWithValue("@city", objVendor.City);
                objSQLCommand.Parameters.AddWithValue("@state", objVendor.State);
                objSQLCommand.Parameters.AddWithValue("@contactNumber", objVendor.ContactNumber);
                objSQLCommand.Parameters.AddWithValue("@vendorType", objVendor.VendorType);
                objSQLCommand.Parameters.AddWithValue("@emailId", objVendor.EmailId);
                //objSQLCommand.Parameters.AddWithValue("@categoryId ", objVendor.CategoryId);

                objSQLCommand.Parameters.Add("@vendorId", System.Data.SqlDbType.Int);
                objSQLCommand.Parameters["@vendorId"].Direction = System.Data.ParameterDirection.Output;

                objSQLConn.Open();
                objTran = objSQLConn.BeginTransaction();
                objSQLCommand.Transaction = objTran;

                int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
                if (noOfRowsAffected > 0)
                {
                    objVendor.VendorId = Convert.ToInt32(objSQLCommand.Parameters["@vendorId"].Value);

                    //loop thru vendor's cateogry list
                    for (int i = 0; i < objVendor.CategoryList.Count; i++)
                    {
                        objSQLCommand = new SqlCommand("usp_AddVendorItemCategory_group1", objSQLConn);
                        objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        objSQLCommand.Parameters.AddWithValue("@VendorID ", objVendor.VendorId);
                        objSQLCommand.Parameters.AddWithValue("@CategoryID ", objVendor.CategoryList[i]);
                        objSQLCommand.Transaction = objTran;
                        noOfRowsAffected = objSQLCommand.ExecuteNonQuery();

                        if (noOfRowsAffected == 0)
                        {
                            objTran.Rollback();
                            break;
                        }
                    }
                }

                objTran.Commit();
                isAdded = true;
            }
            catch
            {
                objTran.Rollback();
                throw;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }

            return isAdded;
        }
        /// <summary>
        /// this method updates vendor details
        /// </summary>
        /// <param name="objVendor"></param>
        /// <param name="vendorId"></param>
        public bool UpdateVendorDetails(IVendor objVendor,int vendorId)
        {
            bool isUpdated = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            SqlTransaction objTran = null;
           
            

               
           try
           {
               objSQLConn = new SqlConnection(strConnectionString);

               objSQLCommand = new SqlCommand("usp_updateVendorDetails", objSQLConn);
               objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
               objSQLCommand.Parameters.AddWithValue("@vendorId", vendorId);
               objSQLCommand.Parameters.AddWithValue("@nameOfOrganization", objVendor.NameOfOrganisation);

               objSQLCommand.Parameters.AddWithValue("@nameOfContactPerson", objVendor.NameOfContactPerson);
               objSQLCommand.Parameters.AddWithValue("@vendorAddress", objVendor.Address);
               objSQLCommand.Parameters.AddWithValue("@city", objVendor.City);
               objSQLCommand.Parameters.AddWithValue("@state", objVendor.State);
               objSQLCommand.Parameters.AddWithValue("@contactNumber", objVendor.ContactNumber);
               objSQLCommand.Parameters.AddWithValue("@vendorType", objVendor.VendorType);
               objSQLCommand.Parameters.AddWithValue("@emailId", objVendor.EmailId);
               //objSQLCommand.Parameters.AddWithValue("@categoryId ", objVendor.CategoryId);

               
               objSQLConn.Open();
               objTran = objSQLConn.BeginTransaction();
               objSQLCommand.Transaction = objTran;

               int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
               if (noOfRowsAffected > 0)
               {

                   //loop thru vendor's cateogry list
                   foreach (int category in objVendor.CategoryList)
                   {
                       objSQLCommand = new SqlCommand("usp_AddVendorItemCategory_group1", objSQLConn);
                       objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                       objSQLCommand.Parameters.AddWithValue("@VendorID ", vendorId);
                       objSQLCommand.Parameters.AddWithValue("@CategoryID ", category);
                       objSQLCommand.Transaction = objTran;
                       noOfRowsAffected = objSQLCommand.ExecuteNonQuery();

                       if (noOfRowsAffected == 0)
                       {
                           objTran.Rollback();
                           break;
                       }
                   }
               }

               objTran.Commit();
               isUpdated = true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                   objSQLConn.Close();

           }
          return isUpdated;
       }

        /// <summary>
        /// this method gives vendor based on vendorId
        /// </summary>
        /// <param name="VendorId"></param>
        public IVendor GetVendorByVendorId(int VendorId)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
           
            IVendor objVendors = VendorBOFactory.CreateVendorObject();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetVendorByVendorId", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@VendorID", VendorId);
                objSQLCommand.Parameters["@VendorID"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    /*IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();*/
                    objVendors.VendorId = Convert.ToInt32(objSQLReader["VendorID"]);
                    objVendors.NameOfOrganisation = Convert.ToString(objSQLReader["NameOfOrganization"]);
                    objVendors.NameOfContactPerson = Convert.ToString(objSQLReader["NameOfContactPerson"]);
                    objVendors.Address = Convert.ToString(objSQLReader["VendorAddress"]);
                    objVendors.City = Convert.ToString(objSQLReader["City"]);
                    objVendors.State = Convert.ToString(objSQLReader["State"]);
                    objVendors.ContactNumber = Convert.ToInt32(objSQLReader["ContactNumber"]);
                    objVendors.VendorType= Convert.ToString(objSQLReader["VendorType"]);
                    objVendors.EmailId = Convert.ToString(objSQLReader["EmailID"]);
                    /*objEmployee.Address = Convert.ToString(objSQLReader["Address"]);
                    objEmployee.City = Convert.ToString(objSQLReader["State"]);
                    objEmployee.State = Convert.ToString(objSQLReader["City"]);
                    objEmployee.MobileNumber = Convert.ToInt64(objSQLReader["ContactNumber"]);*/


                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return objVendors;

        }
            
        

        /// <summary>
        /// to delete a Vendor from the list of vendors
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public bool DeleteVendor(List<int> vendorID)
        {
            bool isDeleted = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();
                for (int i = 0; i < vendorID.Count; i++)
                {
                    objSQLCommand = new SqlCommand("usp_UpdateVendor_Group1", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    objSQLCommand.Parameters.AddWithValue("@VendorID", vendorID[i]);
                    objSQLCommand.Parameters["@VendorID"].Direction = System.Data.ParameterDirection.Input;

                    objSQLCommand.ExecuteNonQuery();
                    isDeleted = true;
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return isDeleted;
        }

/// <summary>
/// View Vendor Details
/// </summary>
/// <returns>List of Vendors</returns>
        public List<IVendor> GetVendorDetails()
        {

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IVendor> vendorList = new List<IVendor>();
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_ViewVendorDetails_group1", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IVendor objVendorDetails = VendorBOFactory.CreateVendorObject();
                    objVendorDetails.VendorId = Convert.ToInt32(objSQLReader["VendorID"]);
                    objVendorDetails.NameOfOrganisation = objSQLReader["NameOfOrganization"].ToString();

                    objVendorDetails.NameOfContactPerson = objSQLReader["NameOfContactPerson"].ToString();
                    objVendorDetails.Address = objSQLReader["VendorAddress"].ToString();
                    objVendorDetails.City = objSQLReader["City"].ToString();
                    objVendorDetails.State = objSQLReader["State"].ToString();

                    objVendorDetails.ContactNumber = Convert.ToInt64(objSQLReader["ContactNumber"]);
                    objVendorDetails.VendorType = objSQLReader["VendorType"].ToString();
                    objVendorDetails.EmailId = objSQLReader["EmailID"].ToString();

                    vendorList.Add(objVendorDetails);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return vendorList;

        }
        /// <summary>
        /// Function to view list of items status for the selected category
        /// </summary>
        /// <param name="CategoryId"> User selected categoryId </param>
        /// <returns> list of items for the selected category </returns>
        public List<IItem> CheckStatusOfInventory(int CategoryId)
        {
            List<IItem> itemList = new List<IItem>();
            SqlConnection objSqlConn = null;
            SqlCommand objSqlCommand = null;

            try
            {
                objSqlConn = new SqlConnection(strConnectionString);

                objSqlCommand = new SqlCommand("usp_getItemDetails", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();

                objSqlCommand.Parameters.AddWithValue("@CategoryID", CategoryId);
                objSqlCommand.Parameters["@CategoryID"].Direction = System.Data.ParameterDirection.Input;


                SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
                while (objSqlReader.Read())
                {
                    IItem objItem = ViewItemBOFactory.CreateItemobject();
                    objItem.ItemID = Convert.ToInt32(objSqlReader["ItemID"]);
                    objItem.ItemName = objSqlReader["ItemName"].ToString();
                    objItem.CategoryName = (objSqlReader["CategoryName"].ToString());
                    objItem.ItemQuantity = Convert.ToInt32(objSqlReader["Quantity"]);
                    objItem.ItemPrice = Convert.ToInt32(objSqlReader["ItemPrice"]);


                    itemList.Add(objItem);
                }
                objSqlReader.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConn != null && objSqlConn.State != System.Data.ConnectionState.Closed)
                    objSqlConn.Close();
            }
            return itemList;
        }

        public List<IItem> ViewRportGeneratedBySP()
        {
            List<IItem> itemList = new List<IItem>();
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_getNotAvailableItems", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IItem objItemDetails = ViewItemBOFactory.CreateItemobject();
                    objItemDetails.ItemID = Convert.ToInt32(objSQLReader["ItemID"]);
                    objItemDetails.ItemName = objSQLReader["ItemName"].ToString();
                    objItemDetails.ItemCategory = Convert.ToInt32(objSQLReader["CategoryID"]);
                    objItemDetails.ItemPrice = Convert.ToInt64(objSQLReader["ItemPrice"]);
                    objItemDetails.ItemQuantity = Convert.ToInt32(objSQLReader["Quantity"]);
                    itemList.Add(objItemDetails);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }

            return itemList;
        }

        public List<IHRLR> GetHighestAndLowestRollingItems(DateTime fromDate,DateTime toDate, out List<IHRLR> lrl)
        {
            List<IHRLR> HRLRitemList = new List<IHRLR>();
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
          

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_HR", objSQLConn);
               
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@FromDate", fromDate);

                objSQLCommand.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IHRLR objHrLr = HrLrBOFactory.CreateIHRLRObject();
                    
                    objHrLr.ItemName = Convert.ToString(objSQLReader["ItemName"]);
                    objHrLr.ItemCategory = Convert.ToString(objSQLReader["CategoryName"]);

                    objHrLr.ItemSold = Convert.ToInt32(objSQLReader["ItemSold"]);

                    HRLRitemList.Add(objHrLr);
                }
                objSQLReader.Close();

                objSQLCommand = new SqlCommand("usp_LR", objSQLConn);

                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                
                objSQLCommand.Parameters.AddWithValue("@FromDate", fromDate);

                objSQLCommand.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataReader objSQLReader1 = objSQLCommand.ExecuteReader();
                List<IHRLR> lrls = new List<IHRLR>();
                while (objSQLReader1.Read())
                {
                    IHRLR objHrLr = HrLrBOFactory.CreateIHRLRObject();
                   

                    objHrLr.ItemName = Convert.ToString(objSQLReader1["ItemName"]);
                    objHrLr.ItemCategory = Convert.ToString(objSQLReader1["CategoryName"]);

                    objHrLr.ItemSold = Convert.ToInt32(objSQLReader1["ItemSold"]);

                    lrls.Add(objHrLr);
                }
                lrl = lrls;
               
                objSQLReader1.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }

           
            return HRLRitemList;
        }
        /// <summary>
        /// Cross Checks Inventory Items
        /// </summary>
        /// <returns>returns list of items</returns>
        public List<IIMCrossCheck> CrossCheckInventoryWithSales()
        {

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IIMCrossCheck> itemCrosscheckList = new List<IIMCrossCheck>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_crossCheckItems", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IIMCrossCheck objCrossCheck = IMCrossCheckBOFactory.CreateIMCrosscheckObject();

                    objCrossCheck.ItemName = Convert.ToString(objSQLReader["ItemName"]);
                    objCrossCheck.ItemCount = Convert.ToInt32(objSQLReader["Quantity"]);
                    objCrossCheck.LastSale = Convert.ToInt32(objSQLReader["ItemClosingCount"]);
                    objCrossCheck.ItemSold = Convert.ToInt32(objSQLReader["ItemSold"]);
                    objCrossCheck.AddedByAdmin = Convert.ToInt32(objSQLReader["QuantityAdded"]);
                    objCrossCheck.Difference = (objCrossCheck.LastSale - objCrossCheck.ItemCount) - objCrossCheck.ItemSold;
                    itemCrosscheckList.Add(objCrossCheck);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }

            return itemCrosscheckList;
        }



        public List<int> getVendorCategoryList(int VendorId)
        {

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<int> categoryList = new List<int>();
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_getItemCategoryForVendor", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@VendorID", VendorId);

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                   
                    int categoryID = Convert.ToInt32(objSQLReader["CategoryId"]);
                

                    categoryList.Add(categoryID);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return categoryList;
        
        }



        /// <summary>
        /// To get the details of categories from database
        /// </summary>
        /// /// <returns>returns list of category</returns>
        public List<IItemCategory> GetItemCategory()
        {

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IItemCategory> categoryList = new List<IItemCategory>();
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_getitemcategory", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IItemCategory objCategoryDetails = ItemCategotyBOFactory.CreateItemCategoryObject();
                    objCategoryDetails.CategoryId = Convert.ToInt32(objSQLReader["CategoryId"]);
                    objCategoryDetails.CategoryName = objSQLReader["CategoryName"].ToString();
                    categoryList.Add(objCategoryDetails);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return categoryList;

        }

        /// <summary>
        /// Function to view list of items of selected category
        /// </summary>
        /// <param name="CategoryId"> User selected categoryId </param>
        /// <returns> list of items of selected category </returns>
        public List<IItem> GetItemList(int CategoryId)
        {
            SqlConnection objSqlConn = null;
            SqlCommand objSqlCommand = null;
            List<IItem> itemList = new List<IItem>();

            try
            {
                objSqlConn = new SqlConnection(strConnectionString);

                objSqlCommand = new SqlCommand("usp_getNotAvailableItems", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();

                objSqlCommand.Parameters.AddWithValue("@CategoryID", CategoryId);
                objSqlCommand.Parameters["@CategoryID"].Direction = System.Data.ParameterDirection.Input;


                SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
                while (objSqlReader.Read())
                {
                    IItem objItem = ViewItemBOFactory.CreateItemobject();
                    objItem.ItemID = Convert.ToInt32(objSqlReader["ItemID"]);
                    objItem.ItemName = objSqlReader["ItemName"].ToString();
                    objItem.ItemCategory = Convert.ToInt32(objSqlReader["CategoryID"]);
                    objItem.ItemQuantity = Convert.ToInt32(objSqlReader["Quantity"]);
                    objItem.ItemPrice = Convert.ToInt32(objSqlReader["ItemPrice"]);


                    itemList.Add(objItem);
                }
                objSqlReader.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSqlConn != null && objSqlConn.State != System.Data.ConnectionState.Closed)
                    objSqlConn.Close();
            }
            return itemList;
        }

        /// <summary>
        /// Gives list of Vendors Category Wise
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns>list of Vendors</returns>
        public List<IVendor> GetVendorDetailsCategoryWise(int CategoryId)
        {

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IVendor> vendorList = new List<IVendor>();
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);


                objSQLCommand = new SqlCommand("usp_getVendorCategoryWise", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLConn.Open();

                objSQLCommand.Parameters.AddWithValue("@CategoryID", CategoryId);
                objSQLCommand.Parameters["@CategoryID"].Direction = System.Data.ParameterDirection.Input;
                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();


                while (objSQLReader.Read())
                {
                    IVendor objVendorDetails = VendorBOFactory.CreateVendorObject();

                    objVendorDetails.NameOfContactPerson = objSQLReader["NameOfContactPerson"].ToString();
                    objVendorDetails.VendorId = Convert.ToInt32(objSQLReader["VendorID"]);
                    vendorList.Add(objVendorDetails);
                }

                objSQLReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
                    objSQLConn.Close();
            }
            return vendorList;

        }

    }


}

