using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios;

public class ClienteRepositorio : IClienteRepositorio
{
    private string CadenaConexion;

    public ClienteRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }
    
    //++++++++++++++++++++++++++++++++++++++++++++++++
    public async Task<bool> Actualizar(Cliente cliente)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE cliente SET IdCliente = @IdCliente, Nombres = @Nombres, Apellidos = @Apellidos, Identificacion = @Identificacion, Direccion = @Direccion, Telefono= @Telefono WHERE IdCliente = @IdCliente ;";
            resultado = await conexion.ExecuteAsync(sql, new
            {
                
                cliente.IdCliente,
                cliente.Nombres,
                cliente.Apellidos,
                cliente.Identificacion,
                cliente.Direccion,
                cliente.Telefono
            

            });
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }


    public async Task<bool> Eliminar(Cliente cliente)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "DELETE FROM cliente WHERE IdCliente = @IdCliente;";
            resultado = await conexion.ExecuteAsync(sql, new { cliente.IdCliente });
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<IEnumerable<Cliente>> GetLista()
    {
        IEnumerable<Cliente> lista = new List<Cliente>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM cliente;";
            lista = await conexion.QueryAsync<Cliente>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;

    }

    public async Task<Cliente> GetPorCodigo(string idCliente)
    {
        Cliente customer = new Cliente();
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM cliente WHERE IdCliente = @IdCliente;";
            customer = await conexion.QueryFirstAsync<Cliente>(sql, new { idCliente });
        }
        catch (Exception)
        {
        }
        return customer;


    }

    public async Task<bool> Nuevo(Cliente cliente)
    {
        int resultado;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "INSERT INTO cliente (IdCliente, Nombres, Apellidos, Identificacion, Direccion, Telefono) VALUES (@IdCliente, @Nombres, @Apellidos, @Identificacion, @Direccion,@Telefono )";
            resultado = await conexion.ExecuteAsync(sql, cliente);
            return resultado > 0;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
}
