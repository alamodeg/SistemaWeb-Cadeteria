using AutoMapper;
using Cadeteria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppCadeteria.Models.ViewModels;

namespace WebAppCadeteria.Mapper
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<Cadete, MostrarCadetesVM>().ReverseMap();
            CreateMap<Pedido, MostrarPedidosVM>().ReverseMap();
            CreateMap<Pedido, AddPedidoVM>().ReverseMap();
            CreateMap<Pedido, EditPedidoVM>().ReverseMap();
        }
    }
}
