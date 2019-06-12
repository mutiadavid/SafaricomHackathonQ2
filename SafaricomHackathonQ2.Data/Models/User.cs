using System;
using System.Collections.Generic;
using System.Text;

namespace SafaricomHackathonQ2.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Balamce { get; set; }


        public virtual IList<CreditVoucher> CreditVouchers { get; set; }
    }
}
