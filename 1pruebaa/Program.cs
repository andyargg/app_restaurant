using BibResto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1pruebaa
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            {
                Proveedor proveedor1 = new Proveedor("Proveedor 1", "Bebidas 1", "Efectivo", "22", "san martin 700", 4);
                Restaurante restaurante = new Restaurante();
                ContabilidadRestaurante contabilidad = new ContabilidadRestaurante();
                Encargado encargado = new Encargado("Andres", "ARrguindegui", "siempreviva123", "46", 1000, "empleado", restaurante, contabilidad);

                // Configurar condiciones para el test
                IConsumible bebida = new Bebida("CocaCola", 10, 1500, false);  // Precio alto para asegurar deuda

                // Agregar dinero disponible al contabilidad
                contabilidad.DineroDisponible = 1000;

                // Actuar: Llamar al método AgregarArticulo del Encargado
                encargado.AgregarArticulo(bebida, 1, proveedor1);

                // Verificar: Imprimir resultados para confirmar que la deuda se haya agregado correctamente
                decimal deuda = contabilidad.GetDeuda(proveedor1);
                decimal dineroDisponible = contabilidad.DineroDisponible;

                Console.WriteLine($"Deuda con {proveedor1.Nombre}: {deuda}");
                Console.WriteLine($"Dinero disponible después de la operación: {dineroDisponible}");

                // Esperar la entrada del usuario antes de cerrar la aplicación
                Console.ReadLine();



            }
        }
    }
}
