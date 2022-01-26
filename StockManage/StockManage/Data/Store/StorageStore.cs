using StockManage.Data.Entities;
using System;
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

        public string AddOrUpdateCategory(Category category)
        {
            if(category.id_category == 0)
            {
                category.dt_created = DateTime.Now; 
                _storageContext.Category.Add(category);
                _storageContext.SaveChanges();
            }
            else
            {
                Category categoryUpdate = _storageContext.Category.Find(category.id_category);
                if(categoryUpdate == null)
                {
                    return "Nenhuma categoria encontrada com o id informado";
                }
                else {

                    categoryUpdate.categ_name = category.categ_name;
                    _storageContext.SaveChanges();
                };                
            }
            return category.categ_name;
        }

        public List<Category> GetCategories()
        {
            return _storageContext.Category.ToList();
        }

        public List<Product> GetProducts()
        {
            return _storageContext.Product.ToList();
        }



        

    }
}
