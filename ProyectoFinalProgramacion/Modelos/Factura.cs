using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos;

public class Factura
{
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
    public string NombreCliente { get; set; }
    public string DNI { get; set; }
    public string Cantidad { get; set; }
    public string Precio { get; set; }
    public string SubTotal { get; set; }
    public string Impuesto { get; set; }
    public string Total { get; set; }

}
