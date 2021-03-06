﻿using System;
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
            Service.SQL_Inquire_Pdt SIP = new Service.SQL_Inquire_Pdt();

            List<Model.Data> Drop = new List<Model.Data>();


            Drop = SIC.GetData(Data.ShipperID);
            DropDownListMakeCpy(Drop, Data);

            Drop = new List<Model.Data>();
            Drop = SIE.GetData(Data.EmployeeID);
            DropDownListMakeEmp(Drop, Data);

            Drop = new List<Model.Data>();
            Drop = SICU.GetData(Data.CustName);
            DropDownListMakeCust(Drop, Data);

            Drop = new List<Model.Data>();
            Drop = SIP.GetData("");
            DropDownListMakePdt(Drop);

            string[] Price = new string[(Drop.Count + 1)];
            for (int i = 1; i < Price.Length; i++)
            {
                Price[i] = Drop[i - 1].UnitPrice.ToString();
            }
            ViewBag.Price = Price;

            Drop = new List<Model.Data>();
            Drop = SIP.GetData(Data.OrderId);
            ViewBag.result = Drop;

            return View();
        }

        public ActionResult Update(Model.Data Data, string ID, string submit, string[] Pdt, string[] UnitPrice, string[] Qty)
        {
            if (submit == "true")
            {
                submit = "存檔";
            }
            else
            {
                submit = "刪除本筆訂單";
            }
            switch (submit)
            {
                case "存檔":
                    Service.SQL_Inquire SI = new Service.SQL_Inquire();
                    Service.SQL_Update SU = new Service.SQL_Update();
                    Service.SQL_Insert SIt = new Service.SQL_Insert();
                    List<Model.Data> LData = new List<Model.Data>();
                    Model.Data NData = new Model.Data();

                    NData.CustomerID = Data.CustName;
                    NData.EmployeeID = "null";
                    NData.ShipperID = "null";
                    LData = SI.GetData(NData);
                    Data.CustName = LData[0].CustName;
                    Data.CustomerID = LData[0].CustomerID;

                    NData = new Model.Data();
                    NData.EmployeeID = Data.EmpName;
                    NData.ShipperID = "null";
                    LData = SI.GetData(NData);
                    Data.EmpName = LData[0].EmpName;
                    Data.EmployeeID = LData[0].EmployeeID;

                    NData = new Model.Data();
                    NData.ShipperID = Data.CpyName;
                    NData.EmployeeID = "null";
                    LData = SI.GetData(NData);
                    Data.CpyName = LData[0].CpyName;
                    Data.ShipperID = LData[0].ShipperID;

                    Data.OrderId = ID;                    
                    SU.Update(Data);


                    SU.Delete(Data.OrderId);
                    if (Pdt != null)
                    {
                        for (int i = 0; i < Pdt.Length; i++)
                        {
                            Data.ProductID = Pdt[i];
                            Data.UnitPrice = UnitPrice[i];
                            Data.Qty = Qty[i];
                            SIt.Product(Data);
                        }
                    }


                    return RedirectToAction("index", "Inquire", new { OrderId = ID , ShipperID = "null", EmployeeID = "null" });
                case "刪除本筆訂單":
                    Service.SQL_Delete SD = new Service.SQL_Delete();
                    SD.Delete(ID);
                    return RedirectToAction("Index", "Inquire", new { OrderId = Data.OrderId });
            }
            return null;
        }

        public void DropDownListMakeCpy(List<Model.Data> Drop, Model.Data Data)
        {
            List<SelectListItem> CpyName = new List<SelectListItem>();
            if (Data.CpyName==null)
            {
                Data.CpyName = "無";
                Data.ShipperID = "0";
            }
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
        public void DropDownListMakePdt(List<Model.Data> Drop)
        {
            List<SelectListItem> Pdt = new List<SelectListItem>();

            for (int i = 0; i < Drop.Count; i++)
            {
                string re = Drop[i].ProductName.Replace("Product ", "");
                Pdt.Add(new SelectListItem()
                {
                    Text = re,
                    Value = Drop[i].ProductID
                });
            }
            ViewBag.Pdt = Pdt;
        }
    }
}