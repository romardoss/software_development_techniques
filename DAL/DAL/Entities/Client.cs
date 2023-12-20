namespace DAL.Entities
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Department { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
