using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibResto;

namespace _1prueba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurante restaurant = new Restaurante();
            Cocinero cocinero = new Cocinero("Andres", "Arguindegui", "abc 123", "247", 300, "Cocinero", restaurant);

            // Arrange
            IConsumible carne = new Producto("Milanesa", 10, 105);
            IConsumible pure = new Producto("Pure", 5, 50);
            Dictionary<IConsumible, int> ingredientes2 = new Dictionary<IConsumible, int>
            {
                { carne, 1000 },
                { pure, 10000 }
            };

            // Act
            cocinero.CrearPlato("Carne con pure", 30, ingredientes2, 40);

            // Verificar el menú
            Console.WriteLine("Menú del restaurante:");
            foreach (Plato plato in restaurant.Menu)
            {
                Console.WriteLine(plato.Nombre);
            }

            // Verificar el stock
            Console.WriteLine("Stock del restaurante:");
            foreach (IConsumible producto in restaurant.Stock)
            {
                Console.WriteLine($"{producto.Nombre}: {producto.Stock}");
            }

            // Assert
            List<Plato> platoSinStock = cocinero.PlatosSinStockSuficiente();
            Console.WriteLine("Platos sin stock suficiente:");
            foreach (Plato p in platoSinStock)
            {
                Console.WriteLine(p.Nombre);
            }

            Console.ReadKey();
        }

    }
}
