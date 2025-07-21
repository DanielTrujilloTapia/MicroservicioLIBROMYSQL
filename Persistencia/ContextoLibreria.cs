using Microsoft.EntityFrameworkCore;
using uttt.Micro.Libro.Modelos;

namespace uttt.Micro.Libro.Persistencia
{
    public class ContextoLibreria : DbContext 
    {
        public ContextoLibreria(DbContextOptions <ContextoLibreria> options ) : base(options)
        {

        }
        
        public DbSet<LibreriaMaterial> LibreriasMateriales { get; set; }
    }
}
