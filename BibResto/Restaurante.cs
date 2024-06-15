using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Restaurante
    {
        private List<IConsumible> _stock;
        private List<Plato> _menu;
        private List<Empleado> _empleados;
        private List<Proveedor> _proveedores;

        public Restaurante()
        {
            _stock = new List<IConsumible>();
            _menu = new List<Plato>();
            _empleados = new List<Empleado>();
        }
        public List<IConsumible> Stock { get { return _stock; } }
        public List<Plato> Menu { get { return _menu; } }
        public List<Empleado> Empleados { get { return _empleados; } }
    }
}
