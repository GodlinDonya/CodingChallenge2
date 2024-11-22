using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Model
{
    internal class Policy
    {
        public string PolicyName { get; set; }
        public int PolicyId { get; set; }

        public string ClientName { get; set; }
        public string ContactInfo { get; set; }
        


        public Policy() { }

        public Policy(string policyName, int policyId,string clientname,string contactinfo)
        {
            PolicyName = policyName;
            PolicyId = policyId;
            ClientName = clientname;    
            ContactInfo = contactinfo;

        }
    }
}

