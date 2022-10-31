using System;
using System.ComponentModel.DataAnnotations;

namespace pryBookstore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Display(Name = "Lanzamiento")]
        public DateTime ReleaseDate { get; set; }
        
        [MaxLength(30)]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Display(Name = "Pags. Totales")]
        public int NumberPages { get; set; }
        [Display(Name = "Editorial")]
        public string Editorial { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        [Display(Name = "Categoría")]
        public string Category { get; set; } 

        public Category ID_Category { get; set; } //Foránea de Category
    }
}
