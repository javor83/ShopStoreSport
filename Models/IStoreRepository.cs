using Microsoft.AspNetCore.Mvc.Rendering;
using ShopStoreSport.database;

namespace ShopStoreSport.Models
{
    public interface IStoreRepository
    {
       IEnumerable<Product> GetProducts();

       IEnumerable<ProductDTO> GetProductsDTO(int current_page, int? category, int take_count);

        int CountProducts(int? category);

        IEnumerable<Category> GetCategories();
        IEnumerable<SelectListItem> SelectTagCategoryList();

        Task AddProduct(InsertProductDTO key);
       


    }
}
