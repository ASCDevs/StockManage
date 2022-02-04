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
            try
            {
                return Json(_storageStore.GetCategories());
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message })); ;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> addorupdate([FromBody]Category category)
        {
            try
            {
                string outputMessage = _storageStore.AddOrUpdateCategory(category);
                return Ok(Json(new { message = outputMessage}));

            }catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message }));
            }
        }

        [HttpPost]
        [Route("categorias/{id_category}/delete")]
        public async Task<IActionResult> DeleteProduct(int id_category)
        {
            try
            {
                if (_storageStore.DeleteCategory(id_category))
                {
                    return Json(new { message = "Categoria excluída com sucesso!"});
                }
                else
                {
                    return BadRequest(Json(new { message = "Não foi possível excluir" }));
                }
            }catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message }));
            }
        }
    }
}