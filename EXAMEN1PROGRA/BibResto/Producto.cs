using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Producto
    {
        private string _nombre;
        private int _cantidad;
        private float _precio;


        public Producto(string _nombre, int _cantidad, float _precio)
        {
            this._nombre = _nombre;
            this._cantidad = _cantidad;
            this._precio = _precio;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Cantidad 
        {
            get { return _cantidad;}
            set {  _cantidad = value; }
        }
        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
    }
}
