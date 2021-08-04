using Xunit;
using Alura.OnlineAuction.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace Alura.OnlineAuction.Core.Tests.Models.AuctionTests
{
    public class Auction_ReceiveBidTests
    {
        [Theory]
        [MemberData(nameof(GetValues))]
        public void ShouldNotAcceptBids_When_TradingFloorIsClosed(decimal[] offers)
        {
            var auction = new Auction("Abaporu");

            auction.OpenTradingFloor();

            foreach (var offer in offers)
                auction.ReceiveBid(new Interested($"test interested {offer}", auction), offer);

            auction.CloseTradingFloor();

            auction.ReceiveBid(new Interested("should not add this interested bid 1", auction), 0);
            auction.ReceiveBid(new Interested("should not add this interested bid 2", auction), 1);


            var expected = offers.Length;
            var actual = auction.Bids.Count();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetValues()
        {
            yield return new object[] { new decimal[] { 100, 200, 350, 100, 500 } };
            yield return new object[] { new decimal[] { 100, 200 } };
            yield return new object[] { new decimal[] { 100 } };
            yield return new object[] { new decimal[] { 100, 200, 350, 100, 500, 600, 700, 700, 800, 80, 50 } };
            yield return new object[] { new decimal[] { } };
        }

        [Fact]
        public void AuctionShouldNotAccept_ConsecutiveBids_FromSame_Interested()
        {
            var auction = new Auction("Mozart Partitures");
            var customer = new Interested("test interested customer", auction);

            auction.OpenTradingFloor();

            auction.ReceiveBid(customer, 100);
            auction.ReceiveBid(customer, 500);

            var expected = 1;
            var actual = auction.Bids.Count();

            Assert.Equal(expected, actual);
        }
    }
}