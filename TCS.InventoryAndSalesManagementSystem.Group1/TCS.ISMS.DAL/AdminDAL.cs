////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an employee DAL which contains various admin functionalities and implements IAdminDAL.
// ---------------------------------------------------------------------------------
//	Date Created		:     April 19, 2013
//	Author			    :     Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
//
//  Change History
//  Data Modified          :April 25, 2013
//  Changed By             :Suman Pradhan
//  Change Description     :Edited methods Add Item Details and Get Category List . 
//
//-------------------------------------------------------------------------------------
//
//	Date Modified		 :  April 26, 2013
//	Changed By		     :  Arshin Saluja
//	Change Description   :  Edited methods get employee and get role list.
//------------------------------------------------------------------------------------- 
//
//  Date Modified		 : April 29, 2013
//	Changed By		     : Arshin Saluja
//	Change Description   : Edited method delete employee details .
//
//--------------------------------------------------------------------------------------
//
//Data Modified          :April 29, 2013
//Changed By             :Suman Pradhan
//Change Description     :Added Get Item Details method and Edited Delete Item Details .
//
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using System.Data.SqlClient;
using TCS.ISMS.BOFactory;




namespace TCS.ISMS.DAL
{
    public class AdminDAL : IAdminDAL
    {
        string strConnectionString =
               "Data Source=ingnrilpsql02;" +
               "Initial Catalog=AHD21_A104_Group1;" +
               "User id=a36;" +
               "Password=a36;";

        //Employee functionalities.
        /// <summary>
        /// To add a new employee.
        /// </summary>
        /// <param name="objEmployee">object of Employee class</param>
        /// <returns>returns true or false</returns>
        public bool AddEmployeeDetails(IEmployee objEmployee)
        {
            bool isAdded=false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

             try
            {
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_addEmployee", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@EmployeeFirstName", objEmployee.FirstName);
                objSQLCommand.Parameters.AddWithValue("@EmployeeLastName", objEmployee.LastName);
                objSQLCommand.Parameters.AddWithValue("@RoleId", objEmployee.RoleId);
                objSQLCommand.Parameters.AddWithValue("@DateOfBirth", objEmployee.Dob);
                objSQLCommand.Parameters.AddWithValue("@DateOfJoining", objEmployee.Doj);
                objSQLCommand.Parameters.AddWithValue("@Address", objEmployee.Address);
                objSQLCommand.Parameters.AddWithValue("@State", objEmployee.State);
                objSQLCommand.Parameters.AddWithValue("@City", objEmployee.City);
                objSQLCommand.Parameters.AddWithValue("@ContactNumber", objEmployee.MobileNumber);

                objSQLCommand.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
                objSQLCommand.Parameters["@EmployeeID"].Direction = System.Data.ParameterDirection.Output;

                objSQLConn.Open();
                int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
                if (noOfRowsAffected > 0)
                  objEmployee.EmployeeId   = Convert.ToInt32(objSQLCommand.Parameters["@EmployeeID"].Value);
                  isAdded = true;

                  objSQLCommand = new SqlCommand("usp_addToLoginDetails", objSQLConn);
                  objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                  objSQLCommand.Parameters.AddWithValue("@EmployeeID", objEmployee.EmployeeId);
                  objSQLCommand.Parameters.AddWithValue("@RoleId", objEmployee.RoleId);
                  string pwd = string.Empty;
                  pwd = (objEmployee.Dob.Month).ToString() + (objEmployee.Dob.Day).ToString()+(objEmployee.Dob.Year).ToString();
                  objSQLCommand.Parameters.AddWithValue("@Password", pwd);

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

            return isAdded;
        }


        /// <summary>
        /// This method get the list of role tags.
        /// </summary>
        /// <returns>returns list of roles.</returns>
        public List<IRole> GetRoleList()
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IRole> lstRole = new List<IRole>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetRoleDetails", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IRole objRole = RoleBOFactory.CreateRoleObject();
                    objRole.RoleId = Convert.ToInt32(objSQLReader["RoleID"]);
                    objRole.RoleName = Convert.ToString(objSQLReader["RoleName"]);
                    

                    lstRole.Add(objRole);
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
            return lstRole;


        }


