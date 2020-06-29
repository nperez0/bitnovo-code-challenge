using System;
using Microsoft.AspNetCore.Mvc;
using Bitnovo.Banking.Shared.Responses;
using Bitnovo.Banking.Shared.Requests;
using Bitnovo.Banking.Application.Services;
using System.Threading.Tasks;
using Bitnovo.Common;

namespace Banking.Api.Controllers
{
    [Route("api/banking/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountsAppService _accountsAppService;

        public AccountController(IAccountsAppService accountsAppService)
        {
            _accountsAppService = accountsAppService;
        }

        // GET api/values
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> Get([FromBody]AccountsRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request");

            var result = await _accountsAppService.GetAccountsByCustomerIds(request);

            return result.OnBoth(ParseResult(result));
        }

        Func<Result, IActionResult> ParseResult(Result<AccountsResponse> response)
            => result => result.IsSuccess
                ? Ok(response.Value) as IActionResult
                : BadRequest(result.Error);
    }
}
