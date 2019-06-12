using Microsoft.EntityFrameworkCore;
using SafaricomHackathonQ2.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafaricomHackathonQ2.Data
{
    public class SafaricomContext : DbContext
    {
        public SafaricomContext(DbContextOptions<SafaricomContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<CreditVoucher> CreditVouchers { get; set; }
    }
}
