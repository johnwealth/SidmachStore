using SidmachStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Services
{
    public interface ICategory
    {

        List<Category> GetCategory();

        Category GetCategory(Guid Id);


        Category AddCategory(Category category);


        void DeleteCategory(Category category);


        Category EditCategory(Category category);
    }
}
