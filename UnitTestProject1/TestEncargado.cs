using BibResto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace UnitTestProject1
{

    [TestClass]
    public class TestEncargado
    {
        private Encargado _encargado;
        private Restaurante _restaurante;
        private ContabilidadRestaurante _contabilidad;
        private Proveedor proveedor1;
        private Proveedor proveedor2;
        private Proveedor proveedor3;
        private List<Proveedor> proveedores;
        //private Mesero mesero1;
        //private Delivery delivery1;
        //private Mesa mesa1;
        private List<Mesero> meseros;
        private List<Delivery> deliveries;
        private Plato plato1;
        private Plato plato2;

        [TestInitialize]
        public void Setup()
        {
            proveedor1 = new Proveedor("Proveedor 1", "Bebidas 1", "Efectivo", "22","san martin 700", 4);
            proveedor2 = new Proveedor("Proveedor 2", "Carnes", "Transferencia", "23", "Alberdi 600", 2);
            proveedor3 = new Proveedor("Proveedor 3", "Alcohol", "Efectivo", "24", "Lafuente 123", 1);
            _restaurante = new Restaurante();
            _contabilidad = new ContabilidadRestaurante();
            _encargado = new Encargado("Andres", "ARrguindegui", "siempreviva123", "46", 1000, "empleado", _restaurante, _contabilidad);
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
        public void AgregarArticulo_ArticuloNoExistente_ArticuloAgregado()
        {
            // Arrange
            IConsumible bebida = new Bebida("CocaCola", 10, 13, false);

            // Act
            _encargado.AgregarArticulo(bebida, 10, proveedor1);

            // Assert
            Assert.AreEqual(1, _restaurante.Stock.Count);
            
        }

        [TestMethod]
        public void AgregarArticulo_ArticuloExistente_CantidadIncrementada()
        {
            // Arrange
            IConsumible bebida = new Bebida("CocaCola", 10, 15, false);
            // Act
            _encargado.AgregarArticulo(bebida, 10, proveedor1);
            // Assert
            Assert.AreEqual(1, _restaurante.Stock.Count);
            Assert.AreEqual(20, _restaurante.Stock[0].Stock);
        }

        [TestMethod]
        public void ConsultaStockVigente_DevuelveStockActual()
        {
            // Arrange
            IConsumible bebida = new Bebida("CocaCola", 10, 13, false);
            IConsumible bife = new Producto("bife", 5, 15);
            _encargado.AgregarArticulo(bebida, 20, proveedor1);
            _encargado.AgregarArticulo(bife, 20, proveedor2);

            // Act
            List<IConsumible> stockVigente = _encargado.ConsultaStockVigente();

            // Assert
            Assert.AreEqual(2, stockVigente.Count);
            CollectionAssert.Contains(stockVigente, bebida);
            CollectionAssert.Contains(stockVigente, bebida);
        }

        [TestMethod]
        public void ConsultaStockPorAgotarse_DevuelveArticulosPorAgotarse()
        {
            // Arrange
            IConsumible bebida1 = new Bebida("CocaCola", 10, 15, false);
            IConsumible bebida2 = new Bebida("Pepsi", 5, 15, false);
            IConsumible papas = new Producto("PapasFritas", 25, 15);
            _encargado.AgregarArticulo(bebida1,1, proveedor1);
            _encargado.AgregarArticulo(bebida2, 4, proveedor1);
            _encargado.AgregarArticulo(papas, 30, proveedor3);

            // Act
            List<IConsumible> stockPorAgotarse = _encargado.ConsultaStockPorAgotarse();

            // Assert
            Assert.AreEqual(2, stockPorAgotarse.Count);
            CollectionAssert.Contains(stockPorAgotarse, bebida1);
            CollectionAssert.Contains(stockPorAgotarse, bebida2);
        }

        [TestMethod]
        public void EstablecerPrecio_ArticuloExistente_PrecioActualizado()
        {
            // Arrange
            IConsumible bebida = new Bebida("CocaCola", 10, 15, false);

            // Act
            _encargado.AgregarArticulo(bebida, 1, proveedor1);

            // Assert
            Assert.AreEqual(15, _restaurante.Stock[0].Precio);
        }
        [TestMethod]
        public void PagarProveedor_SaldoInsuficiente_DeudaAgregada()
        {
            // Arrange
            IConsumible bebida = new Bebida("CocaCola", 10, 1500, false);  // Precio alto para asegurar deuda

            // Act
            _encargado.AgregarArticulo(bebida, 1, proveedor1);

            // Assert
            Assert.AreEqual(1500, _contabilidad.GetDeuda(proveedor1));
            Assert.AreEqual(1000, _contabilidad.DineroDisponible); 
        }
        [TestMethod]
        public void GananciaDelDia_CalculaGananciaCorrectamente()
        {

            Mesero mesero1 = new Mesero("Juan", "Perez", "Dirección 123", "123456789", 1500, "Mesero", true, _encargado);
            Mesa mesa1 = new Mesa(1, 4, mesero1, "Abierta", "Efectivo");

            mesero1.AsignarPlatoMesa(plato1, mesa1);
            mesa1.PagoRealizado(); 
            meseros.Add(mesero1);

            Delivery delivery1 = new Delivery("Motoman", "Motomel", "123", "2", 10, "delivery", true);
            delivery1.PagoTotalDia = 15; 
            deliveries.Add(delivery1);

            // Act
            _encargado.CalcularGananciaDelDia(meseros, deliveries);

            // Assert
            Assert.AreEqual(25, _encargado.GananciaTotalDia);
        }
        [TestMethod]
        public void AsignarPlato_ReducirStock()
        {
            Producto carne = new Producto("Carne", 300, 105);
            Producto ensalada = new Producto("Ensalada", 100, 50);
            Dictionary<IConsumible, int> ingredientes = new Dictionary<IConsumible, int>
            {
                { carne, 20 },
                { ensalada, 10 }
            };

            plato2 = new Plato("Bife con ensalada", 10, ingredientes, 10);
            Mesero mesero1 = new Mesero("Juan", "Perez", "Dirección 123", "123456789", 1500, "Mesero", true, _encargado);
            Mesa mesa1 = new Mesa(1, 4, mesero1, "Abierta", "Efectivo");

            mesero1.AsignarPlatoMesa(plato1, mesa1);

            Assert.AreEqual(280, carne.Stock);
        }
        [TestMethod]
        public void PagarSueldosEmpleados_RestarDinero()
        {
            _contabilidad.DineroDisponible = 1000;
            Mesero mesero1 = new Mesero("Juan", "Perez", "Dirección 123", "123456789", 100, "Mesero", true, _encargado);
            Delivery delivery1 = new Delivery("Motoman", "Motomel", "123", "2", 100, "delivery", true);
            Encargado encargado1 = new Encargado("xd", "2", "123", "2", 300, "encargado", _restaurante, _contabilidad);
            Cocinero cociner1 = new Cocinero("Motoman", "Motomel", "123", "2", 300, "cocinero", _restaurante);
            List<Mesero> meseros = new List<Mesero> { mesero1 };
            List<Delivery> deliveries = new List<Delivery> { delivery1 };
            List<Encargado> encargados = new List<Encargado> { encargado1 };
            List<Cocinero> cocineros = new List<Cocinero> { cociner1 };

            _encargado.PagarEmpleados(encargados, cocineros, meseros, deliveries);

            Assert.AreEqual(200, _contabilidad.DineroDisponible);


        }
    }
}
