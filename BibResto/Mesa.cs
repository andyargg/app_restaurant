using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Mesa
    {
        private int _id;
        private int _capacidad;
        private Mesero _mesero;
        private List<Plato> _platosAsignados;
        private string _estado;
        private string _medioDePago;
        public Mesa(int _id, int _capacidad, Mesero _mesero, string estado, string _medioDePago)
        {
            this._id = _id;
            this._capacidad = _capacidad;
            this._mesero = _mesero;
            this._platosAsignados = new List<Plato>();
            this._estado = estado;
            this._medioDePago = _medioDePago;
        }
        public int Id
        {
            get { return _id; }
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
        public string MedioDePago
        {
            get { return this._medioDePago; }
            set { this._medioDePago = value; }
        }
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        } 
        public void AgregarPlato(Plato plato)
        {
            _platosAsignados.Add(plato);
        }
        public void PagoRealizado()
        {
            Estado = "cerrado";
            foreach (Plato plato in _platosAsignados)
            {
                Mesero.PagoTotalDia += plato.Precio;
            }
        }
    }
}
