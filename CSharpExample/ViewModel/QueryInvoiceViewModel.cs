﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllPay.EInvoice.Integration.Models;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    /// <summary>
    /// 查詢發票API
    /// </summary>
    public class QueryInvoiceViewModel
    {
        public string MerchantID { get; set; }
        public string RelateNumber { get; set; }
    }
}