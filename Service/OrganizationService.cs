using Constant;
using DTO.Organization;
using DTO.Package;

using dotenv.net;
using Middleware;
using Newtonsoft.Json.Linq;

namespace Service
{
    public class OrganizationService
    {
        public StatusResponse<List<OrganizationResponse>>? GetAllOrganizations(OrganizationRequest organizationRequest)
        {
            try
            {
                DotEnv.Load();
                string token = Environment.GetEnvironmentVariable("token")!;
                string query = string.Empty;

                GitHubApi gitHubApi = new();

                if (organizationRequest.NumberOfOrganizations > 0)
                {
                    query = OrganizationQuery.GetAllOrganizations(organizationRequest.NumberOfOrganizations);
                }
                else
                {
                    query = OrganizationQuery.GetAllOrganizations(10);
                }

                string response = gitHubApi.QueryQLAsync(token, query).Result;
                var jObject = JObject.Parse(response);
                var nodes = jObject.SelectToken("data.viewer.organizations.nodes");
                var organizationResponse = nodes!.ToObject<List<OrganizationResponse>>();

                return StatusResponse<List<OrganizationResponse>>.SuccessStatus(organizationResponse!, StatusCode.Success);

            }
            catch (Exception ex)
            {
                return StatusResponse<List<OrganizationResponse>>.FailureStatus(StatusCode.knownException, ex);
            }
        }
    }
}