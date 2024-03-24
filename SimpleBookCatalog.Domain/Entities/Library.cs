using System.ComponentModel.DataAnnotations;

namespace SimpleBookCatalog.Domain.Entities
{
    public class Library
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe agregar un nombre para la librería")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Debe agregar un correo para la librería")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe agregar una contraseña para la librería")]
        public string Password { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public ICollection<Book>? Books { get; set; }

    }
}
