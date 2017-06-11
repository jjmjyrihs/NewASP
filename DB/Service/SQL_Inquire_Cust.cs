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
    public class SQL_Inquire_Cust
    {
        public List<Model.Data> GetData(string CustName)
        {
            string sql = "Select DISTINCT  CustName, b.CustomerID " +
                "From Sales.Orders a inner join Sales.Customers b " +
                "on b.CustomerID = a.CustomerID " +
                "inner join HR.Employees c " +
                "on c.EmployeeID = a.EmployeeID " +
                "inner join Sales.Shippers d " +
                "on d.ShipperID = a.ShipperID " +
                "Where CustName != '" + CustName + "' order by b.CustomerID";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString);
            using (conn)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return (FillData(dt));
        }

        private List<Model.Data> FillData(DataTable dt)
        {
            List<Model.Data> result = new List<Model.Data>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Model.Data
                {
                    CustomerID = row["CustomerID"].ToString(),
                    CustName = row["CustName"].ToString(),
                });
            }
            return result;
        }
    }
}
