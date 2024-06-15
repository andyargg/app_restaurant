using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public abstract class Empleado
    {
        protected string _nombre;
        protected string _apellido;
        protected string _direccion;
        protected string _contacto;
        protected float _sueldo;
        

        public Empleado(string _nombre, string _apellido, string _direccion, string _contacto, float _sueldo, string _rol)
        {
            this._nombre = _nombre;
            this._apellido = _apellido;
            this._direccion = _direccion;
            this._contacto = _contacto;
            this._sueldo = _sueldo;
            
        }
        public string Nombre 
        { 
            get {  return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }
        public float Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }
    }
}
