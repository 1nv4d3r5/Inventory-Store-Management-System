using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IReturnedItems
    {
        int BillNo { get; set; }
        int ItemID { get; set; }
        string Name { get; set; }
        double Quantity { get; set; }
        string Remarks { get; set; }

    }
}
