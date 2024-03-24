using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using SimpleBookCatalog.Application.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly SimpleBookCatalogDbContext _context;

        public LibraryRepository(SimpleBookCatalogDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Library library)
        {
            _context.Libraries.Add(library);
            await _context.SaveChangesAsync();
        }

        public async Task<Library> GetByIdAsync(int id)
        {
            return await _context.Libraries.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
