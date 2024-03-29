﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SafaricomHackathonQ2.Data.Models
{
    public class Vendor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public double Balance { get; set; }

        public virtual IList<CreditVoucher> CreditVouchers { get; set; }
    }
}
