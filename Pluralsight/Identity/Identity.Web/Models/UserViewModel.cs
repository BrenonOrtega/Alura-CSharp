using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public string RedirectUrl { get; set; }

        public static UserViewModel NullObject => new UserViewModel
        {   
            Name = "string",
            Email = "string",
            Password = "string",
            Role = "string",
            FavoriteMovie = "string",
            RememberLogin = false,
        };
    }
}