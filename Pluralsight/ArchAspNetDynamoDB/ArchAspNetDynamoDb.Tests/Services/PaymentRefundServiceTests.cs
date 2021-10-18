using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using ArchAspNetDynamoDb.Api.Services;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Infra.DynamoDb.Mappers;
using ArchAspNetDynamoDb.Infra.DynamoDb.Models;
using ArchAspNetDynamoDb.Infra.Repositories;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace ArchAspNetDynamoDb.Tests.Services
{
    public class PaymentRefundServiceTests
    {
        [Fact]
        public void GettingRefundPaymentsShouldMapCorrectly()
        {
            //Given
            var payerDocument = "000.000.000-00";
            var payerName = "Default Test Name";
            var dateTime = new DateTime(2010, 8, 18);
            var paymentId = "00000000-0000-0000-0000-000000000000";
            var amount = 25;

            var dynamoPayments = new List<DynamoPaymentRefund>()
            {
                GetRefund(amount: amount), GetRefund(amount: amount), GetRefund(amount: amount), GetRefund(amount: amount), GetRefund(amount: amount), GetRefund(amount: amount), GetRefund(amount: amount),
            };

            var cfg = new MapperConfiguration(c => c.AddProfile(new PaymentRefundProfile()));
            var mapper = cfg.CreateMapper();
            var dynamoMapper = new DynamoMapper(mapper);

            //When
            IEnumerable<PaymentRefund> payments = mapper.Map<IEnumerable<PaymentRefund>>(dynamoPayments);

            //Then
            payments.Should().AllBeOfType<PaymentRefund>();
            payments.Should().Satisfy(GetPredicates(
                itemCount: payments.Count(),
                paymentId: paymentId,
                refundAmount: amount,
                paidOutDate: dateTime,
                payerName: payerName,
                payerDocument: payerDocument));
        }

        Expression<Func<PaymentRefund, bool>> GetPredicate(int itemCount, string paymentId,
            decimal refundAmount, DateTime paidOutDate, string payerName, string payerDocument)
        {
            Expression<Func<PaymentRefund, bool>> expression =
                refund =>
                    paymentId.Equals(refund.PaymentId)
                    && refundAmount.Equals(refund.Amount)
                    && paidOutDate.Equals(refund.PaidOutDate)
                    && payerName.Equals(refund.Payer.Name)
                    && payerDocument.Equals(refund.Payer.Document);

            return expression;
        }

        IEnumerable<Expression<Func<PaymentRefund, bool>>> GetPredicates(int itemCount, string paymentId,
            decimal refundAmount, DateTime paidOutDate, string payerName, string payerDocument)
        {
            for(var i = 0; i<= itemCount; i++)
                yield return GetPredicate(itemCount, paymentId, refundAmount, paidOutDate, payerName, payerDocument);
        }

        DynamoPaymentRefund GetRefund(string paymentId = "00000000-0000-0000-0000-000000000000",
            decimal amount = decimal.Zero, DateTime paidOutDate = default,
            string payerDocument = "000.000.000-00", string payerName = "Default Test Name")
            => new DynamoPaymentRefund()
            {
                PaymentId = paymentId,
                Amount = amount,
                PaidOutDate = paidOutDate == default ? DateTime.Now : paidOutDate,
                Payer = new Person()
                {
                    Document = payerDocument,
                    Name = payerName,
                    Bank = new Bank()
                    {
                        Branch = "001",
                        AccountNumber = "1231-2"
                    }
                }
            };
    }
}