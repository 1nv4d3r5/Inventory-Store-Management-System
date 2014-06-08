using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface IMenu
    {
        int MenuId { get; set; }
        string MenuName { get; set; }
        string NavigationUrl { get; set; }
        int ParentMenuId { get; set; }
        string Description { get; set; }
        string ToolTip { get; set; }
    }   
}
