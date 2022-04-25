using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoFinalProgramacion.Data;
using ProyectoFinalProgramacion.Interfaces;

namespace ProyectoFinalProgramacion.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly MySQLConfiguration _configuration;
        private IClienteRepositorio clienteRepositorio;

        public ClienteServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            clienteRepositorio = new ClienteRepositorio(configuration.CadenaConexion);
        }


        public async Task<bool> Actualizar(Cliente cliente)
        {
            return await clienteRepositorio.Actualizar(cliente);
        }

        public async Task<bool> Eliminar(Cliente cliente)
        {
            return await clienteRepositorio.Eliminar(cliente);
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            return await clienteRepositorio.GetLista();
        }

        public async Task<Cliente> GetPorCodigo(string idCliente)
        {
            return await clienteRepositorio.GetPorCodigo(idCliente);

        }

        public async Task<bool> Nuevo(Cliente cliente)
        {
            return await clienteRepositorio.Nuevo(cliente);
        }
    }
}
