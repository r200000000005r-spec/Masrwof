using Masrwof.Components.Data;
using Masrwof.Components.Interfaces;
using Masrwof.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Masrwof.Components.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext categ;
        public CategoryService(AppDbContext con)
        {
            categ = con;
        }

        public void AddCategory(Category category)
        {
            if (category == null) return;
            categ.Categories.Add(category);
            categ.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            var category = categ.Categories.FirstOrDefault(e => e.Id == id);
            if(category != null)
            {
                categ.Categories.Remove(category);
                categ.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
             return categ.Categories.OrderByDescending(e => e.Id).ToList();
        }

        public Category GetCategoryById(Guid id)
        {
            return categ.Categories.FirstOrDefault(e => e.Id == id);
        }

        public void UpdateCategory(Category category)
        {
            if (category == null) return;
            categ.Categories.Update(category);
            categ.SaveChanges();
        }
    }
}
