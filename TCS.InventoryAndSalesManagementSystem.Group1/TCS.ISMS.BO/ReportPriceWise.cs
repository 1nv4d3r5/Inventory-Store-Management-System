
////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an Pricewise Report class which implements an IReportPriceWise.
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

    public class ReportPriceWise : IReportPriceWise
    {
        private double price;
        private double totalAvailable;
        private string range;
        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties

        public double Price
        {
            get { return price; }
            set { price =value; }
        }

        public double TotalAvailable
        {
            get { return totalAvailable; }
            set { totalAvailable = value; }
        }

        public string Range
        {
            get { return range; }
            set { range = value; }
        
        }


    }
}
        #endregion
