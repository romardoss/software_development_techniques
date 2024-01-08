namespace CCL.Security.Identity
{
    public class Accountant : User
    {
        public Accountant(int userId, string name, string surname, 
            string login, string password, string userType) : 
            base(userId, name, surname, login, password, nameof(Accountant))
        {
        }
    }
}
