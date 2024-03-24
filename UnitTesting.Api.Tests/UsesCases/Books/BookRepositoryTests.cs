using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Enums;
using SimpleBookCatalog.Infrastructure.Context;
using SimpleBookCatalog.Infrastructure.Repositories;

namespace SimpleBookCatalog.UnitTesting.Api.Tests.UseCases.Books;

public class BookRepositoryTests
{
    private DbContextOptions<SimpleBookCatalogDbContext> CreateNewContextOptions()
    {
        return new DbContextOptionsBuilder<SimpleBookCatalogDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
    }
    //Agregar y traer libros
    [Fact]
    public async Task AddAndGetBookAsync()
    {
        var options = CreateNewContextOptions();

        // Arrange
        var factory = new InMemoryDbContextFactory<SimpleBookCatalogDbContext>(options);
        var arrangeRepository = new BookRepository(factory);
        var testBook = new Book
        {
            Title = "Test Book",
            Author = "Test Author",
            Description = "Test Description",
            Category = Category.Fantasia,
            LibraryId = 1
        };

        // Act
        await arrangeRepository.AddAsync(testBook);

        // Assert
        using var assertContext = new SimpleBookCatalogDbContext(options);
        var assertRepository = new BookRepository(factory);
        var retrievedBook = await assertRepository.GetByIdAsync(testBook.Id);

        Assert.NotNull(retrievedBook);
        Assert.Equal("Test Book", retrievedBook.Title);
        Assert.Equal("Test Author", retrievedBook.Author);
        Assert.Equal("Test Description", retrievedBook.Description);
        Assert.Equal(Category.Fantasia, retrievedBook.Category);
        Assert.Equal(1, retrievedBook.LibraryId);
    }

    //Actuualizar libros
    [Fact]
    public async Task UpdateBookAsync()
    {
        var options = CreateNewContextOptions();

        // Arrange
        var factory = new InMemoryDbContextFactory<SimpleBookCatalogDbContext>(options);
        var arrangeRepository = new BookRepository(factory);
        var book = new Book
        {
            Title = "Original Title",
            Author = "Original Author",
            Description = "Original Description",
            Category = Category.Fantasia,
            LibraryId = 1
        };

        await arrangeRepository.AddAsync(book);

        // Act
        book.Title = "Updated Title";
        book.Author = "Updated Author";
        await arrangeRepository.UpdateAsync(book);

        // Assert
        var updatedBook = await arrangeRepository.GetByIdAsync(book.Id);
        Assert.NotNull(updatedBook);
        Assert.Equal("Updated Title", updatedBook.Title);
        Assert.Equal("Updated Author", updatedBook.Author);
    }

    //Eliminar libros
    [Fact]
    public async Task DeleteBookByIdAsync()
    {
        var options = CreateNewContextOptions();

        // Arrange
        var factory = new InMemoryDbContextFactory<SimpleBookCatalogDbContext>(options);
        var arrangeRepository = new BookRepository(factory);
        var book = new Book
        {
            Title = "Test Book",
            Author = "Test Author",
            Description = "Test Description",
            Category = Category.Fantasia,
            LibraryId = 1
        };

        await arrangeRepository.AddAsync(book);

        // Act
        await arrangeRepository.DeleteByIdAsync(book.Id);

        // Assert
        var deletedBook = await arrangeRepository.GetByIdAsync(book.Id);
        Assert.Null(deletedBook);
    }
    private class InMemoryDbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
    {
        private readonly DbContextOptions<TContext> _options;

        public InMemoryDbContextFactory(DbContextOptions<TContext> options)
        {
            _options = options;
        }

        public TContext CreateDbContext()
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), _options);
        }
    }
}
