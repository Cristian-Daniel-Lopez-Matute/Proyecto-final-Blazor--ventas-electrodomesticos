using Modelos;

namespace ProyectoFinalProgramacion.Interfaces;

public interface IProductoServicio
{
    Task<bool> Nuevo(Producto producto);
    Task<bool> Actualizar(Producto producto);
    Task<bool> Eliminar(Producto producto);
    Task<IEnumerable<Producto>> GetLista();
    Task<Producto> GetPorCodigo(string codigo);
}
