using DonVo.GraphAPI.Year2021.Repositories.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace DonVo.GraphAPI.Year2021.GraphqlCore
{
    public class AuthorQuery : ObjectGraphType
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorQuery(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            Field<AuthorType>(
              "author",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "authorId" }),
              resolve: context => _authorRepository.GetAuthorById(context.GetArgument<int>("authorId"))
           );

            Field<ListGraphType<AuthorType>>(
             "authors",
             resolve: context => _authorRepository.GetAuthors());
        }
    }
}
