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
        public ActionResult GraficoPorEdades()
        {           
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetInfoGraficoPorEdades()
        {
            var clientes = await _clienteBL.ObtenerTodos();
            var yearActual = DateTime.Now.Year;
            //2024-18 = 2012
            // 2024-30 = 1994
            var clienteEntre18y30 = clientes.Where(s => s.FechaNacimiento.Year> (yearActual-30) && s.FechaNacimiento.Year <= (yearActual - 18));
            var clienteEntre31y50 = clientes.Where(s => s.FechaNacimiento.Year > (yearActual - 50) && s.FechaNacimiento.Year <= (yearActual - 30));
            var clientemayoresa50 = clientes.Where(s => s.FechaNacimiento.Year > (yearActual - 200) && s.FechaNacimiento.Year <= (yearActual - 50));
            var objs = new List<object>();
            objs.Add(new
            {
                grupo = "Entre 18 y 30 años",
                cantidad = clienteEntre18y30.Count(),
            });
            objs.Add(new
            {
                grupo = "Entre 30 y 50 años",
                cantidad = clienteEntre31y50.Count(),
            });
            objs.Add(new
            {
                grupo = "Mayores a 50 años",
                cantidad = clientemayoresa50.Count(),
            });
            return Json(objs);
        }
    }
}
