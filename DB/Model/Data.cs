using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Data
    {
        public string OrderId { set; get; }
        public string CustomerID { set; get; }
        public string CustName { set; get; }
        public string EmployeeID { set; get; }
        public string EmpName { set; get; }
        public string ShipperID { set; get; }
        public string CpyName { set; get; }

        public string OrderDate { set; get; }
        public string RequiredDate { set; get; }
        public string ShippedDate { set; get; }

        public string ShipAddress { set; get; }
        public string ShipCity { set; get; }
        public string ShipRegion { set; get; }
        public string ShipPostalCode { set; get; }
        public string ShipCountry { set; get; }
        public string Freight { set; get; }
    }
}
