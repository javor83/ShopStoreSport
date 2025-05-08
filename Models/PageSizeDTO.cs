namespace ShopStoreSport.Models
{
    public class PageSizeDTO
    {
        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalItems { get; set; }

        public int TotalPages()
        {
            int result = (int)Math.Ceiling(TotalItems / (float)ItemsPerPage);
            return result;
        }
    }
}
