using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafaricomHackathonQ2.Logic.Requests;
using SafaricomHackathonQ2.Logic.Responses;
using SafaricomHackathonQ2.Logic.Services.Contracts;

namespace SafaricomHackathonQ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly ICreditVoucherService _creditVoucherService;
        public VoucherController(ICreditVoucherService creditVoucherService)
        {
            _creditVoucherService = creditVoucherService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(VoucherResponse),StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVoucherAsync([FromBody] CreateVoucherRequest createVoucherRequest)
        {
            var result = await _creditVoucherService.CreateVoucherAsync(createVoucherRequest);
            return Ok(result);
        }

        [HttpGet("DeActivateVouchers/{duration}")]
        public async Task<IActionResult> DeActivateVouchersAsync(int duration = 5)
        {
           await _creditVoucherService.DeActivateVouchersAsync(TimeSpan.FromMinutes(duration));
            return Ok();
        }
        
        [HttpGet("DeleteInActiveVouchers")]
        public async Task<IActionResult> DeleteInActiveVouchersAsync()
        {
           await _creditVoucherService.DeleteInActiveVouchersAsync();
            return Ok();
        }

        [HttpGet("Get3MinVouchers")]
        [ProducesResponseType(typeof(List<VoucherResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get3MinVouchersAsync()
        {
           var response = await _creditVoucherService.Get3MinVouchersAsync();
            return Ok(response);
        }

        [HttpGet("GetVourcherbySerialNumber/{serialNumber}")]
        [ProducesResponseType(typeof(VoucherResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVourcherbySerialNumberAsync(string serialNumber)
        {
           var response = await _creditVoucherService.GetVourcherbySerialNumberAsync(serialNumber);
            return Ok(response);
        }

        [HttpGet("UserLoadVoucher")]
        [ProducesResponseType(typeof(LoadVoucherResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UserLoadVoucher([FromBody] LoadVoucherRequest loadVoucherRequest)
        {
           var response = await _creditVoucherService.UserLoadVoucher(loadVoucherRequest);
            return Ok(response);
        }
    }
}