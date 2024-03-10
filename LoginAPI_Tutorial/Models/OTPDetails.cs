using System.ComponentModel.DataAnnotations;

namespace LoginAPI_Tutorial.Models
{
    public class OTPDetails
    {
        [Required]
        [StringLength(36, MinimumLength = 36, ErrorMessage = "Guid must be 36 characters long")]
        public string Guid { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "OTP must be 6 characters long")]

        [Required]
        public string OTPNumber { get; set; }
    }
}
