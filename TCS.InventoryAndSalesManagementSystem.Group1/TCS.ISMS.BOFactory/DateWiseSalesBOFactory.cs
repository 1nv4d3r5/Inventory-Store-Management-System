//File Description	: This page shows Date Wise Sales BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Arshin Saluja, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.BO;

namespace TCS.ISMS.BOFactory
{
    public class DateWiseSalesBOFactory
    {
        public static IDateWiseSale CreateDateWiseSalesObject()
        {
            IDateWiseSale objDateWiseSales = new DateWiseSale();
            return objDateWiseSales;
        }
    }
}
