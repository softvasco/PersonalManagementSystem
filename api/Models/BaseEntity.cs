using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
