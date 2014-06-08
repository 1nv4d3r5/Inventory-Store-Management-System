using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface ILogon
    {
        int EmployeeId{ get; set; }
        string RoleName{ get; set; }
        string EmployeeName{ get; set; }
        List<IMenu> MenoBo { get; set; }
    }
}
