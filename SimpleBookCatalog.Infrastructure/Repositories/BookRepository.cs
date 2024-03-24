using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Infrastructure.Context;

namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SimpleBookCatalogDbContext context;
        public BookRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            var books = await context.Books.ToListAsync();
            return books;
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await context.Books.SingleOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<List<Book>> GetByLibraryIdAsync(int libraryId)
        {
            return await context.Books
                                .Where(b => b.LibraryId == libraryId)
                                .ToListAsync();
        }
    }
}
