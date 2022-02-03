using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockManage.Data.Entities;
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
            try
            {
                return Json(_storageStore.GetProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message }));
            }
            
        }

        public async Task<IActionResult> addorupdate([FromBody]Product product)
        {
            try
            {
                string outputMessage = _storageStore.AddOrUpdateProduct(product);
                return Ok(Json(new {message = outputMessage}));
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message }));
            }
            
        }

        [Route("produtos/{id_product}/details")]
        public async Task<IActionResult> GetProductDetail(int id_product)
        {
            try {
                return Ok(_storageStore.GetProduct(id_product));
            }catch (Exception ex)
            {
                return BadRequest(Json(new {message = ex.Message}));
            }
        }

        [HttpPost]
        [Route("produtos/{id_product}/delete")]
        public async Task<IActionResult> DeleteProduct(int id_product)
        {
            try
            {
                if (_storageStore.DeleteProduct(id_product))
                {
                    return Ok(Json(new {message = "Produto excluído com sucesso!"}));
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