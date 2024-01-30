namespace Constant
{
    public static class OrganizationQuery
    {
        public static string GetAllOrganizations(int numberOfOrganizations)
        {
            string graphqlQuery = @"
        {
            viewer {
                organizations(first: {{{numberOfOrganizations}}}) {
                    nodes {
                        name
                        url
                    }
                }
            }
        }";
            return graphqlQuery.Replace("{{{numberOfOrganizations}}}", numberOfOrganizations.ToString());
        }
    }
}