namespace CCL.Security.Identity
{
    public class Client : User
    {
        public Client(int userId, string name, string surname, 
            string login, string password, string userType) : 
            base(userId, name, surname, login, password, nameof(Client))
        {
        }
    }
}
