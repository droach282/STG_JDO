using System.Collections.Generic;
using System.Linq;

namespace STG_RestaurantBuzzer
{
    public class MockPartyRepository : IPartyRepository
    {
        private readonly List<Party> _parties = new List<Party>();

        public MockPartyRepository()
        {
            _parties.AddRange(new[]
            {
                new Party {Id = 5, PartySize = 5, WaitMinutes = 10},
                new Party {Id = 15, PartySize = 2, WaitMinutes = 5},
                new Party {Id = 25, PartySize = 10, WaitMinutes = 30}
            });
        }

        public void CreateParty(Party party)
        {
            party.WaitMinutes = 5;
            party.Id = 10;
            _parties.Add(party);
        }

        public List<Party> WaitingParties()
        {
            foreach (var party in _parties)
            {
                if (party.WaitMinutes == 0)
                    party.IsSeated = true;
                else
                    party.WaitMinutes--;
            }

            return _parties.Where(x => !x.IsSeated).ToList();
        }
    }
}
