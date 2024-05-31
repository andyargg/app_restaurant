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
        private Mesero _mesero;

        public Mesa(int _id, int _capacidad, Mesero _mesero)
        {
            this._id = _id;
            this._capacidad = _capacidad;
            this._mesero = _mesero;
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
        public Mesero Mesero
        {
            get { return _mesero; }
            set { _mesero = value; }
        }
    }
}
