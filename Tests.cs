using Microsoft.VisualStudio.TestTools.UnitTesting;
using QBankingSystem;

namespace BankingSystemTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestDeposit()
        {
            Bank bank = new Bank("Bank of America");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 500.00);
            bank.GetAccounts();

            chk.makeDeposit(15.99);
        }

        [TestMethod]
        public void TestWithdrawal_Successful()
        {
            Bank bank = new Bank("Wells Fargo");
            Account chk = bank.OpenCheckingAccount("John Doe", 600.00);
            bank.GetAccounts();

            chk.makeWithdrawal(499);
        }

        [TestMethod]
        public void TestWithdrawal_ExceedLimit()
        {
            Bank bank = new Bank("Wells Fargo");
            Account chk = bank.OpenCheckingAccount("John Doe", 600.00);
            bank.GetAccounts();

            chk.makeWithdrawal(501);
        }

        [TestMethod]
        public void TestWithrawal_ExceedBalance()
        {
            Bank bank = new Bank("Regions Bank");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 7000.00);
            bank.GetAccounts();
                        chk.makeWithdrawal(8000);
        }

        [TestMethod]
        public void TestTransfer_ExceedBalance()
        {
            Bank bank = new Bank("Chase Bank");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 700.00);
            Account inv = bank.OpenInvestmentAccount("John Doe", 100000.00, InvestmentAccountType.INDIVIDUAL);
            bank.GetAccounts();

            chk.makeTransfer(inv, 5000);
        }

        [TestMethod]
        public void TestTransfer_Successful()
        {
            Bank bank = new Bank("Wells Fargo");
            Account chk = bank.OpenCheckingAccount("Jane Doe", 7000.00);
            Account inv = bank.OpenInvestmentAccount("John Doe", 100000.00, InvestmentAccountType.INDIVIDUAL);
            bank.GetAccounts();

            chk.makeTransfer(inv, 5000);
        }

        [TestMethod]
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
