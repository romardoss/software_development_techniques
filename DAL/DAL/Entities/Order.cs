namespace DAL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public string StaffToDeliver { get; set; }
    }
}
