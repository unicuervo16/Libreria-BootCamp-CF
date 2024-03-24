using Microsoft.AspNetCore.Mvc;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Infrastructure.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SimpleBookCatalog.Application.Interfaces;
using static System.Reflection.Metadata.BlobBuilder;


namespace SimpleBookCatalog.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SimpleBookCatalogDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<ApiController> _logger;
        private readonly IBookRepository _bookRepository;

        public AccountController(SimpleBookCatalogDbContext context, IConfiguration config, IBookRepository bookRepository)
        {
            _context = context;
            _config = config;
            _bookRepository = bookRepository;
        }
        private Library Authenticate(Library library)
        {
            var currentUser = _context.Libraries
                .FirstOrDefault(l => l.Email == library.Email && l.Password == library.Password);

            return currentUser;
        }

        private string GenerateJwtToken(Library library)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, library.Id.ToString()),
            new Claim(ClaimTypes.Email, library.Email),
        }),
                Expires = DateTime.UtcNow.AddHours(1), // El token expira en 1 hora
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("IsAuthenticated")]
        public IActionResult Login(Library library)
        {
            var user = Authenticate(library);
            if(user != null)
            {
                var token = GenerateJwtToken(user);
                var result = new
                {
                    Aclaracion = "Esta API si contiene JWT.",
                    Token = token
                };
                return Ok(result);
            }
            return NotFound("Usuario no encontrado");
        }
    }
}
