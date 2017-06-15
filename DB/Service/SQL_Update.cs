using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Service
{
    public class SQL_Update
    {
        public void Update(Model.Data Data)
        {
            string sql = "update Sales.Orders set CustomerID = '"+Data.CustomerID+"' , EmployeeID = '"+Data.EmployeeID+"' ,OrderDate = '"+Data.OrderDate+"' , RequiredDate = '"+Data.RequiredDate+"' , ShippedDate = '"+Data.ShippedDate+"' , ShipperID = '"+Data.ShipperID+"' , Freight = '"+"100"+"' , ShipAddress = '"+Data.ShipAddress+"' , ShipCity = '"+Data.ShipCity+"' , ShipRegion = '"+Data.ShipRegion+"' , ShipPostalCode = '"+Data.ShipPostalCode+"' , ShipCountry = '"+Data.ShipCountry+"' where OrderId = '"+Data.OrderId+"'";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Product(Model.Data Data)
        {
            string sql = "insert into Sales.OrderDetails(OrderId, ProductID, UnitPrice, Qty, Discount) values('" + Data.OrderId + "','" + Data.ProductID + "','" + Data.UnitPrice + "','" + Data.Qty + "','0.000')";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Delete(string OrderId)
        {
            string sql = "delete from Sales.OrderDetails where OrderId = '"+OrderId+"'";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
