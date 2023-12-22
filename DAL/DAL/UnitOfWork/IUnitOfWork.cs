using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository ClientRepository { get; }
        IOrderRepository OrderRepository { get; }
        void Save();
    }
}
