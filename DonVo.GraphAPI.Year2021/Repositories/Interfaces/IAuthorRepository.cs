using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonVo.GraphAPI.Year2021.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author[]> GetAuthors();
        Task<Author> GetAuthorById(int id);

        Task<Author> CreateAuthor(Author author);
    }
}
