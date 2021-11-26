using AutoMapper;
using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCadeteria.Mapper
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<Cadete, MostrarCadetesVM>().ReverseMap();
        }
    }
}
