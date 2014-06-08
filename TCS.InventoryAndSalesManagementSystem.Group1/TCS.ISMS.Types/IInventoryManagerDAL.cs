//File Description	: This file Contains an IInventoryManagerDal which has definitions of the functions of InventoryMangerDAL
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		:Apr 26, 2013
//	Changed By		    :Naincy Jain
//	Change Description  :Added GetItemCategory Function Definition
// ---------------------------------------------------------------------------------
//  Change History
//	Date Modified		: Apr 27, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added GetItemList Function Definition
// ---------------------------------------------------------------------------------
//  Change History
//	Date Modified		: Apr 30, 2013
//	Changed By		    : Susmita Rana
//	Change Description  : Added GetVendorDetailsCategoryWise Function Definition
// ---------------------------------------------------------------------------------
//  Change History
//	Date Modified		: May 1, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added Check status of inventory Function
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TCS.ISMS.Types
{
   public interface IInventoryManagerDAL
    {
       bool PlaceOrder(List<Iorder> lstItems, List<IOrderedItems> listOrderItems);

       List<IReportCategoryWise> GenerateCategoryWiseReport();

       List<IReportPriceWise> GeneratePriceWiseReport();

       List<int> getVendorCategoryList(int VendorId);

       List<IItem> GenerateInventoryReport(IItemCategory objCategory);

       bool AddVendorDetails(IVendor objVendor);

       bool UpdateVendorDetails(IVendor objVendor,int vendorId);


       bool DeleteVendor(List<int> vendorId);


       List<IVendor> GetVendorDetails();

       List<IItem> CheckStatusOfInventory(int CategoryId);

       List<IItem> ViewRportGeneratedBySP();

       List<IHRLR> GetHighestAndLowestRollingItems(DateTime frmDate, DateTime toDate, out List<IHRLR> lrl);

       List<IIMCrossCheck> CrossCheckInventoryWithSales();
      List<IItemCategory> GetItemCategory();
      List<IItem> GetItemList(int CategoryId);
      List<IVendor> GetVendorDetailsCategoryWise(int CategoryId);
      IVendor GetVendorByVendorId(int VendorId);
    }
}
