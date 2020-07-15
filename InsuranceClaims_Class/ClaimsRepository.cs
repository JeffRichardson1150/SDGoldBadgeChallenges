using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims_Class
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claim> _claimQueue = new Queue<Claim>();

        public Queue<Claim> GetAllClaims()
        {
            // return the queue of all existing claims
            return _claimQueue;
        }

        public void AddClaimToQueue(Claim newClaim)
        {
            _claimQueue.Enqueue(newClaim);
        }
    }
}
