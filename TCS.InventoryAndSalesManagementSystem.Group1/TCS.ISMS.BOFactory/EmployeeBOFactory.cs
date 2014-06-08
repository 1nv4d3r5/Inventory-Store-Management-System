//File Description	: This page shows Employee BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Arshin Saluja, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.BO;
using TCS.ISMS.Types;

namespace TCS.ISMS.BOFactory
{
    public class EmployeeBOFactory
    {
        public static IEmployee CreateEmployeeObject()
        {
            IEmployee objEmployee = new Employee();
            return objEmployee;
        }
    }
}
