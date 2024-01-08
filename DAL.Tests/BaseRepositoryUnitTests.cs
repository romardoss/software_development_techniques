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

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodOfDbSetWithCorrectArg()
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
            repository.Delete(expecterOrder.OrderId);

            //Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expecterOrder.OrderId), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(expecterOrder), Times.Once());
        }

        /*
        [Fact]
        public void GetAll_WithoutParameters_CalledToListMethodOfDbSet()
        {
            //Arrange
            DbContextOptions options = new DbContextOptionsBuilder<DeliveryContext>().Options;
            var mockContext = new Mock<DeliveryContext>(options);
            var mockDbSet = new Mock<DbSet<Order>>();

            List<Order> expectedList = new List<Order>(){
                new() { OrderId = 1 },
                new() { OrderId = 2 },
                new() { OrderId = 3 },
                new() { OrderId = 4 },
                new() { OrderId = 5 },
            };

            mockDbSet = new Mock<DbSet<Order>>(GetQueryableMockDbSet<Order>(expectedList));

            mockContext.Setup(context => context.Set<Order>())
                .Returns(mockDbSet.Object);

            

            

            /*mockDbSet.Setup(mock => mock.ToList())
                .Returns(expectedList);

            var repository = new TestOrderRepository(mockContext.Object);


            //Act
            IEnumerable<Order> actualOrderList = repository.GetAll();

            //Assert
            //mockDbSet.Verify(dbSet => dbSet.ToList(), Times.Once());
            Assert.Equal(expectedList.Count, actualOrderList.Count());
        }

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }*/
    }
}
