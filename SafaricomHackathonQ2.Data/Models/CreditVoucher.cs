using System;
using System.Collections.Generic;
using System.Text;

namespace SafaricomHackathonQ2.Data.Models
{
    public class CreditVoucher
    {
        public CreditVoucher()
        {
            VoucherStatus = VoucherStatus.Active;
        }

        public Guid Id { get; set; }
        public string VoucherNumber { get; set; }
        public string  SerialNumber { get; set; }
        public double Amount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public VoucherStatus VoucherStatus { get; set; }

        public virtual User User { get; set; }
        public Guid? UserId { get; set; }
        public virtual Vendor Vendor { get; set; }
        public Guid VendorId { get; set; }

    }

    public enum VoucherStatus
    {
        Taken,
        Purchased,
        Active,
        InACtive
    }
}
