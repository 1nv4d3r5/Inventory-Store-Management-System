using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IReportPriceWise
    {
        double Price { get; set; }
        double TotalAvailable { get; set; }
        string Range { get; set; }

    }
}
