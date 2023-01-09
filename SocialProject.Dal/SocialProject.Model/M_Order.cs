﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialProject.Model
{
    public class M_Order
    {
        public int Code { get; set; }
        public string SA_code { get; set; }
        public string BC_code { get; set; }
        public int Campaign_code { get; set; }
        public int Product_code { get; set; }
        public DateTime Order_Time { get; set; }
        public bool Is_Sent { get; set; }
    }
}
