﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Merchant
{
    public class ReadMerchantDTO
    {
       
            public int ID { get; set; }
            public decimal PickUpPrice { get; set; }
            public decimal RejectedOrderPrice { get; set; }
            public string UserID { get; set; }
            public string CityName { get; set; }
            public string GovernorateName { get; set; }
            public string UserName { get;  set; }
            public string UserEmail { get;  set; }
            public string UserPhoneNumber { get; set; }
    }

    }
