namespace Ertaqy_Task.BLL.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string PrdctName { get; set; } = string.Empty;
        public decimal PrdctPrice { get; set; }
        public DateTime CreationDate { get; set; }

        public string ProviderName { get; set; } = string.Empty;
        public int ProviderId { get; set; }
    }
}
