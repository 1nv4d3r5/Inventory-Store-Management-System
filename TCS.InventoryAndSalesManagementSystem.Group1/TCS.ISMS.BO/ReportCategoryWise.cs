
////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an Categorywise Report class which implements an IReportCategoryWise.
// ---------------------------------------------------------------------------------
//	Date Created		: April 17, 2013
//	Author			    :     Amit Nadkarni, Tata Consultancy Services
///////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class ReportCategoryWise : IReportCategoryWise
    {
        private string categoryName;
        private int totalAvailableItems;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public int TotalAvailableItems
        {
            get { return totalAvailableItems; }
            set { totalAvailableItems = value; }
        }

    }
}
        #endregion
