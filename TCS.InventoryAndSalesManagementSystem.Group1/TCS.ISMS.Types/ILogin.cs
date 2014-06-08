using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface ILogin
    {
        int EmployeeId{ get; set; }
        string Password{ get; set; }
        int Role { get; set; }
        
       
    }
}
