using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
