using Contratos.GestionClientes;
using Datos.GestionClientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.GestionClientes
{
    public class AbmClientes
    {
        public static async Task<RespuestaApi> InsertarCliente(Cliente cliente)
        {
            return await AccionesClientes.InsertarCliente(cliente);
        }
        public static async Task<List<Cliente>> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            RespuestaApiClientes respuestaApi = new RespuestaApiClientes();
            respuestaApi = await AccionesClientes.ObtenerClientes();
            listaClientes = respuestaApi.Response;
            return listaClientes;
        }
        public static async Task<Cliente> ObtenerClientesPorId(int idCliente)
        {
            Cliente clienteEncontrado = new Cliente();
            RespuestaApiBusquedaClientes respuestaApi = new RespuestaApiBusquedaClientes();
            respuestaApi = await AccionesClientes.BuscarClientePorId(idCliente);
            clienteEncontrado = respuestaApi.Response;
            return clienteEncontrado;
        }
        public static async Task<List<Cliente>> ObtenerClientesPorNombre(string nombre)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            RespuestaApiClientes respuestaApi = new RespuestaApiClientes();
            respuestaApi = await AccionesClientes.BuscarClientePorNombre(nombre);
            listaClientes = respuestaApi.Response;
            return listaClientes;
        }
        public static async Task<RespuestaApi> ModificarCliente(Cliente cliente)
        {
            return await AccionesClientes.ModificarCliente(cliente);
        }
    }
}
