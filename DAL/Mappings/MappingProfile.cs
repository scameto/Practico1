using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using Shared;

namespace DAL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Persona, Personas>()
                          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                          .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                          .ForMember(dest => dest.Documento, opt => opt.MapFrom(src => src.Documento))
                          .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                          .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
                          .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
                          .ForMember(dest => dest.FechaNacimiento, opt => opt.MapFrom(src => src.FechaNacimiento));


            CreateMap<Personas, Persona>();
        }
    }
}
