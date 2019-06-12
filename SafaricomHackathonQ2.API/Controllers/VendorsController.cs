using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafaricomHackathonQ2.Logic.Requests;
using SafaricomHackathonQ2.Logic.Services.Contracts;

namespace SafaricomHackathonQ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorsService _vendorService;
        public VendorsController(IVendorsService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVendorAsync([FromBody] CreateVendorRequest createVendorRequest)
        {
            var result = await _vendorService.CreateVendorAsync(createVendorRequest);
            return Ok(result);
        }
    }
}