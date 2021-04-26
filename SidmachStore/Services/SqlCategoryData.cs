using SidmachStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Services
{
    public class SqlCategoryData : ICategory
    {

        private readonly ApplicationDbContext _categoryContext;
        public SqlCategoryData(ApplicationDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }
        public Category AddCategory(Category category)
        {
            category.Id = Guid.NewGuid();
            _categoryContext.Categories.Add(category);
            _categoryContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(Category category)
        {
            _categoryContext.Categories.Remove(category);
            _categoryContext.SaveChanges();
        }

        public Category EditCategory(Category category)
        {
            var existingCategory = _categoryContext.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                _categoryContext.Categories.Update(existingCategory);
                _categoryContext.SaveChanges();
            }

            return category;
        }

        public List<Category> GetCategory()
        {
            return _categoryContext.Categories.ToList();
        }

        public Category GetCategory(Guid Id)
        {
            var category = _categoryContext.Categories.Find(Id);
            return category;
            // return _customerContext.Customers.SingleOrDefault(x => x.Id == id);
        }
    }
}


