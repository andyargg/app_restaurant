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
        private Restaurante _restaurante;
        public Encargado(string _nombre, string _apellido, string _direccion, string _contacto, float _sueldo, string _rol, Restaurante _restaurante) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._restaurante = _restaurante;
        }

        public void AgregarArticulo(Producto producto, int cantidad)
        {
            Producto productoEncontrado = _restaurante.Stock.Find(p => p.Nombre == producto.Nombre);
            if (productoEncontrado != null)
            {
                productoEncontrado.Stock += cantidad;
            }
            else
            {
                producto.Stock = cantidad;
                _restaurante.Stock.Add(producto);
            }
        }

        public List<Producto> ConsultaStockVigente()
        {
            return new List<Producto>(_restaurante.Stock);
        }

        public List<Producto> ConsultaStockPorAgotarse()
        {
            var stockPorAgotarse = new List<Producto>();

            foreach (var producto in _restaurante.Stock)
            {
                if (producto.Stock <= LIMITE_AGOTARSE)
                {
                    stockPorAgotarse.Add(producto);
                }
            }
            return stockPorAgotarse;
        }

        public void EstablecerPrecio(Producto productoNuevoPrecio, float nuevoPrecio)
        {
            Producto productoEncontrado = _restaurante.Stock.Find(p => p.Nombre == productoNuevoPrecio.Nombre);
            if (productoEncontrado != null)
            {
                productoEncontrado.Precio = nuevoPrecio;
            }
        }
    }
}

