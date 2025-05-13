

namespace ShopStoreSport.Models
{
    public class CartLineDTO
    {
       
        public int? ID { get; set; }
        public string? Name { get; set; }

        public decimal Price { get; set; }


        
        public int? Qty { get; set; }

        public CartLineDTO()
        {
            
        }
    }
}
