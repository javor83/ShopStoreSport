using Microsoft.AspNetCore.Mvc;
using ShopStoreSport.database;
using ShopStoreSport.Models;

namespace ShopStoreSport.Controllers
{
    public class ShopCartController : Controller
    {
        public IStoreRepository store = null;
        //**************************************************************
        public ShopCartController(IStoreRepository x)
        {
            this.store = x;
        }

        //**************************************************************
        [HttpPost , ValidateAntiForgeryToken]
        public IActionResult Update()
        {
            return Json(new { });
        }

        //**************************************************************
        [HttpPost]
       
        public IActionResult Buy(int pid)
        {
            Product p = this.store.GetProducts().Where(x => x.Id == pid).First();
            ListCartLine list = HttpContext.Session.GetJson();
           
            list.Add(p);
            HttpContext.Session.SetJson(list);
           

            return 
                Json(list);
                //RedirectToAction("Index", "ShopCart");
        }

        //**************************************************************
        public IActionResult Index()
        {
            ListCartLine list = HttpContext.Session.GetJson();
            
            /*
            IEnumerable<Product> list_product = this.store.GetProducts();
            for (int i = 0; i < list_product.Count(); i++)
            {
                list.Add(list_product.ElementAt(i), i + 1);
            }
            */
            return View(list);
        }
        //**************************************************************
    }
}
