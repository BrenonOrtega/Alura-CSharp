using System.Linq;
using Alura.OnlineAuction.Core.Models;

namespace Alura.OnlineAuction.Core.Models.AuctionTypes
{
    public class ClosestToTargetValue : IAuctionType
    {
        public decimal TargetValue { get; set; }

        public ClosestToTargetValue(decimal targetValue)
        {
            TargetValue = targetValue;
        }

        public Bid Audit(Auction auction)
        {
            return auction.Bids
                .DefaultIfEmpty(new Bid(new Interested("", auction), 0))
                .Where(x => x.Value >= TargetValue)
                .OrderBy(x => x.Value)
                .FirstOrDefault();
        }
    }
}