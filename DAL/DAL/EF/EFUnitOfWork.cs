using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DeliveryContext db;
        private ClientRepository clientRepository;
        private OrderRepository orderRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new DeliveryContext(options);
        }

        public IClientRepository ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new ClientRepository(db);
                }
                return clientRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if(orderRepository == null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
    }
}
