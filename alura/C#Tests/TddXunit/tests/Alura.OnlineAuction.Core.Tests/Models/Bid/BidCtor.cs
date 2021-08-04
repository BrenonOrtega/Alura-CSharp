using System;
using Alura.OnlineAuction.Core.Models;
using Xunit;

namespace Alura.OnlineAuction.Core.Tests.Models
{
    public class BidCtor
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        public void Throws_ArgumentException_When_BidValue_IsNotPositive(decimal value)
        {
            var auction = new Auction("monalisa");
            var testClient = new Interested("test client", auction);

            Assert.Throws(typeof(ArgumentException), () => new Bid(testClient, value));
        }
    }
}