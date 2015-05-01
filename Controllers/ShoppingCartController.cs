using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppShop.Models;

namespace MvcAppShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ProductDBContext db = new ProductDBContext();
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderItem(int id)
        {
            String sessionKey = "shoppingCart";
           
            bool cond=true;
            if (Session[sessionKey] == null)
            {

                Session[sessionKey] = new List<Cart>();
                List<Cart> c = (List<Cart>)Session[sessionKey];
                Product p = db.Products.Find(id);

                p.ID= c.Count == 0 ? 1 : c.Last().getProd().ID + 1;

                c.Add(new Cart(p, 1));
                
                Session[sessionKey] = c;
            }
            else
            {
                List<Cart> c = (List<Cart>)Session[sessionKey];
                Product p = db.Products.Find(id);

                p.ID = c.Count == 0 ? 1 : c.Last().getProd().ID + 1;

                for (int i = 0; i < c.Count; i++)
                {
                    if (c[i].getProd().ID == id)
                    {
                     
                        int quantity = c[i].getQty();
                        c[i].setQty(++quantity);
                        cond = false;
                    }

                }

                if (cond == true)
                {
                    c.Add(new Cart(p, 1));
                }


               
                Session[sessionKey] = c;
            }

            return View("CartView");
        }

        public ActionResult Remove(int id)
        {
            String sessionKey = "shoppingCart";
            List<Cart> c = (List<Cart>)Session[sessionKey];
            Product p = db.Products.Find(id);

            for (int i = 0; i < c.Count; i++)
            {
                if (c[i].getProd().ID == id)
                {
                    c.RemoveAt(i);
                
                }

            }

            Session[sessionKey] = c;
            return View("CartView");
        }

    }
}
