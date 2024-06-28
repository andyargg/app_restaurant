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
        private ContabilidadRestaurante _contabilidadRestaurante;
        private decimal _gananciaTotalDia;
        public Encargado(string _nombre, string _apellido, string _direccion, string _contacto, decimal _sueldo, string _rol, Restaurante _restaurante) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._restaurante = _restaurante;
            this._contabilidadRestaurante = new ContabilidadRestaurante();
        }
        public decimal GananciaTotalDia
        {
            get { return _gananciaTotalDia; }
            set { _gananciaTotalDia = value; }
        }
        public void AgregarArticulo(IConsumible consumible, int cantidad, Proveedor proveedor)
        {
            IConsumible consumibleEncontrado = _restaurante.Stock.Find(p => p.Nombre == consumible.Nombre);
            if (consumibleEncontrado != null)
            {
                consumibleEncontrado.Stock += cantidad;
                PagarProveedor(proveedor, consumible);
            }
            else
            {
                consumible.Stock += cantidad;
                PagarProveedor(proveedor, consumible);
                _restaurante.Stock.Add(consumible);
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

        public void EstablecerPrecio(IConsumible productoNuevoPrecio, decimal nuevoPrecio)
        {
            IConsumible productoEncontrado = _restaurante.Stock.Find(p => p.Nombre == productoNuevoPrecio.Nombre);
            if (productoEncontrado != null)
            {
                productoEncontrado.Precio = nuevoPrecio;
            }
        }
        private void PagarProveedor(Proveedor proveedor, IConsumible consumible)
        {
            if (_contabilidadRestaurante.DineroDisponible < consumible.Precio)
            {
                _contabilidadRestaurante.AgregarDeuda(proveedor, consumible.Precio);
            }
            else
            {
                _contabilidadRestaurante.DineroDisponible -= consumible.Precio;
            }
        }
        public void CalcularGananciaDelDia(List<Mesero> listaMeseros, List<Delivery> listDeliveries) 
        {
            foreach (Mesero mesero in listaMeseros)
            {
                GananciaTotalDia += mesero.PagoTotalDia;
            }
            foreach (Delivery delivery in listDeliveries)
            {
                GananciaTotalDia += delivery.PagoTotalDia;
            }
        }
    }
}

