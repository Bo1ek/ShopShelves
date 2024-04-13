using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShelves
{
    internal class Warehouseman
    {
        public bool isBusy { get; set; }
        public int timeBeforeCompleteSupplementComplete;

        public Warehouseman()
        {
            this.isBusy = false;
            this.timeBeforeCompleteSupplementComplete = 400;
        }
    }
}
