using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int current_page = 1)
        {
            int total_elements = this.rp.CountProducts();
            var filtered = this.rp.GetProductsDTO(current_page, consts.ProductPageSize);
            ProductsListViewModel list = new ProductsListViewModel()
            {
                Products = filtered,
                PagingInfo = new PageSizeDTO()
                {
                    CurrentPage = current_page,
                    ItemsPerPage = consts.ProductPageSize,
                    TotalItems = total_elements
                    
                }
            };
    
            
            
            return View(list);
        }
        //************************************************************************
        public IActionResult Privacy()
        {
            return View();
        }
        //************************************************************************
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //************************************************************************
    }
}
