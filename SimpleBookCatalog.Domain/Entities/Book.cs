using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Domain.Enums;
using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Debe agregar un título")]
    [StringLength(100)]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Debe agregar un autor")]
    [StringLength(100)]
    public string? Author { get; set; }
    public DateTime PublicationDate { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Debe agregar una descripción")]
    [StringLength(100)]
    public string? Description { get; set; } = string.Empty;
    public int? PageCount { get; set; } = 0;
    [EnumDataType(typeof(Category), ErrorMessage = "Debe seleccionar una categoría")]
    public Category Category { get; set; }
    public int LibraryId { get; set; } // Clave foránea
    public Library Library { get; set; } // Propiedad de navegación
}
