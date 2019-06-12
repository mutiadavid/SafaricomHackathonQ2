using SafaricomHackathonQ2.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafaricomHackathonQ2.Logic.Responses
{
    public class VoucherResponse
    {
        public Guid Id { get; set; }
        public string VoucherNumber { get; set; }
        public string SerialNumber { get; set; }
        public double Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public VoucherStatus VoucherStatus { get; set; }
    }
}
