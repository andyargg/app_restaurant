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
                // Crear instancias necesarias
                Restaurante restaurante = new Restaurante();
                ContabilidadRestaurante _contabilidad = new ContabilidadRestaurante();
                Encargado _encargado = new Encargado("Andres", "ARrguindegui", "siempreviva123", "46", 1000, "empleado", restaurante, _contabilidad);
                Mesero mesero1 = new Mesero("Juan", "Perez", "Dirección 123", "123456789", 1500, "Mesero", true, _encargado);
                Delivery delivery1 = new Delivery("Pedro", "Gomez", "Dirección 456", "987654321", 1200, "Delivery", true);
                Mesa mesa1 = new Mesa(1, 4, mesero1, "Abierta", "Efectivo");

                // Agregar mesero, delivery y mesa al restaurante
                restaurante.AgregarMesero(mesero1);
                restaurante.AgregarDelivery(delivery1);
                restaurante.AgregarMesa(mesa1);

                // Crear algunos platos
                Plato plato1 = new Plato("Bife con ensalada", 10, new Dictionary<IConsumible, int>(), 10);
                Plato plato2 = new Plato("Pasta con salsa", 15, new Dictionary<IConsumible, int>(), 12);
                Plato plato3 = new Plato("Pizza napolitana", 12, new Dictionary<IConsumible, int>(), 8);

                // Asignar platos a mesas y deliveries
                mesero1.AsignarPlatoMesa(plato1, mesa1);
                delivery1.AgregarPlato(plato2);
                delivery1.PagoEfectuado();
                mesero1.AsignarPlatoMesa(plato3, mesa1);
                mesa1.PagoRealizado();

                // Calcular el consumo total
                decimal consumoTotal = restaurante.CalcularConsumoTotal();

                // Mostrar resultado por consola
                Console.WriteLine($"Consumo total del restaurante: {consumoTotal}");

                Console.ReadKey();


            }
        }
    }
}
