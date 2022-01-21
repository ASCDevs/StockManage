using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockManage.Data.Store;
using StockManage.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StockManage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StorageStore _storageStore;

        public HomeController(ILogger<HomeController> logger, StorageStore storageStore)
        {
            _logger = logger;
            _storageStore = storageStore;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> categorias()
        {
            return Json(_storageStore.GetCategories());
        }
    }
}
