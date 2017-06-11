using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            DropDownListMakeEmp();
            DropDOwnListMakeCpy();
            return View();
        }

        public void DropDOwnListMakeCpy()
        {
            List<SelectListItem> CpyName = new List<SelectListItem>();
            CpyName.Add(new SelectListItem()
            {
                Text = "無",
                Value = "null"
            });
            CpyName.Add(new SelectListItem()
            {
                Text = "GVSUA",
                Value = "1"
            });
            CpyName.Add(new SelectListItem()
            {
                Text = "ETYNR",
                Value = "2"
            });
            CpyName.Add(new SelectListItem()
            {
                Text = "ZHISN",
                Value = "3"
            });
            ViewBag.CpyName = CpyName;
        }
        public void DropDownListMakeEmp()
        {
            List<SelectListItem> EmpName = new List<SelectListItem>();
            EmpName.Add(new SelectListItem()
            {
                Text = "無",
                Value = "null"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Davis-Sara",
                Value = "1"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Funk-Don",
                Value = "2"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Lew-Judy",
                Value = "3"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Peled-Yael",
                Value = "4"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Buck-Sven",
                Value = "5"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Suurs-Paul",
                Value = "6"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "King-Russell",
                Value = "7"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Cameron-Maria",
                Value = "8"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Dolgopyatova-Zoya",
                Value = "9"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Brown-John",
                Value = "11"
            });
            EmpName.Add(new SelectListItem()
            {
                Text = "Harris-Bill",
                Value = "12"
            });
            ViewBag.EmpName = EmpName;
        }
    }
}