using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        internal ClientRepository(DeliveryContext context) : base(context) { }
    }
}
