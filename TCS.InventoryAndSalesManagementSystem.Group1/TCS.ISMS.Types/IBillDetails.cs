using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IBillDetails
    {
       int BillNumber{ get; set; }
        

        int QuantityPurchased{ get; set; }
        
        int QuantityReturned{ get; set; }

        int ItemID { get; set; }
       string ItemName{ get; set; }
       
       int ItemCategory{ get; set; }
        
        string Remarks{ get; set; }
       
      string ItemStatus{ get; set; }
        
       double Discount{ get; set; }
        

      double LineTotal{ get; set; }

      double LineTotalofReturnedItems { get; set; }
       
    }
}
