using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Bebida : IConsumible
    {
        private string _nombre;
        private int _stock;
        private float _precio;
        private bool _conAlcohol;

        public Bebida(string _nombre, int _stock, bool _conAlcohol)
        {
            this._nombre = _nombre;
            this._stock = _stock;
            this._conAlcohol = _conAlcohol;
        }   

        public string Nombre
        {
            get { return _nombre; } 
            set { _nombre = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set {  this._stock = value; }
        }
        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public bool ConAlcohol 
        {
            get { return _conAlcohol; }
            set { _conAlcohol = value; }
        }

       
    }
}
