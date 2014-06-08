//File Description	: This is the code for Sales Manager BLL
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 1, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Edited GetBillList Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 2, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Edited GetMoneyTransaction Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Edited GenerateReportCategoryWise Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Edited GenerateReportDateWise Function
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.DALFactory;
using TCS.ISMS.Types;

namespace TCS.ISMS.BLL
{
    public class SalesManagerBLL:ISalesManagerBLL
    {
        public List<ICustomerBill> GetBillList(DateTime date)
        {
            ISalesManager objDAL = SalesManagerDALFactory.CreateSalesManagerDALObject();
            return objDAL.GetBillList(date);
        }

        public List<IViewMoneyTransaction> GetMoneyTransaction(DateTime date)
        {
            ISalesManager objDAL = SalesManagerDALFactory.CreateSalesManagerDALObject();
            return objDAL.GetMoneyTransaction(date);
        }

        public List<ICustomerBill> GetCancelledBillList(DateTime date)
        {
            ISalesManager objDAL = SalesManagerDALFactory.CreateSalesManagerDALObject();
            return objDAL.GetCancelledBillList(date);
        }

        public List<IReturnedItems> GetReturnedItemList(DateTime date)
        {
            ISalesManager objDAL = SalesManagerDALFactory.CreateSalesManagerDALObject();
            return objDAL.GetReturnedItemList(date);
        }

        public List<ICategoryWiseSale> GenerateReportCategoryWise(DateTime date1, DateTime date2)
        {
            ISalesManager objDAL = SalesManagerDALFactory.CreateSalesManagerDALObject();
            return objDAL.GenerateReportCategoryWise(date1, date2);
        }

        public List<IDateWiseSale> GenerateReportDateWise(DateTime date1, DateTime date2)
        {
            ISalesManager objDAL = SalesManagerDALFactory.CreateSalesManagerDALObject();
            return objDAL.GenerateReportDateWise(date1, date2);
        }
    }
}