        /// <summary>
        /// This method updates the role of the employee.
        /// </summary>
        /// <param name="lstEmployee"></param>
        /// <returns>returns true or false</returns>
        public bool UpdateEmployeeDetails(List<IEmployee> lstEmployee)
        {
            bool isUpdated=false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {

                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();
                
                foreach (IEmployee objEmployee in lstEmployee)
                {
                
                    
                    objSQLCommand = new SqlCommand("usp_updateEmployeeDetails", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objSQLCommand.Parameters.AddWithValue("@EmployeeID", objEmployee.EmployeeId);
                    objSQLCommand.Parameters.AddWithValue("@RoleId", objEmployee.RoleId);
                    isUpdated = true;
                    objSQLCommand.ExecuteNonQuery();
                    

                }
                objSQLConn.Close();
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

            return isUpdated;
                 
        }

        /// <summary>
        /// This method deletes the employee from the list of employees.
        /// </summary>
        /// <param name="lstEmployee">List of employees</param>
        /// <returns>returns true or false</returns>
        public bool DeleteEmployeeDetails(List<int> lstEmployee)
        {
            bool isDeleted = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            //List<IVendor> lstEmployeeDetail = new List<IVendor>();
            //IVendor objVendorDetail = VendorBOFactory.CreateVendorObject();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();
                foreach (int employeeId in lstEmployee)
                {
                    objSQLCommand = new SqlCommand("[usp_UpdateEmployee]", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    objSQLCommand.Parameters.AddWithValue("@EmployeeID", employeeId);
                    objSQLCommand.Parameters["@EmployeeID"].Direction = System.Data.ParameterDirection.Input;

                    objSQLCommand.ExecuteNonQuery();
                }
                isDeleted = true;
                return isDeleted;
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
        }


        /// <summary>
        /// This method displays the list of employees working in the organisation.
        /// </summary>
        /// <returns>returns the list of employees</returns>
        public List<IEmployee> GetEmployeeDetailsList()
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IEmployee> lstEmployee = new List<IEmployee>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetEmployeeDetails", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
                    objEmployee.EmployeeId = Convert.ToInt32(objSQLReader["EmployeeID"]);
                    objEmployee.FirstName = Convert.ToString(objSQLReader["EmployeeFirstName"]);
                    objEmployee.LastName = Convert.ToString(objSQLReader["EmployeeLastName"]);
                    objEmployee.RoleName = Convert.ToString(objSQLReader["RoleName"]);
                    objEmployee.Dob = Convert.ToDateTime(objSQLReader["DateOfBirth"]);
                    objEmployee.Doj = Convert.ToDateTime(objSQLReader["DateOfJoining"]);
                    objEmployee.Address = Convert.ToString(objSQLReader["Address"]);
                    objEmployee.City = Convert.ToString(objSQLReader["State"]);
                    objEmployee.State = Convert.ToString(objSQLReader["City"]);
                    objEmployee.MobileNumber = Convert.ToInt64(objSQLReader["ContactNumber"]);

                    lstEmployee.Add(objEmployee);
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
            return lstEmployee;
        }


        public List<IEmployee> GetEmployeeDetailsList(string name)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IEmployee> lstEmployee = new List<IEmployee>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetEmployeeDetailsByName", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@name", name);

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
                    objEmployee.EmployeeId = Convert.ToInt32(objSQLReader["EmployeeID"]);
                    objEmployee.FirstName = Convert.ToString(objSQLReader["EmployeeFirstName"]);
                    objEmployee.LastName = Convert.ToString(objSQLReader["EmployeeLastName"]);
                    objEmployee.RoleName = Convert.ToString(objSQLReader["RoleName"]);
                    objEmployee.Dob = Convert.ToDateTime(objSQLReader["DateOfBirth"]);
                    objEmployee.Doj = Convert.ToDateTime(objSQLReader["DateOfJoining"]);
                    objEmployee.Address = Convert.ToString(objSQLReader["Address"]);
                    objEmployee.City = Convert.ToString(objSQLReader["State"]);
                    objEmployee.State = Convert.ToString(objSQLReader["City"]);
                    objEmployee.MobileNumber = Convert.ToInt64(objSQLReader["ContactNumber"]);

                    lstEmployee.Add(objEmployee);
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
            return lstEmployee;
        }

