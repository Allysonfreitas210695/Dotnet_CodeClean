using System.ComponentModel.DataAnnotations;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get;  set; }
        public ICollection<Product> Products { get;  set; } 
    }
}