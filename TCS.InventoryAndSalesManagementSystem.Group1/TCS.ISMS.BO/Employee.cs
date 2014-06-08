////////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an employee class which implements an interface IEmployee.
// ---------------------------------------------------------------------------------
//	Date Created		: April 19, 2013
//	Author			    :     Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		 :  April 26, 2013
//	Changed By		     :  Arshin Saluja
//	Change Description   :  Changed the role name to role Id.
//
//-------------------------------------------------------------------------------------
//
//  Date Modified		 : April 29, 2013
//	Changed By		     : Arshin Saluja
//	Change Description   : Added a new attribute role name.
////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
   public class Employee : IEmployee
    {   
        //Attribute declaration
        int employeeId;
        string firstName;
        string lastName;
        int roleId;
        string address;
        string city;
        string state;
        DateTime dob;
        DateTime doj;
        long mobileNumber;
        string roleName;

        /// <summary>
        /// Properties of BO
        /// </summary>
        #region properties
       
       //properties
        public int EmployeeId
        {
            get { return employeeId;}
            set { employeeId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public DateTime Doj
        {
            get { return doj; }
            set { doj = value; }
        }
        /// <summary>
        /// Property Mobile Number is Unique
        /// </summary>
        public long MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }

        public string RoleName
        {
            get { return roleName; }
            set {roleName = value;}
        }
        #endregion

    }
}
