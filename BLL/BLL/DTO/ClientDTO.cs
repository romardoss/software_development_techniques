using DAL.Entities;

namespace BLL.DTO
{
    public class ClientDTO
    {
        public int ClientID { get; set; }
        public string Department { get; set; }
        //public IEnumerable<Order> Orders { get; set; }
    }
}
