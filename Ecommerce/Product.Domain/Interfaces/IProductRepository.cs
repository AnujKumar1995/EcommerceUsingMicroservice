
#region Import Packages
using Product.SharedDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        #region Interfaces
        Task<bool> AddProduct(ProductDto product);
        Task<bool> RemoveProduct(int productId);
        Task<IEnumerable<ProductDto>> GetProductList();
        Task<IEnumerable<ProductDto>> SearchProduct(string productName);
        #endregion

    }
}
