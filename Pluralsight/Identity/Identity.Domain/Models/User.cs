namespace Identity.Domain.Models
{
    public class User
    {
        public static User NullUser = new User { Id = -1, Email = "", Name = "", Password = "", FavoriteMovie = "" };

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string FavoriteMovie { get; private set; }

        public User() { }
    }
}