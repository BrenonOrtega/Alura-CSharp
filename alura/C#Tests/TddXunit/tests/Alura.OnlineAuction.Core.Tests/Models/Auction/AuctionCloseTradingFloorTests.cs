using Xunit;
using System;
using System.Collections.Generic;
using Alura.OnlineAuction.Core.Models;
using Alura.OnlineAuction.Core.Models.AuctionTypes;

namespace Alura.OnlineAuction.Core.Tests.Models.AuctionTests
{
    public class Auction_CloseTradingFloorTests
    {
        [Fact]
        public void NoBidAuction_WinnerValue_ShouldBeZero()
        {
            var auction = new Auction("Van Gogh", new GreatestValue());

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
            var auctionType = new GreatestValue();
            var auction = new Auction("Monalisa", auctionType);

            auction.OpenTradingFloor();

            foreach (var offer in offers)
                auction.ReceiveBid(new Interested($"test interested for offer {offer}", auction), offer);

            auction.CloseTradingFloor();

            var actual = auction.Winner.Value;

            Assert.Equal(expected: expected, actual: actual);
        }

        [Theory]
        [InlineData(1250, 1350, new double[] { 800, 400, 1500, 1350 })]
        public void WinnerBid_ShouldBeTheClosestTo_AuctionTargetValue(decimal targetValue, decimal expected, decimal[] offers)
        {
            var auctionType = new ClosestToTargetValue(targetValue); 
            var auction = new Auction("monalisa", auctionType);

            auction.OpenTradingFloor();

            foreach(var offer in offers)
                auction.ReceiveBid(new Interested($"interested offering {offer}", auction), offer);
            
            auction.CloseTradingFloor();

            var actual = auction.Winner.Value;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClosingTradingFloor_BeforeOpening_ShouldThrow_InvalidOperationException()
        {
            var auctionType = new GreatestValue();
            var auction = new Auction("monalisa", auctionType);

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