using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace jobapp.Models
{
    public class Tech
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string? first_name { get; set; }
        [Display(Name = "Last Name")]
        public string? last_name { get; set; }
        public int Vehicle { get; set; }
    }
}
