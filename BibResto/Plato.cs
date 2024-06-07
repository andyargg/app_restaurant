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
        private List<(Producto producto, int cantidad)> _ingredientes;

        public Plato(string nombre, List<(Producto producto, int cantidad)> ingredientes, decimal precio, int tiempoDePreparacion)
        {
            _nombre = nombre;
            _ingredientes = ingredientes;
            _precio = precio;
            _tiempoPreparacion = tiempoDePreparacion;
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
        public List<(Producto producto, int cantidad)> Ingredientes
        {
            get { return _ingredientes; }
            set { _ingredientes = value; }
        }
    }
}
