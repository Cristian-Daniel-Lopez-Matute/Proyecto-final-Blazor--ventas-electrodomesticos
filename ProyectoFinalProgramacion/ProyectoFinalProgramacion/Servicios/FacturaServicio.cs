using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using ProyectoFinalProgramacion.Data;
using ProyectoFinalProgramacion.Interfaces;

namespace ProyectoFinalProgramacion.Servicios
{
    public class FacturaServicio : IFacturaServicio
    {
        private readonly MySQLConfiguration _configuration;
        private IFacturaRepositorio facturaRepositorio;

        public FacturaServicio(MySQLConfiguration configuration)
        {
            _configuration = configuration;
            facturaRepositorio = new FacturaRepositorio(configuration.CadenaConexion);
        }

        public async Task<bool> Actualizar(Factura factura)
        {
            return await facturaRepositorio.Actualizar(factura);
        }

        public async Task<bool> Eliminar(Factura factura)
        {
            return await facturaRepositorio.Eliminar(factura);
        }

        public async Task<IEnumerable<Factura>> GetLista()
        {
            return await facturaRepositorio.GetLista();
        }

        public async Task<Factura> GetPorCodigo(string Codigo)
        {
            return await facturaRepositorio.GetPorCodigo(Codigo);
        }

        public async Task<bool> Nuevo(Factura factura)
        {
            return await facturaRepositorio.Nuevo(factura);
        }
    }
}
