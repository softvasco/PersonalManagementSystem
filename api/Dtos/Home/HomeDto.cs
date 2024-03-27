namespace api.Dtos.Home
{
    public class HomeDto
    {
        public HomeCategoryDto HomeCategoryDto { get; set; } = new();

        public HomeDto()
        {
            HomeCategoryDto = new();
        }
    }
}
