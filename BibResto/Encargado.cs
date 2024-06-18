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

        public void AgregarArticulo(IConsumible consumible, int cantidad)
        {
            IConsumible consumibleEncontrado = _restaurante.Stock.Find(p => p.Nombre == consumible.Nombre);
            if (consumibleEncontrado != null)
            {
                consumibleEncontrado.Stock += cantidad;
            }
            else
            {
                consumibleEncontrado.Stock = cantidad;
                _restaurante.Stock.Add(consumibleEncontrado);
            }
        }

        public List<IConsumible> ConsultaStockVigente()
        {
            return new List<IConsumible>(_restaurante.Stock);
        }

        public List<IConsumible> ConsultaStockPorAgotarse()
        {
            var stockPorAgotarse = new List<IConsumible>();

            foreach (IConsumible consumible in _restaurante.Stock)
            {
                if (consumible.Stock <= LIMITE_AGOTARSE)
                {
                    stockPorAgotarse.Add(consumible);
                }
            }
            return stockPorAgotarse;
        }

        public void EstablecerPrecio(IConsumible productoNuevoPrecio, float nuevoPrecio)
        {
            IConsumible productoEncontrado = _restaurante.Stock.Find(p => p.Nombre == productoNuevoPrecio.Nombre);
            if (productoEncontrado != null)
            {
                productoEncontrado.Precio = nuevoPrecio;
            }
        }
    }
}

