using System.Collections.Generic;

namespace STG_RestaurantBuzzer
{
    public interface IPartyRepository
    {
        void CreateParty(Party party);
        List<Party> WaitingParties();
    }
}