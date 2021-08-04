using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Alura.OnlineAuction.Core.Models
{
    public class Auction
    {
        private ICollection<Bid> _bids { get; set; }

        private bool _isOpen;

        private Interested _lastBidInterested;

        public IEnumerable<Bid> Bids => _bids.ToImmutableArray();

        public Bid Winner { get; private set; }

        public string Item { get; }

        public Auction(string item)
        {
            Item = item;
            _bids = new HashSet<Bid>();
        }

        ///<exception cref="InvalidOperationException">Throws when trading floor is not open yet.</exception>
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

        public void CloseTradingFloor()
        {
            if(!_isOpen)
                throw new InvalidOperationException("Cannot close an auction trading floor before it's opening");

            Winner = _bids
                .DefaultIfEmpty(new Bid(null, 0))
                .OrderBy(x => x.Value)
                .LastOrDefault();

            _isOpen = false;
        }

        private bool AcceptedBid(Interested client)
        {
            return _isOpen && _lastBidInterested != client;
        }
    }
}
