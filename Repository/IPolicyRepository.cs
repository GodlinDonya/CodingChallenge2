using Insurance_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Repository
{
    internal interface IPolicyRepository
    {
        int CreatePolicy(Policy policy);
        Policy GetPolicyById(int policyId);
        List<Policy> GetAllPolicies();

        int UpdatePolicy(Policy policy);
        bool DeletePolicy(int policyId);
    }
}
