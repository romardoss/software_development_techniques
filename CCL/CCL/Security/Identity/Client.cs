namespace CCL.Security.Identity
{
    public class Client : User
    {
        public Client(int userId, string name, string surname, 
            string login, string password) : 
            base(userId, name, surname, login, password, nameof(Client))
        {
        }
    }
}
