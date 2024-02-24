using Contratos.GestionClientes;
using Datos.GestionClientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebGestionClientes.Controllers
{
    public class ClientesController : Controller
    {
        // GET: ClientesController
        public async Task<ActionResult> Index()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            if (TempData.ContainsKey("clientes"))
            {
                string serializedClientes = TempData["clientes"] as string;

                if (!string.IsNullOrEmpty(serializedClientes))
                {
                    listaClientes = JsonConvert.DeserializeObject<List<Cliente>>(serializedClientes);
                    return View(listaClientes);
                }
            }

            listaClientes = await Servicios.GestionClientes.AbmClientes.ObtenerClientes();
            return View(listaClientes);
        }

        // GET: ClientesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Cliente clienteEncontrado = new Cliente();
            clienteEncontrado = await Servicios.GestionClientes.AbmClientes.ObtenerClientesPorId(id);

            if (clienteEncontrado != null)
            {
                return View(clienteEncontrado);
            }
            else
            {
                return View();
            }
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Servicios.GestionClientes.AbmClientes.InsertarCliente(cliente);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Cliente clienteEncontrado = new Cliente();
            clienteEncontrado = await Servicios.GestionClientes.AbmClientes.ObtenerClientesPorId(id);

            if (clienteEncontrado != null)
            {
                return View(clienteEncontrado);
            }
            else
            {
                return View();
            }

        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Servicios.GestionClientes.AbmClientes.ModificarCliente(cliente);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ObtenerClientePorNombre(string nombre)
        {
            List<Cliente> clientesEncontrado = await Servicios.GestionClientes.AbmClientes.ObtenerClientesPorNombre(nombre);

            if (clientesEncontrado != null)
            {
                // Serializa la lista de clientes a JSON y almacénala en TempData
                string serializedClientes = JsonConvert.SerializeObject(clientesEncontrado);
                TempData["clientes"] = serializedClientes;

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
