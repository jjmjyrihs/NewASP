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
        public void Insert(Model.Data Data)
        {
            string sql = "insert into Sales.Orders(";
            string field = "CustomerID,EmployeeID,OrderDate,RequiredDate,ShipperID,ShipName";
            string value = "'"+Data.CustomerID+"','"+Data.EmployeeID+"','"+Data.OrderDate+"','"+Data.RequiredDate+"','"+Data.ShipperID+"','無'";
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
