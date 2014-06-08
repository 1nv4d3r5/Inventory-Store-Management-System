//File Description	: This file Contains an InventoryManagerBLL which implements IInventoryManagerBLL
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		    :Naincy Jain
//	Change Description   : Added GetItemCategory Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		    :Amit Nadkarni
//	Change Description   : Added Delete Vendor Function
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: May 1, 2013
//	Changed By		    : Suman Pradhan
//	Change Description  : Added Check status of inventory Function
////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.DALFactory;
using TCS.ISMS.Types;
using System;


namespace TCS.ISMS.BLL
{
    public class InventoryManagerBLL : IInventoryManagerBLL
    {
        public bool PlaceOrder(List<Iorder> lstOrder,List<IOrderedItems> lstOrderItems)
        {
            bool isPlaced = false; 
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            isPlaced= objDAL.PlaceOrder(lstOrder,lstOrderItems);
            return isPlaced;
        }

        public List<IReportCategoryWise> GenerateCategoryWiseReport()
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GenerateCategoryWiseReport();
        }

        //public List<IReportCategoryWise> GenerateInventoryReport(string category)
        //{
        //    IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
        //    return objDAL.GenerateInventoryReport(category);
        //}
       
        public List<IReportPriceWise> GeneratePriceWiseReport()
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GeneratePriceWiseReport();
        }

        public List<IItem> GenerateInventoryReport(IItemCategory objCategory)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GenerateInventoryReport(objCategory);
        }

        public bool AddVendorDetails(IVendor objVendor)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.AddVendorDetails(objVendor);
        }

        public bool UpdateVendorDetails(IVendor objVendor,int vendorId)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.UpdateVendorDetails(objVendor,vendorId);
        }

        public bool DeleteVendor(List<int> vendorId)
        {
            bool isDeleted = false;
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            isDeleted=objDAL.DeleteVendor(vendorId);
            return isDeleted;
        }

        public List<IVendor> GetVendorDetails()
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GetVendorDetails();
        }

        public List<IItem> CheckStatusOfInventory(int CategoryId)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.CheckStatusOfInventory(CategoryId);
        }

        public List<IItem> ViewRportGeneratedBySP()
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.ViewRportGeneratedBySP();
        }

        public List<IHRLR> GetHighestAndLowestRollingItems(DateTime frmDate,DateTime toDate, out List<IHRLR> lrl)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GetHighestAndLowestRollingItems(frmDate,toDate, out lrl);
        }

        public List<IIMCrossCheck> CrossCheckInventoryWithSales()
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.CrossCheckInventoryWithSales();
        }
        public List<IItemCategory> GetItemCategory()
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GetItemCategory();
        }

        public List<int> getVendorCategoryList(int VendorId)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.getVendorCategoryList(VendorId);
        }

        public List<IItem> GetItemList(int CategoryId)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GetItemList(CategoryId);
        }
        public List<IVendor> GetVendorDetailsCategoryWise(int CategoryId)
        { 
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GetVendorDetailsCategoryWise(CategoryId);
        }
        public IVendor GetVendorByVendorId(int VendorId)
        {
            IInventoryManagerDAL objDAL = InventoryManagerDALFactory.CreateInventoryManagerDALObject();
            return objDAL.GetVendorByVendorId(VendorId);
        
        }
        

        
    }
}
