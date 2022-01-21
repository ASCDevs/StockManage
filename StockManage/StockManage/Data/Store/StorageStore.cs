using StockManage.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StockManage.Data.Store
{
    public class StorageStore
    {
        private readonly StorageContext _storageContext;
        public StorageStore(StorageContext storageContext)
        {
            _storageContext = storageContext;
        }

        public List<Category> GetCategories()
        {
            return _storageContext.Category.ToList();
        }

        

    }
}
