using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB.Controllers
{
    public class InsertController : Controller
    {
        public ActionResult Index()
        {
            Service.SQL_Inquire_Cpy SIC = new Service.SQL_Inquire_Cpy();
            Service.SQL_Inquire_Emp SIE = new Service.SQL_Inquire_Emp();
            Service.SQL_Inquire_Cust SICU = new Service.SQL_Inquire_Cust();


            List<Model.Data> Drop = new List<Model.Data>();


            Drop = SIC.GetData("");
            DropDownListMakeCpy(Drop);

            Drop = new List<Model.Data>();
            Drop = SIE.GetData("");
            DropDownListMakeEmp(Drop);

            Drop = new List<Model.Data>();
            Drop = SICU.GetData("");
            DropDownListMakeCust(Drop);
            return View();            
        }

        public void DropDownListMakeCpy(List<Model.Data> Drop)
        {
            List<SelectListItem> CpyName = new List<SelectListItem>();
            CpyName.Add(new SelectListItem()
            {
                Text = "無",
                Value = "null"
            });
            for (int i = 0; i < Drop.Count; i++)
            {
                string re = Drop[i].CpyName.Replace("Shipper ", "");
                CpyName.Add(new SelectListItem()
                {
                    Text = re,
                    Value = Drop[i].ShipperID
                });
            }

            ViewBag.CpyName = CpyName;
        }


        public void DropDownListMakeEmp(List<Model.Data> Drop)
        {
            List<SelectListItem> EmpName = new List<SelectListItem>();
            EmpName.Add(new SelectListItem()
            {
                Text = "無",
                Value = "null"
            });
            for (int i = 0; i < Drop.Count; i++)
            {
                EmpName.Add(new SelectListItem()
                {
                    Text = Drop[i].EmpName,
                    Value = Drop[i].EmployeeID
                });
            }
            ViewBag.EmpName = EmpName;
        }

        public void DropDownListMakeCust(List<Model.Data> Drop)
        {
            List<SelectListItem> Cust = new List<SelectListItem>();

            for (int i = 0; i < Drop.Count; i++)
            {
                Cust.Add(new SelectListItem()
                {
                    Text = "無",
                    Value = "null"
                });
                string re = Drop[i].CustName.Replace("Customer ", "");
                Cust.Add(new SelectListItem()
                {
                    Text = re,
                    Value = Drop[i].CustomerID
                });
            }
            ViewBag.Cust = Cust;
        }
    }
}