using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB.Controllers
{
    public class InquireController : Controller
    {
        // GET: Inquire
        public ActionResult Index(Model.Data Data)
        {
            Service.SQL_Inquire SI = new Service.SQL_Inquire();
            List<Model.Data> GetData = new List<Model.Data>();
            GetData = SI.GetData(Data);
            if (GetData.Count < 1)
            {
                return RedirectToAction("Non", "Inquire");
            }
            ViewBag.GetData = GetData;
            ViewBag.Data = Data;
            return View();
        }
        public ActionResult Non()
        {
            return View();
        }
    }
}