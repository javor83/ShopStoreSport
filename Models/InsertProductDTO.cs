using Microsoft.AspNetCore.Mvc.Rendering;
using ShopStoreSport.database;
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

        public IEnumerable<Category>? CategoryList { get; set; }
        //*******************************************************
        [Required(ErrorMessage = InsertProductDTO_caption.ReqPreview)]
        public IFormFile? UploadFile { get; set; }
        //*******************************************************
        public IEnumerable<SelectListItem> CatList()
        {
            

            SelectListItem default_key = new SelectListItem()
            {
                Text = "-----",
                Value = string.Empty
            };
            yield return default_key;

            foreach (Category category in this.CategoryList)
            {
                SelectListItem key = new SelectListItem()
                {
                    Text = category.Cname,
                    Value = Convert.ToString(category.Id)
                };
                yield return key;
            }
        }
        //*******************************************************
        public static InsertProductDTO Empty()
        {
            InsertProductDTO result = new InsertProductDTO()
            {
                Name = "... product name ...",
                Description = "... product descr...",
                Price = 1,
                Category = null,
                UploadFile = null,
                CategoryList = null
            };
            return result;
        }
        //*******************************************************

    }
}
