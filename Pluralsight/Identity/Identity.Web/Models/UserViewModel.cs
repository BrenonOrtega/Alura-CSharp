using System.ComponentModel.DataAnnotations;

namespace Identity.Web.Models
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string FavoriteMovie { get; set; }
        public bool RememberLogin { get; set; }
        public string RedirectUrl { get; set; }
    }
}