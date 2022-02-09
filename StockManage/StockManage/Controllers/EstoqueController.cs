using Microsoft.AspNetCore.Mvc;
using StockManage.Data.Entities;
using StockManage.Data.Store;
using System;
using System.Threading.Tasks;

namespace StockManage.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly StorageStore _storageStore;

        public EstoqueController(StorageStore storageStore)
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
                return Json(_storageStore.GetStorageList());
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new {message = ex.Message}));
            }
        }

        public async Task<IActionResult> addorupdate([FromBody] Storage storage)
        {
            try
            {
                string outputMessage = _storageStore.AddOrUpdateStorage(storage);
                return Ok(Json(new { message = outputMessage }));
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new { message = ex.Message }));
            }

        }

        [Route("estoque/{id_storage}/details")]
        public async Task<IActionResult> GetStorageDetail(int id_storage)
        {
            try
            {
                return Ok(_storageStore.GetStorageDetail(id_storage));
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new {message = ex.Message}));
            }
        }

        [Route("estoque/{id_storage}/delete")]
        public async Task<IActionResult> DeleteStorage(int id_storage)
        {
            try
            {
                if (_storageStore.DeleteStorage(id_storage))
                {
                    return Ok(Json(new { message = "Estoque excluído com sucesso!" }));
                }
                else
                {
                    return BadRequest(Json(new { message = "Não foi possível excluir o estoque"}));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(Json(new {message = ex.Message}));
            }
        }
    }


}
