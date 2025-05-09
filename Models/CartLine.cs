using Microsoft.Identity.Client;
using ShopStoreSport.database;
using System.Runtime.CompilerServices;

namespace ShopStoreSport.Models
{
    public class CartLine
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }

        

    }
}
