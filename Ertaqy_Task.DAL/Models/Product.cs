namespace Ertaqy_Task.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now;
        public int ProviderId { get; set; }
    }
}
