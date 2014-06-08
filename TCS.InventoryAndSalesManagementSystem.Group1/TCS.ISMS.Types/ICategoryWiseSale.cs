//File Description	: This page shows interface of sales based on category.
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

namespace TCS.ISMS.Types
{
    public interface ICategoryWiseSale
    {
        DateTime Date { get; set; }
        string CategoryName { get; set; }
        double TotalSales { get; set; }
    }
}
