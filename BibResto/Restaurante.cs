using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Restaurante
    {
        private List<Producto> stock;

        public Restaurante()
        {
            stock = new List<Producto>();
        }
        public List<Producto> Stock { get { return stock; } }
    }
}
