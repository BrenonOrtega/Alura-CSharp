namespace Alura.OnlineAuction.Core.Models
{
    public interface IAuctionType
    {
        Bid Audit(Auction auction);
    }
}