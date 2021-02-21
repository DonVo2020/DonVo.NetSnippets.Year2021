using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace DonVo.GraphAPI.Year2021.GraphqlCore
{
    public class AuthorSchema : Schema
    {
        public AuthorSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AuthorQuery>();
            Mutation = provider.GetRequiredService<AuthorMutation>();
        }
    }
}
