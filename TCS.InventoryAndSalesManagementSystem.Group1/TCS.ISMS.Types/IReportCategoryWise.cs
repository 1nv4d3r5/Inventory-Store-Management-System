using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IReportCategoryWise
    {
       string CategoryName{ get; set; }
       int TotalAvailableItems{ get; set; }
    }
}
