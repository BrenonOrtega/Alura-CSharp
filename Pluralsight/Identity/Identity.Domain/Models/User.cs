namespace Identity.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FavoriteMovie { get; set; }
        public string Role { get; set; }

        public static User Null = new User()
        {
            Id = -1,
            Email = "",
            Name = "",
            Password = "",
            FavoriteMovie = "", 
            Role = ""
        };
    }
}