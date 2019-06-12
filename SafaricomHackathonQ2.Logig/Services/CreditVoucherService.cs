using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SafaricomHackathonQ2.Data;
using SafaricomHackathonQ2.Data.Models;
using SafaricomHackathonQ2.Logic.Requests;
using SafaricomHackathonQ2.Logic.Responses;
using SafaricomHackathonQ2.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafaricomHackathonQ2.Logic.Services
{
    public class CreditVoucherService : ICreditVoucherService
    {
        private readonly ILogger<CreditVoucherService> _logger;
        private readonly SafaricomContext _context;


        public CreditVoucherService(SafaricomContext context, ILogger<CreditVoucherService> logger)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<VoucherResponse> CreateVoucherAsync(CreateVoucherRequest createVoucherRequest)
        {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(x => x.Id == createVoucherRequest.VendorId);
            if (vendor == null) throw new Exception("vendor not found");

            if (vendor.Balance < createVoucherRequest.Amount) throw new Exception("You dont have enough credit");

            var newVoucher = new CreditVoucher
            {
                Amount = createVoucherRequest.Amount,
                VendorId = vendor.Id
            };

            newVoucher.VoucherNumber = GenerateVoucher(4);

            vendor.Balance -= createVoucherRequest.Amount;

            _context.CreditVouchers.Add(newVoucher);

            await _context.SaveChangesAsync();

            return new VoucherResponse()
            {
                Amount = newVoucher.Amount,
                DateCreated = newVoucher.DateCreated,
                SerialNumber = newVoucher.SerialNumber,
                DateUpdated = newVoucher.DateUpdated,
                ExpiryDate = newVoucher.ExpiryDate,
                Id = newVoucher.Id,
                VoucherNumber = newVoucher.VoucherNumber,
                VoucherStatus = newVoucher.VoucherStatus
            };
        }

        public async Task DeActivateVouchersAsync(TimeSpan duration)
        {
            var dateBefore = DateTime.Now.Add(-duration);
            var vouchers = await _context.CreditVouchers.Where(x => x.DateCreated < dateBefore).ToListAsync();

            if (vouchers != null && vouchers.Any())
            {
                foreach (var voucher in vouchers)
                {
                    voucher.VoucherStatus = VoucherStatus.InACtive;
                }
                await _context.SaveChangesAsync();
            };
        }

        public async Task DeleteInActiveVouchersAsync()
        {
            var vouchers = await _context.CreditVouchers.Where(x => x.VoucherStatus == VoucherStatus.InACtive).ToListAsync();

            if (vouchers != null && vouchers.Any())
            {
                //_context.CreditVouchers.RemoveRange(vouchers);
                foreach (var voucher in vouchers)
                {
                    voucher.Deleted = true;
                }
                await _context.SaveChangesAsync();
            };
        }

        public async Task<List<VoucherResponse>> Get3MinVouchersAsync()
        {
            var result = new List<VoucherResponse>();
            var min3 = DateTime.Now.AddMinutes(-3);
            var vouchers = await _context.CreditVouchers.Where(x => x.DateCreated < min3).ToListAsync();
            if (vouchers != null && vouchers.Any())
            {
                foreach (var newVoucher in vouchers)
                {
                    result.Add(new VoucherResponse()
                    {
                        Amount = newVoucher.Amount,
                        DateCreated = newVoucher.DateCreated,
                        SerialNumber = newVoucher.SerialNumber,
                        DateUpdated = newVoucher.DateUpdated,
                        ExpiryDate = newVoucher.ExpiryDate,
                        Id = newVoucher.Id,
                        VoucherNumber = newVoucher.VoucherNumber,
                        VoucherStatus = newVoucher.VoucherStatus
                    });
                }
            }
            return result;
        }

        public async Task<VoucherResponse> GetVourcherbySerialNumberAsync(string serialNumber)
        {
            var newVoucher = await _context.CreditVouchers.FirstOrDefaultAsync(x=>x.SerialNumber == serialNumber);
            if (newVoucher == null) return null;

            return new VoucherResponse()
            {
                Amount = newVoucher.Amount,
                DateCreated = newVoucher.DateCreated,
                SerialNumber = newVoucher.SerialNumber,
                DateUpdated = newVoucher.DateUpdated,
                ExpiryDate = newVoucher.ExpiryDate,
                Id = newVoucher.Id,
                VoucherNumber = newVoucher.VoucherNumber,
                VoucherStatus = newVoucher.VoucherStatus
            };
        }

        public async Task<LoadVoucherResponse> UserLoadVoucher(LoadVoucherRequest loadVoucherRequest)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == loadVoucherRequest.PhoneNumber);

            if (user == null) return null;

            var voucher = await _context.CreditVouchers.FirstOrDefaultAsync(x => x.VoucherNumber == loadVoucherRequest.VoucherNumber);
            if (voucher == null || voucher.ExpiryDate < DateTime.Now || voucher.VoucherStatus != VoucherStatus.Active) return null;

            user.Balamce = voucher.Amount;
            voucher.UserId = user.Id;
            voucher.VoucherStatus = VoucherStatus.Taken;
            await _context.SaveChangesAsync();

            return new LoadVoucherResponse()
            {
                NewBalance = user.Balamce
            };
        }

        private string GenerateVoucher(int n)
        {
            var random = new Random();
            string voucher = "";
            while (n > 0)
            {
                --n;
                voucher += random.Next(1000, 9999).ToString();
            }

            return voucher;

        }
    }
}
