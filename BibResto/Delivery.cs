using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Delivery : Empleado
    {

        private List<Plato> _platosAsignadosDelivery;
        private bool _disponible;
        private decimal _pagoTotalDia;
        private string _medioDePago;
        public Delivery(string _nombre, string _apellido, string _direccion, string _contacto, decimal _sueldo, string _rol, bool disponible,  string medioDePago) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._disponible = disponible;
            this._medioDePago = medioDePago;
            this._pagoTotalDia = 0;
        }
        public List<Plato> PlatosAsignadosDelivery
        {
            get { return _platosAsignadosDelivery; }
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
        public string MedioDePago
        {
            get { return this._medioDePago; }
            set { this.MedioDePago = value; }
        }

        public void PagoEfectuado()
        {
            foreach (Plato plato in PlatosAsignadosDelivery)
            {
                PagoTotalDia += plato.Precio;
            }
        }
        public void AgregarPlato(Plato plato)
        {
            PlatosAsignadosDelivery.Add(plato);
        }
    }
}
