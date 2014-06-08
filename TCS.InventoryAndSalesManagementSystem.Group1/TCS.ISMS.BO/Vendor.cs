//File Description	: This file contains Vendor Class
// ---------------------------------------------------------------------------------
//	Date Created		:Apr 19, 2013
//	Author			: Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 25, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added emailid
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added VendorID
// ---------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 29, 2013
//	Changed By		:Naincy Jain
//	Change Description   : Added Category List in the Default Constructor
//----------------------------------------------------------------------------------
// 	Change History
//	Date Modified		: Apr 26, 2013
//	Changed By		:Amit Nadkarni
//	Change Description   : Added Vendor Type attribute
//----------------------------------------------------------------------------------




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    /// <summary>
    /// This class contains all functionality and data related to the Vendor
    /// </summary>
    public class Vendor : IVendor
    {
        string nameOfOrganisation;
        
        string nameOfContactPerson;
        string address;
        string city;
        string state;
        long contactNumber;
        string vendorType;
        int vendorId;
        string emailId;
        List<int> categorylst;

        /// <summary>
        /// This constructor initializes categorylst
        /// </summary>
        public Vendor()
        {
            categorylst = new List<int>();
        }

        #region properties
        /// <summary>
        /// Properties of BO
        /// </summary>
        public string NameOfOrganisation
        {
            get { return nameOfOrganisation; }
            set { nameOfOrganisation = value; }
        }
        
        public string NameOfContactPerson
        {
            get { return nameOfContactPerson; }
            set { nameOfContactPerson = value; }
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

        public long ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string VendorType
        {
            get { return vendorType; }
            set { vendorType = value; }
        }

        public int VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }
       
       
        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }
        public List<int> CategoryList
        {
            get { return categorylst; }
            set { categorylst = value; }
         }
        #endregion

    }

}
