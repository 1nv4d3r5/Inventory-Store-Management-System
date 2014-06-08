//File Description	: This page shows Menu BO Factory.
// ---------------------------------------------------------------------------------
//	Date Created		:19 Apr, 2013
//	Author			    :Naincy Jain, Tata Consultancy Services
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCS.ISMS.Types;
using TCS.ISMS.BO;


namespace TCS.ISMS.BOFactory
{
   public class MenuBOFactory
    {
        public static IMenu CreateMenuObject()
       {
         IMenu objMenu = new Menu();
           return objMenu;
       
       }
    }
}
