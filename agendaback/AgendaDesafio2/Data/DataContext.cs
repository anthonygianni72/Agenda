using AgendaDesafioAPI.Models;

using Microsoft.EntityFrameworkCore;

namespace AgendaDesafioAPI.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }

        public DataContext():base()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
