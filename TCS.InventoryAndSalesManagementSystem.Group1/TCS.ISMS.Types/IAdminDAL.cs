////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an interface for AdminDAL class.
// ---------------------------------------------------------------------------------
//	Date Created		:     April 19, 2013
//	Author			    :     Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Data Modified       :   April 25. 2013
//  Changed By          :   Suman Pradhan
//  Change Description  :   Added method get Category list. 
//----------------------------------------------------------------------------------
//
//  Date Modified		 :  April 26, 2013
//	Changed By		     :  Arshin Saluja
//	Change Description   :  Added method get Role list.
//----------------------------------------------------------------------------------
//
//  Data Modified        :  April 27, 2013
//  Changed By           :  Suman Pradhan
//  Change Description   :  Added method get Item details list.
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
   public  interface IAdminDAL
    {
        //Employee functionalities
       bool AddEmployeeDetails(IEmployee objEmployee);

         bool UpdateEmployeeDetails(List<IEmployee> lstEmployee);



         bool DeleteEmployeeDetails(List<int> lstEmployee);

         List<IRole> GetRoleList();

         List<IEmployee> GetEmployeeDetailsList();

         List<IEmployee> GetEmployeeDetailsList(string name);

         IEmployee GetEmployee(int employeeID);

         bool UpdateEmployee(IEmployee objEmployee);

       // login & logon

         int ChkLogInCredentials(ILogin objLogIn);

         ILogon GetUserMenu(ILogin loginDetails);

         //Items functionalities
         bool AddItemDetails(IItem objItem);

         bool UpdateItemDetails(IItem objItem);

         List<IItem> GetItemDetails(int CategoryId);

         bool DeleteItemDetails(List<int> ItemID);
         List<IItemCategory> GetCategoryList();
         IItem GetItemByItemId(int itemId);
          void SaveCategory(string name);
          bool CheckEmpID(int empID);
       bool ValidateSecurity(int empid,string answer);
       bool ChangePassword(int empid,string password);

    }
}