        /// <summary>
        /// This method fetch a particular recird from the data base for the view profile page.
        /// </summary>
        /// <returns>returns object of employee BO</returns>
        public IEmployee GetEmployee(int employeeID)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();
           
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetEmployee", objSQLConn);
                objSQLCommand.Parameters.AddWithValue("@EmployeeID", employeeID);
                objSQLCommand.Parameters["@EmployeeID"].Direction = System.Data.ParameterDirection.Input;

                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    
                    objEmployee.EmployeeId = Convert.ToInt32(objSQLReader["EmployeeID"]);
                    objEmployee.FirstName = Convert.ToString(objSQLReader["EmployeeFirstName"]);
                    objEmployee.LastName = Convert.ToString(objSQLReader["EmployeeLastName"]);
                    objEmployee.RoleName = Convert.ToString(objSQLReader["RoleName"]);
                    objEmployee.Dob = Convert.ToDateTime(objSQLReader["DateOfBirth"]);
                    objEmployee.Doj = Convert.ToDateTime(objSQLReader["DateOfJoining"]);
                    objEmployee.Address = Convert.ToString(objSQLReader["Address"]);
                    objEmployee.City = Convert.ToString(objSQLReader["City"]);
                    objEmployee.State = Convert.ToString(objSQLReader["State"]);
                    objEmployee.MobileNumber = Convert.ToInt64(objSQLReader["ContactNumber"]);

