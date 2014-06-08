//File Description	: This file contains Interface of Vendor Class
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    /// <summary>
    /// Interface of the Vendor BO
    /// </summary>
   public interface IVendor
    {
        #region properties

        string NameOfOrganisation
        {
            get;
            set;
        }

        

        string NameOfContactPerson
        {
            get;
            set;
        }

        string Address
        {
            get;
            set;
        }
       
        string City
        {
            get;
            set;
        }

        string State
        {
            get;
            set;
        }

        long ContactNumber
        {
            get;
            set;
        }

        string VendorType
        {
            get;
            set;
        }

        int VendorId
        {
            get;
            set;
        }
        string EmailId
        {
            get;
            set;
        }
        List<int> CategoryList
        {
            get;
            set;
        }
       
        #endregion

    }
}
