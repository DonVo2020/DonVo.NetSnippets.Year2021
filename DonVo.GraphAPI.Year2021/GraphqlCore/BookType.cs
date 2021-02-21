using DonVo.GraphAPI.Year2021.Repositories.Interfaces;
using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using GraphQL.Types;

namespace DonVo.GraphAPI.Year2021.GraphqlCore
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IAuthorRepository repository)
        {
            Field(x => x.BookId).Description("Book Id.");
            Field(x => x.Title).Description("Book Title.");
            Field(x => x.Description).Description("Book Description.");
            Field(x => x.Price).Description("Book Price.");
            //Field(x => x.ReleaseDate).Description("Book Release Date.");
            Field<DateTimeGraphType>("date", resolve: context => context.Source.ReleaseDate);
            Field(x => x.AgeRestriction).Description("Book Age Restriction.");
        }
    }
}
