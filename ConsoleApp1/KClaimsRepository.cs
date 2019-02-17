using System;
using System.Collections.Generic;
using static Challenge_02.KClaims;

namespace Challenge_02
{
    public class KClaimsRepository
    {
        List<KClaims> _claimList;
        Queue<KClaims> _claimQueue;

        public List<KClaims> SeeClaimList()
        {
            _claimList = new List<KClaims>();
            return _claimList;
        }
        public void AddClaimToList(KClaims claim)
        {
            _claimList.Add(claim);
        }
        public Queue<KClaims> GetClaimQueue()
        {
            _claimQueue = new Queue<KClaims>();
            return _claimQueue;
        }
        public void ResolveNextClaim()
        {
            _claimQueue.Dequeue();
        }
        public void AddContentToQueue(KClaims claim)
        {
            _claimQueue.Enqueue(claim);
        }
        public ClaimType GetTypeFromInt(int typeInput)
        {
            ClaimType type;
            switch (typeInput)
            {
                case 1:
                    type = ClaimType.Car;
                    break;
                case 2:
                    type = ClaimType.Home;
                    break;
                case 3:
                    type = ClaimType.Theft;
                    break;
                default:
                    type = ClaimType.Car;
                    break;
            }
            return type;

        }
    }
}