using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;

namespace BLL.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            //Arrange
            IUnitOfWork nullUnitOfWork = null;

            //Act
            //Arrange
            Assert.Throws<ArgumentNullException>(() => new OrderService(nullUnitOfWork));
        }

        [Fact]
        public void GetOrders_UserIsCourier_ThrowsMethodAccessException()
        {
            //Arrange
            User user = new Courier(2, "Johny", "Davidson", "Jonik", "johny_the_great111");
            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IOrderService orderService = new OrderService(mockUnitOfWork.Object);

            //Act
            //Assert
            Assert.Throws<MethodAccessException>(() => orderService.GetOrders());
        }

        [Fact]
        public void GetOrders_OrderFromDAL_CorrectMappingToOrderDTO()
        {
            //Arrange
            User user = new CCL.Security.Identity.Client(0, "Steve", "Peterson", "steevee", "steve123");
            SecurityContext.SetUser(user);
            var orderService = GetOrderService();

            //Act
            var actualOrderDTO = orderService.GetOrders().First();

            //Assert
            Assert.True(
                actualOrderDTO.OrderId == 1
                && actualOrderDTO.ClientId == 2
                && actualOrderDTO.StaffToDeliver == "Ketchup"); ;
        }

        IOrderService GetOrderService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedOrder = new Order
            {
                OrderId = 1,
                ClientId = 2,
                StaffToDeliver = "Ketchup"
            };

            var mockDbSet = new Mock<IOrderRepository>();
            mockDbSet.Setup(z => z.Find(
                It.IsAny<Func<Order,bool>>()
                )).Returns(new List<Order> { expectedOrder });

            mockContext.Setup(context => context.OrderRepository).Returns(mockDbSet.Object);

            IOrderService orderService = new OrderService(mockContext.Object);

            return orderService;
        }
    }
}
