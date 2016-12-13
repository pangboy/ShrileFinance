namespace Core.Entities.Loan.Tests
{
    using System;
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoanTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeAppException))]
        public void Ctor_PrincipleZero()
        {
            var loan = new Loan(0, DateTime.MinValue, DateTime.MinValue, "001");

            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeAppException))]
        public void Ctor_SpecialDateLaterThanMatureDate()
        {
            var loan = new Loan(1000, DateTime.MaxValue, DateTime.MinValue, "001");

            Assert.Fail();
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullAppException))]
        public void Ctor_ContractNumberEmpty()
        {
            var loan = new Loan(1000, DateTime.MinValue, DateTime.MinValue, string.Empty);

            Assert.Fail();
        }

        [TestMethod]
        public void AddPaymentHistory_ActualPaymentPrincipalLessThanBalance()
        {
            var loan = new Loan(1000, DateTime.MinValue, DateTime.MaxValue, "001");
            var payment = new PaymentHistory(600, 0, 600, 0);

            try
            {
                loan.AddPaymentHistory(payment);

                Assert.AreEqual(loan.Principle - loan.Balance, payment.ActualPaymentPrincipal);
            }
            catch (ArgumentOutOfRangeAppException)
            {
                Assert.Fail();
            }

            try
            {
                loan.AddPaymentHistory(payment);

                Assert.Fail();
            }
            catch (ArgumentOutOfRangeAppException)
            {
            }

            Assert.AreEqual(loan.Payments.Count, 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeAppException))]
        public void AddPaymentHistory_DatePaymentLaterThanLastDatePayment()
        {
            var loan = new Loan(1000, DateTime.MaxValue, DateTime.MaxValue, "001");
            var payment = new PaymentHistory(600, 0, 600, 0);

            loan.AddPaymentHistory(payment);

            Assert.AreEqual(loan.Payments.Count, 0);
        }

        [TestMethod]
        public void Test()
        {
        }
    }
}