namespace SimpleBookCatalog.Application.Interfaces
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<List<Book>> GetByLibraryIdAsync(int libraryId);
        Task UpdateAsync(Book book);
        Task DeleteByIdAsync(int id);
    }
}
