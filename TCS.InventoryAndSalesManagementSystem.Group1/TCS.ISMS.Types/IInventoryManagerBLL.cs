//File Description	: This file Contains an interface IInventoryManagerBLL which has definitions of the functions of InventoryMangerBLL
// ---------------------------------------------------------------------------------
//  Date Created    : April 19, 2013
//  Author          : Suman Pradhan, Tata Consultancy Services
//----------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		    :Naincy Jain
//	Change Description   : Added GetItemCategory Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 1, 2013
//	Changed By		    : Suman Pradhan
//	Change Description   : Added check status of inventory Function
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IInventoryManagerBLL
    {
        bool PlaceOrder(List<Iorder> lstItems, List<IOrderedItems> lstOrderItems);


        List<IReportCategoryWise> GenerateCategoryWiseReport();

        List<int> getVendorCategoryList(int VendorId);

        List<IReportPriceWise> GeneratePriceWiseReport();
        

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
