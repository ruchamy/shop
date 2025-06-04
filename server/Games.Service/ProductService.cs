using Games.Core;
using Games.Core.data;
using Games.Core.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductData productData;
        public ProductService(IProductData _productData)
        {
            productData = _productData;   
        }
        public void addProduct(Product product)
        {
            productData.addProduct(product);
        }

        public List<Product> getAll()
        {
           return productData.getAll();
        }

        public List<Product> getByCategory(int categoryId)
        {
            return productData.getByCategory(categoryId);
        }

        public Product getById(int id)
        {
            return productData.getById(id);
        }

        public List<Product> getfinished()
        {
          return productData.getfinished();
        }

        public void removeProduct(int id)
        {
            productData.removeProduct(id);
        }

        public void updateProduct(Product product)
        {
            productData.updateProduct(product);
        }
    }
}
