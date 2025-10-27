using System.ComponentModel.DataAnnotations;

namespace Ertaqy_Task.PL.ActionRequests
{
    public class CreateServicePrviderAR
    {
        [Required(ErrorMessage = "Provider name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string ProviderName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string ProviderEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^01[0-2,5]{1}[0-9]{8}$", ErrorMessage = "Please enter a valid Egyptian phone number")]
        public string ProviderPhoneNumber { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string ProviderAddress { get; set; } = string.Empty;

    }
}
