using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IIMCrossCheck
    {

       string ItemName{ get; set; }
         double ItemCount{ get; set; }
         double LastSale{ get; set; }
         double ItemSold{ get; set; }
         double Difference{ get; set; }
         int AddedByAdmin { get; set; }
    }
}
