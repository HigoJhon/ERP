using backend.Models;

namespace backend.Repository
{
    public interface IClientRepository
    {
        IEnumerable<Clients> GetAll();
        Clients GetClientById(int id);
        Clients AddClient(Clients client);
        Clients UpdateClient(Clients client);
        Clients DeleteClient(int id);
    }
}