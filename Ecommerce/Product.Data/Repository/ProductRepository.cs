using AutoMapper;
using Product.Data.Context;
using Product.Domain.Interfaces;
using Product.Domain.Models;
using Product.SharedDTO;
using System.Collections.Generic;
using System.Linq;

namespace Product.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly ProductDbContext _db;
        private bool flag;
        public ProductRepository(ProductDbContext product)
        {
            _db = product;
            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, ProductModel>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        public bool AddProduct(ProductDto product)
        {
            try 
            {
                var productModel = _mapper.Map<ProductModel>(product);
                _db.Add(productModel);
                _db.SaveChanges();
                flag = true;
                return flag;
            }
            catch
            {
                flag = false;
                return flag;
            }
         
        }

        public IEnumerable<ProductDto> GetProductList()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(_db.ProductModels);
        }

        public bool RemoveProduct(int productId)
        {
            try
            {
                ProductModel product = _db.ProductModels.Where(e => e.ProductId == productId).FirstOrDefault();
                _db.ProductModels.Remove(product);
                _db.SaveChanges();
                flag = true;
                return flag;
            }
            catch
            {
                flag = false;
                return flag;
            }
        }
    }
}
