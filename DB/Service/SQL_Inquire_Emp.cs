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
    public class SQL_Inquire_Emp
    {
        public List<Model.Data> GetData(string EmpName)
        {
            string sql = "Select DISTINCT LastName+FirstName EmpName, c.EmployeeID " +
                "From Sales.Orders a inner join Sales.Customers b " +
                "on b.CustomerID = a.CustomerID " +
                "inner join HR.Employees c " +
                "on c.EmployeeID = a.EmployeeID " +
                "inner join Sales.Shippers d " +
                "on d.ShipperID = a.ShipperID " +
                "Where c.EmployeeID != '" + EmpName + "' order by c.EmployeeID";
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
                    EmployeeID = row["EmployeeID"].ToString(),
                    EmpName = row["EmpName"].ToString(),
                });
            }
            return result;
        }
    }
}
