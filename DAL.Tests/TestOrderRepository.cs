using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestOrderRepository : BaseRepository<Order>
    {
        public TestOrderRepository(DbContext context) : base(context)
        {
        }
    }
}
