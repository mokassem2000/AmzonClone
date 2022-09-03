using System.ComponentModel.DataAnnotations;

namespace AmazonClone.Models
{
    public class SignUpVM
    {
        [Required]
        public string UserName { set; get; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Enter Email")]
        public string Email { set; get; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { set; get; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password",ErrorMessage ="enter password right")]
        public string confirmPassword { set; get; }
    }
}
