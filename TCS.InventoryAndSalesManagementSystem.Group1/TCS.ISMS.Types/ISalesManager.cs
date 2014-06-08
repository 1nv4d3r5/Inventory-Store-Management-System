//File Description	: This is the code for Sales Manager DAL interface
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 1, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added GetBillList Function Signature
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 2, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added GetMoneyTransaction Function Signature
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added GenerateReportCategoryWise Function Signature
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 3, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added GenerateReportDateWise Function Signature
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface ISalesManager
    {
        List<ICustomerBill> GetBillList(DateTime date);

         List<IViewMoneyTransaction> GetMoneyTransaction(DateTime d);
        

         List<ICustomerBill> GetCancelledBillList(DateTime d);
        

         List<IReturnedItems> GetReturnedItemList(DateTime d);


         List<ICategoryWiseSale> GenerateReportCategoryWise(DateTime d1, DateTime d2);
        

         List<IDateWiseSale> GenerateReportDateWise(DateTime d1, DateTime d2);
        

       
    }
}
