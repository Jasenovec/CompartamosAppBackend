using CompartamosAppBackend.Dtos;
using CompartamosAppBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompartamosAppBackend.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly IBankingService _service;

        public TransactionsController(IBankingService service) => _service = service;

        /// <summary>Create a deposit or withdrawal transaction.</summary>
        /// <response code="201">Transaction created successfully.</response>
        /// <response code="400">Invalid request (e.g., amount <= 0).</response>
        /// <response code="404">Account was not found.</response>
        /// <response code="409">Insufficient balance for withdrawal.</response>
        [HttpPost]
        [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] CreateTransactionRequest request, CancellationToken ct)
        {
            var (response, errorCode, errorMessage) = await _service.CreateTransactionAsync(request, ct);

            if (response is not null)
                return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

            return errorCode switch
            {
                "ACCOUNT_NOT_FOUND" => NotFound(new { code = errorCode, message = errorMessage }),
                "INSUFFICIENT_BALANCE" => Conflict(new { code = errorCode, message = errorMessage }),
                _ => BadRequest(new { code = errorCode, message = errorMessage })
            };
        }
    }
}
