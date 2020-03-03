
#region Import Packages
using AutoMapper;
using Cart.Data.Context;
using Cart.Domain.Interfaces;
using Cart.Domain.Models;
using Cart.SharedDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace Cart.Data
{
    public class CartRepository : ICartRepository
    {
        #region Instance
        private readonly IMapper _mapper;
        private readonly CartDbContext _db;
        #endregion

        #region Constructor
        public CartRepository(CartDbContext db)
        {
            _db = db;
            MapperConfiguration cofiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CartDTOs, CartModel>().ReverseMap();
                //cfg.CreateMap<Task<CartDTOs>, Task<CartModel>>();
            });
            _mapper = cofiguration.CreateMapper();
        }
        #endregion

        #region Get All Items From Cart
        public async Task<IEnumerable<CartDTOs>> GetCartItems(string email)
        {
            try 
            {
                return await Task.FromResult(_mapper.Map<IEnumerable<CartDTOs>>(_db.CartModels.Where(e=>e.UserId == email)));
            
            } catch(AutoMapperMappingException e) {
                throw new AutoMapperMappingException(e.Message);
            }
        }
        #endregion

        #region Remove Item From Cart with CardID
        public async Task<bool> RemoveItemFromCart(int cartId)
        {
            
            try
            {
                if (cartId > 0)
                {
                    var cartItem = _db.CartModels.Where(e => e.CartId == cartId).FirstOrDefault();
                    _db.Remove(cartItem);
                    await _db.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            } catch(ArgumentNullException e) 
            {
                return await Task.FromResult(false);
            }
        }
        #endregion

        #region Remove Product From Cart with ProductID
        public async Task<bool> RemoveProductFromCart(int productId)
        {
            try
            {
                if (productId > 0)
                {
                    var cartItem = _db.CartModels.Where(e => e.ProductId == productId).FirstOrDefault();
                    _db.Remove(cartItem);
                    await _db.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            }
            catch (ArgumentNullException e)
            {
                return await Task.FromResult(false);
            }
        }
        #endregion
    }
}
