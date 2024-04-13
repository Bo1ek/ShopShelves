using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShelves
{
    internal class Client
    {
        public int clientId { get; set; }
        //Only patient clients will wait untill the shelf is supplemented
        public bool isPatient { get; set; }
        public int? timeBeforeResignation { get; set; }
        public int howMuchProductsHeNeeds { get; set; }
        public bool didClientLeftTheShop { get; set; }


        public Client(int id)
        {
            this.clientId = id;
            Random rnd = new Random();
            var isPatient = rnd.Next(0, 2) == 1;
            
            if (!isPatient)
                this.timeBeforeResignation = rnd.Next(1, 10) * 100;
            else
                this.timeBeforeResignation = null;

            this.howMuchProductsHeNeeds = rnd.Next(1, 5);
            this.didClientLeftTheShop = false;

        }
    }
}
