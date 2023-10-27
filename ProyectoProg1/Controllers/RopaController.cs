using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoProg1.Models;

namespace ProyectoProg1.Controllers
{
    public class RopaController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5137/api");
        private readonly HttpClient _cliente;
        public RopaController()
        {
            _cliente = new HttpClient();
            _cliente.BaseAddress = baseAddress;
        }
        // GET: RopaController
        [HttpGet]
        public IActionResult Index()
        {
            List<Ropa> ListaProductos = new List<Ropa>();
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Ropa").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                ListaProductos = JsonConvert.DeserializeObject<List<Ropa>>(data);
            }
            return View(ListaProductos);
        }

        // GET: RopaController/Details/5
        public IActionResult Details(string Codigo)
        {
            Ropa p;
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Ropa/" + Codigo).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Ropa>(data);
                return View(p);

            }
            return RedirectToAction("Index");
        }

        // GET: RopaController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ropa producto)
        {
            HttpResponseMessage respone = _cliente.PostAsJsonAsync(_cliente.BaseAddress + "/Ropa", producto).Result;
            return RedirectToAction("Index");
        }

        // GET: RopaController/Edit/5
        public async Task<IActionResult> Edit(string Codigo)
        {
            Ropa nuevo = await _cliente.GetFromJsonAsync<Ropa>(_cliente.BaseAddress + "/Ropa/" + Codigo);
            if (nuevo != null)
            {

                return View(nuevo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Ropa producto)
        {
            HttpResponseMessage respone = _cliente.PutAsJsonAsync(_cliente.BaseAddress + "/Ropa/" + producto.Codigo, producto).Result;
            return RedirectToAction("Index");
        }
        // GET: RopaController/Delete/5
        public IActionResult Delete(string Codigo)
        {
            HttpResponseMessage respone = _cliente.DeleteAsync(_cliente.BaseAddress + "/Ropa/" + Codigo).Result;
            return RedirectToAction("Index");
        }
    }
}
