using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAppShop.Models
{
    public class Cart
    {
        private Product product = new Product();
        private int qty;

        public Product getProd()
        {
            return product;
        }

        public void setProd(Product p)
        {
            this.product = p;
        }

        public void setQty(int qty)
        {
            this.qty = qty;
        }

        public int getQty()
        {
            return this.qty;
        }

        public Cart(Product product,int qty)
        {
            this.product = product;
            this.qty = qty;
        }
    }
}