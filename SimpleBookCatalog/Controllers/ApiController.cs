using Microsoft.AspNetCore.Mvc;
using SimpleBookCatalog.Application.Interfaces;

namespace SimpleBookCatalog.Controllers
{
    [Route("api/books")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IBookRepository _bookRepository;

        public ApiController(ILogger<ApiController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet("library/{libraryId}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByLibrary(int libraryId)
        {
            _logger.LogInformation("Get all Books of Library");

            var books = await _bookRepository.GetByLibraryIdAsync(libraryId);
            if (books == null || !books.Any())
            {
                return NotFound();
            }
            var result = new
            {
                Aclaracion = "Esta API no contiene JWT.",
                Datos  = books,
                Salida = "Si desea ver la Api con JWT, debe realizar la petición Post (personalmente prefiero PostMan)" +
                " en 'http://joelgarbagnate-001-site1.etempurl.com/api/account/IsAuthenticated'," +
                " con las credenciales de usuario y se le otorgara un token de acceso"
            };
            return Ok(result);
        }
    }
}
