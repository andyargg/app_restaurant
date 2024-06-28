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
        public Encargado(string _nombre, string _apellido, string _direccion, string _contacto, decimal _sueldo, string _rol, Restaurante _restaurante, ContabilidadRestaurante _contabilidadRestaurante) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._restaurante = _restaurante;
            this._contabilidadRestaurante = _contabilidadRestaurante;
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

        public void EliminarStockPlatoAsignado(Plato plato)
        {
            foreach (KeyValuePair<IConsumible, int> consumible in plato.Ingredientes)
            {
                if (plato.Ingredientes.ContainsKey(consumible.Key))
                {
                    consumible.Key.Stock -= consumible.Value;
                }
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
        public void PagarEmpleados(List<Encargado> encargados, List<Cocinero> cocineros, List<Mesero> meseros, List<Delivery> deliveries)
        {
            PagarEncargados(encargados);
            PagarCocineros(cocineros);
            PagarMeseros(meseros);
            PagarDeliveries(deliveries);
        }
        private void PagarEncargados(List<Encargado> encargados)
        {
            foreach (Encargado encargado in encargados)
            {
                _contabilidadRestaurante.DineroDisponible -= encargado.Sueldo;
            }
        }
        private void PagarCocineros(List<Cocinero> cocineros)
        {
            foreach (Cocinero cocinero in cocineros)
            {
                _contabilidadRestaurante.DineroDisponible -= cocinero.Sueldo;
            }
        }
        private void PagarMeseros(List<Mesero> meseros)
        {
            foreach (Mesero mesero in meseros)
            {
                _contabilidadRestaurante.DineroDisponible -= mesero.Sueldo;
            }
        }
        private void PagarDeliveries(List<Delivery> deliveries)
        {
            foreach (Delivery delivery in deliveries)
            {
                _contabilidadRestaurante.DineroDisponible -= delivery.Sueldo;
            }
        }



    }
}

