using EspeciasCapa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EspeciasCapa.Controllers
{
    public class ClienteController : Controller
    {
        // Lista en memoria
        private static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "Juan Pérez", Correo = "juan@example.com", Telefono = "8888-1111" },
            new Cliente { Id = 2, Nombre = "Ana Gómez", Correo = "ana@example.com", Telefono = "8999-2222" }
        };

        public IActionResult Index()
        {
            return View(clientes);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Cliente cliente)
        {
            cliente.Id = clientes.Max(c => c.Id) + 1;
            clientes.Add(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            var existente = clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existente == null) return NotFound();

            existente.Nombre = cliente.Nombre;
            existente.Correo = cliente.Correo;
            existente.Telefono = cliente.Telefono;

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null) clientes.Remove(cliente);
            return RedirectToAction("Index");
        }
    }
}
