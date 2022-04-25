using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IFacturaRepositorio
    {
        Task<bool> Nuevo(Factura factura);
        Task<bool> Actualizar(Factura factura);
        Task<bool> Eliminar(Factura factura);
        Task<IEnumerable<Factura>> GetLista();
        Task<Factura> GetPorCodigo(string Codigo);


    }
}
