using CompartamosAppBackend.Data;
using CompartamosAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CompartamosAppBackend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db) => _db = db;

        public Task<Account?> GetByIdAsync(int id, CancellationToken ct) =>
            _db.Accounts.FirstOrDefaultAsync(a => a.Id == id, ct);

        public Task SaveChangesAsync(CancellationToken ct) =>
            _db.SaveChangesAsync(ct);
    }
}
