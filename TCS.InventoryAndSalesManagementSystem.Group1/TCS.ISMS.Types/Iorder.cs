using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface Iorder
    {
         int OrderId{get;set;}
       

         int VendorId{get;set;}
        
         string VendorName{get;set;}
        
         DateTime OrderDate{get;set;}
        
        }
}
