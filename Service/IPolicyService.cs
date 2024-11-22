using Insurance_Management_System.Model;
using Insurance_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Service
{
    internal interface IPolicyService
    {
        bool CreatePolicy(Policy policy);
        Policy GetPolicyById(int policyId);

        List<Policy> GetAllPolicies();
        bool UpdatePolicy(Policy policy);
        bool DeletePolicy(int policyId);
    }
}
