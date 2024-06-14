using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Encargado : Empleado
    {
        private const int LIMITE_AGOTARSE = 20;
        public Encargado(string _nombre, string _apellido, string _direccion, string _contacto, float _sueldo, string _rol) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
        }

        public void AgregarArticulo(Restaurante restaurante, Producto producto, int cantidad)
        {
            Producto productoEncontrado = restaurante.Stock.Find(p => p.Nombre == producto.Nombre);
            if (productoEncontrado != null)
            {
                productoEncontrado.Stock += cantidad;
            }
            else
            {
                producto.Stock = cantidad;
                restaurante.Stock.Add(producto);
            }
        }

        public List<Producto> ConsultaStockVigente(Restaurante restaurante)
        {
            return new List<Producto>(restaurante.Stock);
        }

        public List<Producto> ConsultaStockPorAgotarse(Restaurante restaurante)
        {
            var stockPorAgotarse = new List<Producto>();

            foreach (var producto in restaurante.Stock)
            {
                if (producto.Stock <= LIMITE_AGOTARSE)
                {
                    stockPorAgotarse.Add(producto);
                }
            }

            return stockPorAgotarse;
        }

        public void EstablecerPrecio(Restaurante restaurante, Producto productoNuevoPrecio, float nuevoPrecio)
        {
            Producto productoEncontrado = restaurante.Stock.Find(p => p.Nombre == productoNuevoPrecio.Nombre);
            if (productoEncontrado != null)
            {
                productoEncontrado.Precio = nuevoPrecio;
            }
        }
    }
}

