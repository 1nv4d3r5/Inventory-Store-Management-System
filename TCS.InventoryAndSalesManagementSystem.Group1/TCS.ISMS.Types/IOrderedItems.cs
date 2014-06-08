////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an interface IOrderedItems which is implemented by OrderedItems class.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    :     Susmita Rana, Tata Consultancy Services
//
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IOrderedItems
    {
       int OrderId { get; set; }
       
        int ItemId{get;set;}
        
         string ItemName{get;set;}
        
        int ItemCategory{get;set;}
        
        int ItemQuantity{get;set;}
        
    }
}
