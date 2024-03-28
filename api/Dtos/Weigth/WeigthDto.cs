namespace api.Dtos.Categories
{
    public class WeigthDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
        public decimal Kg { get; set; }
        public int UserId { get; set; }
        public bool IsEditing { get; set; }
    }
}