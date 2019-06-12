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

        /// <summary>
        /// Create a credit voucher
        /// </summary>
        /// <param name="createVoucherRequest">Params for creating voucher</param>
        /// <returns></returns>
        [HttpPost("Create")]
        [ProducesResponseType(typeof(VoucherResponse),StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVoucherAsync([FromBody] CreateVoucherRequest createVoucherRequest)
        {
            var result = await _creditVoucherService.CreateVoucherAsync(createVoucherRequest);
            return Ok(result);
        }

        /// <summary>
        /// De-Activating vouchers which have been active for more than given duration
        /// </summary>
        /// <param name="duration">duration from which to de-activate</param>
        /// <returns></returns>
        [HttpGet("DeActivateVouchers/{duration}")]
        public async Task<IActionResult> DeActivateVouchersAsync(int duration = 5)
        {
           await _creditVoucherService.DeActivateVouchersAsync(TimeSpan.FromMinutes(duration));
            return Ok();
        }
        

        /// <summary>
        /// Delete vouchers whose status is InActive
        /// </summary>
        /// <returns></returns>
        [HttpGet("DeleteInActiveVouchers")]
        public async Task<IActionResult> DeleteInActiveVouchersAsync()
        {
           await _creditVoucherService.DeleteInActiveVouchersAsync();
            return Ok();
        }

        /// <summary>
        /// Get vouchers created in less than 3 min
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get3MinVouchers")]
        [ProducesResponseType(typeof(List<VoucherResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get3MinVouchersAsync()
        {
           var response = await _creditVoucherService.Get3MinVouchersAsync();
            return Ok(response);
        }

        /// <summary>
        /// Get vourcher by its serial number
        /// </summary>
        /// <param name="serialNumber">Voucher serial number</param>
        /// <returns></returns>
        [HttpGet("GetVourcherbySerialNumber/{serialNumber}")]
        [ProducesResponseType(typeof(VoucherResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVourcherbySerialNumberAsync(string serialNumber)
        {
           var response = await _creditVoucherService.GetVourcherbySerialNumberAsync(serialNumber);
            return Ok(response);
        }
        /// <summary>
        /// Method for users to load credit into the their phone
        /// </summary>
        /// <param name="loadVoucherRequest">Params for loading a voucher</param>
        /// <returns></returns>
        [HttpPost("UserLoadVoucher")]
        [ProducesResponseType(typeof(LoadVoucherResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UserLoadVoucher([FromBody] LoadVoucherRequest loadVoucherRequest)
        {
           var response = await _creditVoucherService.UserLoadVoucher(loadVoucherRequest);
            return Ok(response);
        }
    }
}