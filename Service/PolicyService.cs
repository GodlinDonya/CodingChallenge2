using Insurance_Management_System.Model;
using Insurance_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Service
{
    internal class PolicyService:IPolicyService
    {
        readonly IPolicyRepository _policyRepository;

        public PolicyService()
        {
            _policyRepository = new PolicyRepository();
        }
        public bool CreatePolicy(Policy policy)
        {
            try
            {
                int created = _policyRepository.CreatePolicy(policy);

                if (created > 0)
                {
                    Console.WriteLine("Policy Created Succesfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Policy Creation Failed.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in the creation of policy: {ex.Message}");
                return false;
            }
        }
        public Policy GetPolicyById(int policyId)
        {
            try
            {
                return _policyRepository.GetPolicyById(policyId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving policy: {ex.Message}");
                return null; 
            }
        }
        public List<Policy> GetAllPolicies()
        {
            try
            {
                return _policyRepository.GetAllPolicies();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving policies: {ex.Message}");
                return new List<Policy>(); 
            }
        }
        public bool UpdatePolicy(Policy policy)
        {
            try
            {
                int updated = _policyRepository.UpdatePolicy(policy);

                if (updated > 0)
                {
                    Console.WriteLine("Policy updated successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Policy update failed.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating policy: {ex.Message}");
                return false;
            }
        }
        public bool DeletePolicy(int policyId)
        {
            try
            {
                
                bool isDeleted = _policyRepository.DeletePolicy(policyId);

                if (isDeleted)
                {
                    Console.WriteLine("Policy deleted successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to delete policy.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting policy: {ex.Message}");
                return false;
            }
        }




    }
}
