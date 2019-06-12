using System;
using System.Collections.Generic;
using System.Text;

namespace SafaricomHackathonQ2.Logic.Requests
{
    public class CreateVoucherRequest
    {
        public double Amount { get; set; }
        public Guid VendorId { get; set; }
    }
}
