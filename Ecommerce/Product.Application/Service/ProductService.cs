using Product.Application.Interfaces;
using Product.Domain.Interfaces;
using Product.SharedDTO;
using System.Collections.Generic;

namespace Product.Application.Service
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _products;
        private  bool flag;
        public ProductService(IProductRepository products)
        {
            _products = products;
        }
        public bool AddProduct(ProductDto product)
        {
            flag = _products.AddProduct(product);
            return flag;
        }

        public IEnumerable<ProductDto> GetProductList()
        {
            var productDtos = _products.GetProductList();
            return productDtos;
        }

        public bool RemoveProduct(int productId)
        {
            flag = _products.RemoveProduct(productId);
            return flag;
        }

        public IEnumerable<ProductDto> SearchProduct(string productName)
        {
            return _products.SearchProduct(productName);
        }
    }
}
