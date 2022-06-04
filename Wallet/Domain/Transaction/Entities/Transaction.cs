using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Guid? FromWalletId { get; set; }
        public Guid? ToWalletId { get; set; }
        public string? ToBankAccountId { get; set; }
        public TransactionType TransactionType { get; set; }


    }
}
