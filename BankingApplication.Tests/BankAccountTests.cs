using NUnit.Framework;
using NUnit.Framework.Legacy;
using BridgeLabz_Training.Review.BankingApplication;

namespace BankingApplication.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount(1000);
        }

        [Test]
        public void InitialBalance_ShouldBeSetCorrectly()
        {
            ClassicAssert.AreEqual(1000, account.Balance);
        }
    }
}
