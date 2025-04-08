using EspeciasCapa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EspeciasCapa.Controllers
{
    public class ProveedorController : Controller
    {
        // Lista en memoria
        private static List<Proveedor> proveedores = new List<Proveedor>
        {
            new Proveedor { Id = 1, Nombre = "MasXMenos", Correo = "masxmneos@example.com", Telefono = "8888-1111" },
            new Proveedor { Id = 2, Nombre = "Megasuper", Correo = "megasuper@example.com", Telefono = "8999-2222" }
        };

        public IActionResult Index()
        {
            return View(proveedores);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Proveedor proveedor)
        {
            proveedor.Id = proveedores.Max(p => p.Id) + 1;
            proveedores.Add(proveedor);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var proveedor = proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor == null) return NotFound();
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Editar(Proveedor proveedor)
        {
            var existente = proveedores.FirstOrDefault(p => p.Id == proveedor.Id);
            if (existente == null) return NotFound();

            existente.Nombre = proveedor.Nombre;
            existente.Correo = proveedor.Correo;
            existente.Telefono = proveedor.Telefono;

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var proveedor = proveedores.FirstOrDefault(p => p.Id == id);
            if (proveedor != null)
                proveedores.Remove(proveedor);

            return RedirectToAction("Index");
        }
    }
}
