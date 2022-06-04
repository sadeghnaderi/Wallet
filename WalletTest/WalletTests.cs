using NUnit.Framework;
using System;
using Wallet.Domain.Entities;
using Wallet.Domain.Transaction.ValueObjects;
using Wallet.Domain.User.Commands;
using Wallet.Domain.User.Queries;
using System.Linq;
using Wallet.Domain.Transaction.Commands;
using Wallet.Domain.Transaction.Queries;
using Wallet.Implementation;

namespace WalletTest
{
    [TestFixture]
    public class MyTest
    {
        
        [Test]
        public void AreUserAndWalletCreated()
        {
            
            var userInfo = new UserInfo { Name = "Ali", Username = "AliSalehi", Password = "1234", BankAccountId = "3323239823" };

            UserCommands userCommands = new UserCommands();
            UserQueries userQueries = new UserQueries();

            userCommands.CreateUser(userInfo);
            var Users = userQueries.GetAllUsers();

            Assert.AreEqual(Users.Last().Username, "AliSalehi");

            var Wallet = userQueries.GetWalletByUserId(Users.Last().Id);
            Assert.IsNotNull(Wallet);
        }

        [Test]
        public void BankToWalletTransactionCheckRemainAmount()
        {
            var userInfo = new UserInfo { Name = "Ali", Username = "AliSalehi", Password = "1234", BankAccountId = "3323239823" };

            UserCommands userCommands = new UserCommands();
            UserQueries userQueries = new UserQueries();

            userCommands.CreateUser(userInfo);
            var Users = userQueries.GetAllUsers();

            var Wallet = userQueries.GetWalletByUserId(Users.Last().Id);
            
            var bankToWalletTransactionInfo = new BankToWalletTransactionInfo { Amount= 10000,ToWalletId= Wallet.Id };

            TransactionCommands transactionCommands = new TransactionCommands();

            transactionCommands.PayToWalletFromBankAccount(bankToWalletTransactionInfo);

            Assert.AreEqual(Wallet.RemainAmount, 10000);
        }
        [Test]
        public void WalletToBankTransactionCheckRemainAmount()
        {
            var userInfo = new UserInfo { Name = "Ali", Username = "AliSalehi", Password = "1234", BankAccountId = "3323239823" };

            UserCommands userCommands = new UserCommands();
            UserQueries userQueries = new UserQueries();

            userCommands.CreateUser(userInfo);
            var Users = userQueries.GetAllUsers();

            var Wallet = userQueries.GetWalletByUserId(Users.Last().Id);

            TransactionCommands transactionCommands = new TransactionCommands();

            var bankToWalletTransactionInfo = new BankToWalletTransactionInfo { Amount = 10000, ToWalletId = Wallet.Id };

            transactionCommands.PayToWalletFromBankAccount(bankToWalletTransactionInfo);

            var walletToBankTransactionInfo = new WalletToBankTransactionInfo { Amount = 4000,ToBankAccountId="2233299443", FromWalletId = Wallet.Id };

            transactionCommands.PayToBankAccountFromWallet(walletToBankTransactionInfo);

            Assert.AreEqual(Wallet.RemainAmount, 6000);
        }
        [Test]
        public void WalletToWalletTransactionCheckRemainAmount()
        {
            var userInfo = new UserInfo { Name = "Ali", Username = "AliSalehi", Password = "1234", BankAccountId = "3323239823" };
            var userInfo2 = new UserInfo { Name = "Mahdi", Username = "MahdiSalehi", Password = "1234", BankAccountId = "3523239823" };

            UserCommands userCommands = new UserCommands();
            UserQueries userQueries = new UserQueries();

            userCommands.CreateUser(userInfo);
            userCommands.CreateUser(userInfo2);
            var Users = userQueries.GetAllUsers();

            var Wallet = userQueries.GetWalletByUserId(Users.Last().Id);
            var Wallet2 = userQueries.GetWalletByUserId(Users.First().Id);

            TransactionCommands transactionCommands = new TransactionCommands();

            var bankToWalletTransactionInfo = new BankToWalletTransactionInfo { Amount = 10000, ToWalletId = Wallet.Id };
            transactionCommands.PayToWalletFromBankAccount(bankToWalletTransactionInfo);

            bankToWalletTransactionInfo = new BankToWalletTransactionInfo { Amount = 10000, ToWalletId = Wallet2.Id };
            transactionCommands.PayToWalletFromBankAccount(bankToWalletTransactionInfo);

            var walletToWalletTransactionInfo = new WalletToWalletTransactionInfo { Amount = 4000,ToWalletId = Wallet2.Id, FromWalletId = Wallet.Id };

            transactionCommands.TransferBetweenTwoWallet(walletToWalletTransactionInfo);

            Assert.AreEqual(Wallet.RemainAmount, 6000);
            Assert.AreEqual(Wallet2.RemainAmount, 14000);
        }
    }
}