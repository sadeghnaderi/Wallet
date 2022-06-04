namespace Wallet.Domain.Entities
{
    public enum TransactionType
    {
        FromWalletToBank = 0,
        FromBankToWallet = 1,
        BetweenTwoWallet = 2
    }
}
