using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Delivery : Empleado
    {

        private List<Plato> _platosAsignadosDelivery;
        private List<decimal> _listaPagosDiarios;
        private bool _disponible;
        private decimal _pagoTotalDia;
        public Delivery(string _nombre, string _apellido, string _direccion, string _contacto, decimal _sueldo, string _rol, bool disponible) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._disponible = disponible;
            this._pagoTotalDia = 0;
            this._platosAsignadosDelivery = new List<Plato>(); 
            this._listaPagosDiarios = new List<decimal>();
        }
        public List<Plato> PlatosAsignadosDelivery
        {
            get { return _platosAsignadosDelivery; }
        }
        public List<decimal> ListaPagosDiarios
        {
            get { return _listaPagosDiarios; }
        }
        public bool Disponible
        {
            get { return _disponible; }
            set {  _disponible = value; }
        }
        public decimal PagoTotalDia
        {
            get { return _pagoTotalDia; }
            set {  this._pagoTotalDia = value; }
        }
        
        public void PagoEfectuado()
        {
            foreach (Plato plato in PlatosAsignadosDelivery)
            {
                ListaPagosDiarios.Add(plato.Precio);
                PagoTotalDia += plato.Precio;
            }
            PlatosAsignadosDelivery.Clear();
        }
        public void AgregarPlato(Plato plato)
        {
            PlatosAsignadosDelivery.Add(plato);
        }
    }
}
