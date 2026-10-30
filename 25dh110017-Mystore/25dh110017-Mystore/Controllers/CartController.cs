using _25dh110017_Mystore.Models;
using _25dh110017_Mystore.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _25dh110017_Mystore.Controllers
{
    public class CartController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        private CartService GetCartService()
        {
            return new CartService(Session);
        }
        // GET: Cart
        public ActionResult Index()
        {
            var cart = GetCartService().GetCart();
            return View(cart);
        }
        [HttpPost]
        public ActionResult AddToCart(int productID, int quantity = 1)
        {
            var product = db.Products.Find(productID);
            if (product != null)
            {
                var cart = GetCartService().GetCart();
                cart.AddItem(product, quantity);
            }
            return RedirectToAction("Index");
        }

        // POST: Cart/UpdateQuantity
        [HttpPost]
        public ActionResult UpdateQuantity(int productID, int quantity)
        {
            var cart = GetCartService().GetCart();
            cart.UpdateQuantity(productID, quantity);
            return RedirectToAction("Index");
        }

        // GET/POST: Cart/RemoveFromCart
        public ActionResult RemoveFromCart(int productID)
        {
            var cart = GetCartService().GetCart();
            cart.RemoveLine(productID);
            return RedirectToAction("Index");
        }

        // Partial View hiển thị tổng số lượng sản phẩm trên Menu/Header
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = GetCartService().GetCart();
            return PartialView("_PVCartSummary", cart);
        }
    }
}