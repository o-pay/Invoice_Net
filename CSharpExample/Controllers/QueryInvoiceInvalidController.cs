﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPay.Einvoice.Integration.Sample.ViewModel;
using AllPay.EInvoice.Integration.Service;
using AllPay.EInvoice.Integration.Models;

namespace AllPay.Einvoice.Integration.Sample.Controllers
{
    public class QueryInvoiceInvalidController : Controller
    {
        // GET: /QueryInvoice/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(QueryInvoiceInvalidViewModel model)
        {
            //1. 設定發票作廢資訊
            QueryInvoiceInvalid qini = new QueryInvoiceInvalid();
            qini.MerchantID = model.MerchantID;
            qini.RelateNumber = model.RelateNumber;

            //2. 初始化發票Service物件
            Invoice<QueryInvoiceInvalid> inv = new Invoice<QueryInvoiceInvalid>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qini);

            //6. 解序列化，還原成物件使用
            //QueryInvoiceInvalidReturn obj = new QueryInvoiceInvalidReturn();
            //obj = JsonConvert.DeserializeObject<QueryInvoiceInvalidReturn>(json);
            //obj.XXX;
            //obj.XXX;
            // ...

            ViewBag.message = json;

            return View();
        }
    }
}
