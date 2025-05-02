using ShopStoreSport.database;
using ShopStoreSport.DTO;

namespace ShopStoreSport.Models
{
    public interface IStoreRepository
    {
       IEnumerable<Product> GetProducts();

       IEnumerable<ProductDTO> GetProductsDTO();


    }
}
