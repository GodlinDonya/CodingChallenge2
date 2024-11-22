using Insurance_Management_System.Model;
using Insurance_Management_System.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.App
{
    internal class InsuranceApp
    {
        IPolicyService policyService = new PolicyService();

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Insurance Management System");
                Console.WriteLine("1. Create Policy");
                Console.WriteLine("2. Get Policy By Id");
                Console.WriteLine("3. Get all policy");
                Console.WriteLine("4. update policy");
                Console.WriteLine("5. delete policy");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreatePolicy();
                        break;
                    case 2:
                        GetPolicyById();
                        break;
                    case 3:
                        GetAllPolicies(); break;
                    case 4:
                        UpdatePolicy();
                        break;
                    case 5:
                        DeletePolicy();
                        break;
                    case 6:
                        exit=true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private void CreatePolicy()
        {
            //Console.WriteLine("Enter Policy ID:");
            //int policyId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Client Name:");
            string clientName = Console.ReadLine();

            Console.WriteLine("Enter Contact Info:");
            string contactInfo = Console.ReadLine();

            Console.WriteLine("Enter Policy Name:");
            string policyName = Console.ReadLine();

            var policy = new Policy
            {
                //PolicyId = policyId,
                ClientName = clientName,
                ContactInfo = contactInfo,
                PolicyName = policyName
            };

            bool isCreated = policyService.CreatePolicy(policy);

            if (isCreated)
            {
                Console.WriteLine("Policy created successfully!");
            }
            else
            {
                Console.WriteLine("Failed to create policy. Please try again.");
            }
        }
        public void GetPolicyById()

        {
            Console.WriteLine("Enter the policy Id:");
            int policyId=Convert.ToInt32(Console.ReadLine()) ;
            Policy policy = policyService.GetPolicyById(policyId);

            if (policy != null)
            {
                Console.WriteLine($"Client name {policy.ClientName}");
                Console.WriteLine($"Policy Name: {policy.PolicyName}");
                Console.WriteLine($"Policy ID:  {policy.PolicyId}");
                Console.WriteLine($"Contact Info:  {policy.ContactInfo}");
            }
            else
            {
                Console.WriteLine("Policy not found.");
            }
        }
        public void GetAllPolicies()
        {
            var policies = policyService.GetAllPolicies();

            if (policies.Count == 0)
            {
                Console.WriteLine("No policies available.");
                
            }

            foreach (var policy in policies)
            {
                Console.WriteLine($"Policy ID: {policy.PolicyId}");
                Console.WriteLine($"Policy Name: {policy.PolicyName}");
                Console.WriteLine($"Client Name: {policy.ClientName}");
                Console.WriteLine($"Contact Info: {policy.ContactInfo}");
               
            }
        }
        private void UpdatePolicy()
        {
            
            Console.WriteLine("Enter the Policy Name:");
            string policyName = Console.ReadLine();

            Console.WriteLine("Enter the Policy Id:");
            int policyId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the Client Name:");
            string clientName = Console.ReadLine();

            Console.WriteLine("Enter the Contact Info:");
            string contactInfo = Console.ReadLine();
            Policy updatedPolicy = new Policy
            {
                PolicyName = policyName,
                PolicyId = policyId,
                ClientName = clientName,
                ContactInfo = contactInfo
            };

            bool result = policyService.UpdatePolicy(updatedPolicy);

            if (result)
            {
                Console.WriteLine("Policy updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update policy.");
            }
        }
        private void DeletePolicy()
        {
            Console.WriteLine("Enter the Policy Id to delete:");
            int policyId = Convert.ToInt32(Console.ReadLine());

            bool result = policyService.DeletePolicy(policyId);

            if (result)
            {
                Console.WriteLine("Policy deleted successfully.");
            }
            else
            {
                Console.WriteLine("Failed to delete policy.");
            }
        }


    }

}

