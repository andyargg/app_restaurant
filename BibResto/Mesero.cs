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
        private List<decimal> _listaPagosDiarios;
        public Mesero(string _nombre, string _apellido, string _direccion, string _contacto, decimal _sueldo, string _rol, bool disponible, Encargado encargado) 
            : base(_nombre, _apellido, _direccion, _contacto, _sueldo, _rol)
        {
            this._disponible = disponible;
            this._pagoTotalDia = 0;
            this._encargado = encargado;
            this._listaPagosDiarios = new List<decimal>();
        }
        public List<decimal> ListaPagosDiarios
        {
            get { return _listaPagosDiarios; }
            set {  _listaPagosDiarios = value;}
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
                _encargado.EliminarStockPlatoAsignado(plato);
                mesa.AgregarPlato(plato);
            }
        }
    }
}
