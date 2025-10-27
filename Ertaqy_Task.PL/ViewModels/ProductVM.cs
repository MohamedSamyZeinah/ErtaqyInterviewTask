namespace Ertaqy_Task.PL.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public int ProviderId { get; set; }
    }
}
