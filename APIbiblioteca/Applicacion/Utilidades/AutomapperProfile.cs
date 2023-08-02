using Applicacion.DTO;
using AutoMapper;
using Models;
using System.Globalization;

namespace Applicacion.Utilidades
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Libro, LibroDTO>()
                .ForMember(dest => dest.NombreAutor, opt => opt.MapFrom(src => src.Autor.Nombre))
                .ForMember(dest => dest.NombreGenero, opt => opt.MapFrom(src => src.Genero.Nombre))
                .ForMember(d => d.FechaLanzamiento,
                    opt => opt.MapFrom(o => o.FechaLanzamiento.ToString("dd/MM/yyyy")));


            CreateMap<LibroCreacionDTO, Libro>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Autor, opt => opt.Ignore())
                .ForMember(dest => dest.Genero, opt => opt.Ignore());


            CreateMap<Autor, AutorDTO>()
                   .ForMember(d => d.FechaNacimiento,
                    opt => opt.MapFrom(o => o.FechaNacimiento.ToString("dd/MM/yyyy")));

            CreateMap<AutorCreacionDTO, Autor>()
                .ForMember(d => d.FechaNacimiento,
                    opt => opt.MapFrom(o => DateTime.Parse(o.FechaNacimiento)));

            CreateMap<Genero, GeneroDTO>();
            CreateMap<GeneroCreacionDTO, Genero>();

            CreateMap<Comentario, ComentarioDTO>().ReverseMap();
        }
    }
}
