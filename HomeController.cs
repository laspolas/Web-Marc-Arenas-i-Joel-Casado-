using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mecanica_Foix.Models;

namespace Mecanica_Foix.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public IActionResult Index(string categoria = "Todos")
    {
        var productos = new List<dynamic>
        {
            new { Id = 1, Nombre = "Máquina de alineación", Precio = "€2,500", Imagen = "/Img/alineaciomaq.jpg", Video = "/vid/ali.mp4", Categoria = "Corrección" },
            new { Id = 2, Nombre = "Banco de enderezado", Precio = "€7,800", Imagen = "/Img/maqenderezado.jpg", Video = "/vid/mesa.mp4", Categoria = "Corrección" },
            new { Id = 3, Nombre = "Escáner de diagnóstico", Precio = "€1,200", Imagen = "/Img/carly.jpg", Video = "/vid/carly.mp4", Categoria = "Diagnóstico" },
            new { Id = 4, Nombre = "Medidor electrónico de chasis", Precio = "€4,500", Imagen = "/Img/medidorelectro.jpg", Video = "/vid/varas.mp4", Categoria = "Medición" },
            new { Id = 5, Nombre = "Sistema de medición 3D", Precio = "€9,000", Imagen = "/Img/3descaner.jpg", Video = "/vid/3dr.mp4", Categoria = "Medición" },
            new { Id = 6, Nombre = "Sistema de medición por láser", Precio = "€7,200", Imagen = "/Img/lasermaq.png", Video = "/vid/laser.mp4", Categoria = "Medición" },
            new { Id = 7, Nombre = "Sistema de medición acústico", Precio = "€6,800", Imagen = "/Img/ultra.jpg", Video = "/vid/audio.mp4", Categoria = "Medición" },
        };

        // Normaliza la categoría seleccionada
        string categoriaSeleccionada = string.IsNullOrEmpty(categoria) ? "Todos" : categoria.Trim().ToLower();
        ViewBag.CategoriaSeleccionada = categoriaSeleccionada;

        // Filtrar productos
        var productosFiltrados = categoriaSeleccionada == "todos"
            ? productos
            : productos.Where(p => p.Categoria.ToLower() == categoriaSeleccionada).ToList();

        ViewBag.Productos = productosFiltrados;

        return View();
    }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
