using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShelves
{
    internal class ProductType
    {
        public decimal price { get; set; }
        public int productsAmount { get; set; }

        //Constructor for ProdutType
        internal ProductType()
        {
            //For using Random.Next method, Random is a class so we need to create an object as below
            var rnd = new Random();
            //Random number, for price and amount of the product
            this.price = rnd.Next((int)(100 * 100), (int)(5000000 * 100)) / 100m;
            this.productsAmount = rnd.Next(1, 10);
        }
    }



}
