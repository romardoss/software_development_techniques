namespace CCL.Security.Identity
{
    public class User
    {
        public int UserId { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Login { get; }
        public string Password { get; }
        protected string UserType { get; }

        public User(int userId, string name, string surname, 
            string login, string password, string userType)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            UserType = userType;
        }
    }
}
