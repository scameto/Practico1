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
                          .ForMember(dest => dest.Apellido, opt => opt.Ignore()) // Si no necesitas mapear
                          .ForMember(dest => dest.Telefono, opt => opt.Ignore()) // Si no necesitas mapear
                          .ForMember(dest => dest.Direccion, opt => opt.Ignore()) // Si no necesitas mapear
                          .ForMember(dest => dest.FechaNacimiento, opt => opt.Ignore()); // Si no necesitas mapear
        
        CreateMap<Personas, Persona>();
        }
    }
}
