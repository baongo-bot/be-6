using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _25dh110017_Mystore.Models.Cart
{
    public class CartService
    {
        private readonly HttpSessionStateBase session;

        public CartService(HttpSessionStateBase session)
        {
            this.session = session;
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)session["CartSession"];
            if (cart == null)
            {
                cart = new Cart();
                session["CartSession"] = cart;
            }
            return cart;
        }

        public void ClearCart()
        {
            session["CartSession"] = null;
        }
    }
}