﻿namespace api.Dtos.Home
{
    public class HomeDto
    {
        public List<HomeCategoryDto> HomeCategories { get; set; } = new();
        public HomeFinanceGoal HomeFinanceGoal { get; set; } = new();

        public HomeDto()
        {
            
        }
    }
}
