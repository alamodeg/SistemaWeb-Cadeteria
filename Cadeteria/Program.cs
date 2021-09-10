using System;
using Cadeteria.Model;

namespace Cadeteria
{
    class Program
    {
        static void Main()
        {
            Pedido ped1 = new ("Cuidado con el perro", "Augier", "Avenida Siempre Viva", "0800355456");
            Console.WriteLine($"{ped1.Id}");
        }
    }
}
