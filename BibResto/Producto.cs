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
        private int _stock;
        private float _precio;


        public Producto(string _nombre, int _stock, float _precio)
        {
            this._nombre = _nombre;
            this._stock = _stock;
            this._precio = _precio;
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Stock 
        {
            get { return _stock; }
            set { _stock = value; }
        }
        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
    }
}
