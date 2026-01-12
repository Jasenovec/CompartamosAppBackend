using CompartamosAppBackend.Models;

namespace CompartamosAppBackend.Dtos
{
    public record TransactionResponse(
        int Id,
        int AccountId,
        TransactionType Type,
        decimal Amount,
        DateTime CreatedAt,
        decimal NewBalance
    );
}
