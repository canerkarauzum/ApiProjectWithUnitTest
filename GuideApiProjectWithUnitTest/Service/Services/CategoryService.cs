using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoriesWithProducts()
        {
            return await _categoryRepository.GetCategoriesWithProducts();
        }

        public async Task<Category> GetCategoryByIdWithProduct(int categoryId)
        {
            return await _categoryRepository.GetCategoryByIdWithProduct(categoryId);
        }
    }
}
