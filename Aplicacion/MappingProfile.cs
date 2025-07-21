using AutoMapper;
using uttt.Micro.Libro.Modelos;


namespace Uttt.Micro.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();

        }
    }
}