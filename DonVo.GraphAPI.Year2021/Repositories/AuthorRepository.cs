using DonVo.GraphAPI.Year2021.Repositories.Interfaces;
using EfLinqQuerySnippets._03.AdvancedQuerying.Data;
using EfLinqQuerySnippets._03.AdvancedQuerying.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;

namespace DonVo.GraphAPI.Year2021.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookShopContext _context;

        public AuthorRepository(BookShopContext context)
        {
            this._context = context;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await Task.FromResult(_context.Authors.FirstOrDefault(i => i.AuthorId == id));
        }

        public async Task<Author[]> GetAuthors()
        {
            return await _context.Authors.ToArrayAsync();
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            EntityEntry<Author> entityEntry =  await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

    }
}
