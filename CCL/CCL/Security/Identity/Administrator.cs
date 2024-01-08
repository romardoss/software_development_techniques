namespace CCL.Security.Identity
{
    public class Administrator : User
    {
        public Administrator(int userId, string name, string surname, 
            string login, string password, string userType) : 
            base(userId, name, surname, login, password, nameof(Administrator))
        {
        }
    }
}
