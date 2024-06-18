using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibResto;

namespace UnitTestProject1
{
    [TestClass]
    public class CalcPlato
    {
        [TestClass]
        public class RestauranteTests
        {
            private Restaurante restaurant;
            private Cocinero cocinero;
            private Producto milanesa;
            private Producto pure;
            private Dictionary<IConsumible, int> ingredientes;

            [TestInitialize]
            public void TestSetup()
            {
                restaurant = new Restaurante();
                cocinero = new Cocinero("Andres", "Arguindegui", "abc 123", "247", 300, "Cocinero", restaurant);
                milanesa = new Producto("Milanesa", 300, 105);
                pure = new Producto("Pure", 100, 50);
                ingredientes = new Dictionary<IConsumible, int>
                {
                    { milanesa, 20 },
                    { pure, 10 }
                };
            }

            [TestMethod]
            public void CrearPlato_Cocinero_NuevoPlato()
            {
                // Arrange
                Plato expected = new Plato("Milanesa con pure", 400, ingredientes, 30);

                // Act
                cocinero.CrearPlato("Milanesa con pure", 400, ingredientes, 30);

                // Assert
                Assert.AreEqual(restaurant.Menu[0].Nombre, expected.Nombre);
                Assert.AreEqual(restaurant.Menu[0].Precio, expected.Precio);
            }

            [TestMethod]
            public void ModificarPlato_Cocinero_CambiarDatos()
            {
                // Arrange
                cocinero.CrearPlato("Milanesa con pure", 400, ingredientes, 30);
                Plato plato1 = restaurant.Menu[0];

                Producto carne = new Producto("Carne", 300, 105);
                Producto ensalada = new Producto("Ensalada", 100, 50);
                Dictionary<IConsumible, int> ingredientesMod = new Dictionary<IConsumible, int>
                {
                    { carne, 20 },
                    { ensalada, 10 }
                };

                // Act
                cocinero.ModificarPlato(plato1, "Bife con ensalada", 100, ingredientesMod, 40);

                // Assert
                Assert.AreEqual(restaurant.Menu[0].Nombre, "Bife con ensalada");
                Assert.AreEqual(restaurant.Menu[0].Precio, 100);
            }
            [TestMethod]
            public void BuscarPlatoPorProducto_Cocinero_PlatosConProducto()
            {
                //arrange
                cocinero.CrearPlato("Milanesa con pure", 400, ingredientes, 30);

                //act
                List<Plato> platoPorProducto = cocinero.BuscarPlatoPorProducto(milanesa);

                //assert
                Assert.AreEqual(platoPorProducto[0], restaurant.Menu[0]);


            }
            [TestMethod]
            public void BuscarPlatoSinStock_Cocinero_PlatoSinStock()
            {
                //arrange
                IConsumible carne = new Producto("Milanesa", 10, 105);
                IConsumible pure = new Producto("Pure", 5, 50);
                Dictionary<IConsumible, int> ingredientes2 = new Dictionary<IConsumible, int>
                {
                    { carne, 20 },
                    { pure, 10 }
                };

                //act
                cocinero.CrearPlato("Carne con pure", 30, ingredientes2, 40);
                List<Plato> platoSinStock = cocinero.PlatosSinStockSuficiente();

                //assert
                Assert.AreEqual(platoSinStock[0], restaurant.Menu[0]);
            }
        }
    }
}
