using System.ComponentModel.DataAnnotations.Schema;


namespace jobapp.Models
{
    public class Pairs
    {
        public int Id { get; set; }
        [ForeignKey("Key")]
        public int key_id { get; set; }
        
        public virtual Key? Key { get; set; }
        [ForeignKey("Vehicle")]
        public int vehicle_id { get; set; }
        
        public virtual Vehicle? Vehicle { get; set; }
    }
}
