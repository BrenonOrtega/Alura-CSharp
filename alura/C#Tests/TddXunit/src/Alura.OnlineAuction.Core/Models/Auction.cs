using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Alura.OnlineAuction.Core.Models
{
    public class Auction
    {
        private ICollection<Bid> _bids { get; set; }

        private bool _isOpen;

        private readonly IAuctionType _auctionType;

        private Interested _lastBidInterested;
       
        public string Item { get; }

        public IEnumerable<Bid> Bids => _bids.ToImmutableArray();

        public Bid Winner { get; private set; }

        public Auction(string item, IAuctionType auctionType)
        {
            Item = item;
            _auctionType = auctionType;
            _bids = new HashSet<Bid>();
        }

        public void ReceiveBid(Interested client, decimal value)
        {
            if (AcceptedBid(client))
            {
                _lastBidInterested = client;
                _bids.Add(new Bid(_lastBidInterested, value));
            }
        }

        public void OpenTradingFloor() =>
            _isOpen = true;

        ///<exception cref="InvalidOperationException"> Throws when an attempt to close the auction happen before opening it</exception>
        public void CloseTradingFloor()
        {
            if (!_isOpen)
                throw new InvalidOperationException("Cannot close an auction trading floor before it's opening");

            Winner = _auctionType.Audit(this);

            _isOpen = false;
        }

        private bool AcceptedBid(Interested client) =>
            _isOpen && _lastBidInterested != client;
    }
}
