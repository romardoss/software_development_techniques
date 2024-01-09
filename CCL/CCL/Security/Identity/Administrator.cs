namespace CCL.Security.Identity
{
    public class Administrator : User
    {
        public Administrator(int userId, string name, string surname, 
            string login, string password) : 
            base(userId, name, surname, login, password, nameof(Administrator))
        {
        }
    }
}
