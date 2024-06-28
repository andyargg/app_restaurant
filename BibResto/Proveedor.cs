using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Proveedor
    {
        private string _nombre;
        private string _tipoProducto;
        private string _medioDePago;
        private string _cuit;
        private string _direccion;
        private int _diaEntrega;

        public Proveedor(string _nombre, string _tipoProducto, string _medioDePago, string _cuit, string _direccion, int _diaEntrega)
        {
            this._nombre = _nombre;
            this._tipoProducto = _tipoProducto;
            this._medioDePago = _medioDePago;
            this._cuit = _cuit;
            this._direccion = _direccion;
            this._diaEntrega = _diaEntrega;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string TipoProducto
        {
            get { return _tipoProducto; }
            set { _tipoProducto = value; }
        }
        public string MedioDePago
        {
            get { return _medioDePago; }
            set { _medioDePago = value; }
        }
        public string Cuit
        {
            get { return _cuit; }
            set { _cuit = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public int DiaEntrega
        {
            get { return _diaEntrega; }
            set { _diaEntrega = value; }
        }
    }
}
