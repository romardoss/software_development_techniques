namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputOrderInstance_CalledAddMethodOfDbSetWithStreetInstance()
        {
            //Arrange
            DbContextOptions options = new DbContextOptionsBuilder<DeliveryContext>().Options;
            var mockContext = new Mock<DeliveryContext>(options);
            var mockDbSet = new Mock<DbSet<Order>>();

            mockContext.Setup(context => context.Set<Order>())
                .Returns(mockDbSet.Object);

            var repository = new TestOrderRepository(mockContext.Object);
            Order expecterOrder = new Mock<Order>().Object;

            //Act
            repository.Create(expecterOrder);

            //Assert
            mockDbSet.Verify(dbSet => dbSet.Add(expecterOrder), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDbSetWithCorrectId()
        {
            //Arrange
            DbContextOptions options = new DbContextOptionsBuilder<DeliveryContext>().Options;
            var mockContext = new Mock<DeliveryContext>(options);
            var mockDbSet = new Mock<DbSet<Order>>();

            mockContext.Setup(context => context.Set<Order>())
                .Returns(mockDbSet.Object);

            Order expecterOrder = new() { OrderId = 1 };
            mockDbSet.Setup(mock => mock.Find(expecterOrder.OrderId)).Returns(expecterOrder);

            var repository = new TestOrderRepository(mockContext.Object);
            

            //Act
            var actualOrder = repository.Get(expecterOrder.OrderId);

            //Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expecterOrder.OrderId), Times.Once());
            Assert.Equal(expecterOrder, actualOrder);
        }
    }
}
