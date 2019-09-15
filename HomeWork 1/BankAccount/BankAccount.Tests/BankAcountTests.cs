namespace BankAccount.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class BankAcountTests
    {
        private const decimal InitialAmount = 5000.0m;

        private BankAcount testAccount;

        [SetUp]
        public void Setup()
        {
            testAccount = new BankAcount(InitialAmount);
        }

        [Test]
        public void TestBankAccountShouldBeCreatedCorrectly()
        {
            BankAcount account = new BankAcount(InitialAmount);

            Assert.IsNotNull(account);
        }

        [Test]
        public void TestBankAccountAmountShouldBeSetCorrectly()
        {
            decimal expectedAmount = 5000.0m;
            decimal actualAmount = testAccount.Amount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void TestBankAccountShouldThrowExceptionWithNegativeAmount()
        {
            Assert.Throws<ArgumentException>(() => new BankAcount(-1000.0m));
        }

        [Test]
        public void TestBankAccountShouldThrowCorrectExceptionMessageWithNegativeAmount()
        {
            Assert.That(() => new BankAcount(-1000.0m), Throws.ArgumentException.With.Message.EqualTo("Amount can not be negative!"));
        }

        [Test]
        public void TestDepositShouldCorrectlyAddMoneyToAccount()
        {
            decimal moneyToDeposit = 2000.0m;

            testAccount.Deposit(moneyToDeposit);
            decimal expectedResult = 7000.0m;
            decimal actualResult = testAccount.Amount;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestDepositNegativeAmountThrowsException()
        {
            Assert.Throws<ArgumentException>(() => testAccount.Deposit(-1000.0m));
        }

        [Test]
        public void TestDepositNegativeAmountThrowsCorrectExceptionMessage()
        {
            string expectedExceptionMessage = "Deposit can not be negative!";
            string actualExceptionMessage = Assert.Throws<ArgumentException>(() => testAccount.Deposit(-1000.0m)).Message;

            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void TestWithdrawCorrectlyCalculatesFeeWhenAmountIsBelow1000()
        {
            decimal moneyToWithdraw = 500.0m;

            testAccount.Withdraw(moneyToWithdraw);
            decimal expectedResult = 4475.0m;
            decimal actualResult = testAccount.Amount;
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestWithdrawCorrectlyCalculatesFeeWhenAmountIsAbove1000()
        {
            decimal moneyToWithdraw = 2000.0m;

            testAccount.Withdraw(moneyToWithdraw);
            decimal expectedResult = 2960.0m;
            decimal actualResult = testAccount.Amount;
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestWithdrawCorrectlyCalculatesFeeWhenAmountIsExactly1000()
        {
            decimal moneyToWithdraw = 1000.0m;

            testAccount.Withdraw(moneyToWithdraw);
            decimal expectedResult = 3980.0m;
            decimal actualResult = testAccount.Amount;
            
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}