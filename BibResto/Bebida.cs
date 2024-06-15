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
        private string _stock;
        private bool _conAlcohol;

        public Bebida(string _nombre, string _stock, bool _conAlcohol)
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
        public string Stock
        {
            get { return _stock; }
            set {  this._stock = value; }
        }
        public bool ConAlcohol 
        {
            get { return _conAlcohol; }
            set { _conAlcohol = value; }
        }
    }
}
