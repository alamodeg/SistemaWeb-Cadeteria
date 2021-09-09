using System;

namespace Cadeteria
{
    class Program
    {
        static void Main()
        {
            Pedido ped1 = new ("Cuidado con el perro", false, "Augier", "Avenida Siempre Viva", "0800355456");
            Console.WriteLine($"{ped1.Cliente.Apellido} y {ped1.Cliente.Direccion}");
        }
    }
}
