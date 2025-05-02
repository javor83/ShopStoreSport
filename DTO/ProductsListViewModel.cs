namespace ShopStoreSport.DTO
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public PageSizeDTO PagingInfo { get; set; }
    }
}
