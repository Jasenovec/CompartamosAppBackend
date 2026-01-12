using CompartamosAppBackend.Dtos;
using CompartamosAppBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompartamosAppBackend.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IBankingService _service;

        public AccountsController(IBankingService service) => _service = service;

        /// <summary>Returns the account balance and basic account data by id.</summary>
        /// <param name="id">Account id.</param>
        /// <response code="200">Account was found.</response>
        /// <response code="404">Account was not found.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var account = await _service.GetAccountAsync(id, ct);
            return account is null ? NotFound() : Ok(account);
        }
    }

}
