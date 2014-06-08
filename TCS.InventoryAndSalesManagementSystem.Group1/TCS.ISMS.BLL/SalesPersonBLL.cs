////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an SalesPersonBLL class which implements ISalesPersonBLL interface.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    : Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		 :  April 25, 2013
//	Changed By		     :  Susmita Rana
//	Change Description   :  Added GetItemList method.
//
//-------------------------------------------------------------------------------------
//  Change History
//	Date Modified		 :  April 26, 2013
//	Changed By		     :  Susmita Rana
//	Change Description   :  Added GetItemCategoryList method.
//----------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 27, 2013
//	Changed By		    :Amit Nadkarni
//	Change Description   : Added Delete Vendor Function
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
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.DALFactory;

namespace TCS.ISMS.BLL
{
    public class SalesPersonBLL:ISalesPersonBLL
    {
        public List<IItem> GetItemList(int CategoryId)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.GetItemList(CategoryId);
        }

        public void CreateBill(ICustomerBill objCustomerBill)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            objDAL.CreateBill(objCustomerBill);
            //return objDAL.CreateBill(objBillDetails);
        }

        public bool CancelBill(ICustomerBill objCustomerBill)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.CancelBill(objCustomerBill);
        }

        public List<IItem> SearchItem(String itemName)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.SearchItem(itemName);
        }
        public void TakeBackSoldItems(IBillDetails objBillDetails)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            objDAL.TakeBackSoldItems(objBillDetails);
        }


        public List<IBillDetails> GetBillDetails(int billNumber)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.GetBillDetails(billNumber);
        }
        //public List<IItem> GenerateReport(int CategoryId)
        //{
        //    ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
        //    return objDAL.GenerateReport(CategoryId);
        //}

        public List<IItemCategory> GetItemCategoryList()
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.GetItemCategoryList();
        }

        public List<IItem> SearchItembyName(string name)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.SearchItemDetails(name);
        }

        public List<IItem> GetItemList(int categoryId,string name)
        {
             ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.GetItemList(categoryId,name);
        }
        public bool SaveReportofNotAvalableItems(List<IItem> itemslst)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.SaveReportofNotAvalableItems(itemslst);
        }
        public List<ICustomerBill> SearchBillDetails(int billNumber)
        {
            ISalesPersonDAL objDAL = SalesPersonDALFactory.CreateSalesPersonDALObject();
            return objDAL.SearchBillDetails(billNumber);
        }

    }
}
