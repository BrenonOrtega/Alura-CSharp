using Xunit;
using System;
using System.Collections.Generic;
using Alura.OnlineAuction.Core.Models;

namespace Alura.OnlineAuction.Core.Tests.Models.AuctionTests
{
    public class Auction_CloseTradingFloorTests
    {
        [Fact]
        public void NoBidAuction_WinnerValue_ShouldBeZero()
        {
            var auction = new Auction("Van Gogh");

            auction.OpenTradingFloor();
            auction.CloseTradingFloor();

            decimal expected = 0;
            var actual = auction.Winner.Value;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetValues))]
        public void AuctionWinner_ShouldReturnHighestBid(decimal expected, decimal[] offers)
        {
            var auction = new Auction("Monalisa");

            auction.OpenTradingFloor();

            foreach (var offer in offers)
                auction.ReceiveBid(new Interested($"test interested for offer {offer}", auction), offer);

            auction.CloseTradingFloor();

            var actual = auction.Winner.Value;

            Assert.Equal(expected: expected, actual: actual);
        }

        [Theory]
        [InlineData(1250, new double[] { 800, 400, 1500, 1350 })]
        public void WinnerBid_ShouldBeTheClosestTo_AuctionTargetValue(decimal targetValue, decimal[] offers)
        {
            var auction = new Auction("monalisa", targetValue);

            auction.OpenTradingFloor();

            foreach(var offer in offers)
                auction.ReceiveBid(new Interested($"interested offering {offer}", auction), offer);
            
            auction.CloseTradingFloor();

            var expected = auction.TargetValue;
            var actual = auction.Winner.Value;
        }

        [Fact]
        public void ClosingTradingFloor_BeforeOpening_ShouldThrow_InvalidOperationException()
        {
            var auction = new Auction("monalisa");

            var expectedMessage = "Cannot close an auction trading floor before it's opening";

            var exception = Assert.Throws(typeof(InvalidOperationException), () => auction.CloseTradingFloor());
            Assert.Equal(expectedMessage, exception.Message);
        }

        public static IEnumerable<object[]> GetValues()
        {
            yield return new object[] { 500, new decimal[] { 100, 200, 300, 400, 500 } };
            yield return new object[] { 100, new decimal[] { 100 } };
            yield return new object[] { 500, new decimal[] { 100, 500, 200, 350, 120 } };
        }
    }
}