using System;
using System.Collections.Generic;
using System.Text;

namespace QBankingSystem
{
    public class Account
    {
        public string Owner;
        public double Balance;
        public AccountType Type;
        public InvestmentAccountType InvType;

        //account constructor: 3 arguments
        public Account(string owner, double balance, AccountType type)
        {
            if (type == AccountType.CHECKING)
            {
                Owner = owner;
                Balance = balance;
                Type = type;
            }
            else
            {
                throw new Exception("You are required to assign an investment account type.");
            }

        }

        //account constructor: 4 arguments
        public Account(string owner, double balance, AccountType type, InvestmentAccountType invType)
        {
            if (type == AccountType.INVESTMENT)
            {
                Owner = owner;
                Balance = balance;
                Type = type;
                InvType = invType;
            }
            else
            {
                throw new Exception("You may not assign an investment account type to a checking account.");
            }

        }

        //retrieve account balance
        public double getBalance()
        {
            return Balance;
        }

        //deposit money into the current account
        public void makeDeposit(double amount)
        {
            Console.WriteLine("Depositing ${0}:",amount);
            Balance += amount;
            Console.WriteLine("\tYou've successfully deposited ${0} into the {1} account belonging to {2}. Balance is now ${3}.", amount, Type, Owner, Balance);
        }

        //withdraw money from the current account
        public void makeWithdrawal(double amount)
        {
            Console.WriteLine("Withdrawing ${0}:",amount);

            if (amount > Balance) //withdrawal amount exceeds available balance
            {
                Console.WriteLine("\tUh oh! You are attempting to withdraw more money than what's currently available in this account.");
            }
            else if (amount > 500) //amount exceeds withdrawal limit of $500
            {
                Console.WriteLine("\tUh oh! You cannot withdraw more than $500 from your account today.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine("\tYou've successfully withdrawn ${0} from the {1} account belonging to {2}. Balance is now ${3}.", amount, Type, Owner, Balance);
            }
        }

        //transfer money from the current account to the target account
        public void makeTransfer(Account account, double amount)
        {
            Console.WriteLine("Transfer ${0}:", amount);
            if (amount < Balance)
            {
                Balance -= amount;
                account.Balance += amount;
                Console.WriteLine("You've successfully transferred ${0} from the {1} account belonging to {2} to the {3} account belonging to {4}. Balance is now ${5}.", amount, Type, Owner, account.Type, account.Owner, account.Balance);
            }
            else //transfer amount exceeds available balance
            {
                Console.WriteLine("Uh oh! You are attempting to transfer more money than what's currently available in this account.", amount, Owner, Balance);
            }

        }
    }
}
