using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Middleware
{
    public class GitHubApi
    {
        public async Task<string> QueryQLAsync(string token, string query)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.github.com/graphql");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                request.Headers.Add("User-Agent", "CSharp-GraphQL-Client");
                request.Content = new StringContent(JsonConvert.SerializeObject(new { query = query }), Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}