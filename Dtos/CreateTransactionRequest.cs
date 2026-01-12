using System.ComponentModel.DataAnnotations;
using CompartamosAppBackend.Models;

namespace CompartamosAppBackend.Dtos
{
    public class CreateTransactionRequest
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Range(typeof(decimal), "0.01", "1000000000000")]
        public decimal Amount { get; set; }
    }
}
