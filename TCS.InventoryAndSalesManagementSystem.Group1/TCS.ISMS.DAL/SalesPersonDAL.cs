
///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : Data Access Layer for sales person
// ---------------------------------------------------------------------------------
// Date Created  :  Apr 19, 2013
// Author   : Sandeep Sanjay Kothawade, Tata Consultancy Services
// ---------------------------------------------------------------------------------
//  Change History : <List of Dev(s) making the change> 
//	Change Description   : Added SearchItemDetails Function. 
//	Changed By		:Amit Nadkarni
//	Date Modified		: Apr 19, 2013
//  ---------------------------------------------------------------------------------
//
//  Date Modified  : Apr 25, 2013
//  Changed By  : Susmita Rana
//  Change Description# : Added function for get item list.
//
//  ---------------------------------------------------------------------------------
//
//  Change Description# : Added function for generate bill. 
//  Changed By  : Sandeep Kothawade
//  Date Modified  : Apr 26, 2013
//    
//  ----------------------------------------------------------------------------------
//
//  Date Modified  : Apr 26, 2013
//  Changed By  : Susmita Rana
//  Change Description# : Added function for get item category list.
//----------------------------------------------------------------------------------
//
//  Date Modified  : Apr 28, 2013
//  Changed By  : Naincy Jain
//  Change Description# : Added function for generate report of not available items.
// -----------------------------------------------------------------------------------
//
//  Date Modified  : May 2, 2013
//  Changed By  : Susmita Rana
//  Change Description# : Added function for SearchBillDetails. 
// -----------------------------------------------------------------------------------
//
//  Date Modified  : May 2, 2013
//  Changed By  : Susmita Rana
//  Change Description# : Added function for CancelBill. 
///////////////////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using System.Data.SqlClient;
using TCS.ISMS.BOFactory;

namespace TCS.ISMS.DAL
{
    public class SalesPersonDAL : ISalesPersonDAL
    {
        string strConnectionString =
                "Data Source=ingnrilpsql02;" +
                "Initial Catalog=AHD21_A104_Group1;" +
                "User id=a36;" +
                "Password=a36;";

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

            try {
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
                    objItem.CategoryName = objSqlReader["CategoryName"].ToString();
                    objItem.ItemCategory = Convert.ToInt32(objSqlReader["CategoryID"]);
                    objItem.ItemQuantity = Convert.ToInt32(objSqlReader["Quantity"]);
                    objItem.ItemPrice = Convert.ToInt32(objSqlReader["ItemPrice"]);


                    itemList.Add(objItem);
                    
                }
                objSqlReader.Close();
            }
            
