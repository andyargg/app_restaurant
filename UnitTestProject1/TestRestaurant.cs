using BibResto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class TestRestaurant
    {
        private Encargado _encargado;
        private Restaurante _restaurante;
        private ContabilidadRestaurante _contabilidad;
        private Proveedor proveedor1;
        private Proveedor proveedor2;
        private Proveedor proveedor3;
        private List<Proveedor> proveedores;
        private List<Mesero> meseros;
        private List<Delivery> deliveries;
        private Plato plato1;
        private Plato plato2;

        [TestInitialize]
        public void Setup()
        {
            //proveedor1 = new Proveedor("Proveedor 1", "Bebidas 1", "Efectivo", "22", "san martin 700", 4);
            //proveedor2 = new Proveedor("Proveedor 2", "Carnes", "Transferencia", "23", "Alberdi 600", 2);
            //proveedor3 = new Proveedor("Proveedor 3", "Alcohol", "Efectivo", "24", "Lafuente 123", 1);
            _restaurante = new Restaurante();
            _contabilidad = new ContabilidadRestaurante();
            _encargado = new Encargado("Andres", "Arguindegui", "siempreviva123", "46", 1000, "empleado", _restaurante, _contabilidad);
            _contabilidad.DineroDisponible = 1000;

            meseros = new List<Mesero>();
            deliveries = new List<Delivery>();

            Producto carne = new Producto("Carne", 300, 105);
            Producto ensalada = new Producto("Ensalada", 100, 50);
            Dictionary<IConsumible, int> ingredientes = new Dictionary<IConsumible, int>
            {
                { carne, 20 },
                { ensalada, 10 }
            };

            plato1 = new Plato("Bife con ensalada", 10, ingredientes, 10);
            plato2 = new Plato("Carne asada", 15, ingredientes, 10);
        }

        [TestMethod]
        public void CalcularTotalConsumo_Consumo()
        {
            Plato plato1 = new Plato("Bife con ensalada", 10, new Dictionary<IConsumible, int>(), 10);
            Plato plato2 = new Plato("Pasta con salsa", 15, new Dictionary<IConsumible, int>(), 12);
            Plato plato3 = new Plato("Pizza napolitana", 12, new Dictionary<IConsumible, int>(), 8);
            Mesero mesero1 = new Mesero("Juan", "Perez", "Dirección 123", "123456789", 1500, "Mesero", true, _encargado);
            Mesa mesa1 = new Mesa(1, 4, mesero1, "Abierta", "Efectivo");
            Delivery delivery1 = new Delivery("Motoman", "Motomel", "123", "2", 10, "delivery", true);


            _restaurante.AgregarMesero(mesero1);
            _restaurante.AgregarDelivery(delivery1);
            _restaurante.AgregarMesa(mesa1);
            mesero1.AsignarPlatoMesa(plato1, mesa1);
            mesero1.AsignarPlatoMesa(plato3, mesa1);

            mesa1.PagoRealizado();
            delivery1.AgregarPlato(plato2);
            delivery1.PagoEfectuado();

            decimal consumoTotal = _restaurante.CalcularConsumoTotal();

            Assert.AreEqual(37, consumoTotal); // Ajustar el valor
        }
    }
}
