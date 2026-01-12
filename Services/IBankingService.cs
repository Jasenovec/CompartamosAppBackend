using CompartamosAppBackend.Dtos;

namespace CompartamosAppBackend.Services
{
    public interface IBankingService
    {
        Task<AccountResponse?> GetAccountAsync(int id, CancellationToken ct);
        Task<(TransactionResponse? response, string? errorCode, string? errorMessage)> 
            CreateTransactionAsync(CreateTransactionRequest request, CancellationToken ct);
    }
}
