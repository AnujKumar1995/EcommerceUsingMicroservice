
#region Import Packages
using Product.Application.Interfaces;
using Product.Domain.Interfaces;
using Product.SharedDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Product.Application.Service
{
    public class ProductService : IProductServices
    {
        #region Instance
        private readonly IProductRepository _products;
        private  bool flag;
        #endregion

        #region Constructor
        public ProductService(IProductRepository products)
        {
            _products = products;
        }
        #endregion

        #region Add New Product
        public async Task<bool> AddProduct(ProductDto product)
        {
            flag = await Task.FromResult(await _products.AddProduct(product));
            return flag;
        }
        #endregion

        #region GetAllProducts
        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            var productDtos = await Task.FromResult(await _products.GetProductList());
            return productDtos;
        }
        #endregion

        #region Remove Product with ProductId
        public async Task<bool> RemoveProduct(int productId)
        {
            flag = await Task.FromResult(await _products.RemoveProduct(productId));
            return flag;
        }
        #endregion

        #region Search Product with productName
        public async Task<IEnumerable<ProductDto>> SearchProduct(string productName)
        {
            return await Task.FromResult(await _products.SearchProduct(productName));
        }
        #endregion
    }
}
