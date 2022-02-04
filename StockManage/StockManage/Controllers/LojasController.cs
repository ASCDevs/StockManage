using Microsoft.AspNetCore.Mvc;
using StockManage.Data.Entities;
using StockManage.Data.Store;
using System;
using System.Threading.Tasks;

namespace StockManage.Controllers
{
    public class LojasController : Controller
    {
        private readonly StorageStore _storageStore;

        public LojasController(StorageStore storageStore)
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
                return Json(_storageStore.GetStoreFilials());
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new {message = ex.Message}));
            }
        }

        public async Task<IActionResult> addorupdate([FromBody]StoreFilial storeFilial)
        {
            try
            {
                string outputMessage = _storageStore.AddOrUpdateStoreFilial(storeFilial);
                return Ok(Json(new { message = outputMessage }));
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new {message = ex.Message }));
            }
        }

        [Route("lojas/{id_store}/details")]
        public async Task<IActionResult> GetStoreDetail(int id_store)
        {
            try
            {
                return Ok(_storageStore.GetStoreFilial(id_store));
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message }));
            }
        }

        [HttpPost]
        [Route("lojas/{id_store}/delete")]
        public async Task<IActionResult> DeleteStore(int id_store)
        {
            try
            {
                if (_storageStore.DeleteStoreFilial(id_store))
                {
                    return Ok(Json(new { message = "Loja excluída com sucesso!" }));
                }
                else
                {
                    return BadRequest(Json(new { message = "Não foi possível excluir a loja" }));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message }));
            }
        }
    }
}
