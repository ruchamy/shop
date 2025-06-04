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
    public class CategoryDeta : ICategoryDeta
    {
        public readonly DataContext dataContext;
        public CategoryDeta(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public void addCategory(Category category)
        {
            dataContext.Categories.Add(category);
            dataContext.SaveChanges();

        }

        public List<Category> getAll()
        {
            return dataContext.Categories.ToList();
        }

        public Category getById(int id)
        {
            return dataContext.Categories.FirstOrDefault(x => x.Id == id)!;
        }

        public Category getByName(string name)
        {
            return dataContext.Categories.FirstOrDefault(x => x.Name == name)!;
        }

        public void removeCategory(int id)
        {
            Category c = getById(id);
            if (c != null)
            {
                dataContext.Categories.Remove(c);
                dataContext.SaveChanges();

            }
        }

        public void updateCategory(Category category)
        {
            Category c = getById(category.Id);
            if (c != null)
            {
                c.Name = category.Name;
                dataContext.SaveChanges();
            }
        }
    }
}
