using SimpleBookCatalog.Domain.Entities;

namespace SimpleBookCatalog.Application.Interfaces
{
    public interface ILibraryRepository
    {
        Task AddAsync(Library library);
        Task<Library> GetByIdAsync(int id);
    }
}

