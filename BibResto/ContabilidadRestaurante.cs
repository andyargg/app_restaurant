using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class ContabilidadRestaurante
    {
        private decimal _dineroDisponible;
        private Dictionary<Proveedor, decimal> deudasPendientes;

        public ContabilidadRestaurante()
        {
            this._dineroDisponible = 0;
            deudasPendientes = new Dictionary<Proveedor, decimal>();
        }
        public decimal DineroDisponible
        {
            get { return _dineroDisponible; }
            set {  _dineroDisponible = value; }
        }
        public Dictionary<Proveedor, decimal> DeudasPendientes
        {
            get { return deudasPendientes; }
        }
        public void RegistrarPago(decimal monto)
        {
            DineroDisponible += monto;
        }
        public void RegistrarGasto(decimal monto)
        {
            DineroDisponible -= monto;
        }
        public void AgregarDeuda(Proveedor proveedor, decimal monto)
        {
            if (deudasPendientes.ContainsKey(proveedor))
            {
                deudasPendientes[proveedor] += monto;
            }
            else
            {
                deudasPendientes[proveedor] = monto;
            }
        }
        public void PagarDeuda(Proveedor proveedor, decimal monto)
        {
            if (deudasPendientes.ContainsKey(proveedor))
            {
                decimal deudaActual = deudasPendientes[proveedor];

                if (monto >= deudaActual)
                {
                    deudasPendientes.Remove(proveedor);
                    DineroDisponible -= deudaActual;
                }
                else
                {
                    deudasPendientes[proveedor] -= monto;
                    DineroDisponible -= monto;
                }
            }
        }
        public decimal GetDeuda(Proveedor proveedor)
        {
            if (DeudasPendientes.ContainsKey(proveedor))
            {
                return DeudasPendientes[proveedor];
            }
            else
            {
                return 0;
            }
        }
    }
}
