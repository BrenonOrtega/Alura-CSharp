using System.Linq;

namespace Alura.OnlineAuction.Core.Models.AuctionTypes
{
    public class GreatestValue : IAuctionType
    {
        public Bid Audit(Auction auction)
        {
            return auction.Bids
                .DefaultIfEmpty(new Bid(new Interested("", auction), 0))
                .OrderBy(x => x.Value)
                .LastOrDefault();
        }
    }
}