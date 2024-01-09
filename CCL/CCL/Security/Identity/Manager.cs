namespace CCL.Security.Identity
{
    public class Manager : User
    {
        public Manager(int userId, string name, string surname, 
            string login, string password) : 
            base(userId, name, surname, login, password, nameof(Manager))
        {
        }
    }
}
