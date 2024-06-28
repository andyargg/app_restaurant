using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Restaurante
    {
        private List<IConsumible> _stock;
        private List<Plato> _menu;
        private List<Mesa> mesas;
        private List<Delivery> deliveries;
        private List<Mesero> meseros;
        private List<decimal> listaTop3ventas;
        private List<Proveedor> _proveedores;

        public Restaurante()
        {
            _stock = new List<IConsumible>();
            _menu = new List<Plato>();
            mesas = new List<Mesa>();
            deliveries = new List<Delivery>();
            meseros = new List<Mesero>();
            listaTop3ventas = new List<decimal>();
        }
        public List<IConsumible> Stock { get { return _stock; } }
        public List<Plato> Menu { get { return _menu; } }
        public void AgregarMesero(Mesero mesero)
        {
            meseros.Add(mesero);
        }

        public void AgregarDelivery(Delivery delivery)
        {
            deliveries.Add(delivery);
        }

        public void AgregarMesa(Mesa mesa)
        {
            mesas.Add(mesa);
        }

        public decimal CalcularConsumoTotal()
        {
            return CalcularConsumoDelivery() + ConsultarConsumoMesero();
        }
        private decimal CalcularConsumoDelivery()
        {
            decimal total = 0;
            foreach (Delivery delivery in deliveries)
            {
                total += delivery.PagoTotalDia;
            }
            return total;
        }
        private decimal ConsultarConsumoMesero()
        {
            decimal total = 0;
            foreach (Mesero mesero in meseros)
            {
                total += mesero.PagoTotalDia;
            }
            return total;
        }
        public string ConsultarEstadoMesa()
        {
            
            foreach (Mesa mesa in mesas)
            {
                return mesa.Estado;
            }
            return "";
           
        }

        public List<decimal> MostrarTop3Ventas()
        {
            List<decimal> ventas = CalcularVentas();

            // Ordenar las ventas de mayor a menor
            ventas.Sort((a, b) => b.CompareTo(a));

            // Tomar los primeros tres elementos
            List<decimal> top3Ventas = ventas.Take(3).ToList();

            return top3Ventas;
        }
        private List<decimal> CalcularVentas()
        {
            foreach (Mesero mesero in meseros)
            {
                foreach (decimal pago in mesero.ListaPagosDiarios)
                {
                    listaTop3ventas.Add(pago);
                }
            }
            foreach (Delivery delivery in deliveries)
            {
                foreach(decimal pago in delivery.ListaPagosDiarios)
                {
                    listaTop3ventas.Add(pago);
                }
            }
            return listaTop3ventas;
        }
    }
}
