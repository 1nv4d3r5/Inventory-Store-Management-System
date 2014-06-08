//File Description	: This is the code for Sales Manager DAL
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 1, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added GetBillList Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 2, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added GetMoneyTransaction Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added GenerateReportCategoryWise Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added GenerateReportDateWise Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added View Money Transaction Function
//
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using System.Data.SqlClient;
using TCS.ISMS.BOFactory;

namespace TCS.ISMS.DAL
{
    public class SalesManagerDAL : ISalesManager
    {
        string strConnectionString =
               "Data Source=ingnrilpsql02;" +
               "Initial Catalog=AHD21_A104_Group1;" +
               "User id=a36;" +
               "Password=a36;";

        // <summary>
        /// This method will display the bill details .
        /// </summary>
        /// <returns>returns the list of bills generated on that date</returns>
        public List<ICustomerBill> GetBillList(DateTime date)
        {
            SqlConnection objSqlConn = null;
            SqlCommand objSqlCommand = null;
           
            List<ICustomerBill> custBillList = new List<ICustomerBill>();

            try
            {
                objSqlConn = new SqlConnection(strConnectionString);

                objSqlCommand = new SqlCommand("usp_viewBillByDate", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();
                objSqlCommand.Parameters.AddWithValue("@BillDate", date);
                objSqlCommand.Parameters["@BillDate"].Direction = System.Data.ParameterDirection.Input;
                    

                SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
                while (objSqlReader.Read())
                {
                    ICustomerBill objBill = CustomerBillBOFactory.CreateCustomerBillObject() ;
                    objBill.BillNumber = Convert.ToInt32(objSqlReader["BillNumber"]);
                    objBill.CustomerName = objSqlReader["CustomerName"].ToString();
                    objBill.TotalBillAmount = Convert.ToInt32(objSqlReader["TotalBillAmount"]);


                    custBillList.Add(objBill);
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


            return custBillList;
        }
        // <summary>
        /// This method will display the money transaction .
        /// </summary>
        /// <returns>returns the list of bills generated on that date</returns>
        public List<IViewMoneyTransaction> GetMoneyTransaction(DateTime date)
        {
            List<IViewMoneyTransaction> viewMoneyTrans = new List<IViewMoneyTransaction>();
            SqlConnection objSqlConn = null;
            SqlCommand objSqlCommand = null;

           try
            {
                objSqlConn = new SqlConnection(strConnectionString);

                objSqlCommand = new SqlCommand("usp_viewMoneyTransaction", objSqlConn);
                objSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSqlConn.Open();
                objSqlCommand.Parameters.AddWithValue("@BillDate", date);
                objSqlCommand.Parameters["@BillDate"].Direction = System.Data.ParameterDirection.Input;


                SqlDataReader objSqlReader = objSqlCommand.ExecuteReader();
                while (objSqlReader.Read())
                {
                    IViewMoneyTransaction objBill = ViewMoneyTransactionBOFactory.CreateViewMoneyTransactionObject();
                    objBill.BillNo = Convert.ToInt32(objSqlReader["BillNumber"]);
                    objBill.AmountReceived= Convert.ToDouble(objSqlReader["MoneyIn"]);
                    objBill.AmountReturned = Convert.ToDouble(objSqlReader["ReturnAmount"]);
                    objBill.TotalPrice = Convert.ToInt32(objSqlReader["TotalBillAmount"]);


                    viewMoneyTrans.Add(objBill);
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


           return viewMoneyTrans;
        }
        
        public List<ICustomerBill> GetCancelledBillList(DateTime d)
        {
            
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            List<ICustomerBill> custBillList = new List<ICustomerBill>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetCancelledBills", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                   objSQLCommand.Parameters.AddWithValue("@BillDate", d);
                objSQLCommand.Parameters["@BillDate"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    ICustomerBill objCustCancelledBill = CustomerBillBOFactory.CreateCustomerBillObject();

                    objCustCancelledBill.BillDate = (DateTime)((objSQLReader["BillDate"]));
                    objCustCancelledBill.BillNumber = Convert.ToInt32(objSQLReader["BillNumber"]);

                    objCustCancelledBill.EmployeeId = Convert.ToInt32(objSQLReader["EmployeeID"]);
                    objCustCancelledBill.CustomerName = (objSQLReader["CustomerName"]).ToString();
                    objCustCancelledBill.TotalBillAmount = Convert.ToDouble((objSQLReader["TotalBillAmount"]));
                  
                    objCustCancelledBill.MoneyIn = Convert.ToDouble(objSQLReader["MoneyIn"]);
                    objCustCancelledBill.TotalMoneyReturned = Convert.ToDouble(objSQLReader["ReturnAmount"]);
                    objCustCancelledBill.BillStatus = (objSQLReader["BillStatus"]).ToString();

                    custBillList.Add(objCustCancelledBill);
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
            
            
            return custBillList;
        
        }

        public List<IReturnedItems> GetReturnedItemList(DateTime d)
        {
            




            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            List<IReturnedItems> retunedItemList = new List<IReturnedItems>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_ViewReturnedItems", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@Date", d);
                objSQLCommand.Parameters["@Date"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IReturnedItems objReturnedItems = ReturnedItemBOFactory.CreateReturnedItemsObject();

                    objReturnedItems.BillNo = Convert.ToInt32((objSQLReader["BillNumber"]));
                    objReturnedItems.ItemID = Convert.ToInt32(objSQLReader["ItemID"]);

                    objReturnedItems.Name =(objSQLReader["ItemName"]).ToString();
                    objReturnedItems.Remarks = (objSQLReader["Remark"]).ToString();
                    objReturnedItems.Quantity = Convert.ToInt32((objSQLReader["QuantityReturned"]));


                    retunedItemList.Add(objReturnedItems);
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


            return retunedItemList;
        }
        // <summary>
        /// This method generate report category wise.
        /// </summary>
        /// <returns>returns list of items report categorywise.</returns>
        public List<ICategoryWiseSale> GenerateReportCategoryWise(DateTime d1, DateTime d2)
        {
            List<ICategoryWiseSale> lstReportCategoryWise = new List<ICategoryWiseSale>();
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_ReportCategoryWiseSM", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@BillDate1", d1);
                objSQLCommand.Parameters["@BillDate1"].Direction = System.Data.ParameterDirection.Input;
                objSQLCommand.Parameters.AddWithValue("@BillDate2", d2);
                objSQLCommand.Parameters["@BillDate2"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    ICategoryWiseSale objCategoryWiseSale = CategoryWiseSalesBOFactory.CreateCategoryWiseSalesObject();

                    objCategoryWiseSale.Date = Convert.ToDateTime(objSQLReader["BillDate"]);
                    objCategoryWiseSale.CategoryName = objSQLReader["CategoryName"].ToString();
                    objCategoryWiseSale.TotalSales = Convert.ToDouble(objSQLReader["TotalSales"]);

                    lstReportCategoryWise.Add(objCategoryWiseSale);
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
        // <summary>
        /// This method generate report date wise.
        /// </summary>
        /// <returns>returns list of items report datewise.</returns>
        public List<IDateWiseSale> GenerateReportDateWise(DateTime d1,DateTime d2)
        {
            List<IDateWiseSale> dateWiseSale = new List<IDateWiseSale>();
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

           try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_reportDateWise", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@BillDate1", d1);
                objSQLCommand.Parameters["@BillDate1"].Direction = System.Data.ParameterDirection.Input;
                objSQLCommand.Parameters.AddWithValue("@BillDate2", d2);
                objSQLCommand.Parameters["@BillDate2"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IDateWiseSale objDateWiseSale = DateWiseSalesBOFactory.CreateDateWiseSalesObject();
                    objDateWiseSale.Date = (DateTime)((objSQLReader["BillDate"]));
                    objDateWiseSale.TotalSales = Convert.ToDouble(objSQLReader["TotalSales"]);
                    objDateWiseSale.ItemName =objSQLReader["ItemName"].ToString();
                    
                    dateWiseSale.Add(objDateWiseSale);
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

            return dateWiseSale;
        
        }

    }
}
