using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockManage.Data.Store;

namespace StockManage.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly StorageStore _storageStore;

        public ProdutosController(StorageStore storageStore)
        {
            _storageStore = storageStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> list()
        {
            return Json(_storageStore.GetProducts());
        }
    }
}