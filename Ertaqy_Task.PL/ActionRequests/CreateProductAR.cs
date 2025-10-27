using System.ComponentModel.DataAnnotations;

namespace Ertaqy_Task.PL.ActionRequests
{
    public class CreateProductAR
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name must not exceed 100 characters.")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product price is required.")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than zero.")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Provider is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid provider ID.")]
        public int ProviderId { get; set; }
    }
}
