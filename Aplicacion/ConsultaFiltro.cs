using AutoMapper;
using MediatR;
using uttt.Micro.Libro.Modelos;
using uttt.Micro.Libro.Persistencia;
using Uttt.Micro.Libro.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace uttt.Micro.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDto>
        {
            public Guid? LibroId { get; set; }
        }
        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            
            private readonly IMapper _mapper;
            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                
                _mapper = mapper;
                
            }

            public async Task<LibroMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var Libro = await _contexto.LibreriasMateriales.
                Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();

                if (Libro == null)
                {
                    throw new Exception("No se encontró el libro en ninguna base de datos.");
                }

                var libroDto = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(Libro);
                return libroDto;
            }

        }
    }
}

