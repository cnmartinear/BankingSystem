using System;
using System.Text;
using System.Threading;

namespace QBankingSystem
{
    public enum AccountType
    {
        CHECKING,
        INVESTMENT
    }

    public enum InvestmentAccountType
    {
        INDIVIDUAL,
        CORPORATE
    }

    class Program
    {
        static void Main(string[] args)
        {

            Test test = new Test();
            test.TestDeposit();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);

            test.TestWithdrawal_Successful();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);

            test.TestWithdrawal_ExceedLimit();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);

            test.TestWithrawal_ExceedBalance();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);

            test.TestTransfer_AcrossBanks();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);

            test.TestTransfer_ExceedBalance();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);

            test.TestTransfer_Successful();
            Console.WriteLine("----------------------------------------------------");
            Thread.Sleep(3000);
        }
    }

    class Test
    {
        public void TestDeposit()
        {
            Bank bank = new Bank("Bank of America");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 500.00);
            bank.GetAccounts();

            chk.makeDeposit(15.99);
        }

        public void TestWithdrawal_Successful()
        {
            Bank bank = new Bank("Wells Fargo");
            Account chk = bank.OpenCheckingAccount("John Doe", 600.00);
            bank.GetAccounts();

            chk.makeWithdrawal(499);
        }

        public void TestWithdrawal_ExceedLimit()
        {
            Bank bank = new Bank("Wells Fargo");
            Account chk = bank.OpenCheckingAccount("John Doe", 600.00);
            bank.GetAccounts();

            chk.makeWithdrawal(501);
        }

        public void TestWithrawal_ExceedBalance()
        {
            Bank bank = new Bank("Regions Bank");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 7000.00);
            bank.GetAccounts();

            chk.makeWithdrawal(8000);
        }
        public void TestTransfer_ExceedBalance()
        {
            Bank bank = new Bank("Chase Bank");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 700.00);
            Account inv = bank.OpenInvestmentAccount("John Doe", 100000.00, InvestmentAccountType.INDIVIDUAL);
            bank.GetAccounts();

            chk.makeTransfer(inv, 5000);
        }

        public void TestTransfer_Successful()
        {
            Bank bank = new Bank("Wells Fargo");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 7000.00);
            Account inv = bank.OpenInvestmentAccount("John Doe", 100000.00, InvestmentAccountType.INDIVIDUAL);
            bank.GetAccounts();

            chk.makeTransfer(inv, 5000);
        }

        public void TestTransfer_AcrossBanks()
        {
            Bank bank1 = new Bank("Wells Fargo");
            Bank bank2 = new Bank("Bank of America");

            Account chk = bank1.OpenCheckingAccount("Jane Doe", 100.00);
            Account inv = bank2.OpenCheckingAccount("John Doe", 10);
            bank1.GetAccounts();
            bank2.GetAccounts();

            chk.makeTransfer(inv, 50);
        }
    }
}
