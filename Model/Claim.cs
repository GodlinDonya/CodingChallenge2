using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Model
{
    internal class Claim
    {
        //        a.claimId;
        //b.claimNumber;
        //c.dateFiled;
        //d.claimAmount;
        //e.status;
        //f.policy;//Represents the policy associated with the claim
        //g.client;
        public int ClaimId { get; set; }
        public DateTime DateFiled { get; set; }
        public float ClaimAmount { get; set; }
        public string Status { get; set; }
        public string Policy { get; set; }
        public string Client { get; set; }
        public Claim()
        {
            
        }
        public Claim(int claimid, DateTime datefiled, float claimamount,string status, string policy, string client)
        {
            ClaimId=claimid;
            DateFiled=datefiled;
            ClaimAmount=claimamount;
            Status=status;
            Policy=policy;
            Client=client;
        }
        public override string ToString()
        {
            return $"Claim Id:{ClaimId} Date Filed:{DateFiled} ClaimAmount:{ClaimAmount} Status:{Status} Policy:{Policy}, Client:{Client}";
            
       
    }
    }
}
