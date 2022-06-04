using Wallet.Domain.Entities;

namespace Wallet.Domain.Transaction.ValueObjects
{
    public class WalletToWalletTransactionInfo
    {
        public int Amount { get; set; }
        public Guid FromWalletId { get; set; }
        public Guid ToWalletId { get; set; }
        public TransactionType TransactionType { get; } = TransactionType.BetweenTwoWallet;
    }
}
