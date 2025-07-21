using System.ComponentModel.DataAnnotations;

namespace uttt.Micro.Libro.Modelos
{
    public class LibreriaMaterial
    {
        [Key]
        public Guid? LibreriaMaterialId { get; set; }
        public string Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }

        public int NewData { get; set; }

    }
}
