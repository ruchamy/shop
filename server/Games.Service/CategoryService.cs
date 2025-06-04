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
   public class CategoryService : ICategoryService
    {
        private readonly ICategoryDeta categoryDeta;
        public CategoryService(ICategoryDeta _categoryDeta)
        {
            categoryDeta = _categoryDeta;
        }
        public void addCategory(Category category)
        {
            categoryDeta.addCategory(category);
        }

        public List<Category> getAll()
        {
           return categoryDeta.getAll();
        }

        public Category getById(int id)
        {
            return categoryDeta.getById(id);
        }

        public Category getByName(string name)
        {
            return categoryDeta.getByName(name);
        }

        public void removeCategory(int id)
        {
            categoryDeta.removeCategory(id);
        }

        public void updateCategory(Category category)
        {
            categoryDeta.updateCategory(category);
        }
    }
}
