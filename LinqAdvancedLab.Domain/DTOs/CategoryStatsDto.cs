namespace LinqAdvancedLab.Domain.DTOs
{
    public class CategoryStatsDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public int TotalProducts { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
