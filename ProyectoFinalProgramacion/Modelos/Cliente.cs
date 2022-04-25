using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public  string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
       

        //public virtual ICollection<Factura> Facturas { get; set; }
   
    }
}
