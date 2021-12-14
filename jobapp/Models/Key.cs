using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobapp.Models
{using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    public class Key
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Display(Name = "Description")]
        public string? Desc { get; set; }
        public decimal Price { get; set; }
    }
}
