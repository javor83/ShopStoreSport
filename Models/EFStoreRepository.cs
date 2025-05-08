using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ShopStoreSport.database;

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
        private bool valid_product(Product p, int? ct)
        {
            return ct.HasValue == false || p.Category == ct;
        }
        //******************************************************************************
        IEnumerable<Category> IStoreRepository.GetCategories()
        {
            var result = this.context.Categories;
            return result;
        }
        //******************************************************************************
        int IStoreRepository.CountProducts(int? category)
        {
            
            
            int result = this.context.Products.AsEnumerable<Product>().
                Where(p => valid_product(p,category)).Count();
            return result;
        }
        //******************************************************************************
        IEnumerable<ProductDTO> IStoreRepository.GetProductsDTO(int current_page, int? category ,int take_count)
        {
            IEnumerable<Product> filtered = this.context.Products.AsEnumerable().
                Where(p=> valid_product(p, category))
                .Skip(take_count*(current_page - 1)).Take(take_count).ToList();
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
