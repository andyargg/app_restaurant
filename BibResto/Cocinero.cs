using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public class Cocinero
    {
        public Plato CrearPlato(string nombrePlato, List<(Producto producto, int cantidad)> ingredientes, decimal precio, int tiempoDePreparacion)
        {
            return new Plato(nombrePlato, ingredientes, precio, tiempoDePreparacion);
        }

        public void ModificarPlato(
            Plato plato, string nombre,
            List<(Producto producto, int cantidad)> ingredientes,
            decimal precio,
            decimal tiempoPreparacion
            )
        {
            plato.Nombre = nombre;
            plato.Ingredientes = ingredientes;
            plato.Precio = precio;
            plato.TiempoPreparacion = tiempoPreparacion;
        }
    }
}
