using CalvinProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CalvinProject.Models
{
    public class CartItemSQLRepository : ICartItemsInterface
    {
        public AppDbContext context;

        public CartItemSQLRepository(AppDbContext context)
        {
            this.context = context;
        }

        public CartItem AddToCart(int userId, Product prod)
        {
            using (context)
            {
                var items = new CartItem();
                var itemSearch = context.CartItems.FirstOrDefault(itm => itm.UserId == userId && itm.CartItemStatus == "Pending" && itm.ProductId == prod.Id);
                if (itemSearch == null)
                {
                    items = new CartItem
                    {
                        UserId = userId,
                        ProductId = prod.Id,
                        Quantity = 1,
                        DateCreated = DateTime.Now,
                        CartItemStatus = "Pending"
                    };
                    context.CartItems.Add(items);
                    context.SaveChanges();
                }
                else
                {
                    UpdateCartItem(itemSearch, 1);
                }

                return items;
            }
        }

        public List<CartItem> GetCartItems(int userId)
        {
            using (context)
            {
                var items = context.CartItems.Where(itm => itm.UserId == userId && itm.CartItemStatus == "Pending").ToList();
                foreach (CartItem item in items)
                {
                    item.Product = context.Products.FirstOrDefault(prod => prod.Id == item.ProductId);
                }
                return items;
            }
        }

        public CartItem RemoveCartItem(int id)
        {
            using (context)
            {
                var item = context.CartItems.First(itm => itm.Id == id);
                context.Remove(item);
                context.SaveChanges();
                return item;
            }
        }

        public CartItem UpdateCartItem(CartItem cartItem, int Quantity = 0)
        {
            using (context)
            {
                var item = context.CartItems.First(itm => itm.Id == cartItem.Id);
                item.Quantity = Quantity != 0 ? cartItem.Quantity + Quantity : cartItem.Quantity ;
                context.SaveChanges();
                return item;
            }
        }
    }
}