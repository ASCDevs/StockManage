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
                return "A categoria "+category.categ_name+" foi cadastrada com sucesso!";
            }
            else
            {
                Category categoryUpdate = _storageContext.Category.Find(category.id_category);
                if(categoryUpdate == null)
                {
                    return "Nenhuma categoria encontrada para alterar com o id informado";
                }
                else {

                    categoryUpdate.categ_name = category.categ_name;
                    _storageContext.SaveChanges();
                };
                return "A categoria " + category.categ_name +" foi atualizada com sucesso!";
            }
            
        }

        public List<Category> GetCategories()
        {
            return _storageContext.Category.ToList();
        }

        public string AddOrUpdateProduct(Product product)
        {
            if(product.id_product == 0)
            {
                product.dt_created = DateTime.Now;
                _storageContext.Product.Add(product);
                _storageContext.SaveChanges();
                return "O produto "+product.prod_name+" foi adicionado com sucesso!";
            }
            else
            {
                Product productUpdate = _storageContext.Product.Find(product.id_product);
                if(productUpdate == null)
                {
                    throw new Exception("Nenhum produto com o id informado foi encontrado");
                }
                else
                {
                    //Melhorar para atualizar somente as mudanças
                    productUpdate.prod_name = product.prod_name;
                    productUpdate.prod_desc = product.prod_desc;
                    productUpdate.price_buy = product.price_buy;
                    productUpdate.price_sell = product.price_sell;
                    _storageContext.SaveChanges();
                }
                return "O produto " + product.prod_name + " foi alterado com sucesso!";
            }

        }

        public bool DeleteCategory(int id_category)
        {
            Category categoryFound = _storageContext.Category.Find(id_category);
            if(categoryFound == null)
            {
                throw new Exception("Categoria não encontrada");
            }
            else
            {
                _storageContext.Category.Remove(categoryFound);
                _storageContext.SaveChanges();
            }
            return true;
        }

        public Product GetProduct(int id_product)
        {
            Product productFound = _storageContext.Product.Find(id_product);
            if( productFound == null)
            {
                throw new Exception("Produto não Encontrado");
            }
            else
            {
                return productFound;
            }

        }
        
        public bool DeleteProduct(int id_product)
        {
            Product productFound = _storageContext.Product.Find(id_product);
            if(productFound == null)
            {
                throw new Exception("Produto não encontrado para excluir");
            }
            else
            {
                _storageContext.Product.Remove(productFound);
                _storageContext.SaveChanges();
            }
            return true;
        }

        public List<Product> GetProducts()
        {
            return _storageContext.Product.ToList();
        }

        public string AddOrUpdateStoreFilial(StoreFilial storeFilial)
        {
            if(storeFilial.id_store == 0)
            {
                _storageContext.StoreFilial.Add(storeFilial);
                _storageContext.SaveChanges();
                return "A loja " + storeFilial.store_name + " foi adicionada com sucesso!";
            }
            else
            {
                StoreFilial storeFound = _storageContext.StoreFilial.Find(storeFilial.id_store);   
                if(storeFound == null)
                {
                    throw new Exception("A loja não foi encontrada");
                }
                else
                {
                    storeFound.store_name = storeFilial.store_name;
                    storeFound.store_address = storeFilial.store_address;
                    storeFound.store_city = storeFilial.store_city;
                    storeFound.store_district = storeFilial.store_district;
                    storeFound.store_country = storeFilial.store_country;
                    _storageContext.SaveChanges();
                    return "A loja "+storeFilial.store_name+" foi atualizada com sucesso";
                }
            }
        }

        public StoreFilial GetStoreFilial(int id_store)
        {
            StoreFilial storeFound = _storageContext.StoreFilial.Find(id_store);
            if(storeFound == null)
            {
                throw new Exception("Loja não encontrada!");
            }
            else
            {
                return storeFound;
            }
        }

        public bool DeleteStoreFilial(int id_store)
        {
            StoreFilial storeFound = _storageContext.StoreFilial.Find(id_store);
            if( storeFound == null)
            {
                throw new Exception("Loja não encontrada!");
            }
            else
            {
                _storageContext.StoreFilial.Remove(storeFound);
                _storageContext.SaveChanges();
            }
            return true;
        }

        public List<StoreFilial> GetStoreFilials()
        {
            return _storageContext.StoreFilial.ToList();
        }

        

    }
}
