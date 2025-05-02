using ShopStoreSport.database;
using ShopStoreSport.DTO;

namespace ShopStoreSport.Models
{
    public class EFStoreRepository:IStoreRepository
    {
        private SportsstoreContext context = null;
        public EFStoreRepository(SportsstoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<ProductDTO> GetProductsDTO()
        {
            var query = from x in this.context.Products
                        join y in this.context.Categories
                        on x.Category equals y.Id
                        select new ProductDTO()
                        {
                            ID = x.Id,
                            Description = x.Description,
                            Price = x.Price,
                            Category = y.Cname,
                            Name = x.Name
                        };
            return query;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products;
        }

    }
}
