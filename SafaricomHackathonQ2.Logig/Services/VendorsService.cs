using Microsoft.Extensions.Logging;
using SafaricomHackathonQ2.Data;
using SafaricomHackathonQ2.Logic.Requests;
using SafaricomHackathonQ2.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafaricomHackathonQ2.Logic.Services
{
    public class VendorsService : IVendorsService
    {
        private readonly ILogger<VendorsService> _logger;
        private readonly SafaricomContext _context;

        public VendorsService(ILogger<VendorsService> logger, SafaricomContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<Guid> CreateVendorAsync(CreateVendorRequest vendor)
        {
            try
            {
                var vn = new Data.Models.Vendor()
                {
                    Active = vendor.Active,
                    Balance = vendor.Balance,
                    Name = vendor.Name
                };
                _context.Vendors.Add(vn);
                await _context.SaveChangesAsync();

                return vn.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating Vendor", ex);
                throw ex;
            }
        }
    }
}
