//File Description	: This page shows report of sales based on category.
// ---------------------------------------------------------------------------------
//	Date Created		:3 May, 2013
//	Author			    :Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: 3 May, 2013
//	Changed By		    : Susmita Rana
//	Change Description   :Implemented ICategoryWiseSale interface
// 
/////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class CategoryWiseSale : ICategoryWiseSale
    {
        private DateTime date;
        private string categoryName;
        private double totalSales;
        /// <summary>
        /// Properties of BO
        /// </summary>

         #region properties

       public DateTime Date
       {
           get { return date; }
           set { date = value; }
       
       }

        public string CategoryName
        {
            get { return categoryName; }
            set {  categoryName = value; }
        }

       public double TotalSales
       {
           get { return totalSales; }
           set { totalSales = value; }

       }
         #endregion
    }
}
