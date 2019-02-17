using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    public enum ClaimType { Car, Home, Theft }

    public class KClaims
    {
        public string ClaimId { get; set; }
        public ClaimType TypeofClaim { get; set; }
        public string Descrip { get; set; }
        public decimal ClaimAmount { get; set; }
        public string IncidentDate { get; set; }
        public string ClaimDate { get; set; }
        public bool IsValid { get; set; }

        public KClaims()
        {

        }

        public KClaims(string claimId, ClaimType claimType, string descrip, decimal claimAmount, string incidentDate, string claimDate, bool isValid)
        {
           
            ClaimId = claimId;
            TypeofClaim = claimType;
            Descrip = descrip;
            ClaimAmount = claimAmount;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
            IsValid = isValid;
         }   
    }
}



