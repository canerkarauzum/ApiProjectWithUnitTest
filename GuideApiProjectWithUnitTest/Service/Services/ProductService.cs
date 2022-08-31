using Core.Entities;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _productRepository.GetProductsWithCategory();
        }
    }
}
