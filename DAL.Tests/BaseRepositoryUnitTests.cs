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
    }
}
