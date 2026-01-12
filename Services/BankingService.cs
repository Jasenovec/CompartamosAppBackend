using CompartamosAppBackend.Dtos;
using CompartamosAppBackend.Models;
using CompartamosAppBackend.Repositories;

namespace CompartamosAppBackend.Services
{
    public class BankingService : IBankingService
    {
        private readonly IAccountRepository _accounts;
        private readonly ITransactionRepository _transactions;

        public BankingService(IAccountRepository accounts, ITransactionRepository transactions)
        {
            _accounts = accounts;
            _transactions = transactions;
        }

        public async Task<AccountResponse?> GetAccountAsync(int id, CancellationToken ct)
        {
            var account = await _accounts.GetByIdAsync(id, ct);
            return account is null
                ? null
                : new AccountResponse(account.Id, account.AccountNumber, account.Balance);
        }

        public async Task<(TransactionResponse? response, string? errorCode, string? errorMessage)> CreateTransactionAsync(
            CreateTransactionRequest request,
            CancellationToken ct)
        {
            // Validation: amount must be > 0 (also covered by DataAnnotations)
            if (request.Amount <= 0)
                return (null, "INVALID_AMOUNT", "Amount must be greater than zero.");

            var account = await _accounts.GetByIdAsync(request.AccountId, ct);
            if (account is null)
                return (null, "ACCOUNT_NOT_FOUND", "Account was not found.");

            if (request.Type == TransactionType.WITHDRAW && account.Balance < request.Amount)
                return (null, "INSUFFICIENT_BALANCE", "Insufficient balance for withdrawal.");

            // Update balance
            account.Balance = request.Type == TransactionType.DEPOSIT
                ? account.Balance + request.Amount
                : account.Balance - request.Amount;

            var tx = new Transaction
            {
                AccountId = account.Id,
                Type = request.Type,
                Amount = request.Amount,
                CreatedAt = DateTime.UtcNow
            };

            await _transactions.AddAsync(tx, ct);
            await _accounts.SaveChangesAsync(ct);

            var response = new TransactionResponse(
                tx.Id,
                tx.AccountId,
                tx.Type,
                tx.Amount,
                tx.CreatedAt,
                account.Balance
            );

            return (response, null, null);
        }
    }
}
