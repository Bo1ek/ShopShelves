using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShelves
{
    internal class Shelf
    {
        public List<ProductType> productsOnShelf { get; set; }


        public Shelf()
        {
            this.productsOnShelf = new List<ProductType>();
        }
    }
}
