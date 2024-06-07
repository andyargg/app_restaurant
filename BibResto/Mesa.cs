using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Mesa
    {
        private int _id;
        private int _capacidad;
        private  Empleado _empleado;

        public Mesa(int _id, int _capacidad, Empleado _empleado)
        {
            this._id = _id;
            this._capacidad = _capacidad;
            this._empleado = _empleado;
        }

        public int Id 
        {
            get {  return _id; }
            set { _id = value; }
        }
        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }
        public Empleado Empleado
        {
            get { return _empleado; }
            set { _empleado = value; }
        }
    }
}
