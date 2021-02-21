using DonVo.GraphAPI.Year2021.Repositories.Interfaces;
using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using GraphQL;
using GraphQL.Types;

namespace DonVo.GraphAPI.Year2021.GraphqlCore
{
    public class AuthorMutation : ObjectGraphType
    {
        public AuthorMutation(IAuthorRepository authorRepository)
        {
            FieldAsync<AuthorType>("createAuthor",
              arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AuthorInputType>> { Name = "author" }),
              resolve: async context =>
              {
                  Author author = context.GetArgument<Author>("author");
                  var result = await authorRepository.CreateAuthor(author);
                  return result;
              });
        }
    }
}
