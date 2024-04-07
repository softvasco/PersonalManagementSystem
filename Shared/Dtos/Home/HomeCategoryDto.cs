namespace Shared.Dtos.Home
{
    public class HomeCategoryDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public decimal JanuaryExpenses { get; set; }
        public decimal FebruaryExpenses { get; set; }
        public decimal MarchExpenses { get; set; }
        public decimal AprilExpenses { get; set; }
        public decimal MayExpenses { get; set; }
        public decimal JuneExpenses { get; set; }
        public decimal JulyExpenses { get; set; }
        public decimal AugustExpenses { get; set; }
        public decimal SeptemberExpenses { get; set; }
        public decimal OctoberExpenses { get; set; }
        public decimal NovemberExpenses { get; set; }
        public decimal DecemberExpenses { get; set; }
    }
}