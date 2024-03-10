using System.ComponentModel.DataAnnotations;

namespace LoginAPI_Tutorial.Models
{
    public class LoginRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, ErrorMessage = "Minimum 7 characters and maximum 50 characters is required ", MinimumLength = 7)]
        public string Email { get; set; }
       
        [StringLength(100, ErrorMessage = "Minimum 6 characters required", MinimumLength = 6)]
        [Required(ErrorMessage = "Required")]
        public string LoginID { get; set; }
    }
}
