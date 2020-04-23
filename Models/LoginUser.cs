using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models {
    public class LoginUser {
        [Required]
        [EmailAddress]
        [Display (Name = "Email Address : ")]
        public string LoginEmail { get; set; }

        [DataType (DataType.Password)]
        [Required]
        [Display (Name = "Password : ")]
        public string LoginPassword { get; set; }

    }
}