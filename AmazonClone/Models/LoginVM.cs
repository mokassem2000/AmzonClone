using System.ComponentModel.DataAnnotations;

namespace AmazonClone.Models
{
    public class LoginVM
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string password { set; get; }
        public bool remberMe { set; get; }
    }
}
