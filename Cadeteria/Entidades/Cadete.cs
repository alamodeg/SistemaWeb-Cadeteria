﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    class Cadete
    {
        Guid id;
        string nombre;
        string apellido;
        string telefono;
        List<Pedido> listaPedidos;

        public Cadete(string nombre, string apellido, string telefono, List<Pedido> listaPedidos)
        {
            this.id = Guid.NewGuid();
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.listaPedidos = listaPedidos;
        }

        public Guid Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        internal List<Pedido> ListadoPedidos { get => listaPedidos; set => listaPedidos = value; }

        public void CargarPedido(Pedido pedido)
        {
            listaPedidos.Add(pedido); //El cadete carga pedidos a su lista
        }
    }
}
