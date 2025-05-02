using Microsoft.AspNetCore.Mvc;
using ShopStoreSport.database;
using ShopStoreSport.DTO;
using ShopStoreSport.Models;
using System.Diagnostics;

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
        public IActionResult Privacy()
        {
            return View();
        }
        
        //************************************************************************
    }
}
