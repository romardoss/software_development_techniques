using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetOrders();
    }
}
