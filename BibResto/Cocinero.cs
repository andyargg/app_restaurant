using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Cocinero : Empleado
    {
        private List<Plato> _menu;

        public Cocinero(string _nombre, string _apellido, string _direccion, string _contacto, float _sueldo, string _rol) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            _menu = new List<Plato>();
        }

        //AGREGAR EXCEPCIONES
        public List<Plato> Menu
        {
            get { return _menu; }
        }
        public void AgregarPlato(Plato plato)
        {
            bool stockSuficiente = true;
            foreach (Producto producto in plato.Ingredientes.Keys)
            {
                if (producto.Stock < 20)
                {
                    stockSuficiente = false;
                }
            }

            if (stockSuficiente)
            {
                Menu.Add(plato);
            }
        }
        public void EliminarPlato(Plato plato)
        {
            _menu.Remove(plato);
        }
        public void CrearPlato(string nombrePlato, decimal precio, Dictionary<Producto, int> ingredientes, int tiempoDePreparacion)
        {
            if (ingredientes.Count() >= 2)
            {
                Plato plato = new Plato(nombrePlato, precio, ingredientes, tiempoDePreparacion);
                AgregarPlato(plato);
            }
        }
        public void ModificarPlato(Plato plato, string nombrePlato, Dictionary<Producto, int> ingredientes, decimal precio, decimal tiempoPreparacion)
        {
            foreach (Plato platoMenu in _menu)
            {
                if (platoMenu == plato)
                {
                    platoMenu.Nombre = nombrePlato;
                    platoMenu.Ingredientes = ingredientes;
                    platoMenu.Precio = precio;
                    platoMenu.TiempoPreparacion = tiempoPreparacion;
                }
            }
            //preguntar por Plato plato = _menu.Find(p => p.Nombre == nombrePlato);
        }
        public List<Plato> BuscarPlatoPorProducto(Producto producto)
        {
            List<Plato> platosConProducto = new List<Plato>();

            foreach (Plato plato in _menu)
            {
                foreach (KeyValuePair<Producto, int> ingrediente in plato.Ingredientes)
                {
                    Producto productoPlato = ingrediente.Key;

                    if (productoPlato == producto)
                    {
                        platosConProducto.Add(plato);
                    }
                }
            }
            platosConProducto.Sort((plato1, plato2) =>
            {
                int cantidad1 = plato1.Ingredientes[producto];
                int cantidad2 = plato2.Ingredientes[producto];
                return cantidad1.CompareTo(cantidad2); // Orden ascendente
            });

            return platosConProducto;
        }

        public List<Plato> PlatosSinStockSuficiente()
        {
            List<Plato> platosSinStock = new List<Plato>();

            foreach (Plato plato in _menu)
            {
                foreach (KeyValuePair<Producto, int> ingrediente in plato.Ingredientes)
                {
                    Producto producto = ingrediente.Key;
                    int cantidadNecesaria = ingrediente.Value;

                    if (producto.Stock < cantidadNecesaria)
                    {
                        platosSinStock.Add(plato);
                    }
                }
            }
            return platosSinStock;
        }
    }
}
