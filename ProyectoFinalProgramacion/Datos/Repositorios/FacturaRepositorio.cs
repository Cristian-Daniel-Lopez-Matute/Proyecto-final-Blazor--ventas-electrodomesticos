using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class FacturaRepositorio : IFacturaRepositorio
    {
        private string CadenaConexion;

        public FacturaRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }


        public async Task<bool> Actualizar(Factura factura)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "UPDATE factura SET Codigo = @Codigo, Descripcion = @Descripcion, NombreCliente = @NombreCliente, DNI = @DNI, Cantidad = @Cantidad, Precio= @Precio, SubTotal=@SubTotal, Impuesto= @Impuesto, Total= @Total WHERE Codigo = @Codigo ;";
                resultado = await conexion.ExecuteAsync(sql, new
                {

                    factura.Codigo,
                    factura.Descripcion,
                    factura.NombreCliente,
                    factura.DNI,
                    factura.Cantidad,
                    factura.Precio,
                    factura.SubTotal,
                    factura.Impuesto,
                    factura.Total,

                });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(Factura factura)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "DELETE FROM factura WHERE Codigo = @Codigo;";
                resultado = await conexion.ExecuteAsync(sql, new { factura.Codigo });
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IEnumerable<Factura>> GetLista()
        {
            IEnumerable<Factura> lista = new List<Factura>();

            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM factura;";
                lista = await conexion.QueryAsync<Factura>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;


        }

        public async Task<Factura> GetPorCodigo(string Codigo)
        {
            Factura fact = new Factura();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM factura WHERE Codigo = @Codigo;";
                fact = await conexion.QueryFirstAsync<Factura>(sql, new { Codigo });
            }
            catch (Exception)
            {
            }
            return fact;


        }

        public async Task<bool> Nuevo(Factura factura)
        {
            int resultado;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "INSERT INTO factura (Codigo, Descripcion, NombreCliente, DNI, Cantidad, Precio, SubTotal, Impuesto, Total) VALUES (@Codigo, @Descripcion, @NombreCliente, @DNI, @Cantidad,@Precio, @SubTotal, @Impuesto, @Total )";
                resultado = await conexion.ExecuteAsync(sql, factura);
                return resultado > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
