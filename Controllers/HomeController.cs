using FirstRadio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRadio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public string basePath = @"C:\Users\koste\Desktop\Music";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var mp3Files = Directory.GetFiles(basePath, "*.mp3", SearchOption.TopDirectoryOnly).Select(Path.GetFileName);
            return View(mp3Files);
        }

        public IActionResult GetAudio(string fileName)
        {
            return File(System.IO.File.OpenRead(Path.Combine(basePath, fileName)), "audio/mpeg", fileName);
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
}
