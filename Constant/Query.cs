namespace Constant
{
  public static class Query
  {


    public static string GetCommitAnalysisQuery(string orgName)
    {
      string graphqlQuery = @"
{
  organization(login: ""ORG_NAME_PLACEHOLDER"") {
    repositories(first: 30) {
      nodes {
        name
        refs(first: 30, refPrefix: ""refs/heads/"") {
          nodes {
            name
            target {
              ... on Commit {
                history(first: 500) {
                  edges {
                    node {
                      messageHeadline
                      author {
                        user {
                          login
                        }
                        date
                      }
                    }
                  }
                  pageInfo {
                    hasNextPage
                    endCursor
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}";


      return graphqlQuery.Replace("ORG_NAME_PLACEHOLDER", orgName);
    }
  }
}
