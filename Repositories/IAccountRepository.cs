using CompartamosAppBackend.Models;

namespace CompartamosAppBackend.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(int id, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
    }
}
