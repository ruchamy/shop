using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Core.data
{
    public interface ICategoryDeta
    {
        List<Category> getAll();
        Category getByName(string name);
        Category getById(int id);
        void addCategory(Category category);
        void updateCategory(Category category);
        void removeCategory(int id);

    }
}
