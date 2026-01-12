using CompartamosAppBackend.Models;
using CompartamosAppBackend.Data;

namespace CompartamosAppBackend.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _db;

        public TransactionRepository(AppDbContext db) => _db = db;

        public Task AddAsync(Transaction tx, CancellationToken ct)
        {
            _db.Transactions.Add(tx);
            return Task.CompletedTask;
        }
    }
}
