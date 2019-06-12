using System;
using System.Collections.Generic;
using System.Text;

namespace SafaricomHackathonQ2.Logic.Requests
{
    public class CreateVendorRequest
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public double Balance { get; set; }
    }
}
