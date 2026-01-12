using CompartamosAppBackend.Models;

namespace CompartamosAppBackend.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction tx, CancellationToken ct);
    }
}
