namespace api.Dtos.Home
{
    public class HomeCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal JanuaryPrev { get; set; } 
        public decimal JanuaryReal { get; set; } 
        public int FebruaryPrev { get; set; }
        public int FebruaryReal { get; set; }
        public string MarchPrev { get; set; } = string.Empty;
        public string MarchReal { get; set; } = string.Empty;
        public int AprilPrev { get; set; }
        public int AprilReal { get; set; }
        public string MayPrev { get; set; } = string.Empty;
        public string MayReal { get; set; } = string.Empty;
        public int JunePrev { get; set; }
        public int JuneReal { get; set; }
        public string JulyPrev { get; set; } = string.Empty;
        public string JulyReal { get; set; } = string.Empty;
        public int AugustPrev { get; set; }
        public int AugustReal { get; set; }
        public string SeptemberPrev { get; set; } = string.Empty;
        public string SeptemberReal { get; set; } = string.Empty;
        public int OctoberPrev { get; set; }
        public int OctoberReal { get; set; }
        public string NovemberPrev { get; set; } = string.Empty;
        public string NovemberReal { get; set; } = string.Empty;
        public int DecemberPrev { get; set; }
        public int DecemberReal { get; set; }
    }
}
