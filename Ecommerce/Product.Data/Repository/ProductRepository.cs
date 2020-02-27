
#region Import Packages
using AutoMapper;
using Product.Data.Context;
using Product.Domain.Interfaces;
using Product.Domain.Models;
using Product.SharedDTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace Product.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Instance
        private readonly IMapper _mapper;
        private readonly ProductDbContext _db;
        private bool flag;
        #endregion

        #region Constructor
        public ProductRepository(ProductDbContext product)
        {
            _db = product;
            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, ProductModel>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        #endregion

        #region Add New Product
        public async Task<bool> AddProduct(ProductDto product)
        {
            try 
            {
                var productModel = _mapper.Map<ProductModel>(product);
                _db.Add(productModel);
                _db.SaveChanges();
                flag = true;
                return await Task.FromResult(flag);
            }
            catch
            {
                flag = false;
                return await Task.FromResult(flag);
            }
         
        }
        #endregion

        #region Get All Products
        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            try
            {
                return await Task.FromResult(_mapper.Map<IEnumerable<ProductDto>>(_db.ProductModels));
            }
            catch
            {
                throw new System.Exception("No Product Available....");
            }
        }
        #endregion

        #region Remove Product with ProductId
        public async Task<bool> RemoveProduct(int productId)
        {
            try
            {
                ProductModel product = _db.ProductModels.Where(e => e.ProductId == productId).FirstOrDefault();
                _db.ProductModels.Remove(product);
                _db.SaveChanges();
                flag = true;
                return await Task.FromResult(flag);
            }
            catch
            {
                flag = false;
                return await Task.FromResult(flag);
            }
        }
        #endregion

        #region Search Product with productName
        public async Task<IEnumerable<ProductDto>> SearchProduct(string productName)
        {
            try
            {
                return await Task.FromResult(_mapper.Map<IEnumerable<ProductDto>>(_db.ProductModels.Where(e => e.ProductName == productName).ToList()));
            }
            catch
            {
                throw new System.Exception("No product available...");
            }
        }
        #endregion
    }
}
