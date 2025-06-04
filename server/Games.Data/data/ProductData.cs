using Games.Core;
using Games.Core.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Data.data
{
    public class ProductData : IProductData
    {
        private readonly DataContext dataContext;
        public ProductData(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public void addProduct(Product product)
        {
            dataContext.products.Add(product);
            dataContext.SaveChanges();
        }

        public List<Product> getAll()
        {
            return dataContext.products.Include(x=>x.Category).ToList();
        }

        public List<Product> getByCategory(int categoryId)
        {
            return dataContext.products.Where(x => x.CategoryId == categoryId).Include(x => x.Category).ToList();
        }

        public Product getById(int id)
        {
            return dataContext.products.Include(x => x.Category).FirstOrDefault(x => x.Id == id)!;
        }

        public List<Product> getfinished()
        {
            return dataContext.products.Where(x => x.quantity == 0).Include(x => x.Category).ToList();
        }

        public void removeProduct(int id)
        {
            Product p = getById(id);
            if (p != null)
            {
                dataContext.products.Remove(p);
                dataContext.SaveChanges();

            }
        }

        public void updateProduct(Product product)
        {
            Product p = getById(product.Id);
            if (p != null)
            {
                p.Name = product.Name;
                p.CategoryId = product.CategoryId;
                p.Description = product.Description;
                p.Price = product.Price;
                p.quantity = product.quantity;
                p.ImageSrc = product.ImageSrc;
                dataContext.SaveChanges();
            }
        }
    }
}
