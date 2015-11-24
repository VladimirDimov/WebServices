using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articles.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
