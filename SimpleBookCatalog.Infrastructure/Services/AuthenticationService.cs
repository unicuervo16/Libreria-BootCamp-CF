using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Infrastructure.Context;
using SimpleBookCatalog.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace SimpleBookCatalog.Infrastructure.Services
{
    public class AuthenticationService
    {
        private readonly SimpleBookCatalogDbContext _context;

        public AuthenticationService(SimpleBookCatalogDbContext context)
        {
            _context = context;
        }

        private readonly PasswordHasher<Library> _passwordHasher = new PasswordHasher<Library>();

        public async Task<Library> AuthenticateAsync(string email, string password)
        {
            try
            {
                var library = await _context.Libraries.FirstOrDefaultAsync(l => l.Email == email);

                if (library != null)
                {
                    var verificationResult = _passwordHasher.VerifyHashedPassword(library, library.Password, password);
                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        return library;
                    }
                    else
                    {
                        Console.WriteLine($"Falló la verificación de contraseña. Resultado: {verificationResult}");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró el usuario con ese correo electrónico.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error durante la autenticación: {ex.Message}");
            }

            return null;
        }

    }
}
