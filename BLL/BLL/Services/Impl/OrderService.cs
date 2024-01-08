using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _database;
        
        public OrderService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<OrderDTO> GetOrders(int clientId)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();

            if(userType != typeof(CCL.Security.Identity.Client))
            {
                throw new MethodAccessException();
            }

            var ordersEntities = _database.ClientRepository.Get(clientId).Orders;

            var mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();

            var ordersDto = mapper.Map<IEnumerable<Order>, List<OrderDTO>>(ordersEntities);

            return ordersDto;
        }
    }
}
