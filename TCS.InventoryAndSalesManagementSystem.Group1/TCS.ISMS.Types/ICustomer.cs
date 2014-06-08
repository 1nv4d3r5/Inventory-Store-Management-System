using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface ICustomer
    {
       int CustomerId{ get; set; }
       

      long CustomerPhnNumber{ get; set; }

       string CustomerName { get; set; }
       
    }
}
