using Microsoft.EntityFrameworkCore;
using uttt.Micro.Libro.Modelos;

namespace uttt.Micro.Libro.Persistencia
{
    public class ContextoLibreriaDbGlobal: DbContext
    {
        public ContextoLibreriaDbGlobal(DbContextOptions<ContextoLibreriaDbGlobal> options) : base(options) { }
        public DbSet<LibreriaMaterial> LibreriasMateriales { get; set; }
    }
}
