////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an interface for AdminBLL .
// ---------------------------------------------------------------------------------
//	Date Created        : April 19, 2013
//  Author              : Suman Pradhan,Tata Consultancy Service
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		 :  April 25, 2013
//	Changed By		     :  Suman Pradhan
//	Change Description   :  Added new method get category list.
//
//----------------------------------------------------------------------------------
//  Date Modified		 :  April 26, 2013
//	Changed By		     :  Arshin Saluja
//	Change Description   :  Added new method get role list.
//
//----------------------------------------------------------------------------------
//Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Amit Nadkarni
//	Change Description   : Edited Data Types 
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IAdminBLL
    {
        
        bool AddEmployeeDetails(IEmployee objEmployee);
        

         bool UpdateEmployeeDetails(List<IEmployee> lstEmployee);



         bool DeleteEmployeeDetails(List<int> lstEmployee);

         List<IEmployee> GetEmployeeDetailsList(string name);

         List<IEmployee> GetEmployeeDetailsList();

         List<IRole> GetRoleList();

         IEmployee GetEmployee(int employeeID);

        // logon & login

         ILogon GetUserMenu(ILogin loginDetails);

         int ChkLogInCredentials(ILogin objLogIn);

         bool UpdateEmployee(IEmployee objEmployee);
        //Items
         bool AddItemDetails(IItem objItem);
        


         bool UpdateItemDetails(IItem objItem);
         bool CheckEmpID(int empID);

         List<IItem> GetItemDetails(int CategoryId);


         bool DeleteItemDetails(List<int> ItemID);

         List<IItemCategory> GetCategoryList();
         IItem GetItemByItemId(int itemId);
         void SaveCategory(string name);
        bool ValidateSecurity(int empid,string answer);
        bool ChangePassword(int empid,string password);
    }
}
