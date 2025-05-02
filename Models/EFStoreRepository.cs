using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ShopStoreSport.database;
using ShopStoreSport.DTO;

namespace ShopStoreSport.Models
{
    public class EFStoreRepository:IStoreRepository
    {
        private SportsstoreContext context = null;
        //******************************************************************************
        public EFStoreRepository(SportsstoreContext context)
        {
            this.context = context;
        }
        //******************************************************************************
        int IStoreRepository.CountProducts()
        {
            int result = this.context.Products.Count();
            return result;
        }
        //******************************************************************************
        IEnumerable<ProductDTO> IStoreRepository.GetProductsDTO(int current_page,int take_count)
        {
            IEnumerable<Product> filtered = this.context.Products.Skip(take_count*(current_page - 1)).Take(take_count).ToList();
            var query = from x in filtered
                        join y in this.context.Categories
                        on x.Category equals y.Id
                        select new ProductDTO()
                        {
                            ID = x.Id,
                            Description = x.Description,
                            Price = x.Price,
                            Category = y.Cname,
                            Name = x.Name,
                            Preview = x.Preview
                        };
            return query;
        }
        //******************************************************************************
        IEnumerable<Product> IStoreRepository.GetProducts()
        {
            return this.context.Products;
        }
        //******************************************************************************

    }
}
