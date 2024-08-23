using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public interface IERPContext
    {
        DbSet<Clients> Clients { get; set; }
        int SaveChanges();
    }
}