
#region Import Packages
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Models;
using Product.Application.Interfaces;
using Product.SharedDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Instance
        private readonly IProductServices _products;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductController(IProductServices product)
        {
            _products = product;

            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductViewModel, ProductDto>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        #endregion

        #region Get All Products
        //GET: api/Product/
        [HttpGet("GetProducts")]
        //[Authorize(Roles="Admin")]
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var products = await Task.FromResult(_mapper.Map<IEnumerable<ProductDto>>(await _products.GetProductList()));
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        #endregion

        #region Search Product with product Name
        //GET: api/Product/{Name}
        [HttpGet("{Name}")]
        public async Task<IEnumerable<ProductViewModel>> SearchProduct(string productName)
        {
            var products = await Task.FromResult(_mapper.Map<IEnumerable<ProductDto>>(await _products.SearchProduct(productName)));
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
        #endregion

        #region Add New Product
        // POST: api/Product
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductViewModel model)
        {

            return Ok(await Task.FromResult(await _products.AddProduct(_mapper.Map<ProductDto>(model))));
        }
        #endregion

        #region Remove Product 
        // DELETE: api/ApiWithActions/5
        [HttpDelete("RemoveProduct")]
        //[Authorize(Policy = "AdminRolePolicy")]
        public async Task<IActionResult> Delete(int productId)
        {
            return Ok(await Task.FromResult(await _products.RemoveProduct(productId)));
        }
        #endregion
    }
}
