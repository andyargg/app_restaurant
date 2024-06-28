using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibResto
{
    public interface IConsumible
    {
        string Nombre { get; set; }
        int Stock { get; set; }
        decimal Precio {  get; set; }

    }

}
