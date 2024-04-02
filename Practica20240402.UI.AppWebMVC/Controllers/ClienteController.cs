using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Practica20240402.EntidadesDeNegocio;
using Practica20240402.LogicaDeNegocio;
namespace Practica20240402.UI.AppWebMVC.Controllers
{
    public class ClienteController : Controller
    {
        readonly ClienteBL _clienteBL;
        public ClienteController(ClienteBL clienteBL) {
            _clienteBL=clienteBL;
        }
        // GET: ClienteController
        public async  Task<ActionResult> Index(Cliente cliente)
        {
            var clientes = await _clienteBL.Buscar(cliente);
            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _clienteBL.ObtenerPorId(new Cliente {Id=id });
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                await _clienteBL.Crear(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _clienteBL.ObtenerPorId(new Cliente { Id = id });
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(Cliente cliente)
        {
            try
            {
                await _clienteBL.Modificar(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _clienteBL.ObtenerPorId(new Cliente { Id = id });
            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Cliente cliente)
        {
            try
            {
                await _clienteBL.Eliminar(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
