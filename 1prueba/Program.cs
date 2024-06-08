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
            Cocinero cocinero = new Cocinero("Andres", "Arguindegui", "abc 123", "247", 300, "Cocinero");
            Producto milanesa = new Producto("Milanesa", 300, 105);
            Producto pure = new Producto("Pure", 100, 50);
            Dictionary<Producto, int> ingredientes = new Dictionary<Producto, int>
                {
                    {milanesa, 20},
                    {pure, 10}
            };
            Plato expected = new Plato("Milanesa con pure", 400, ingredientes, 30);

            cocinero.CrearPlato("Milanesa con pure", 400, ingredientes, 30);


            foreach (Plato plato in cocinero.Menu)
            {
                Console.WriteLine(plato.Nombre);
                Console.WriteLine(expected.Nombre);
            }

            Console.ReadKey();        
        }
    }
}
