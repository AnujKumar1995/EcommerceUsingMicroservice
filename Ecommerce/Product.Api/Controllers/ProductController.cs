﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Models;
using Product.Application.Interfaces;
using Product.SharedDTO;
using System.Collections.Generic;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _products;
        private readonly IMapper _mapper;

        public ProductController(IProductServices product)
        {
            _products = product;

            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductViewModel, ProductDto>().ReverseMap();
            });
            _mapper = cofiguration.CreateMapper();
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            return _products.GetProductList();
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductViewModel model)
        {

            return Ok(_products.AddProduct(_mapper.Map<ProductDto>(model)));
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete(int productId)
        {
            return Ok(_products.RemoveProduct(productId));
        }
    }
}