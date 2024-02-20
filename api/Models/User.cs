using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }


        public ICollection<Category> Categories { get; set; }
        //public ICollection<Transaction> Transactions { get; set; }
    }
}