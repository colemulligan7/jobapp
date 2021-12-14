using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jobapp.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? make { get; set; }
        public string? model { get; set; }
        public string? year { get; set; }
        public string? vin { get; set; }
    }
}
