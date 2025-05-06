using AutoMapper;  //  Asegúrate de que esta línea esté presente
using PalacioVerduras.API.Models;

namespace PalacioVerduras.API.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<Venta, VentaDTO>()
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.Cliente.IdUsuario))
                .ForMember(dest => dest.EmpleadoId, opt => opt.MapFrom(src => src.Empleado.IdUsuario))
                .ReverseMap()
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.Empleado, opt => opt.Ignore());
            CreateMap<ProductoVendido, ProductoVendidoDTO>().ReverseMap();
        }
    }
}