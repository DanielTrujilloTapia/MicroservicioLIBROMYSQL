using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using uttt.Micro.Libro.Modelos;
using uttt.Micro.Libro.Persistencia;
using Uttt.Micro.Libro.Aplicacion;


namespace uttt.Micro.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDto>>
        {
            public Ejecuta()
            {

            }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
        {
            private readonly ContextoLibreriaDbGlobal _contextoDbGlobal;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreriaDbGlobal contextoDbGlobal, IMapper mapper)
            {
                _contextoDbGlobal = contextoDbGlobal;
                _mapper = mapper;
            }

            public async Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _contextoDbGlobal.LibreriasMateriales.ToListAsync();
                var LibrosDto = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(libros);
                return LibrosDto;
            }
        }
    }
}
