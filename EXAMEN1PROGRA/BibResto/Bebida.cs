using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Bebida
    {
        private string nombre;
        private bool conAlcohol;

        public Bebida(string nombre, bool conAlcohol)
        {
            this.nombre = nombre;
            this.conAlcohol = conAlcohol;
        }   
    }
}
