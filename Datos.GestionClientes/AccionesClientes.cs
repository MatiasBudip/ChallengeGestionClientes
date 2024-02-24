using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contratos.GestionClientes;
using RestSharp;

namespace Datos.GestionClientes
{
    public class AccionesClientes
    {
        public static async Task<RespuestaApi> InsertarCliente(Cliente cliente)
        {
            RespuestaApi respuesta = new RespuestaApi();
            try
            {

                var options = new RestClientOptions(Utilidades.UrlApiClientes(Utilidades.esProduccion()))
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Clientes/Insert", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var param = new
                {
                    nombres=  cliente.Nombres,
                    apellidos=cliente.Apellidos,
                    cuit = cliente.CUIT,
                    domicilio = cliente.Domicilio,
                    telefonoCelular = cliente.TelefonoCelular,
                    email = cliente.Email,
                    fechaNacimiento = cliente.FechaNacimiento

                };
                request.AddJsonBody(param);
                client.BuildUri(request);

                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful == true)
                {
                    respuesta.Correcto = "Ok";
                    respuesta.Mensaje = response.Content;
                }
                else
                {
                    respuesta.Correcto = "Error";
                    respuesta.Mensaje = response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                respuesta.Correcto = "Error";
                respuesta.Mensaje = ex.Message;
            }


            return respuesta;
        }
        public static async Task<RespuestaApiClientes> ObtenerClientes()
        {
            RespuestaApiClientes respuesta = new RespuestaApiClientes();
            try
            {

                var options = new RestClientOptions(Utilidades.UrlApiClientes(Utilidades.esProduccion()))
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Clientes/GetAll", Method.Get);
                request.AddHeader("Content-Type", "application/json");

                client.BuildUri(request);

                var response = await client.ExecuteAsync<RespuestaApiClientes>(request);

                if (response.IsSuccessful == true)
                {
                    respuesta = response.Data;
                }
            }
            catch (Exception ex)
            {

            }

            return respuesta;
        }
        public static async Task<RespuestaApiBusquedaClientes> BuscarClientePorId(int idCliente)
        {
            RespuestaApiBusquedaClientes respuesta = new RespuestaApiBusquedaClientes();
            try
            {

                var options = new RestClientOptions(Utilidades.UrlApiClientes(Utilidades.esProduccion()))
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Clientes/Get", Method.Get);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("idCliente", idCliente);
                client.BuildUri(request);

                var response = await client.ExecuteAsync<RespuestaApiBusquedaClientes>(request);

                if (response.IsSuccessful == true)
                {
                    respuesta = response.Data;
                }
            }
            catch (Exception ex)
            {

            }

            return respuesta;
        }
        public static async Task<RespuestaApiClientes> BuscarClientePorNombre(string nombre)
        {
            RespuestaApiClientes respuesta = new RespuestaApiClientes();
            try
            {

                var options = new RestClientOptions(Utilidades.UrlApiClientes(Utilidades.esProduccion()))
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Clientes/Search", Method.Get);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("nombre", nombre);
                client.BuildUri(request);

                var response = await client.ExecuteAsync<RespuestaApiClientes>(request);

                if (response.IsSuccessful == true)
                {
                    respuesta = response.Data;
                }
            }
            catch (Exception ex)
            {

            }

            return respuesta;
        }
        public static async Task<RespuestaApi> ModificarCliente(Cliente cliente)
        {
            RespuestaApi respuesta = new RespuestaApi();
            try
            {

                var options = new RestClientOptions(Utilidades.UrlApiClientes(Utilidades.esProduccion()))
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Clientes/Update", Method.Put);
                request.AddHeader("Content-Type", "application/json");
                var param = new
                {
                    id = cliente.ID,
                    nombres = cliente.Nombres,
                    apellidos = cliente.Apellidos,
                    cuit = cliente.CUIT,
                    domicilio = cliente.Domicilio,
                    telefonoCelular = cliente.TelefonoCelular,
                    email = cliente.Email,
                    fechaNacimiento = cliente.FechaNacimiento

                };
                request.AddJsonBody(param);
                client.BuildUri(request);

                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful == true)
                {
                    respuesta.Correcto = "Ok";
                    respuesta.Mensaje = response.Content;
                }
                else
                {
                    respuesta.Correcto = "Error";
                    respuesta.Mensaje = response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                respuesta.Correcto = "Error";
                respuesta.Mensaje = ex.Message;
            }


            return respuesta;
        }
    }
}
