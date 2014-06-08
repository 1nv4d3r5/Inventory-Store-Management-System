////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an interface IHRLR which is implemented by HRLR class.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    :     Susmita Rana, Tata Consultancy Services
//----------------------------------------------------------------------------------------
//Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Amit Nadkarni
//	Change Description   : Edited Data Types
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IHRLR
    {
        string ItemName { get; set; }
        string ItemCategory { get; set; }
        double ItemSold { get; set; }
    }
}
