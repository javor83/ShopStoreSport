using Microsoft.AspNetCore.Mvc.Rendering;
using ShopStoreSport.database;

namespace ShopStoreSport.Models
{
    public class EFStoreRepository:IStoreRepository
    {
        private SportsstoreContext context = null;
        private readonly IWebHostEnvironment _hostingEnvironment;
        //******************************************************************************
        public EFStoreRepository(SportsstoreContext context, IWebHostEnvironment host)
        {
            this.context = context;
            this._hostingEnvironment = host;
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
        
        IEnumerable<SelectListItem> IStoreRepository.SelectTagCategoryList()
        {
            IEnumerable<Category> list = (this as IStoreRepository).GetCategories();

            SelectListItem default_key = new SelectListItem()
            {
                Text = "*",
                Value = string.Empty
            };
            yield return default_key;

            foreach (Category category in list)
            {
                SelectListItem key = new SelectListItem()
                {
                    Text = category.Cname,
                    Value = Convert.ToString(category.Id)
                };
                yield return key;
            }
        }
        //******************************************************************************
        async Task IStoreRepository.AddProduct(InsertProductDTO key)
        {
            string fname = key.UploadFile.FileName;

            Product product = new Product()
            {
                Name = key.Name,
                Description = key.Description,
                Category = key.Category,
                Price = key.Price.Value,
                Preview = fname
                
            };
            using (var stream = key.UploadFile.OpenReadStream())
            {
                string upload_as = $"{this._hostingEnvironment.WebRootPath}/preview/{fname}";
                using (var fs = System.IO.File.OpenWrite(upload_as))
                {
                    stream.CopyTo(fs);
                }
            }

            this.context.Products.Add(product);
            await this.context.SaveChangesAsync();
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
