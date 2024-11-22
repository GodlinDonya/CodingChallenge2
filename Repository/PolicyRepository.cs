using Insurance_Management_System.Model;
using Insurance_Management_System.Utility;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Management_System.Repository
{
    internal class PolicyRepository:IPolicyRepository
    {

        SqlCommand cmd = null;
        string connectionstring;
        public PolicyRepository()
        {
            connectionstring = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();

        }
        public int CreatePolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                
                sb.Append("INSERT INTO policies (ClientName, ContactInfo, PolicyName) ");
                sb.Append("VALUES (@ClientName, @ContactInfo, @PolicyName)");
                sb.Append("select scope_identity()");
                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PolicyID", policy.PolicyId);
                cmd.Parameters.AddWithValue("@ClientName", policy.ClientName);
                cmd.Parameters.AddWithValue("@ContactInfo", policy.ContactInfo);
                cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();

            }
        }
        public Policy GetPolicyById(int policyId)
        {
            Policy policy = null; 

            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT PolicyId, PolicyName, ClientName, ContactInfo ");
                sb.Append("FROM policies ");
                sb.Append("WHERE PolicyId = @PolicyId");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    policy = new Policy
                    { 
                        PolicyId = (int)reader["PolicyId"],
                        PolicyName = (string)reader["PolicyName"],
                        ClientName = (string)reader["ClientName"],
                        ContactInfo = (string)reader["ContactInfo"]
                    };
                }
            }

            return policy;
        }
        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies = new List<Policy>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("SELECT PolicyId, PolicyName, Description, Amount ");
                //sb.Append("FROM Policies");
                sqlConnection.Open();
                cmd.CommandText = "SELECT * From policies";
                cmd.Connection = sqlConnection; 

                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    policies.Add(new Policy
                    {
                        PolicyId = (int)reader["PolicyId"],
                        ClientName = (string)reader["ClientName"],
                        PolicyName = (string)reader["PolicyName"],
                        ContactInfo = (string)reader["ContactInfo"]
                    });
                }
            }

            return policies;
        }
        public int UpdatePolicy(Policy policy)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();

                //sb.Append("UPDATE Policies SET ");
                //sb.Append("PolicyName = @PolicyName,");
                //sb.Append("ClientName = @ClientName ");
                //sb.Append("ContactInfo = @ContactInfo ");
                //sb.Append("WHERE PolicyId = @PoliceId");

                cmd.CommandText = "Update Policies set PolicyName=@PolicyName,ClientName=@ClientName,ContactInfo =@ContactInfo where PolicyId=@PolicyId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PolicyId", policy.PolicyId);
                cmd.Parameters.AddWithValue("@ClientName", policy.ClientName);
                cmd.Parameters.AddWithValue("@ContactInfo", policy.ContactInfo);
                cmd.Parameters.AddWithValue("@PolicyName", policy.PolicyName);
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                return cmd.ExecuteNonQuery();

               
            }
        }
        public bool DeletePolicy(int policyId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("DELETE FROM policies ");
                sb.Append("WHERE PolicyId = @PolicyId");

                cmd.CommandText = sb.ToString();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PolicyId", policyId);
                cmd.Connection = sqlConnection;

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
        }
    }
}
