using CalvinProject.Models;
using System.Collections.Generic;

namespace CalvinProject.Interfaces
{
    public interface ICartItemsInterface
    {
        CartItem AddToCart(int userId, Product prod);
        List<CartItem> GetCartItems(int userId);
        CartItem RemoveCartItem(int id);
        CartItem UpdateCartItem(CartItem cartItem, int Quantity = 0);
    }
}
