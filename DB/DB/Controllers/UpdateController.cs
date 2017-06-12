using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB.Controllers
{
    public class UpdateController : Controller
    {
        // GET: Update
        public ActionResult Index(Model.Data Data)
        {
            ViewBag.Data = Data;

            Service.SQL_Inquire_Cpy SIC = new Service.SQL_Inquire_Cpy();
            Service.SQL_Inquire_Emp SIE = new Service.SQL_Inquire_Emp();
            Service.SQL_Inquire_Cust SICU = new Service.SQL_Inquire_Cust();


            List<Model.Data> Drop = new List<Model.Data>();


            Drop = SIC.GetData(Data.ShipperID);
            DropDownListMakeCpy(Drop, Data);

            Drop = new List<Model.Data>();
            Drop = SIE.GetData(Data.EmployeeID);
            DropDownListMakeEmp(Drop, Data);

            Drop = new List<Model.Data>();
            Drop = SICU.GetData(Data.CustName);
            DropDownListMakeCust(Drop, Data);

            return View();
        }

        public ActionResult Update(Model.Data Data, string ID, string submit)
        {
            switch (submit)
            {
                case "存檔":
                    Service.SQL_Inquire SI = new Service.SQL_Inquire();
                    Service.SQL_Update SU = new Service.SQL_Update();
                    List<Model.Data> LData = new List<Model.Data>();
                    Model.Data NData = new Model.Data();
                    NData.CustomerID = Data.CustomerID;
                    NData.EmployeeID = "null";
                    NData.ShipperID = "null";
                    LData = SI.GetData(NData);
                    Data.CustName = LData[0].CustName;

                    NData = new Model.Data();
                    NData.EmployeeID = Data.EmployeeID;
                    NData.ShipperID = "null";
                    LData = SI.GetData(NData);
                    Data.EmpName = LData[0].EmpName;

                    NData = new Model.Data();
                    NData.ShipperID = Data.ShipperID;
                    NData.EmployeeID = "null";
                    LData = SI.GetData(NData);
                    Data.CpyName = LData[0].CpyName;
                    Data.OrderId = ID;

                    /*int i = 1999;
                    int j = 1999999;
                    string ii = "1999";
                    string jj = "199999999";
                    ii = string.Format("{0:$#,###.##}", ii);
                    string.Format("{0:$#,###.##}", jj);*/



                    SU.Update(Data);

                    return null;
                case "刪除本筆訂單":

                    return null;
            }
            return null;
        }

















        public void DropDownListMakeCpy(List<Model.Data> Drop, Model.Data Data)
        {
            List<SelectListItem> CpyName = new List<SelectListItem>();
            CpyName.Add(new SelectListItem()
            {
                Text = Data.CpyName.Replace("Shipper ", ""),
                Value = Data.ShipperID
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


        public void DropDownListMakeEmp(List<Model.Data> Drop, Model.Data Data)
        {
            List<SelectListItem> EmpName = new List<SelectListItem>();
            EmpName.Add(new SelectListItem()
            {
                Text = Data.EmpName,
                Value = Data.EmployeeID
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

        public void DropDownListMakeCust(List<Model.Data> Drop, Model.Data Data)
        {
            List<SelectListItem> Cust = new List<SelectListItem>();
            Cust.Add(new SelectListItem()
            {
                Text = Data.CustName.Replace("Customer ", ""),
                Value = Data.CustomerID
            });
            for (int i = 0; i < Drop.Count; i++)
            {
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