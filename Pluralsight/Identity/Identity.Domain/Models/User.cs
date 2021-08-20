namespace Identity.Domain.Models
{
    public class User
    {
        public static User NullUser = new User { Id = -1, Email = "", Name = "", Password = "", FavoriteMovie = "" };

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FavoriteMovie { get; set; }
        public string Role { get; set; }

        public User() { }

        public class UserBuilder
        {
            private User _instance;

            public UserBuilder() => _instance = new();

            public UserBuilder SetId(int id)
            {
                _instance.Id = id;
                return this;
            }

            public UserBuilder SetEmail(string email)
            {
                _instance.Email = email;
                return this;
            }

            public UserBuilder SetName(string name)
            {
                _instance.Name = name;
                return this;
            }

            public UserBuilder SetPassword(string Password)
            {
                _instance.Password = Password;
                return this;
            }

            public UserBuilder SetRole(string role) {
                _instance.Role = role;
                return this;
            }

            public UserBuilder SetFavoriteMovie(string movie)
            {
                _instance.FavoriteMovie = movie;
                return this;
            }

            public User Build()
            {
                var builtUser = _instance;
                _instance = User.NullUser;
                return builtUser;
            }
        }
    }
}