                   // lstEmployee.Add(objEmployee);
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
            return objEmployee;
        }


        public bool UpdateEmployee(IEmployee objEmployee)
        {
            bool isUpdated=false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {

                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                    objSQLCommand = new SqlCommand("usp_UpdateEmployeeViewProfile", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objSQLCommand.Parameters.AddWithValue("@EmployeeID", objEmployee.EmployeeId);
                    objSQLCommand.Parameters.AddWithValue("@Address" , objEmployee.Address);
                    objSQLCommand.Parameters.AddWithValue("@State", objEmployee.State);
                    objSQLCommand.Parameters.AddWithValue("@City",objEmployee.City);
                    objSQLCommand.Parameters.AddWithValue("@ContactNumber", objEmployee.MobileNumber);
                    isUpdated = true;
                    objSQLCommand.ExecuteNonQuery();
                    
                objSQLConn.Close();
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

            return isUpdated;
        }
        /// <summary>
        /// This method verifies the login and password and if valid redirects the user to the home page.
        /// </summary>
        /// <returns>returns true or false</returns>
        public int ChkLogInCredentials(ILogin objLogIn)
        {
            
            //bool isValid = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            int roleId = 0;

            try
            {
                
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();
                objSQLCommand = new SqlCommand("usp_ChkLogin", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@EmployeeID", objLogIn.EmployeeId);
                objSQLCommand.Parameters.AddWithValue("@Password", objLogIn.Password);

                 roleId = Convert.ToInt32(objSQLCommand.ExecuteScalar());
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
            return roleId;
        }




        public ILogon GetUserMenu(ILogin loginDetails)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            
            ILogon objLogOn = LogonBOFactory.CreateLogonObject();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetUserName", objSQLConn);

                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@EmployeeID",loginDetails.EmployeeId);
                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    
                    //objLogOn.EmployeeId = Convert.ToInt32(objSQLReader["EmployeeID"]);
                    objLogOn.EmployeeName = Convert.ToString(objSQLReader["EmployeeFirstName"])+" "+Convert.ToString(objSQLReader["EmployeeLastName"]);
                    objLogOn.RoleName = Convert.ToString(objSQLReader["RoleName"]);
                    objLogOn.EmployeeId = Convert.ToInt32(objSQLReader["EmployeeID"]);
                    
                }

                objSQLReader.Close();

                objSQLCommand = new SqlCommand("usp_GetMenuItems", objSQLConn);

                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@RoleID", loginDetails.Role);
                
                SqlDataReader objSQLReader1 = objSQLCommand.ExecuteReader();
                List<IMenu> menuList = new List<IMenu>();
                while (objSQLReader1.Read())
                {
                    
                    IMenu menuItem=MenuBOFactory.CreateMenuObject();
                    menuItem.MenuId = Convert.ToInt32(objSQLReader1["MenuID"]);
                    menuItem.MenuName = Convert.ToString(objSQLReader1["Title"]);
                    menuItem.ToolTip = Convert.ToString(objSQLReader1["ToolTip"]);
                    menuItem.NavigationUrl = Convert.ToString(objSQLReader1["NavigationURL"]); 
                    menuItem.ParentMenuId = Convert.ToInt32(objSQLReader1["RoleID"]); 

                    menuList.Add(menuItem);

                }
                objLogOn.MenoBo = menuList;

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
            return objLogOn;



        }

        //Items
        //Items functionalities.
        /// <summary>
        /// To add a new item.
        /// </summary>
        /// <param name="objEmployee">object of Item class</param>
        /// <returns>returns true or false</returns>
        public bool AddItemDetails(IItem objItem)
        {
            bool canAdd = false;

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_addItemDetails", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@ItemName", objItem.ItemName);
                objSQLCommand.Parameters.AddWithValue("@CategoryID", objItem.ItemCategory);
                objSQLCommand.Parameters.AddWithValue("@Quantity", objItem.ItemQuantity);
                objSQLCommand.Parameters.AddWithValue("@ItemPrice", objItem.ItemPrice);
                objSQLCommand.Parameters.AddWithValue("@ItemDiscount", objItem.ItemDiscount);
                objSQLCommand.Parameters.AddWithValue("@ItemClosingCount", objItem.ItemClosingCount);
                objSQLCommand.Parameters.Add("@ItemID", System.Data.SqlDbType.Int);
                objSQLCommand.Parameters["@ItemID"].Direction = System.Data.ParameterDirection.Output;
                objSQLConn.Open();
                int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
                if (noOfRowsAffected > 0)
                    objItem.ItemID = Convert.ToInt32(objSQLCommand.Parameters["@ItemID"].Value);
                canAdd = true;

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

            return canAdd;
        }



        public bool UpdateItemDetails(IItem objItem)
        {
            bool isUpdated = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {

                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                //foreach (IEmployee objEmployee in lstEmployee)
                {

                    objSQLCommand = new SqlCommand("usp_updateItemDetails", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    objSQLCommand.Parameters.AddWithValue("@ItemID", objItem.ItemID);
                    objSQLCommand.Parameters.AddWithValue("@ItemName", objItem.ItemName);
                    objSQLCommand.Parameters.AddWithValue("@Quantity", objItem.ItemQuantity);
                    objSQLCommand.Parameters.AddWithValue("@ItemPrice", objItem.ItemPrice);
                    objSQLCommand.Parameters.AddWithValue("@ItemDiscount", objItem.ItemDiscount);
                    objSQLCommand.Parameters.AddWithValue("@ItemClosingCount", objItem.ItemClosingCount);
                    objSQLCommand.Parameters.AddWithValue("@CategoryID", objItem.ItemCategory);
                    //objSQLCommand.Parameters.AddWithValue("@ITEMSTATUS", objItem.);
                   
                    
                   if( objSQLCommand.ExecuteNonQuery()>0);
                   isUpdated = true;
                }
                objSQLConn.Close();
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

            return isUpdated;
                 
        
        }
        /// <summary>
        /// This method wil display the items of selected category.
        /// </summary>
        /// <returns>returns the list of items</returns>
        public List<IItem> GetItemDetails(int CategoryId)
        {
           
            SqlConnection objSqlConn = null;
            SqlCommand objSqlCommand = null;
            List<IItem> itemList = new List<IItem>();

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
        /// This method deletes the items from the list of items.
        /// </summary>
        /// <param name="ItemID">List of Items</param>
        /// <returns>returns true or false</returns>
        public bool DeleteItemDetails(List<int> ItemID)
        {
            bool isDeleted = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
           try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();
                for(int i=0;i<ItemID.Count;i++)
                {
                    objSQLCommand = new SqlCommand("usp_deleteItems", objSQLConn);
                    objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    objSQLCommand.Parameters.AddWithValue("@ItemID", ItemID[i]);
                    objSQLCommand.Parameters["@ItemID"].Direction = System.Data.ParameterDirection.Input;

                    objSQLCommand.ExecuteNonQuery();
                }
                isDeleted = true;
                return isDeleted;
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
        }

        /// <summary>
        /// This method get the list of Item Category .
        /// </summary>
        /// <returns>returns list of category.</returns>
        public List<IItemCategory> GetCategoryList()
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IItemCategory> lstCategory = new List<IItemCategory>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_getitemcategory", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    IItemCategory objCategory = ItemCategotyBOFactory.CreateItemCategoryObject();
                    objCategory.CategoryId= Convert.ToInt32(objSQLReader["CategoryID"]);
                    objCategory.CategoryName= Convert.ToString(objSQLReader["CategoryName"]);


                    lstCategory.Add(objCategory);
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
            return lstCategory;


        }


       public void SaveCategory(string name)
        {
          

            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);

                objSQLCommand = new SqlCommand("usp_AddCategory", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@CategoryName", name);
               
               
                objSQLConn.Open();
                int noOfRowsAffected = objSQLCommand.ExecuteNonQuery();
             
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

           
        }

        public IItem GetItemByItemId(int itemId)
        {
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            IItem objItem = ViewItemBOFactory.CreateItemobject ();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_GetItemByItemId", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objSQLCommand.Parameters.AddWithValue("@ItemID", itemId);
                objSQLCommand.Parameters["@ItemID"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader = objSQLCommand.ExecuteReader();

                while (objSQLReader.Read())
                {
                    /*IEmployee objEmployee = EmployeeBOFactory.CreateEmployeeObject();*/
                    objItem.ItemID       = Convert.ToInt32(objSQLReader["ItemID"]);
                    objItem.ItemName     = Convert.ToString(objSQLReader["ItemName"]);
                    objItem.ItemPrice    = Convert.ToInt32(objSQLReader["ItemPrice"]);
                    objItem.ItemQuantity = Convert.ToInt32(objSQLReader["Quantity"]);
                    objItem.ItemCategory = Convert.ToInt32(objSQLReader["CategoryID"]);
                    objItem.ItemDiscount = Convert.ToInt32(objSQLReader["ItemDiscount"]);
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
            return objItem;
           
        }

        public bool CheckEmpID(int empID)
        {
            bool isfound=false;
            
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IItem> lstItem = new List<IItem>();

             try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_checkEmployeeID", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@EmployeeID", empID);
                objSQLCommand.Parameters["@EmployeeID"].Direction = System.Data.ParameterDirection.Input;

                SqlDataReader objSQLReader1 = objSQLCommand.ExecuteReader();

                while (objSQLReader1.Read())
                {
                    isfound = true;
                      
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
             return isfound;
        }

        public bool ValidateSecurity(int empid, string answer)
        {
            bool isvalid = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            List<IItem> lstItem = new List<IItem>();

            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_checkSecurityAnswer", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@EmployeeID", empid);
                objSQLCommand.Parameters["@EmployeeID"].Direction = System.Data.ParameterDirection.Input;
                objSQLCommand.Parameters.AddWithValue("@SecurityAnswer", answer);
                objSQLCommand.Parameters["@SecurityAnswer"].Direction = System.Data.ParameterDirection.Input;
                SqlDataReader objSQLReader1 = objSQLCommand.ExecuteReader();

                while (objSQLReader1.Read())
                {
                    isvalid = true;

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
            return isvalid;

        }

        public bool ChangePassword(int empid,string password)
        {
            bool isUpdated = false;
            SqlConnection objSQLConn = null;
            SqlCommand objSQLCommand = null;
            
            try
            {
                objSQLConn = new SqlConnection(strConnectionString);
                objSQLConn.Open();

                objSQLCommand = new SqlCommand("usp_updatepswrd", objSQLConn);
                objSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objSQLCommand.Parameters.AddWithValue("@EmployeeID", empid);
                objSQLCommand.Parameters["@EmployeeID"].Direction = System.Data.ParameterDirection.Input;
                objSQLCommand.Parameters.AddWithValue("@Password", password);

                isUpdated = true;
                objSQLCommand.ExecuteNonQuery();
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

        }
       
    }

