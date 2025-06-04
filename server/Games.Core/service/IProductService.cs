using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core.service
{
    public interface IProductService
    {
        List<Product> getAll();
        Product getById(int id);
        List<Product> getByCategory(int categoryId);
        List<Product> getfinished();
        void addProduct(Product product);
        void updateProduct(Product product);
        void removeProduct(int id);
    }
}
