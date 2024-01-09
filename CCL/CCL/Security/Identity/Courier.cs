namespace CCL.Security.Identity
{
    public class Courier : User
    {
        public Courier(int userId, string name, string surname, 
            string login, string password) : 
            base(userId, name, surname, login, password, nameof(Courier))
        {
        }
    }
}
