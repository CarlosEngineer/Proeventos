
using Microsoft.EntityFrameworkCore;
using Proeventos.APi.Models;

namespace Proeventos.APi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options ) : base(options)
        {
            
        }

        public DbSet<Evento> Eventos { get; set; }
    }
}