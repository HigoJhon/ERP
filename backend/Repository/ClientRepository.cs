using backend.Context;
using backend.Models;

namespace backend.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IERPContext _context;

        public ClientRepository(IERPContext context)
        {
            _context = context;
        }

        public IEnumerable<Clients> GetAll()
        {
            
            return _context.Clients.ToList();
        }

        public Clients GetClientById(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new ArgumentException("Client not found");
            }

            return client;
        }

        public Clients AddClient(Clients client)
        {
            var newClient = _context.Clients.FirstOrDefault(x => x.Id == client.Id);
            if (newClient != null)
            {
                throw new ArgumentException("Client already exists");
            }

            _context.Clients.Add(client);
            _context.SaveChanges();

            return client;
        }

        public Clients UpdateClient(Clients client)
        {
            var editClient = _context.Clients.Find(client.Id);

            if (editClient == null)
            {
                throw new ArgumentException("Client not found");
            }

            editClient.Name = client.Name;
            editClient.Phone = client.Phone;
            editClient.Email = client.Email;

            _context.SaveChanges();

            return editClient;
        }

        public Clients DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new ArgumentException("Client not found");
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();

            return client;
        }
    }
}