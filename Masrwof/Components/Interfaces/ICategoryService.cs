using Masrwof.Components.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Masrwof.Components.Interfaces
{
    public interface ICategoryService
    {
        Category GetCategoryById(Guid id);
        void DeleteCategory(Guid id);
        void UpdateCategory(Category category);
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        
    }
}
