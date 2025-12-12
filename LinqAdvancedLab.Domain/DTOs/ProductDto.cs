namespace LinqAdvancedLab.Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public short Stock { get; set; }
        public bool IsDiscontinued { get; set; }
    }
}

