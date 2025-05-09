using System.ComponentModel.DataAnnotations;

namespace ShopStoreSport.Models
{
    public class InsertProductDTO
    {
      

        [Required(ErrorMessage = InsertProductDTO_caption.ReqName)]
        
        public string? Name { get; set; }
        //*******************************************************
        [Required(ErrorMessage = InsertProductDTO_caption.ReqDescr)]
        public string? Description { get; set; }
        //*******************************************************
        [Required(ErrorMessage = InsertProductDTO_caption.ReqPrice)]
        public decimal? Price { get; set; }
        //*******************************************************
        [Required(ErrorMessage = InsertProductDTO_caption.ReqCategory)]
        public int? Category { get; set; }
        

       
        //*******************************************************
        [Required(ErrorMessage = InsertProductDTO_caption.ReqPreview)]
        public IFormFile? UploadFile { get; set; }

        
        
        //*******************************************************
        public static InsertProductDTO Empty()
        {
            InsertProductDTO result = new InsertProductDTO()
            {
                Name = "... product name ...",
                Description = "... product descr...",
                Price = 1,
                Category = null,
                UploadFile = null
            };
            return result;
        }
        //*******************************************************

    }
}
