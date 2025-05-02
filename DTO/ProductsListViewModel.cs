using ShopStoreSport.database;

namespace ShopStoreSport.DTO
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public PageSizeDTO PagingInfo { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public int? Category { get; set; }
    }
}
