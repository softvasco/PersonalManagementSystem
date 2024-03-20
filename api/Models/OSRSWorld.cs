using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class OSRSWorld
    {
        [Key]
        public int World { get; set; }
        public bool IsF2P { get; set; }
    }
}
