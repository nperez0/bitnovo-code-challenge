using Bitnovo.Common;
using Bitnovo.Customers.Application.Services;
using Bitnovo.Customers.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Customers.Api.Controllers
{
    [Route("api/customers/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomersAppService _customerAppService;

        public CustomerController(ICustomersAppService customersAppService)
        {
            _customerAppService = customersAppService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _customerAppService.GetCustomers();

            return result.OnBoth(ParseResult(result));
        }

        Func<Result, IActionResult> ParseResult(Result<CustomersResponse> response)
            => result => result.IsSuccess
                ? Ok(response.Value) as IActionResult
                : BadRequest(result.Error);
    }
}