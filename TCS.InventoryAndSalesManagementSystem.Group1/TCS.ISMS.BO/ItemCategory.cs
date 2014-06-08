//File Description	: This page has BO for Item Category
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;

namespace TCS.ISMS.BO
{
    public class ItemCategory : IItemCategory
    {
        int categoryId;
        string categoryName;

        /// <summary>
        /// Properties of BO
        /// </summary>
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public string CategoryName
        {
            get { return categoryName; }
            set {categoryName = value; }
        }
    }
}
