using Microsoft.AspNetCore.Mvc;
using StockManage.Data.Entities;
using StockManage.Data.Store;
using System;
using System.Threading.Tasks;

namespace StockManage.Controllers
{
    public class StorageController : Controller
    {
        private readonly StorageStore _storageStore;

        public StorageController(StorageStore storageStore)
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
    }


}
