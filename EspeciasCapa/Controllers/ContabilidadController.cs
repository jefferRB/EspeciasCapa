using EspeciasCapa.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EspeciasCapa.Controllers
{
    public class ContabilidadController : Controller
    {
        private static List<Contabilidad> registros = new List<Contabilidad>
        {
            new Contabilidad { Id = 1, Descripcion = "Venta de producto A", Monto = 15000, Fecha = DateTime.Today, Tipo = "Ingreso" },
            new Contabilidad { Id = 2, Descripcion = "Compra de insumos", Monto = 5000, Fecha = DateTime.Today.AddDays(-1), Tipo = "Gasto" }
        };

        public IActionResult Index()
        {
            return View(registros);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Contabilidad entrada)
        {
            entrada.Id = registros.Any() ? registros.Max(r => r.Id) + 1 : 1;
            registros.Add(entrada);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var entrada = registros.FirstOrDefault(r => r.Id == id);
            if (entrada == null) return NotFound();
            return View(entrada);
        }

        [HttpPost]
        public IActionResult Editar(Contabilidad entrada)
        {
            var existente = registros.FirstOrDefault(r => r.Id == entrada.Id);
            if (existente == null) return NotFound();

            existente.Descripcion = entrada.Descripcion;
            existente.Monto = entrada.Monto;
            existente.Fecha = entrada.Fecha;
            existente.Tipo = entrada.Tipo;

            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var entrada = registros.FirstOrDefault(r => r.Id == id);
            if (entrada != null)
                registros.Remove(entrada);

            return RedirectToAction("Index");
        }
    }
}
