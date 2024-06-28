using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Mesero : Empleado
    {
        private bool _disponible;
        private decimal _pagoTotalDia;
        private Encargado _encargado;
        public Mesero(string _nombre, string _apellido, string _direccion, string _contacto, decimal _sueldo, string _rol, bool disponible) : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._disponible = disponible;
            this._pagoTotalDia = 0;
        }
        public bool Disponible
        {
            get { return this._disponible; }
            set { _disponible = value; }
        }
        public decimal PagoTotalDia
        {
            get { return this._pagoTotalDia; }
            set {  this._pagoTotalDia = value; }
        }
        public void AsignarPlatoMesa(Plato plato, Mesa mesa)
        {
            if (Disponible == true)
            {
                mesa.AgregarPlato(plato);
            }
        }
    }
}
