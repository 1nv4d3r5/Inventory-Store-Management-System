//File Description	: This page shows category wise sales BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:3 May, 2013
//	Author			    :Susmita Rana, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.BO;

namespace TCS.ISMS.BOFactory
{
    public class CategoryWiseSalesBOFactory
    {
        public static ICategoryWiseSale CreateCategoryWiseSalesObject()
        {
            ICategoryWiseSale objCategoryWiseSales = new CategoryWiseSale();
            return objCategoryWiseSales;
        }

    }
}
