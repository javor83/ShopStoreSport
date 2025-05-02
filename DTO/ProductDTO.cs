using Microsoft.Data.SqlClient.DataClassification;

namespace ShopStoreSport.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string? Preview { get; set; }
       
    }
}
