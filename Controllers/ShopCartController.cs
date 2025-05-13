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

        /*
         *   <div class="mt-3 text-center">
        <form method="post" asp-action="" asp-controller="ShopCart" asp-antiforgery="true">
            <input type="submit" class="btn btn-danger" name="" value="@ListCartLine_caption.ClearCart"/>
            <input type="submit" class="btn btn-outline-primary" name="" value="@ListCartLine_caption.FinishCart" />
        </form>
    </div> 
         */
        //**************************************************************
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            var clear = Request.Form["clear"];
            var checkout = Request.Form["checkout"];

            if (string.IsNullOrEmpty(clear) == false)
            {
                HttpContext.Session.RemoveSession();
                TempData["clear"] = "";
                return RedirectToAction("Index", "Home");
            }
            else
                 if (string.IsNullOrEmpty(checkout) == false)
            {
                
                ListCartLine cart = HttpContext.Session.GetJson();
                TempData["checkout"] = cart.Total().ToMoney();
                HttpContext.Session.RemoveSession();
                return RedirectToAction("Index", "Home");
            }
            else
                return BadRequest();

        }
        //**************************************************************
        [HttpPost , ValidateAntiForgeryToken]
        public IActionResult Update(int product_id,int product_qty)
        {
            var delete_item = Request.Form["delete_item"];
            var update_item = Request.Form["update_item"];


            if (string.IsNullOrEmpty(delete_item) == false)
            {
                ListCartLine list = HttpContext.Session.GetJson();
                list.Remove(product_id);
                HttpContext.Session.SetJson(list);
                return RedirectToAction("Index", "ShopCart");
            }
            else
            if (string.IsNullOrEmpty(update_item) == false)
            {
                ListCartLine list = HttpContext.Session.GetJson();
                list.Update(product_id, product_qty);
                HttpContext.Session.SetJson(list);
                return RedirectToAction("Index", "ShopCart");
            }
            else
                return BadRequest();


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
                
                RedirectToAction("Index", "ShopCart");
        }

        //**************************************************************
        public IActionResult Index()
        {
            ListCartLine list = HttpContext.Session.GetJson();
            return View(list);
        }
        //**************************************************************
    }
}
