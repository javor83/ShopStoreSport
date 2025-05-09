using Microsoft.AspNetCore.Mvc;
using ShopStoreSport.Models;


namespace ShopStoreSport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStoreRepository rp = null;
        //************************************************************************
            
        public HomeController(ILogger<HomeController> logger, IStoreRepository x)
        {
            _logger = logger;
            this.rp = x;
        }
        //************************************************************************
        public IActionResult Index(int? category,int pindex = 1)
        {
            int total_elements = this.rp.CountProducts(category);
            var filtered = this.rp.GetProductsDTO(pindex, category, consts.ProductPageSize);
            ProductsListViewModel list = new ProductsListViewModel()
            {
                Products = filtered,
                PagingInfo = new PageSizeDTO()
                {
                    CurrentPage = pindex,
                    ItemsPerPage = consts.ProductPageSize,
                    TotalItems = total_elements
                    
                },
                Categories = this.rp.GetCategories(),
                Category = category
            };
    
            
            
            return View(list);
        }
        //************************************************************************
        [HttpPost, ValidateAntiForgeryToken]

        public async Task<IActionResult> Add(InsertProductDTO key)
        {
            if (ModelState.IsValid)
            {
                await this.rp.AddProduct(key);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.add = this.rp.SelectTagCategoryList();
                return View(key);
            }
        }
        
       
        //************************************************************************

        public IActionResult Add()
        {
            InsertProductDTO item = InsertProductDTO.Empty();
            ViewBag.add = this.rp.SelectTagCategoryList();
            return View(item);
        }

        //************************************************************************
    }
}
