using Product.Domain.Models;
using Product.SharedDTO;
using System.Collections.Generic;

namespace Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        bool AddProduct(ProductDto product);
        bool RemoveProduct(int productId);
        IEnumerable<ProductDto> GetProductList();
        IEnumerable<ProductDto> SearchProduct(string productName);

    }
}
