using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockManage.Data.Entities;
using StockManage.Data.Store;

namespace StockManage.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly StorageStore _storageStore;

        public CategoriasController(StorageStore storageStore)
        {
            _storageStore = storageStore;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> list()
        {
            return Json(_storageStore.GetCategories());
        }

        [HttpPost]
        public async Task<IActionResult> addorupdate([FromBody]Category category)
        {
            string nome_categ = _storageStore.AddOrUpdateCategory(category);
            return Json(new { result = "Categoria cadastrada foi "+nome_categ});
        }
    }
}