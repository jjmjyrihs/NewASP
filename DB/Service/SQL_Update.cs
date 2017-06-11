using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SQL_Update
    {
        public void Update(Model.Data Data)
        {
            string sql = "update Sales.Orders set CustomerID = '"+Data.CustomerID+"' , EmployeeID = '"+Data.EmployeeID+"' ,OrderDate = '"+Data.OrderDate+"' , RequiredDate = '"+Data.RequiredDate+"' , ShippedDate = '"+Data.ShippedDate+"' , ShipperID = '"+Data.ShipperID+"' , Freight = '"+"test"+"' , ShipAddress = '"+Data.ShipAddress+"' , ShipCity = '"+Data.ShipCity+"' , ShipRegion = '"+Data.ShipRegion+"' , ShipPostalCode = '"+Data.ShipPostalCode+"' , ShipCountry = '"+Data.ShipCountry+"' where OrderId = '"+Data.OrderId+"'";
        }
    }
}
