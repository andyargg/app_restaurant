using System.Collections.Generic;
using System.Linq;

namespace BibResto
{
    public class Cocinero : Empleado
    {

        private Restaurante _restaurante;
        public Cocinero(string _nombre, string _apellido, string _direccion, string _contacto, decimal _sueldo, string _rol, Restaurante _restaurante) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._restaurante = _restaurante;
        }

        //AGREGAR EXCEPCIONES

        public void AgregarPlato(Plato plato)
        {
                _restaurante.Menu.Add(plato);
        }
        public void EliminarPlato(Plato plato)
        {
            _restaurante.Menu.Remove(plato);
        }
        public void CrearPlato(string nombrePlato, decimal precio, Dictionary<IConsumible, int> ingredientes, int tiempoDePreparacion)
        {
            if (ingredientes.Count() >= 2)
            {
                Plato plato = new Plato(nombrePlato, precio, ingredientes, tiempoDePreparacion);
                AgregarPlato(plato);
            }
        }
        public void ModificarPlato(Plato plato, string nombrePlato, decimal precio, Dictionary<IConsumible, int> ingredientes,  decimal tiempoPreparacion)
        {
            foreach (Plato platoMenu in _restaurante.Menu)
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
        public List<Plato> BuscarPlatoPorProducto(IConsumible producto)
        {
            List<Plato> platosConProducto = new List<Plato>();

            foreach (Plato plato in _restaurante.Menu)
            {
                foreach (KeyValuePair<IConsumible, int> ingrediente in plato.Ingredientes)
                {
                    IConsumible productoPlato = ingrediente.Key;

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

            foreach (Plato plato in _restaurante.Menu)
            {
                bool sinStockSuficiente = false;

                foreach (KeyValuePair<IConsumible, int> ingrediente in plato.Ingredientes)
                {
                    IConsumible producto = ingrediente.Key;
                    int cantidadNecesaria = ingrediente.Value;

                    IConsumible productoEnStock = _restaurante.Stock.FirstOrDefault(p => p.Equals(producto));

                    if (productoEnStock == null || productoEnStock.Stock < cantidadNecesaria)
                    {
                        sinStockSuficiente = true;
                        break; // Salir  si no hay suficiente stock
                    }
                }

                if (sinStockSuficiente)
                {
                    platosSinStock.Add(plato);
                }
            }

            return platosSinStock;
        }
    }
}
