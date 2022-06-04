using Wallet.Domain.Entities;

namespace Wallet.Domain.Transaction.ValueObjects
{
    public class BankToWalletTransactionInfo
    {
        public int Amount { get; set; }
        public Guid ToWalletId { get; set; }
        public TransactionType TransactionType { get; } = TransactionType.FromBankToWallet;
    }
}
