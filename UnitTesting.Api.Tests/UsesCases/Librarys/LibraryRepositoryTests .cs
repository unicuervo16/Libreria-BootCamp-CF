using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Infrastructure.Context;
using SimpleBookCatalog.Infrastructure.Repositories;


namespace SimpleBookCatalog.UnitTesting.Api.Tests.UserCase.Librarys;

public class LibraryRepositoryTests
{
    [Fact]
    //Librerias
    public async Task GetAllLibrarysTests()
    {
        var options = new DbContextOptionsBuilder<SimpleBookCatalogDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        // Arrange
        using var context = new SimpleBookCatalogDbContext(options);
        var repository = new LibraryRepository(context);

        var newLibrary = new Library
        {
            Name = "Test Library",
            Address = "123 Test Street",
            Email = "test@test.com",
            Password = "TestPassword123",
            CreationDate = DateTime.Now,
            IsActive = true
        };

        // Act
        await repository.AddAsync(newLibrary);

        // Assert
        var libraryInDb = await context.Libraries.FirstOrDefaultAsync(l => l.Id == newLibrary.Id);
        Assert.NotNull(libraryInDb);
        Assert.Equal("Test Library", libraryInDb.Name);
        Assert.Equal("123 Test Street", libraryInDb.Address);
        Assert.Equal("test@test.com", libraryInDb.Email);
        Assert.Equal("TestPassword123", libraryInDb.Password);
        Assert.True((DateTime.Now - libraryInDb.CreationDate).TotalMinutes < 5);
        Assert.True(libraryInDb.IsActive);
    }
}
