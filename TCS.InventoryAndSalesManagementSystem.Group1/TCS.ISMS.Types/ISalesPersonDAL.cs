//File Description	: This file Contains an ISalesPersonDAL which has definitions of the functions of SalesPersonDAL
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		:Apr 25, 2013
//	Changed By		    :Susmita Rana
//	Change Description  :Added GetItemList Function signature
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		:Apr 26, 2013
//	Changed By		    :Susmita Rana
//	Change Description  :Added GetItemCategoryList Function signature
// -----------------------------------------------------------------------------------
//
//  Date Modified  : May 2, 2013
//  Changed By  : Susmita Rana
//  Change Description# : Added function signature for SearchBillDetails. 
// -----------------------------------------------------------------------------------
//
//  Date Modified  : May 2, 2013
//  Changed By  : Susmita Rana
//  Change Description# : Added function signature for CancelBill. 
//
////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface ISalesPersonDAL
    {
        List<IItem> GetItemList(int CategoryId);

        void CreateBill(ICustomerBill objCustomerBill);

        bool CancelBill(ICustomerBill objCustomerBill);

        List<IItem> SearchItem(String itemName);

        void TakeBackSoldItems(IBillDetails objBillDetails);

        List<IBillDetails> GetBillDetails(int billNumber);

        //List<IItem> GenerateReport(int CateegoryId);

        List<IItemCategory> GetItemCategoryList();

        List<IItem> SearchItemDetails(string itemName);

        List<IItem> GetItemList(int categoryId, string name);

        bool SaveReportofNotAvalableItems(List<IItem> itemslst);

        List<ICustomerBill> SearchBillDetails(int billNumber);
    }
}
