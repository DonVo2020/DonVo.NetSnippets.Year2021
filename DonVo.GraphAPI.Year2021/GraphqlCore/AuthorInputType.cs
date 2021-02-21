using GraphQL.Types;

namespace DonVo.GraphAPI.Year2021.GraphqlCore
{
    public class AuthorInputType : InputObjectGraphType
    {
        public AuthorInputType()
        {
            Name = "AuthorInputType";

            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
        }
    }
}
