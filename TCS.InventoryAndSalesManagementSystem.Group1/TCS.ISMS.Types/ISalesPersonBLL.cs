////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an interface for SalesPersonBLL which is implemented by SalesPersonBLL class.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		 :  April 25, 2013
//	Changed By		     :  Susmita Rana
//	Change Description   :  Added GetItemList method signature having one parameter CategoryId.
// -----------------------------------------------------------------------------------
//
//  Date Modified        : May 2, 2013
//  Changed By           : Susmita Rana
//  Change Description#  : Added function for SearchBillDetails. 
// -----------------------------------------------------------------------------------
//
//  Date Modified        : May 2, 2013
//  Changed By           : Susmita Rana
//  Change Description#  : Added function for CancelBill. 
///////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface ISalesPersonBLL
    {
        List<IItem> GetItemList(int CategoryId);


        void CreateBill(ICustomerBill objCustomerBill);


        bool CancelBill(ICustomerBill objCustomerBill);
       

        List<IItem> SearchItem(String itemName);


        void TakeBackSoldItems(IBillDetails objBillDetails);


        List<IBillDetails> GetBillDetails(int billNumber);

        //List<IItem> GenerateReport(int CategoryId);

        List<IItemCategory> GetItemCategoryList();

        List<IItem> SearchItembyName(string name);

        List<IItem> GetItemList(int categoryId, string name);

        bool SaveReportofNotAvalableItems(List<IItem> itemslst);

        List<ICustomerBill> SearchBillDetails(int billNumber);

    }
}
