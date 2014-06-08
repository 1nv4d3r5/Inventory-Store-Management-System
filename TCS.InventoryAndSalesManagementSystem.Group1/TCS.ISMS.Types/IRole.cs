using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IRole
    {
         int RoleId{ get; set; }
         string RoleName { get; set; }
    }
}
