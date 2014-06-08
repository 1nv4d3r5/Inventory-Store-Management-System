using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCS.ISMS.Types
{
    public interface ICustomerBill
    {
        

        int BillNumber
        {
            get;
            set;
        }

        double TotalBillAmount
        {
            get;
            set;
        }

        string BillStatus
        {
            get;
            set;
        }

        string CustomerName
        {
            get;
            set;
        }


        DateTime BillDate
        {
            get;
            set;
        }

        double MoneyIn
        {
            get;
            set;
        }

        double MoneyOut
        {
            get;
            set;
        }

        double TotalMoneyReturned
        {
            get;
            set;
        }

        int CustomerId
        {
            get;
            set;
        }

        int EmployeeId
        {
            get;
            set;
        }

        string Remarks
        {
            get;
            set;
        }

        List<IItem> BoughtItemList
        {
            get;
            set;
        }

    }
}
