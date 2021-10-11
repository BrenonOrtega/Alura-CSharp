using System;
using Factory.Application.Models;
using Xunit;

namespace Factory.Tests
{
    public class PaymentTests
    {
        [Fact]
        public void Instantiating_NonStandardPaymentShould_Throw_NotImplementedException()
        {
        //Given
            var throwsException =new Action(() => new Payment(350, "PagSeguro"));
        //Then
            Assert.Throws<NotImplementedException>(throwsException);
        }

        [Fact]
        public void Instantiating_with_StandardPayment_Should_Pass()
        {
        //Given
            var payment = new Payment(350, Payment.PaymentType.Mastercard);
        //Then
            Assert.True(payment.Type == Payment.PaymentType.Mastercard);
        }

    }
}