            catch(Exception ex)
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
        /// Function to generate bill 
        /// </summary>
        /// <param name="objCustomerBill"> contains the bills data </param>
        public void CreateBill(ICustomerBill objCustomerBill)
        {
            

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            SqlTransaction objTran = null;

            try
            {
                // storing data in bills table
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_addBill", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@CustomerID", objCustomerBill.CustomerId);
                objSQLCommand.Parameters.AddWithValue("@CustomerName", objCustomerBill.CustomerName);
                objSQLCommand.Parameters.AddWithValue("@EmployeeID", objCustomerBill.EmployeeId);
                objSQLCommand.Parameters.AddWithValue("@BillStatus ", objCustomerBill.BillStatus);
                objSQLCommand.Parameters.AddWithValue("@BillDate", objCustomerBill.BillDate);
                objSQLCommand.Parameters.AddWithValue("@MoneyIn", objCustomerBill.MoneyIn);
                objSQLCommand.Parameters.AddWithValue("@MoneyOut", objCustomerBill.MoneyOut);
                objSQLCommand.Parameters.AddWithValue("@TotalBillAmount", objCustomerBill.TotalBillAmount);
                objSQLCommand.Parameters.AddWithValue("@ReturnAmount", objCustomerBill.TotalMoneyReturned);

                objSQLCommand.Parameters.Add("@BillNumber", System.Data.SqlDbType.Int);
                objSQLCommand.Parameters["@BillNumber"].Direction = System.Data.ParameterDirection.Output;

                objSQLConn.Open();
                objTran = objSQLConn.BeginTransaction();
                objSQLCommand.Transaction = objTran;

                int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
                if (noOfRowsAffected > 0)
                {
                    objCustomerBill.BillNumber = Convert.ToInt32(objSQLCommand.Parameters["@BillNumber"].Value);


                    // storing data in bill details table
                    foreach (IItem item in objCustomerBill.BoughtItemList)
                    {

                        objSQLCommand = new SqlCommand("usp_addBillDetails", objSQLConn);
                        objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                        objSQLCommand.Parameters.AddWithValue("@BillNumber", objCustomerBill.BillNumber);
                        objSQLCommand.Parameters.AddWithValue("@ItemID", item.ItemID);
                        objSQLCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                        objSQLCommand.Parameters.AddWithValue("@BillDate", objCustomerBill.BillDate);
                        objSQLCommand.Parameters.AddWithValue("@ItemWiseDiscount", item.ItemDiscount);
                        objSQLCommand.Parameters.AddWithValue("@QuantityPurchased", item.ItemQuantity);
                        double lineTotal = item.ItemQuantity * (item.ItemPrice + item.ItemPrice * item.ItemDiscount / 100);
                        objSQLCommand.Parameters.AddWithValue("@LineTotal", lineTotal);
                        objSQLCommand.Parameters.AddWithValue("@ItemStatus", "ok");
                        objSQLCommand.Parameters.AddWithValue("@QuantityReturned", 0);
                        objSQLCommand.Parameters.AddWithValue("@ReturnedTotal", 0);
                        objSQLCommand.Parameters.AddWithValue("@Remark", "");
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

        }

        /// <summary>
        /// Function to cancel bill 
        /// </summary>
        /// <param name="objCustomerBill"> contains the bills data </param>
        public bool CancelBill(ICustomerBill objCustomerBill)
        {
            bool isDeleted = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_CancelBill", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    objSQLCommand.Parameters.AddWithValue("@BillNumber", objCustomerBill.BillNumber);
                    objSQLCommand.Parameters["@BillNumber"].Direction = System.Data.ParameterDirection.Input;

                    objSQLCommand.Parameters.AddWithValue("@Remarks", objCustomerBill.Remarks);
                    objSQLCommand.Parameters["@Remarks"].Direction = System.Data.ParameterDirection.Input;

                    objSQLCommand.ExecuteNonQuery();
                
                isDeleted = true;
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

        
        public List<IItem> SearchItem(String itemName)
        {
            List<IItem> itemList = new List<IItem>();

            return itemList;
        }


        /// <summary>
        /// Function to get bill details
        /// </summary>
        /// <param name="billNumber">  User selected billNumber </param>
        /// <returns> list of attributes of bill details based on bill number </returns>
        public List<IBillDetails> GetBillDetails(int billNumber)
        {
            List<IBillDetails> lstBillDetail = new List<IBillDetails>();
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
           
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_ViewBillDetails", objSQLConn);

                objSQLCommand.Parameters.AddWithValue("@BillNo", billNumber);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();
                IBillDetails bills = BillDetailsBOFactory.CreateBillDetailsObject();
                while (objSQLReader.Read())
                {

                    objSQLCommand.Parameters.AddWithValue("@BillNo", billNumber);
                    bills.ItemName = Convert.ToString(objSQLReader["ItemName"]);
                    //objReturnedItems. = Convert.ToString(objSQLReader["EmployeeLastName"]);
                    bills.ItemID = Convert.ToInt32(objSQLReader["ItemID"]);

                    bills.QuantityPurchased = Convert.ToInt32(objSQLReader["QuantityPurchased"]);
                   bills.LineTotal = Convert.ToDouble(objSQLReader["LineTotal"]);


                   lstBillDetail.Add(bills);
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
          

            return lstBillDetail;
        }

        public void TakeBackSoldItems(IBillDetails objBillDetails)
        {
            
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_ReturnItems", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@QuantityReturned", objBillDetails.QuantityReturned);
                objSQLCommand.Parameters.AddWithValue("@ReturnedTotal", objBillDetails.LineTotalofReturnedItems);
                objSQLCommand.Parameters.AddWithValue("@Remark", objBillDetails.Remarks);
                objSQLCommand.Parameters.AddWithValue("@BillNumber", objBillDetails.BillNumber);
                objSQLCommand.Parameters.AddWithValue("@ItemID", objBillDetails.ItemID);
                //objSQLCommand.Parameters.AddWithValue("@Address", objEmployee.Address);
                //objSQLCommand.Parameters.AddWithValue("@State", objEmployee.State);
                //objSQLCommand.Parameters.AddWithValue("@City", objEmployee.City);
                //objSQLCommand.Parameters.AddWithValue("@ContactNumber", objEmployee.MobileNumber);

                //objSQLCommand.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
                //objSQLCommand.Parameters["@EmployeeID"].Direction = System.Data.ParameterDirection.Output;

                objSQLConn.Open();
                //int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
                //if (noOfRowsAffected > 0)
                //    objBillDetails.EmployeeId = Convert.ToInt32(objSQLCommand.Parameters["@EmployeeID"].Value);
                //isAdded = true;

                //objSQLCommand = new SqlCommand("usp_addToLoginDetails", objSQLConn);
                //objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //objSQLCommand.Parameters.AddWithValue("@EmployeeID", objEmployee.EmployeeId);
                //objSQLCommand.Parameters.AddWithValue("@RoleId", objEmployee.RoleId);
                //string pwd = string.Empty;
                //pwd = (objEmployee.Dob.Month).ToString() + (objEmployee.Dob.Day).ToString() + (objEmployee.Dob.Year).ToString();
                //objSQLCommand.Parameters.AddWithValue("@Password", pwd);

                objSQLCommand.ExecuteNonQuery();

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

            //return isAdded;
        }

        //public List<IItem> GenerateReport(int CategoryId)
        //{
           
        //    List<IItem> itemLists = new List<IItem>();
        //    SqlConnection objSQLConn = null;
        //    SqlCommand objSQLCommand = null;
           
        //    try
        //    {
        //        objSQLConn = new SqlConnection(strConnectionString);
        //        objSQLConn.Open();

        //        objSQLCommand = new SqlCommand("usp_getItemDetails", objSQLConn);
        //        objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objSQLCommand.Parameters.AddWithValue("@CategoryID", CategoryId);
        //        objSQLCommand.Parameters["@CategoryID"].Direction = System.Data.ParameterDirection.Input;
        //        SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

        //        while (objSQLReader.Read())
        //        {
        //            IItem objItemDetails = ViewItemBOFactory.CreateItemobject();
        //            objItemDetails.ItemID = Convert.ToInt32(objSQLReader["ItemID"]);
        //            objItemDetails.ItemName = objSQLReader["ItemName"].ToString();
                   
        //            objItemDetails.ItemPrice = Convert.ToInt64(objSQLReader["ItemPrice"]);
        //            objItemDetails.ItemQuantity = Convert.ToInt32(objSQLReader["Quantity"]);
        //            itemLists.Add(objItemDetails);
        //        }

        //        objSQLReader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objSQLConn != null && objSQLConn.State != System.Data.ConnectionState.Closed)
        //            objSQLConn.Close();
        //    }
            
        //    return itemLists;
        //}

        /// <summary>
        /// Function to get item list based on Category ID
        /// </summary>
        /// <param name="objCustomerBill"> returns list of items based on category ID </param>
        public List<IItemCategory> GetItemCategoryList()
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
        /// Function to view list of items having names similar to the name entered by user
        /// </summary>
        /// <param name="itemName"> item name entered by user </param>
        /// <returns> list of items having names similar to the name entered by user </returns>
        public List<IItem> SearchItemDetails(string itemName)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IItem> lstItem = new List<IItem>();

             try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_SearchItembyname", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@ItemName", itemName);
                objSQLCommand.Parameters["@ItemName"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader1 = objSQLCommand.ExecuteReader();

                while (objSQLReader1.Read())
                {
                    IItem objItem = TCS.ISMS.BOFactory.ViewItemBOFactory.CreateItemobject();
                    objItem.ItemID = Convert.ToInt32(objSQLReader1["ItemID"]);
                    objItem.ItemName = objSQLReader1["ItemName"].ToString();

                    objItem.ItemPrice = Convert.ToDouble(objSQLReader1["ItemPrice"]);
                    objItem.ItemDiscount = Convert.ToInt32(objSQLReader1["ItemDiscount"]);
                    objItem.ItemClosingCount = Convert.ToInt32(objSQLReader1["ItemClosingCount"]);
                    objItem.ItemCategory = Convert.ToInt32(objSQLReader1["CategoryID"]);
                    objItem.ItemQuantity = Convert.ToInt32(objSQLReader1["Quantity"]);
                    objItem.CategoryName = Convert.ToString(objSQLReader1["CategoryName"]);
                  
                   
                    lstItem.Add(objItem);
                }

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
             return lstItem;
        }

        /// <summary>
        /// Function to view list of items having names similar to the name entered by user and selected category
        /// </summary>
        /// <param name="name"> item name entered by user </param>
        /// <param name="categoryId"> item category selected by user </param>
        /// <returns> list of items having names similar to the name entered by user and selected category</returns>
        public List<IItem> GetItemList(int categoryId, string name)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IItem> lstItem = new List<IItem>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_SearchItembynameAndCategory", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@ItemName", name);
                objSQLCommand.Parameters["@ItemName"].Direction = System.Data.ParameterDirection.Input;
                objSQLCommand.Parameters.AddWithValue("@ItemCategory", categoryId);
                objSQLCommand.Parameters["@ItemCategory"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader1 = objSQLCommand.ExecuteReader();

                while (objSQLReader1.Read())
                {
                    IItem objItem = TCS.ISMS.BOFactory.ViewItemBOFactory.CreateItemobject();
                    objItem.ItemID = Convert.ToInt32(objSQLReader1["ItemID"]);
                    objItem.ItemName = objSQLReader1["ItemName"].ToString();
                    
                    objItem.ItemPrice = Convert.ToDouble(objSQLReader1["ItemPrice"]);
                    objItem.ItemDiscount = Convert.ToInt32(objSQLReader1["ItemDiscount"]);
                    objItem.ItemClosingCount = Convert.ToInt32(objSQLReader1["ItemClosingCount"]);
                    objItem.ItemCategory = Convert.ToInt32(objSQLReader1["CategoryID"]);
                    objItem.ItemQuantity = Convert.ToInt32(objSQLReader1["Quantity"]);
                    objItem.CategoryName = Convert.ToString(objSQLReader1["CategoryName"]);


                    lstItem.Add(objItem);
                }

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
            return lstItem;
        }

        public bool SaveReportofNotAvalableItems(List<IItem> itemslst)
        {
            bool addednonavailableitems = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
           
               

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_saveNotAvailableItems", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLConn.Open();
                foreach (IItem items in itemslst)
                {
                    objSQLCommand.Parameters.Clear();
                    objSQLCommand.Parameters.AddWithValue("@ItemID", items.ItemID);
                    objSQLCommand.Parameters.AddWithValue("@ItemName", items.ItemName);
                    objSQLCommand.Parameters.AddWithValue("@Quantity", items.ItemQuantity);
                    objSQLCommand.Parameters.AddWithValue("@ItemPrice", items.ItemPrice);
                    objSQLCommand.Parameters.AddWithValue("@CategoryName", items.CategoryName);
                    objSQLCommand.Parameters.AddWithValue("@CategoryID", items.ItemCategory);


                   
                    objSQLCommand.ExecuteNonQuery();
                   
                }
                objSQLConn.Close();
                addednonavailableitems = true;
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
            return addednonavailableitems;

          
           
        }

        /// <summary>
        /// Function to get searched bill details
        /// </summary>
        /// <param name="billNumber">  User selected billNumber </param>
        /// <returns> list of attributes of bill details based on bill number </returns>
        public List<ICustomerBill> SearchBillDetails(int billNumber)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            List<ICustomerBill> lstBill = new List<ICustomerBill>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_GetBillDetails", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLConn.Open();

                objSQLCommand.Parameters.AddWithValue("@BillNumber", billNumber);
                objSQLCommand.Parameters["@BillNumber"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader1 = objSQLCommand.ExecuteReader();


                while (objSQLReader1.Read())
                {
                    ICustomerBill objBill = CustomerBillBOFactory.CreateCustomerBillObject();
                    objBill.BillNumber = Convert.ToInt32(objSQLReader1["BillNumber"]);
                    objBill.EmployeeId = Convert.ToInt32(objSQLReader1["EmployeeID"]);

                    objBill.CustomerName = objSQLReader1["CustomerName"].ToString();
                    objBill.BillDate = Convert.ToDateTime(objSQLReader1["BillDate"]);
                    objBill.TotalBillAmount = Convert.ToDouble(objSQLReader1["TotalBillAmount"]);

                    lstBill.Add(objBill);
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
            return lstBill;

        }

    }
}
