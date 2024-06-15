using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Plato 
    {
        private string _nombre;
        private decimal _precio;
        private decimal _tiempoPreparacion; 
        private Dictionary<IConsumible, int> _ingredientes;
        
        public Plato(string nombre, decimal precio, Dictionary<IConsumible, int> ingredientes, int tiempoDePreparacion)
        {
            this._nombre = nombre;
            this._ingredientes = ingredientes;
            this._precio = precio;
            this._tiempoPreparacion = tiempoDePreparacion;
        } 

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public decimal TiempoPreparacion
        {
            get { return _tiempoPreparacion; }
            set { _tiempoPreparacion = value; }
        }
        public Dictionary<IConsumible, int> Ingredientes
        {
            get { return _ingredientes; }
            set { _ingredientes = value; }
        }
        
    }
}
