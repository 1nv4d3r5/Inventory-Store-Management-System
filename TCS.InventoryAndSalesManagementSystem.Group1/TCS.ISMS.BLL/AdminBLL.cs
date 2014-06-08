////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an AdminBLL class which implements IAdmin interface.
// ---------------------------------------------------------------------------------
//	Date Created         : April 19, 2013
//  Author               :  Suman Pradhan, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		 :  April 25, 2013
//	Changed By		     :  Suman Pradhan
//	Change Description   :  Data Binding for drop down list for Item Category.
//
//-----------------------------------------------------------------------------------
//
//  Data Modified        : April 26, 2013
//	Changed By		     :  Arshin Saluja
//	Change Description   :  Data Binding for drop down list for role.
//
//----------------------------------------------------------------------------------
//
//  Data Modified        : April 27, 2013 
//  Changed By           :  Suman Pradhan
//  Change Description   :  Added a Get Item Details Method.
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.DALFactory;

namespace TCS.ISMS.BLL
{
    public class AdminBLL : IAdminBLL
    {
        public bool AddEmployeeDetails(IEmployee objEmployee)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.AddEmployeeDetails(objEmployee);
        }

        public void SaveCategory(string name)
        {

            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            objDAL.SaveCategory(name);
        }


        public bool UpdateEmployeeDetails(List<IEmployee> lstEmployee)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.UpdateEmployeeDetails(lstEmployee);
        }


        public bool DeleteEmployeeDetails(List<int> lstEmployee)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.DeleteEmployeeDetails(lstEmployee);
        }

        public bool UpdateEmployee(IEmployee objEmployee)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.UpdateEmployee(objEmployee);
        }

        public List<IEmployee> GetEmployeeDetailsList()
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.GetEmployeeDetailsList();
        }

        public List<IEmployee> GetEmployeeDetailsList(string name)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.GetEmployeeDetailsList(name);
        }

        public IEmployee GetEmployee(int employeeID)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.GetEmployee(employeeID);
        }

        public List<IRole> GetRoleList()
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.GetRoleList();
        }

         public int ChkLogInCredentials(ILogin objLogIn)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.ChkLogInCredentials(objLogIn);
        }

         public ILogon GetUserMenu(ILogin loginDetails)
         {
             IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
             return objDAL.GetUserMenu(loginDetails);
         }

        public bool AddItemDetails(IItem objItem)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.AddItemDetails(objItem);
        }


        public bool UpdateItemDetails(IItem objItem)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.UpdateItemDetails(objItem);
        }

        public List<IItem> GetItemDetails(int CategoryId)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.GetItemDetails(CategoryId);
        }

        public bool DeleteItemDetails(List<int> ItemID)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.DeleteItemDetails(ItemID);
        }
        public List<IItemCategory> GetCategoryList()
        { 
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.GetCategoryList();
        
        }
        public IItem GetItemByItemId(int itemId)
        {
            IAdminDAL objDAL = AdminDALFactory.CreateAdminDALObject();
            return objDAL.GetItemByItemId(itemId);
        }

        public bool CheckEmpID(int empID)
        {
            IAdminDAL objDAL = DALFactory.AdminDALFactory.CreateAdminDALObject();
            return objDAL.CheckEmpID(empID);
        }

        public bool ValidateSecurity(int empid, string answer)
        {
            IAdminDAL objDAL = TCS.ISMS.DALFactory.AdminDALFactory.CreateAdminDALObject();
            return objDAL.ValidateSecurity(empid, answer);
        }
        public bool ChangePassword(int empid,string password)
    {
        IAdminDAL objDAL = TCS.ISMS.DALFactory.AdminDALFactory.CreateAdminDALObject();
          return objDAL.ChangePassword(empid,password);
    }
    
    }
}
