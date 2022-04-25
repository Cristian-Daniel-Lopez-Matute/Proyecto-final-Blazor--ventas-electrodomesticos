using Modelos;

namespace ProyectoFinalProgramacion.Interfaces;

public interface IClienteServicio
{
    Task<bool> Nuevo(Cliente cliente);
    Task<bool> Actualizar(Cliente cliente);
    Task<bool> Eliminar(Cliente cliente);
    Task<IEnumerable<Cliente>> GetLista();
    Task<Cliente> GetPorCodigo(string idCliente);

}
