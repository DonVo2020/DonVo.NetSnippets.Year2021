using DonVo.GraphAPI.Year2021.Repositories.Interfaces;
using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using GraphQL.Types;

namespace DonVo.GraphAPI.Year2021.GraphqlCore
{
    public class AuthorType : ObjectGraphType<Author> 
    {
        public AuthorType(IAuthorRepository repository)
        {
            Field(x => x.AuthorId).Description("Author Id.");
            Field(x => x.FirstName).Description("Author FirstName.");
            Field(x => x.LastName).Description("Author LastName.");
        }
    }
}
