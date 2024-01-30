using Constant;
using dotenv.net;

namespace Service
{
    public class CommitAnalyzerService
    {
        public string GetCommitStatus()
        {
            DotEnv.Load();

            string token = Environment.GetEnvironmentVariable("token")!;

            GraphQLRequest graphQLRequest = new();

            return graphQLRequest.QueryGitHubGraphQLAsync(token, Query.GetCommitAnalysisQuery("techavantgarde")).Result;
        }
    }
}