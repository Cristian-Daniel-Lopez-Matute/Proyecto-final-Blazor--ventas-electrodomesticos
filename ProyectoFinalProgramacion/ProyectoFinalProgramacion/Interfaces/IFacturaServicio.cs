using Modelos;

namespace ProyectoFinalProgramacion.Interfaces;

public interface IFacturaServicio
{
    Task<bool> Nuevo(Factura factura);
    Task<bool> Actualizar(Factura factura);
    Task<bool> Eliminar(Factura factura);
    Task<IEnumerable<Factura>> GetLista();
    Task<Factura> GetPorCodigo(string Codigo);

}
