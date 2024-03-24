using Microsoft.AspNetCore.Http;

namespace SimpleBookCatalog.Infrastructure.Services
{
    public class SessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Logout()
        {
            try
            {
                _httpContextAccessor.HttpContext.Session.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante el inicio de sesión: {ex.Message}");
            }
        }
    }
}
