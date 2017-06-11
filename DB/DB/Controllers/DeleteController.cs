using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB.Controllers
{
    public class DeleteController : Controller
    {
        // GET: Delete
        public ActionResult Index(Model.Data Data, string ID)
        {
            Service.SQL_Delete SD = new Service.SQL_Delete();
            SD.Delete(ID);
            return RedirectToAction("Index", "Inquire",
                new
                {
                    OrderId = Data.OrderId,
                    CustName = Data.CustName,
                    EmployeeID = Data.EmployeeID,
                    EmpName = Data.EmpName,
                    ShipperID = Data.ShipperID,
                    CpyName = Data.CpyName,
                    OrderDate = Data.OrderDate,
                    RequiredDate = Data.RequiredDate,
                    ShippedDate = Data.ShippedDate
                });
        }
    }
}