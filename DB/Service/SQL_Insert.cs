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
    public class SQL_Insert
    {
        public string Insert(Model.Data Data)
        {
            string sql = "insert into Sales.Orders(";
            string field = "CustomerID,EmployeeID,OrderDate,RequiredDate,ShipperID,ShipName";
            string value = "'"+Data.CustomerID+"','"+Data.EmployeeID+"','"+Data.OrderDate+"','"+Data.RequiredDate+"','"+Data.ShipperID+"','無'";
            string NewOrderId = "";
            if (Data.ShippedDate != null)
            {
                field += ",ShippedDate";
                value += ",'" + Data.ShippedDate+"'";
            }
            if(Data.Freight != null)
            {
                field += ",Freight";
                value += ",'"+Data.Freight+"'";
            }
            if (Data.ShipAddress != null)
            {
                field += ",ShipAddress";
                value += ",'"+Data.ShipAddress+"'";
            }
            if (Data.ShipCity != null)
            {
                field += ",ShipCity";
                value += ",'"+Data.ShipCity+"'";
            }
            if (Data.ShipPostalCode != null)
            {
                field += ",ShipPostalCode";
                value += ",'"+Data.ShipPostalCode+"'";
            }
            if (Data.ShipCountry != null)
            {
                field += ",ShipCountry";
                value += ",'"+Data.ShipCountry+"'";
            }
            sql += field + ") values(" + value + ")";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            DataTable dt = new DataTable();
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                sql = "select top 1 OrderID from Sales.Orders order by OrderID desc";
                cmd = new SqlCommand(sql, conn);
                sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                NewOrderId = dt.Rows[0]["OrderId"].ToString();
                conn.Close();
            }
            return NewOrderId;
        }


        public void Product(Model.Data Data)
        {
            string sql = "insert into Sales.OrderDetails(OrderId, ProductID, UnitPrice, Qty, Discount) values('"+Data.OrderId+"','"+Data.ProductID+"','"+Data.UnitPrice+"','"+Data.Qty+"','0.000')";
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
