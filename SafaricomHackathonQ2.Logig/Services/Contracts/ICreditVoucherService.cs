using SafaricomHackathonQ2.Logic.Requests;
using SafaricomHackathonQ2.Logic.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafaricomHackathonQ2.Logic.Services.Contracts
{
    public interface ICreditVoucherService
    {
        Task<VoucherResponse> CreateVoucherAsync(CreateVoucherRequest createVoucherRequest);
        Task<List<VoucherResponse>> Get3MinVouchersAsync();
        Task<VoucherResponse> GetVourcherbySerialNumberAsync(string serialNumber);
        Task DeActivateVouchersAsync(TimeSpan duration);
        Task DeleteInActiveVouchersAsync();
        Task<LoadVoucherResponse> UserLoadVoucher(LoadVoucherRequest loadVoucherRequest);
    }
}
