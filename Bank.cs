using System;
using System.Collections.Generic;
using System.Text;

namespace QBankingSystem
{
    public class Bank
    {
        public string Name;
        public List<Account> Accounts = new List<Account>();

        //add bank to system
        public Bank(string name)
        {
            Name = name;
        }

        //retrieve list of bank's accounts
        public void GetAccounts()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Bank: {0}\n", Name);
            sb.AppendLine();

            sb.AppendLine("Accounts");
            sb.AppendLine("---------");

            foreach (Account account in Accounts)
            {
                sb.AppendLine("Owner: " + account.Owner);
                sb.AppendLine("Type: " + account.Type);
                if (account.Type == AccountType.INVESTMENT) sb.AppendLine("Type:" + account.InvType);
                sb.AppendLine("Balance: $" + account.Balance);
                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        //create new account for this bank: 3 arguments
        public Account OpenCheckingAccount(string owner, double balance)
        {
            Account account = new Account(owner, balance, AccountType.CHECKING);
            Accounts.Add(account);
            return account;
        }

        //create new account for this bank: 4 arguments
        public Account OpenInvestmentAccount(string owner, double balance, InvestmentAccountType invType)
        {
            Account account = new Account(owner, balance, AccountType.INVESTMENT, invType);
            Accounts.Add(account);
            return account;
        }

        //remove account from this bank
        public void CloseAccount(Account account)
        {
            Accounts.Remove(account);
        }
    }
}
