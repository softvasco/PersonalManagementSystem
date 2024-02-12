namespace api.Models
{
    public class TransactionFile : BaseEntity
    {
        public required User User { get; set; }
        public required string FileName { get; set; }
        public required byte[] FileData { get; set; }
    }
}
