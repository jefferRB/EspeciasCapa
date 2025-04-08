using EspeciasCapa.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EspeciasCapa.Controllers
{
	public class InventarioController : Controller
	{
		// Simulamos base de datos con lista estática (temporal)
		private static List<Producto> productos = new List<Producto>
		{
			new Producto { Id = 1, Nombre = "Producto A", Descripcion = "Descripción del Producto A", Precio = 10.00m, Cantidad = 100 },
			new Producto { Id = 2, Nombre = "Producto B", Descripcion = "Descripción del Producto B", Precio = 20.00m, Cantidad = 50 }
		};

		public IActionResult Index()
		{
			return View(productos);
		}

		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Crear(Producto producto)
		{
			producto.Id = productos.Max(p => p.Id) + 1;
			productos.Add(producto);
			return RedirectToAction("Index");
		}

		public IActionResult Editar(int id)
		{
			var producto = productos.FirstOrDefault(p => p.Id == id);
			if (producto == null) return NotFound();
			return View(producto);
		}

		[HttpPost]
		public IActionResult Editar(Producto producto)
		{
			var original = productos.FirstOrDefault(p => p.Id == producto.Id);
			if (original == null) return NotFound();

			original.Nombre = producto.Nombre;
			original.Descripcion = producto.Descripcion;
			original.Precio = producto.Precio;
			original.Cantidad = producto.Cantidad;

			return RedirectToAction("Index");
		}

		public IActionResult Eliminar(int id)
		{
			var producto = productos.FirstOrDefault(p => p.Id == id);
			if (producto != null)
			{
				productos.Remove(producto);
			}
			return RedirectToAction("Index");
		}
	}
}
